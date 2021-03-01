using System;

namespace A6_MovieLibraryWithAbstractClasses
{
    class Program
    {
        static MediaList mediaList = new MediaList();
        static FileRepo movieFile = new FileRepo("movies.csv");        
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

            ConsoleKey input = Console.ReadKey().Key;

            switch (input)
            {
                case ConsoleKey.D1:
                    movieFile.ReadFile(mediaList, typeof(Movie));
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
            }
        }

        public static Movie PromptMediaAdd()
        {
            int id = 0;
            foreach (Media media in mediaList.mediaList)
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
                Console.WriteLine("Press Enter to Continue, Escape to Stop...");
                ConsoleKey readIn = Console.ReadKey().Key;
                while (readIn != ConsoleKey.Enter || readIn != ConsoleKey.Escape)
                {
                    Console.WriteLine("Press Enter to Continue, Escape to Stop...");
                    readIn = Console.ReadKey().Key;
                    if (readIn == ConsoleKey.Enter)
                    {
                        Console.WriteLine("Genre: ");
                        genresString += Console.ReadLine() + ",";
                    }
                    else
                    {
                        isEntering = false;
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
