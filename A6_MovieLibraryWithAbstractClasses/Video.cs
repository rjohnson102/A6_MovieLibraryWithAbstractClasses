using System;
using System.Collections.Generic;
using System.Text;

namespace A6_MovieLibraryWithAbstractClasses
{
    public class Video : Media
    {
        public override int id { get; set; }
        public override string title { get; set; }
        public override string[] genres { get; set; }
        public string format { get; set; }
        public int length { get; set; }
        public int[] regions { get; set; }

        

        public Video(int id, string title, string format, int length, int[] regions, string[] genres)
        {
            this.id = id;
            this.title = title;
            this.format = format;
            this.length = length;
            this.regions = regions;
            this.genres = genres;
        }

        public override string Display()
        {
            string temp = "";
            string regionsString = String.Join(',', regions);
            string genreString = String.Join(',', genres);            
            temp += "ID: " + id + ", Title: " + title + ", Format: " + format + ", Length: " + length + ", Regions: " + regionsString + genreString;
            return temp;
        }

        public override string Title()
        {
            string boom = title;
            return title;
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
