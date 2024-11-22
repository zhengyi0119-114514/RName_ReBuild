namespace RName_MAUI;

public partial class ConfigPage : ContentPage
{
	public ConfigPage()
	{
		InitializeComponent();
		this.BindingContext = this.binding;
	}
    public ConfigDateBindingClass binding = new ConfigDateBindingClass();

    private void AddNameButton_Clicked(object sender, EventArgs e)
    {
		var collection = binding.NameInfos;
		var text = NameEditor.Text;
		if (!String.IsNullOrEmpty(text))
		{
			collection.Add(new NameInfo() { Name = text.ToString() });
			NameEditor.Text = String.Empty;
		}
		binding.NameInfos = collection;
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
		List<Int32> inxeds = new List<Int32>();
		for(Int32 i = binding.NameInfos.Count - 1; i >= 0; i--)
		{
			if (binding.NameInfos[i].IsChoosed)
			{
				inxeds.Add(i);
			}
		}
		foreach(Int32 i in inxeds)
		{
			binding.NameInfos.RemoveAt(i);
		}
    }

    private async void ReadFromFileButton_Clicked(object sender, EventArgs e)
    {
		PickOptions pickOptions = new PickOptions();
		pickOptions.FileTypes = new FilePickerFileType(
			new Dictionary<DevicePlatform, IEnumerable<String>>
			{
				{DevicePlatform.WinUI,new[]{ "txt" }},
				{DevicePlatform.Android,new[]{"txt"} },
				{DevicePlatform.macOS ,new[]{"txt"} },
				{DevicePlatform.iOS,new[]{"txt"} }
			});
		var result = await FilePicker.PickAsync(pickOptions);
		if (result != null)
		{
			using Stream file = result.OpenReadAsync().Result;
			this.binding.NameInfos.Clear();
			var collection = this.binding.NameInfos;
			String line = String.Empty;
			using StreamReader reader = new StreamReader(file);
			while(!String.IsNullOrEmpty(line = reader.ReadLine()!))
			{
				collection.Add(new NameInfo() { Name = line });
			}
			this.binding.NameInfos = collection;
		}
    }
}