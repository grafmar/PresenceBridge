using System;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
// using Microsoft.Extensions.Options;

namespace PresenceBridge
{
	class GraphHandler
	{
        private readonly IGraphService graphservice = new GraphService();
        // var authenticationProvider = CreateAuthorizationProvider();
        GraphServiceClient _graphServiceClient;

        public void Login()
		{
            _graphServiceClient = graphservice.GetAuthenticatedGraphClient();
        }

        public async void Logout()
        {
            try
            {
                var accounts = await WPFAuthorizationProvider.Application.GetAccountsAsync().ConfigureAwait(true);
                
                foreach (var account in accounts)
                {
                    await WPFAuthorizationProvider.Application.RemoveAsync(account).ConfigureAwait(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception in GraphHandler::Logout:\n" + ex.Message);
            }
        }

        public async Task<System.IO.Stream> GetPhoto()
		{
            var photo = await _graphServiceClient.Me.Photo.Content.Request().GetAsync();
            return photo;
        }
        
        public async Task<Presence> GetPresence()
        {
            var presence = await _graphServiceClient.Me.Presence.Request().GetAsync();
            return presence;
        }
    }


    public interface IGraphService
    {
        GraphServiceClient GetAuthenticatedGraphClient();
    }

    public class GraphService : IGraphService
    {
        //AADSettings aadSettings;

        //public GraphService(IOptions<AADSettings> optionsAccessor)
        public GraphService()
        {
            //aadSettings = optionsAccessor.Value;
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

            var clientId = "3bd2647e-821e-48dd-a4b3-158e87fd7945";
            //var pca = PublicClientApplicationBuilder.Create(aadSettings.ClientId)
            var pca = PublicClientApplicationBuilder.Create(clientId)
                //.WithAuthority($"{aadSettings.Instance}common/")
                .WithRedirectUri(Properties.Settings.Default.RedirectUri)
                .Build();

            TokenCacheHelper.EnableSerialization(pca.UserTokenCache);

            return new WPFAuthorizationProvider(pca, scopes);
        }
    }

}
