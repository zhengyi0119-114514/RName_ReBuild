using RNameMAUI.Models;

namespace RNameMAUI.Pages;

public partial class MainPage : ContentPage
{
    private NameListPageBinding nameListPageBinding = new();
	public MainPage()
	{
		InitializeComponent();
	}

    private async void ConfigButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NameListPage(nameListPageBinding));
    }

}

