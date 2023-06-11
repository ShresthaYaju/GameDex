using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Linq;
//using Windows.Gaming.XboxLive.Storage;

namespace GameDex.Pages;

public partial class LandingPage : ContentPage

{
    //private List<Item> itemList = new List<Item>();
    gameDexFunctions functions = new gameDexFunctions();

	public LandingPage()
	{
		InitializeComponent();

        //populateItem();



        functions.ReadFileJson();

        clnGameView.ItemsSource = functions.itemList;

    }

    private void ShowAddPage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AddPage());
    }

    private void populateItem()
    {
        Item newItem = new Item
        {
            Title = "Title",
            Description = "Description of the game",
            Tags = new List<string> { "Tag 1", "Tag 2", "Tag 3" },
            Platform = "Platform",
            Played = true,
            Like = true,
            Heart = false,
            Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/681px-Placeholder_view_vector.svg.png"
        };
        functions.itemList.Add(newItem);
    }
    private void SaveItem_Clicked(object sender, EventArgs e)
    {
        // Get input values from the form
        string title = titleEntry.Text;
        string description = descriptionEntry.Text;
        string[] tags = tagsEntry.Text.Split(',');
        string platform = platformEntry.Text;
        bool played = playedSwitch.IsToggled;
        bool like = likeSwitch.IsToggled;
        bool heart = heartSwitch.IsToggled;
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


    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker= (Picker)sender;
        string selectedItem = picker.SelectedItem.ToString();

        if (selectedItem == "")
        {
            clnGameView.ItemsSource = functions.itemList;
        }
        else if (selectedItem == "Title")
        {
            List<Item> games = new List<Item>();
            games = gameDexFunctions.SortByTitle(functions.itemList.ToList());
            ObservableCollection<Item> myCollection = new ObservableCollection<Item>(games);
            functions.itemList = myCollection;
            clnGameView.ItemsSource= functions.itemList;
        }
        else if (selectedItem == "Tags")
        {
            List<Item> games = new List<Item>();
            games = gameDexFunctions.SortByNumTags(functions.itemList.ToList());
            ObservableCollection<Item> myCollection = new ObservableCollection<Item>(games);
            functions.itemList = myCollection;
            clnGameView.ItemsSource = functions.itemList;
        }
        else if (selectedItem == "Heart")
        {
            List<Item> games = new List<Item>();
            games = gameDexFunctions.SortByHeart(functions.itemList.ToList());
            ObservableCollection<Item> myCollection = new ObservableCollection<Item>(games);
            functions.itemList = myCollection;
            clnGameView.ItemsSource = functions.itemList;
        }

    }
}

