using System.Net.Http;
using System.Text.Json;
namespace _21010310018_Furkan_Eken_Odev2
{
    public partial class DovizKurlari : ContentPage
    {
        private readonly string url = "https://finans.truncgil.com/today.json";

        public DovizKurlari()
        {
            InitializeComponent();
            LoadExchangeRates();
        }

        private async void LoadExchangeRates()
        {
            try
            {
                var httpClient = new HttpClient();
                var json = await httpClient.GetStringAsync(url);

                // JSON verisini Deserialize et
                var exchangeRates = JsonSerializer.Deserialize<ExchangeRate>(json);

                // UI'yi g�ncelle
                UsdAlisLabel.Text = $"Al��: {exchangeRates.USD.Al��}";
                UsdSatisLabel.Text = $"Sat��: {exchangeRates.USD.Sat��}";
                UsdDegisimLabel.Text = $"De�i�im: {exchangeRates.USD.De�i�im}";

                EurAlisLabel.Text = $"Al��: {exchangeRates.EUR.Al��}";
                EurSatisLabel.Text = $"Sat��: {exchangeRates.EUR.Sat��}";
                EurDegisimLabel.Text = $"De�i�im: {exchangeRates.EUR.De�i�im}";

                GbpAlisLabel.Text = $"Al��: {exchangeRates.GBP.Al��}";
                GbpSatisLabel.Text = $"Sat��: {exchangeRates.GBP.Sat��}";
                GbpDegisimLabel.Text = $"De�i�im: {exchangeRates.GBP.De�i�im}";
            }
            catch (Exception ex)
            {
                // Hata durumunda kullan�c�ya bilgi ver
                await DisplayAlert("Error", "Failed to load exchange rates", "OK");
            }
        }
    }

    public class ExchangeRate
    {
        public Currency USD { get; set; }
        public Currency EUR { get; set; }
        public Currency GBP { get; set; }
    }

    public class Currency
    {
        public string Al�� { get; set; }
        public string Sat�� { get; set; }
        public string T�r { get; set; }
        public string De�i�im { get; set; }
    }
}