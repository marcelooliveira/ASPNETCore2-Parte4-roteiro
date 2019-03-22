// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace CasaDoCodigo.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource("api1", "My API #1")
            };
        }

        public static IEnumerable<Client> GetClients(string callbackUrl)
        {
            return new[]
            {
                // MVC client using hybrid flow
                new Client
                {
                    ClientId = "CasaDoCodigo.MVC",
                    ClientName = "Casa do Código MVC",
                    RequireConsent = false,
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    RedirectUris = { callbackUrl + "/signin-oidc" },
                    FrontChannelLogoutUri = callbackUrl + "/signout-oidc",
                    PostLogoutRedirectUris = { callbackUrl + "/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "api1" }
                }
            };
        }
    }
}