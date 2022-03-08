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
		private static log4net.ILog log;
		private readonly GraphService graphservice = new GraphService(log);
		GraphServiceClient _graphServiceClient;

		public GraphHandler(log4net.ILog logger)
		{
			log = logger;
		}


		public void Login()
		{
			_graphServiceClient = graphservice.GetAuthenticatedGraphClient();
		}

		public async void Logout()
		{
			try
			{
				var accounts = await WPFAuthorizationProvider.Application.GetAccountsAsync().ConfigureAwait(true);

				if (accounts.Any())
				{
					log.Info("Logout");
					await WPFAuthorizationProvider.Application.RemoveAsync(accounts.FirstOrDefault()).ConfigureAwait(true);
				}
			}
			catch (Exception ex)
			{
				log.Error(ex.Message);
			}
		}

		public async Task<System.IO.Stream> GetPhoto()
		{
			log.Debug("Requesting Photo");

			var photo = await _graphServiceClient.Me.Photo.Content.Request().GetAsync();
			return photo;
		}

		public async Task<Presence> GetPresence()
		{
			log.Debug("Requesting Presence");
			var presence = await _graphServiceClient.Me.Presence.Request().GetAsync();
			return presence;
		}
	}

}
