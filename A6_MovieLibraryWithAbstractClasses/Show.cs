using System;
using System.Collections.Generic;
using System.Text;

namespace A6_MovieLibraryWithAbstractClasses
{
    public class Show : Media
    {
        public override int id { get; set; }
        public override string title { get; set; }
        public override string[] genres { get; set; }
        public int season { get; set; }
        public int episode { get; set; }
        public string[] writers { get; set; }



        public Show(int id, string title, int season, int episode, string[] writers, string[] genres)
        {
            this.id = id;
            this.title = title;
            this.season = season;
            this.episode = episode;
            this.writers = writers;
            this.genres = genres;
        }

        public override string Display()
        {
            string temp = "";
            string writersString = String.Join(',', writers);
            string genreString = String.Join(',', genres);            
            temp += "ID: " + id + ", Title:" + title + ", Season:" + season + ", Episode: " + episode + ", Writers:" + writersString + "Genres: " + genreString;
            return temp;
        }

        public override string Title()
        {
            string boom = title;
            return boom;
        }

        public override string Genres()
        {
            string v = "";
            try
            {
                foreach (var c in genres)
                {
                    v += c;
                }
            }
            catch (NullReferenceException e)
            {
                v += "";
            }
            return v;
        }
    }
}
