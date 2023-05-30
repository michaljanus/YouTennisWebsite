using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace YouTennis.Core.Identity
{
    public class Config
    {
        private static readonly string _APIResourceName = "YouTennis";
        private static readonly string _clientId = "YouTennis.API";
        private static readonly string _clientSecret = "VerySecretSecret";

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource(_APIResourceName, "YouTennis API")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = _clientId,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    ClientSecrets =
                    {
                        new Secret(_clientSecret.Sha256())
                    },
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Address,
                        _APIResourceName
                    }
                }
            };
        }
    }
}
