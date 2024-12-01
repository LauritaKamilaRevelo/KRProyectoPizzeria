using KRMauiApp.Models;
using Newtonsoft.Json;

namespace KRMauiApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7088");
            var response=client.GetAsync("KRPizza").Result;
            if (response.IsSuccessStatusCode)
            {
                var KRPizzas = response.Content.ReadAsStringAsync().Result;
                var KRPPizzasList = JsonConvert.DeserializeObject<List<KRPizzeria>>(KRPizzas);
                listView.ItemsSource = KRPPizzasList;
            }
        }
    }

}
