namespace GameDex.Pages;

using Newtonsoft.Json;



public partial class AddPage : ContentPage
{
    gameDexFunctions functions = new gameDexFunctions();

    public AddPage()
	{
		InitializeComponent();
        functions.ReadFileJson();

    }

    private void clCancel(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LandingPage());
    }

    private void clAdd(object sender, EventArgs e)
    {
        // Get input values from the form
        string title = titleEntry.Text;
        string description = descriptionEntry.Text;
        string[] tags = tagsEntry.Text.Split(',');
        string platform = platformEntry.Text;
        bool played = playedSwitch.IsChecked;
        bool like = likeSwitch.IsChecked;
        bool heart = heartSwitch.IsChecked;
        string image = imageEntry.Text;

        // Create a new item object with the input values
        Item newItem = new Item
        {
            Title = title,
            Description = description,
            Tags = new List<string>(tags),
            Platform = platform,
            Played = played,
            Like = like,
            Heart = heart,
            Image = image
        };

        // Add the new item to the list
        functions.itemList.Add(newItem);

        // Serialize the list of items to JSON and store it in a string
        string json = JsonConvert.SerializeObject(functions.itemList);

        functions.WriteFileJson(json);
    }
}