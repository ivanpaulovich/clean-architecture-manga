// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


namespace IdentityServerHost.Quickstart.UI
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using IdentityServer4.Events;
    using IdentityServer4.Extensions;
    using IdentityServer4.Models;
    using IdentityServer4.Services;
    using IdentityServer4.Stores;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     This sample controller allows a user to revoke grants given to clients
    /// </summary>
    [SecurityHeaders]
    [Authorize]
    public class GrantsController : Controller
    {
        private readonly IClientStore _clients;
        private readonly IEventService _events;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IResourceStore _resources;

        public GrantsController(IIdentityServerInteractionService interaction,
            IClientStore clients,
            IResourceStore resources,
            IEventService events)
        {
            this._interaction = interaction;
            this._clients = clients;
            this._resources = resources;
            this._events = events;
        }

        /// <summary>
        ///     Show list of grants
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index() => this.View("Index", await this.BuildViewModelAsync());

        /// <summary>
        ///     Handle postback to revoke a client
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Revoke(string clientId)
        {
            await this._interaction.RevokeUserConsentAsync(clientId);
            await this._events.RaiseAsync(new GrantsRevokedEvent(this.User.GetSubjectId(), clientId));

            return this.RedirectToAction("Index");
        }

        private async Task<GrantsViewModel> BuildViewModelAsync()
        {
            IEnumerable<Grant> grants = await this._interaction.GetAllUserGrantsAsync();

            List<GrantViewModel> list = new List<GrantViewModel>();
            foreach (Grant grant in grants)
            {
                Client client = await this._clients.FindClientByIdAsync(grant.ClientId);
                if (client != null)
                {
                    Resources resources = await this._resources.FindResourcesByScopeAsync(grant.Scopes);

                    GrantViewModel item = new GrantViewModel
                    {
                        ClientId = client.ClientId,
                        ClientName = client.ClientName ?? client.ClientId,
                        ClientLogoUrl = client.LogoUri,
                        ClientUrl = client.ClientUri,
                        Description = grant.Description,
                        Created = grant.CreationTime,
                        Expires = grant.Expiration,
                        IdentityGrantNames =
                            resources.IdentityResources.Select(x => x.DisplayName ?? x.Name).ToArray(),
                        ApiGrantNames = resources.ApiScopes.Select(x => x.DisplayName ?? x.Name).ToArray()
                    };

                    list.Add(item);
                }
            }

            return new GrantsViewModel {Grants = list};
        }
    }
}
