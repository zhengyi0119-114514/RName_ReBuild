using RNameMAUI.Models;

namespace RNameMAUI.Pages;

public partial class NameListPage : ContentPage
{
    public NameListPageBinding binding;
    public NameListPage(NameListPageBinding nameListPageBinding)
    {
        InitializeComponent();
        this.BindingContext = this.binding = nameListPageBinding;
    }

    private void Entry_Completed(object sender, EventArgs e)
    {
        this.binding.NameList.Add(new NameInfo(nameEntry.Text));
        nameEntry.Text = String.Empty;
    }
}