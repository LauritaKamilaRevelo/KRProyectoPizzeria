using KRMauiApp.Models;
using Newtonsoft.Json;
using System.Globalization;

namespace KRMauiApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7088/api/");
                    var response = await client.GetAsync("KRPizzeria");

                    if (response.IsSuccessStatusCode)
                    {
                        var KRPizzas = await response.Content.ReadAsStringAsync();
                        var KRPPizzasList = JsonConvert.DeserializeObject<List<KRPizzeria>>(KRPizzas);
                        listView.ItemsSource = KRPPizzasList;
                    }
                    else
                    {
                        await DisplayAlert("Error", $"Error: {response.StatusCode}", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
    public class BoolToTextConverter : IValueConverter
    {
        public static BoolToTextConverter Instance { get; } = new BoolToTextConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? "Incluye Coca-Cola" : "No incluye Coca-Cola";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
