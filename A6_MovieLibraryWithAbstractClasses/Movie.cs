using System;
using System.Collections.Generic;
using System.Text;

namespace A6_MovieLibraryWithAbstractClasses
{
    public class Movie : Media
    {
        public override int id { get; set; }
        public override string title { get; set; }
        public override string[] genres { get; set; }

        public Movie(int id, string title, string[] genres)
        {
            this.id = id;
            this.title = title;
            this.genres = genres;
        }       

        public override string Display()
        {
            string temp = "";
            string genreString = String.Join(',', genres);
            temp += "ID: " + id + ", Title:" + title + ", Genre:" + genreString;
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
            }catch(NullReferenceException e)
            {
                v += "";
            }
            return v;
        }
    }
}
