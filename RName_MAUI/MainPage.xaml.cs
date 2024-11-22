using System.Collections.ObjectModel;

namespace RName_MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        ObservableCollection<NameInfo> nameInfos = new ObservableCollection<NameInfo>();
        private async void SettingButton_Clicked(object sender, EventArgs e)
        {
            ConfigPage configPage = new ConfigPage();
            configPage.binding.NameInfos = nameInfos;
            await Navigation.PushAsync(configPage);

        }
    }

}
