// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


namespace IdentityServerHost.Quickstart.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LoginViewModel : LoginInputModel
    {
        public bool AllowRememberLogin { get; set; } = true;
        public bool EnableLocalLogin { get; set; } = true;

        public IEnumerable<ExternalProvider> ExternalProviders { get; set; } = Enumerable.Empty<ExternalProvider>();

        public IEnumerable<ExternalProvider> VisibleExternalProviders =>
            this.ExternalProviders.Where(x => !String.IsNullOrWhiteSpace(x.DisplayName));

        public bool IsExternalLoginOnly => this.EnableLocalLogin == false && this.ExternalProviders?.Count() == 1;

        public string ExternalLoginScheme => this.IsExternalLoginOnly
            ? this.ExternalProviders?.SingleOrDefault()?.AuthenticationScheme
            : null;
    }
}
