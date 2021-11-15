// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Collections.Generic;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;

namespace IdentityServer;

using System.Collections.Generic;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;

public static class Config
{
    private static Client authorizationCodeFlowClient;

    public static IEnumerable<ApiScope> ApiScopes =>
        new[] { new ApiScope("api1.read_only"), new ApiScope("api1.full_access") };

    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        return new IdentityResource[] { new IdentityResources.OpenId(), new IdentityResources.Profile() };
    }

    public static IEnumerable<ApiResource> GetApis()
    {
        return new[]
        {
                new ApiResource
                {
                    Name = "api1",
                    DisplayName = "Protected Produce API",
                    Scopes = {"api1.full_access", "api1.read_only"}
                }
            };
    }

    public static IEnumerable<Client> GetClients(IConfiguration configuration)
    {
        authorizationCodeFlowClient = new Client
        {
            ClientId = "spa",
            ClientName = "Produce SPA React App",
            RequirePkce = true,
            RequireClientSecret = false,
            AllowedGrantTypes = GrantTypes.Code,
            RedirectUris = { configuration["RedirectUris"] },
            PostLogoutRedirectUris = { configuration["PostLogoutRedirectUris"] },
            AllowedCorsOrigins = { configuration["AllowedCorsOrigins"] },
            AllowedScopes = { "openid", "profile", "api1.read_only", "api1.full_access" }
        };

        return new[] { authorizationCodeFlowClient };
    }
}
