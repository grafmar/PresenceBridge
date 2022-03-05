using System;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace PresenceBridge
{
    public class GraphService
    {

        public GraphService()
        {
        }

        public GraphServiceClient GetAuthenticatedGraphClient()
        {
            var authenticationProvider = CreateAuthorizationProvider();
            var _graphServiceClient = new GraphServiceClient(authenticationProvider);
            return _graphServiceClient;
        }

        private IAuthenticationProvider CreateAuthorizationProvider()
        {
            List<string> scopes = new List<string>
            {
                "https://graph.microsoft.com/.default"
            };

            var pca = PublicClientApplicationBuilder.Create(Properties.Settings.Default.ClientId)
                //.WithAuthority($"{aadSettings.Instance}common/")
                .WithRedirectUri(Properties.Settings.Default.RedirectUri)
                .Build();

            TokenCacheHelper.EnableSerialization(pca.UserTokenCache);

            return new WPFAuthorizationProvider(pca, scopes);
        }
    }
}
