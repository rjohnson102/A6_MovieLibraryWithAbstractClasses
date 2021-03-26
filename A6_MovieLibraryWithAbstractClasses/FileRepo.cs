using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace A6_MovieLibraryWithAbstractClasses
{
    public class FileRepo : IRepository
    {
        public string Path { get; set; }


        public FileRepo(string path)
        {
            this.Path = path;
        }

        public void WritetoFile(MediaList mediaList, Movie movie)
        {
            List<Movie> movies = new List<Movie>();
            FileRepo movieFile = new FileRepo("movies.csv");
            mediaList.medias.Add(movie);

            if (File.Exists(movieFile.Path))
            {
                using (StreamReader file = new StreamReader(movieFile.Path))
                {
                    string line;
                    for (int k = 0; k < 1; k++)
                    {
                        file.ReadLine();
                    }
                    while ((line = file.ReadLine()) != null)
                    {

                        var temp = line.Split(',');

                        string[] genres = temp[2].Split('|');

                        int movieID = Convert.ToInt32(temp[0]);
                        Movie m = new Movie(movieID, temp[1], genres);
                        movies.Add(m);
                    }
                }
            }
            movies.Add(movie);
            using (StreamWriter outputFile = new StreamWriter(movieFile.Path))
            {
                foreach (Movie media in movies)
                {
                    string temp = media.id + "," + media.title + "," + string.Join("|", media.genres);
                    outputFile.WriteLine(temp);
                }
                outputFile.Close();
            }
        }

        public void ReadFile(MediaList mediaList, Type type)
        {            
            Console.WriteLine();
            foreach (Media m in mediaList.medias)
            {
                if(m.GetType() == type)
                {
                    Console.WriteLine(m.Display());
                }                
            }
        }
    }
}
