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

                // UI'yi güncelle
                UsdAlisLabel.Text = $"Alýþ: {exchangeRates.USD.Alýþ}";
                UsdSatisLabel.Text = $"Satýþ: {exchangeRates.USD.Satýþ}";
                UsdDegisimLabel.Text = $"Deðiþim: {exchangeRates.USD.Deðiþim}";

                EurAlisLabel.Text = $"Alýþ: {exchangeRates.EUR.Alýþ}";
                EurSatisLabel.Text = $"Satýþ: {exchangeRates.EUR.Satýþ}";
                EurDegisimLabel.Text = $"Deðiþim: {exchangeRates.EUR.Deðiþim}";

                GbpAlisLabel.Text = $"Alýþ: {exchangeRates.GBP.Alýþ}";
                GbpSatisLabel.Text = $"Satýþ: {exchangeRates.GBP.Satýþ}";
                GbpDegisimLabel.Text = $"Deðiþim: {exchangeRates.GBP.Deðiþim}";
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanýcýya bilgi ver
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
        public string Alýþ { get; set; }
        public string Satýþ { get; set; }
        public string Tür { get; set; }
        public string Deðiþim { get; set; }
    }
}