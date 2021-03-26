using System;
using System.Linq;

namespace A6_MovieLibraryWithAbstractClasses
{
    class Program
    {
        static MediaList mediaList = new MediaList();
        static FileRepo movieFile = new FileRepo("movies.csv");
        static JSONFile jsonFile = new JSONFile("media.json");
        static void Main(string[] args)
        {                
            mediaList.PopulateFromMovieList();
            mediaList.PopulateFromShowList();
            mediaList.PopulateFromVideoList();

            PrintMenu();
        }

        public static void PrintMenu()
        {
            Console.WriteLine("1. List all Movies");
            Console.WriteLine("2. Write Movies to File");
            Console.WriteLine("3. List Media by Type");
            Console.WriteLine("4. Write Media to JSON File");
            Console.WriteLine("5. Search By:");

            ConsoleKey input = Console.ReadKey().Key;

            switch (input)
            {
                case ConsoleKey.D1:
                    jsonFile.ReadFile(mediaList, typeof(Media));
                    PrintMenu();
                    break;
                case ConsoleKey.D2:
                    Movie movie = PromptMediaAdd();
                    movieFile.WritetoFile(mediaList, movie);
                    PrintMenu();
                    break;
                case ConsoleKey.D3:
                    ConsoleKey type = PromptMediaFields();
                    ListTypes(type);
                    PrintMenu();
                    break;
                case ConsoleKey.D4:
                    string[] temp = new string[3];
                    Movie jsonMovie = new Movie(0, "", temp);
                    jsonFile.WritetoFile(mediaList, jsonMovie);
                    Console.WriteLine("\nFile Successfully Written!");
                    PrintMenu();
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine("\n1. Title");
                    Console.WriteLine("2. Genre");
                    ConsoleKey tempKey = Console.ReadKey().Key;
                    switch (tempKey)
                    {
                        case ConsoleKey.D1:
                            Console.WriteLine("\nEnter Title:");
                            string title = Console.ReadLine();
                            mediaList.SearchByTitle(title);                            
                            break;
                        case ConsoleKey.D2:
                            Console.WriteLine("\nEnter Genre:");
                            var genre = Console.ReadLine();
                            mediaList.SearchByGenre(genre);                            
                            break;
                    }
                    PrintMenu();
                    break;
            }
        }

        public static Movie PromptMediaAdd()
        {
            int id = 0;
            foreach (Media media in mediaList.medias)
            {
                id = media.id;
            }
            id++;
            Console.WriteLine("\nName: ");
            string name = Console.ReadLine();
            Console.WriteLine("Genres: \n");
            bool isEntering = true;
            string genresString = "";
            while (isEntering)
            {
                Console.WriteLine("\nPress Enter to Continue, Escape to Stop...");
                ConsoleKey readIn = Console.ReadKey().Key;
                while (readIn == ConsoleKey.Enter || readIn == ConsoleKey.Escape)
                {
                    
                    if (readIn == ConsoleKey.Enter)
                    {
                        Console.WriteLine("Genre: ");
                        genresString += Console.ReadLine() + ",";
                        break;
                    }
                    else
                    {
                        isEntering = false;
                        break;
                    }
                }
            }
            string[] genres = genresString.Split(',');
            Movie movie = new Movie(id, name, genres);
            return movie;
        }        

        public static void ListTypes(ConsoleKey type)
        {
            switch (type)
            {
                case ConsoleKey.D1:
                    movieFile.ReadFile(mediaList, typeof(Movie));
                    PrintMenu();
                    break;
                case ConsoleKey.D2:
                    movieFile.ReadFile(mediaList, typeof(Show));
                    PrintMenu();
                    break;
                case ConsoleKey.D3:
                    movieFile.ReadFile(mediaList, typeof(Video));
                    PrintMenu();
                    break;
            }
        }

        public static ConsoleKey PromptMediaFields()
        {
            Console.WriteLine("What type of Media would you like to Display?");
            Console.WriteLine("1. Movie");
            Console.WriteLine("2. Show");
            Console.WriteLine("3. Video");

            ConsoleKey key = Console.ReadKey().Key;
            return key;
        }
    }
}
