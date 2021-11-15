// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


namespace IdentityServerHost.Quickstart.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using IdentityServer4;
    using IdentityServer4.Configuration;
    using IdentityServer4.Events;
    using IdentityServer4.Extensions;
    using IdentityServer4.Models;
    using IdentityServer4.Services;
    using IdentityServer4.Validation;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [Authorize]
    [SecurityHeaders]
    public class DeviceController : Controller
    {
        private readonly IEventService _events;
        private readonly IDeviceFlowInteractionService _interaction;
        private readonly ILogger<DeviceController> _logger;
        private readonly IOptions<IdentityServerOptions> _options;

        public DeviceController(
            IDeviceFlowInteractionService interaction,
            IEventService eventService,
            IOptions<IdentityServerOptions> options,
            ILogger<DeviceController> logger)
        {
            this._interaction = interaction;
            this._events = eventService;
            this._options = options;
            this._logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userCodeParamName = this._options.Value.UserInteraction.DeviceVerificationUserCodeParameter;
            string userCode = this.Request.Query[userCodeParamName];
            if (string.IsNullOrWhiteSpace(userCode))
            {
                return this.View("UserCodeCapture");
            }

            DeviceAuthorizationViewModel vm = await this.BuildViewModelAsync(userCode);
            if (vm == null)
            {
                return this.View("Error");
            }

            vm.ConfirmUserCode = true;
            return this.View("UserCodeConfirmation", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserCodeCapture(string userCode)
        {
            DeviceAuthorizationViewModel vm = await this.BuildViewModelAsync(userCode);
            if (vm == null)
            {
                return this.View("Error");
            }

            return this.View("UserCodeConfirmation", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Callback(DeviceAuthorizationInputModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            ProcessConsentResult result = await this.ProcessConsent(model);
            if (result.HasValidationError)
            {
                return this.View("Error");
            }

            return this.View("Success");
        }

        private async Task<ProcessConsentResult> ProcessConsent(DeviceAuthorizationInputModel model)
        {
            ProcessConsentResult result = new ProcessConsentResult();

            DeviceFlowAuthorizationRequest request =
                await this._interaction.GetAuthorizationContextAsync(model.UserCode);
            if (request == null)
            {
                return result;
            }

            ConsentResponse grantedConsent = null;

            // user clicked 'no' - send back the standard 'access_denied' response
            if (model.Button == "no")
            {
                grantedConsent = new ConsentResponse {Error = AuthorizationError.AccessDenied};

                // emit event
                await this._events.RaiseAsync(new ConsentDeniedEvent(this.User.GetSubjectId(), request.Client.ClientId,
                    request.ValidatedResources.RawScopeValues));
            }
            // user clicked 'yes' - validate the data
            else if (model.Button == "yes")
            {
                // if the user consented to some scope, build the response model
                if (model.ScopesConsented != null && model.ScopesConsented.Any())
                {
                    IEnumerable<string> scopes = model.ScopesConsented;
                    if (ConsentOptions.EnableOfflineAccess == false)
                    {
                        scopes = scopes.Where(x => x != IdentityServerConstants.StandardScopes.OfflineAccess);
                    }

                    grantedConsent = new ConsentResponse
                    {
                        RememberConsent = model.RememberConsent,
                        ScopesValuesConsented = scopes.ToArray(),
                        Description = model.Description
                    };

                    // emit event
                    await this._events.RaiseAsync(new ConsentGrantedEvent(this.User.GetSubjectId(),
                        request.Client.ClientId, request.ValidatedResources.RawScopeValues,
                        grantedConsent.ScopesValuesConsented, grantedConsent.RememberConsent));
                }
                else
                {
                    result.ValidationError = ConsentOptions.MustChooseOneErrorMessage;
                }
            }
            else
            {
                result.ValidationError = ConsentOptions.InvalidSelectionErrorMessage;
            }

            if (grantedConsent != null)
            {
                // communicate outcome of consent back to identityserver
                await this._interaction.HandleRequestAsync(model.UserCode, grantedConsent);

                // indicate that's it ok to redirect back to authorization endpoint
                result.RedirectUri = model.ReturnUrl;
                result.Client = request.Client;
            }
            else
            {
                // we need to redisplay the consent UI
                result.ViewModel = await this.BuildViewModelAsync(model.UserCode, model);
            }

            return result;
        }

        private async Task<DeviceAuthorizationViewModel> BuildViewModelAsync(string userCode,
            DeviceAuthorizationInputModel model = null)
        {
            DeviceFlowAuthorizationRequest request = await this._interaction.GetAuthorizationContextAsync(userCode);
            if (request != null)
            {
                return this.CreateConsentViewModel(userCode, model, request);
            }

            return null;
        }

        private DeviceAuthorizationViewModel CreateConsentViewModel(string userCode,
            DeviceAuthorizationInputModel model, DeviceFlowAuthorizationRequest request)
        {
            DeviceAuthorizationViewModel vm = new DeviceAuthorizationViewModel
            {
                UserCode = userCode,
                Description = model?.Description,
                RememberConsent = model?.RememberConsent ?? true,
                ScopesConsented = model?.ScopesConsented ?? Enumerable.Empty<string>(),
                ClientName = request.Client.ClientName ?? request.Client.ClientId,
                ClientUrl = request.Client.ClientUri,
                ClientLogoUrl = request.Client.LogoUri,
                AllowRememberConsent = request.Client.AllowRememberConsent
            };

            vm.IdentityScopes = request.ValidatedResources.Resources.IdentityResources.Select(x =>
                this.CreateScopeViewModel(x, vm.ScopesConsented.Contains(x.Name) || model == null)).ToArray();

            List<ScopeViewModel> apiScopes = new List<ScopeViewModel>();
            foreach (ParsedScopeValue parsedScope in request.ValidatedResources.ParsedScopes)
            {
                ApiScope apiScope = request.ValidatedResources.Resources.FindApiScope(parsedScope.ParsedName);
                if (apiScope != null)
                {
                    ScopeViewModel scopeVm = this.CreateScopeViewModel(parsedScope, apiScope,
                        vm.ScopesConsented.Contains(parsedScope.RawValue) || model == null);
                    apiScopes.Add(scopeVm);
                }
            }

            if (ConsentOptions.EnableOfflineAccess && request.ValidatedResources.Resources.OfflineAccess)
            {
                apiScopes.Add(this.GetOfflineAccessScope(
                    vm.ScopesConsented.Contains(IdentityServerConstants.StandardScopes.OfflineAccess) ||
                    model == null));
            }

            vm.ApiScopes = apiScopes;

            return vm;
        }

        private ScopeViewModel CreateScopeViewModel(IdentityResource identity, bool check) =>
            new ScopeViewModel
            {
                Value = identity.Name,
                DisplayName = identity.DisplayName ?? identity.Name,
                Description = identity.Description,
                Emphasize = identity.Emphasize,
                Required = identity.Required,
                Checked = check || identity.Required
            };

        public ScopeViewModel CreateScopeViewModel(ParsedScopeValue parsedScopeValue, ApiScope apiScope, bool check) =>
            new ScopeViewModel
            {
                Value = parsedScopeValue.RawValue,
                // todo: use the parsed scope value in the display?
                DisplayName = apiScope.DisplayName ?? apiScope.Name,
                Description = apiScope.Description,
                Emphasize = apiScope.Emphasize,
                Required = apiScope.Required,
                Checked = check || apiScope.Required
            };

        private ScopeViewModel GetOfflineAccessScope(bool check) =>
            new ScopeViewModel
            {
                Value = IdentityServerConstants.StandardScopes.OfflineAccess,
                DisplayName = ConsentOptions.OfflineAccessDisplayName,
                Description = ConsentOptions.OfflineAccessDescription,
                Emphasize = true,
                Checked = check
            };
    }
}
