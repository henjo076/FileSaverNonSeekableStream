using CommunityToolkit.Maui.Storage;

namespace FileSaverNonSeekableStream;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnDownloadClicked(object sender, EventArgs e)
    {
        var client = new HttpClient();
        try 
        {
            await using var stream = await client.GetStreamAsync(
                "https://www.nuget.org/api/v2/package/CommunityToolkit.Maui/5.0.0");
            var result = await FileSaver.Default.SaveAsync("communitytoolkit.maui.5.0.0.nupkg", stream, CancellationToken.None);
            if (!result.IsSuccessful) 
            {
                await DisplayAlert("Download failed", result.Exception?.Message ?? "Unknown error", "OK");
            }
        } 
        catch (Exception ex) 
        {
            await DisplayAlert("Download failed", ex.Message, "OK");
        }
    }
}

