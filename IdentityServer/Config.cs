using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResource()
        {
            return new List<ApiResource>
            {
                new ApiResource("identityprovider", "IdentityProvider API"),
                new ApiResource("taskapi", "Task API")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes =
                    {
                        "identityprovider"
                    }
                },
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes =
                    {
                        "identityprovider"
                    }
                },
                //new Client
                //{
                //    ClientId = "authenticationclient",
                //    ClientName = "AuthenticationClient",
                //    AllowedGrantTypes = GrantTypes.Implicit,

                //    RedirectUris = { "http://localhost:5002/signin-oidc" },
                //    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                //    AllowedScopes = new List<string>
                //    {
                //        IdentityServerConstants.StandardScopes.OpenId,
                //        IdentityServerConstants.StandardScopes.Profile,
                //    }
                //},
                new Client
                {
                    ClientId = "authenticationclient",
                    ClientName = "Hybrid AuthenticationClient",
                    AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,

                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002/signout-callback-oidc" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "identityprovider",
                        "taskapi"
                    },
                    AllowOfflineAccess = true
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "admin",
                    Password = "adminpw",
                    
                    Claims = new List<Claim>
                    {
                        new Claim("name", "Admin")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "ed",
                    Password = "edpw",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "Elias")
                    }
                }
            };
        }
    }
}
