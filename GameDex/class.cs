using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex
{

    public class Item
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

    public class Game
    {
        public ImageSource imgSource { get; set; }
        public string Title { get; set; }
    }

    public class gameDexFunctions
    {
        //array of all the games
        public ObservableCollection<Item> itemList = new ObservableCollection<Item>();


        //function to read all the file and deserialize it to put into the array
        public void ReadFileJson()
        {
            //finds the documents folder of the user
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documentsPath, "game.txt");

            // if/else statement just in case the program attempts to access a folder that doesn't exist
            if (File.Exists(filename))
            {
                //reads the file
                string fileContent = File.ReadAllText(filename);
                //puts the file's contents into the array of games
                itemList = JsonConvert.DeserializeObject<ObservableCollection<Item>>(fileContent);
            }
            else
            {
                Console.WriteLine("File does not exist!");
            }
        }

        public void WriteFileJson(string s) {


            // Save the JSON to a text file
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documentsPath, "game.txt");
            File.WriteAllText(filename, s);

            // Output a success message to the console
            Console.WriteLine($"The JSON was saved to {filename}.");
        }



        public static  List<Item> SortByTitle(List<Item> games)
        {
            games.Sort((x, y) => x.Title.CompareTo(y.Title));
            return games;
        }

        public static  List<Item> SortByNumTags(List<Item> games)
        {
            games.Sort((x, y) => y.Tags.Count.CompareTo(x.Tags.Count));
            return games;
        }

        public static  List<Item> SortByHeart(List<Item> games)
        {
            games.Sort((x, y) => y.Heart.CompareTo(x.Heart));
            return games;
        }





    }
}
