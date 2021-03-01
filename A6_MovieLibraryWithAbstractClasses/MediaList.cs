using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace A6_MovieLibraryWithAbstractClasses
{
    public class MediaList
    {
        public List<Media> mediaList { get; set; }
        FileRepo movieFile = new FileRepo("movies.csv");
        FileRepo showFile = new FileRepo("shows.csv");
        FileRepo videoFile = new FileRepo("videos.csv");
        

        public MediaList()
        {
            mediaList = new List<Media>();
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
                        mediaList.Add(movie);                        
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

                        int id = Convert.ToInt32(temp[0]);
                        int season = Convert.ToInt32(temp[2]);
                        int episode = Convert.ToInt32(temp[3]);
                        string[] writers = temp[4].Split('|');
                        Show show = new Show(id, temp[1], season, episode, writers);
                        mediaList.Add(show);
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

                        int id = Convert.ToInt32(temp[0]);
                        int length = Convert.ToInt32(temp[3]);
                        string[] regionsTemp = temp[4].Split('|');
                        int[] regions = new int[regionsTemp.Length];
                        for(int i = 0; i<regionsTemp.Length; i++)
                        {
                            regions[i] = Convert.ToInt32(regionsTemp[i]);
                        }
                        Video video = new Video(id, temp[1], temp[2], length, regions);
                        mediaList.Add(video);
                    }
                }
            }
        }
    }
}
