using Module02Exercise01.View;
using System.Net.Http;
using static System.Net.WebRequestMethods;
using System.Diagnostics;
using Microsoft.Maui.ApplicationModel;
using System.Threading.Tasks;

namespace Module02Exercise01
{
    public partial class App : Application
    {
        private const string TestUrl = "https://www.google.com/";
        public App()
        {
            InitializeComponent();

            MainPage = new ContentPage
            {
                Content = new Label { Text = "Loading..." }
            };
        }

        protected override async void OnStart()
        {

            var current = Connectivity.NetworkAccess;

            bool isWebsiteReachable = await IsWebsiteReachable(TestUrl);

            if (current == NetworkAccess.Internet && isWebsiteReachable)
            {
                Debug.WriteLine("Application Started");
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new OfflinePage();
            }
        }

        protected override void OnSleep()
        {
            
            Console.WriteLine("The app is in sleep mode.");
        }

        protected override void OnResume()
        {
            
            Console.WriteLine("The app is resumed.");
        }

        private async Task<bool> IsWebsiteReachable(string url)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(url);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
