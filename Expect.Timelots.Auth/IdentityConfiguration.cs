using IdentityServer4.Models;

namespace Expect.Timelots.Auth
{
    public static class IdentityConfiguration
    {
        public static IEnumerable<ApiScope> ApiScopes =>
            [
                new ApiScope("platforms", "Platforms")
            ];

        public static IEnumerable<Client> Clients =>
            [
                new Client{
                    ClientId = "client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,

                    ClientSecrets = {
                        new Secret("secret".Sha256())
                    },

                    AllowedScopes = {"platforms"}
                }
            ];
    }
}
