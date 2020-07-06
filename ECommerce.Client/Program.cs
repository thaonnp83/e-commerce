using System;
using System.Net.Http;
using IdentityModel;
using IdentityModel.Client;

namespace ECommerce.Client
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            // discover endpoints from metadata
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001/");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }
            //"Error connecting to https://localhost:5001/.well-known/openid-configuration. Connection refused."
            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "Admin-Service",
                ClientSecret = "Admin-Service",
                Scope = "e-commerce-api"
            });

            /*
             * ClientId = "Admin-Service",
                    ClientName = "Client Service",
                    ClientSecrets = new [] { new Secret("Admin-Service".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "e-commerce-api" }
             */
            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
        }
    }
}
