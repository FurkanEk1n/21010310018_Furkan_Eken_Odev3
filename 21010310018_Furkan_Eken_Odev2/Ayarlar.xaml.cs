namespace _21010310018_Furkan_Eken_Odev2;

public partial class Ayarlar : ContentPage
{
    public Ayarlar()
    {
        InitializeComponent();
    }
    public void Switch_Toggled(object sender, ToggledEventArgs e)
    {
        if (Application.Current.UserAppTheme == AppTheme.Light)//e.Value == true
        {
            Application.Current.UserAppTheme = AppTheme.Dark;
        }
        else
            Application.Current.UserAppTheme = AppTheme.Light;
    }
}