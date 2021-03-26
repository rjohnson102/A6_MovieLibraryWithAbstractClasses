using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections;

namespace A6_MovieLibraryWithAbstractClasses
{
    public class MediaList : IEnumerable
    {
        public List<Media> medias { get; set; }
        FileRepo movieFile = new FileRepo("movies.csv");
        FileRepo showFile = new FileRepo("shows.csv");
        FileRepo videoFile = new FileRepo("videos.csv");
        

        public MediaList()
        {
            medias = new List<Media>();
        }

        public void PopulateFromMovieList()
        {
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
                        Movie movie = new Movie(movieID, temp[1], genres);
                        medias.Add(movie);                        
                    }
                }
            }
        }

        public void PopulateFromShowList()
        {
            if (File.Exists(showFile.Path))
            {
                using (StreamReader file = new StreamReader(showFile.Path))
                {
                    string line;
                    for (int k = 0; k < 1; k++)
                    {
                        file.ReadLine();
                    }
                    while ((line = file.ReadLine()) != null)
                    {

                        var temp = line.Split(',');
                        string[] genres = temp[5].Split('|');
                        int id = Convert.ToInt32(temp[0]);
                        int season = Convert.ToInt32(temp[2]);
                        int episode = Convert.ToInt32(temp[3]);
                        string[] writers = temp[4].Split('|');
                        Show show = new Show(id, temp[1], season, episode, writers, genres);
                        medias.Add(show);
                    }
                }
            }
        }

        public void PopulateFromVideoList()
        {
            if (File.Exists(videoFile.Path))
            {
                using (StreamReader file = new StreamReader(videoFile.Path))
                {
                    string line;
                    for (int k = 0; k < 1; k++)
                    {
                        file.ReadLine();
                    }
                    while ((line = file.ReadLine()) != null)
                    {

                        var temp = line.Split(',');
                        string[] genres = temp[5].Split('|');
                        int id = Convert.ToInt32(temp[0]);
                        int length = Convert.ToInt32(temp[3]);
                        string[] regionsTemp = temp[4].Split('|');
                        int[] regions = new int[regionsTemp.Length];
                        for(int i = 0; i<regionsTemp.Length; i++)
                        {
                            regions[i] = Convert.ToInt32(regionsTemp[i]);
                        }
                        Video video = new Video(id, temp[1], temp[2], length, regions, genres);
                        medias.Add(video);
                    }
                }
            }
        }

        public void SearchByTitle(string title)
        {
            int count = 0;
            var titleList = from media in medias
                            where media.Title().ToLower().Contains(title.ToLower()) 
                            select media;
            foreach(Media m in titleList)
            {
                Console.WriteLine(m.Display());
                count++;
            }
            Console.WriteLine("\n-----------------\n\nTotal Search Results: " + count + "\n\n-----------------\n");
        }

        public void SearchByGenre(string genre)
        {
            int count = 0;
            var genreList = from media in medias
                            where media.Genres().ToLower().Contains(genre.ToLower())
                            select media;
            foreach(Media m in genreList)
            {
                Console.WriteLine(m.Display());
                count++;
            }
            Console.WriteLine("\n-----------------\n\nTotal Search Results: " + count + "\n\n-----------------\n");
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
