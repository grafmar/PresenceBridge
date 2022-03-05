using System;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace PresenceBridge
{
	class GraphHandler
	{
        private readonly GraphService graphservice = new GraphService();
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

                if (accounts.Any()) { 
                    await WPFAuthorizationProvider.Application.RemoveAsync(accounts.FirstOrDefault()).ConfigureAwait(true);
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

}
