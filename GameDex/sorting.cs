using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

public class Game
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Tags { get; set; }
    public string Platform { get; set; }
    public bool Played { get; set; }
    public bool Like { get; set; }
    public bool Heart { get; set; }
    public string Image { get; set; }
}

public class Sorting
{
    public static void Main1()
    {
        string fileName = "game.txt";
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
        string jsonText = File.ReadAllText(filePath);

        List<Game> games = JsonConvert.DeserializeObject<List<Game>>(jsonText);



        //foreach (Game game in games)
        //{
        //    Console.WriteLine("Title: " + game.Title);
        //    Console.WriteLine("Description: " + game.Description);
        //    Console.WriteLine("Tags: " + string.Join(", ", game.Tags));
        //    Console.WriteLine("Platform: " + game.Platform);
        //    Console.WriteLine("Played: " + game.Played);
        //    Console.WriteLine("Like: " + game.Like);
        //    Console.WriteLine("Heart: " + game.Heart);
        //    Console.WriteLine("Image: " + game.Image);
        //    Console.WriteLine();

        //}


        games = SortByTitle(games);
        Console.WriteLine("Sorted by Title:");
        foreach (Game game in games)
        {
            Console.WriteLine(game.Title);
        }
        Console.WriteLine();

        // sort by number of tags
        games = SortByNumTags(games);
        Console.WriteLine("Sorted by Number of Tags:");
        foreach (Game game in games)
        {
            Console.WriteLine(game.Title + " - " + game.Tags.Count + " tags");
        }
        Console.WriteLine();

        // sort by Heart
        games = SortByHeart(games);
        Console.WriteLine("Sorted by Heart:");
        foreach (Game game in games)
        {
            Console.WriteLine(game.Title + " - Heart: " + game.Heart);
        }
        Console.WriteLine();




        Console.ReadLine();
    }

    public static List<Game> SortByTitle(List<Game> games)
    {
        games.Sort((x, y) => x.Title.CompareTo(y.Title));
        return games;
    }

    public static List<Game> SortByNumTags(List<Game> games)
    {
        games.Sort((x, y) => y.Tags.Count.CompareTo(x.Tags.Count));
        return games;
    }

    public static List<Game> SortByHeart(List<Game> games)
    {
        games.Sort((x, y) => y.Heart.CompareTo(x.Heart));
        return games;
    }


}
