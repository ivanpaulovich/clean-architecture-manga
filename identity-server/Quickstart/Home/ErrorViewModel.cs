// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


namespace IdentityServerHost.Quickstart.UI
{
    using IdentityServer4.Models;

    public class ErrorViewModel
    {
        public ErrorViewModel()
        {
        }

        public ErrorViewModel(string error) => this.Error = new ErrorMessage {Error = error};

        public ErrorMessage Error { get; set; }
    }
}
