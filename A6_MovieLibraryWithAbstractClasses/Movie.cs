using System;
using System.Collections.Generic;
using System.Text;

namespace A6_MovieLibraryWithAbstractClasses
{
    public class Movie : Media
    {
        public int id { get; set; }
        public string title { get; set; }
        public string[] genre { get; set; }

        public Movie(int id, string title, string[] genre)
        {
            this.id = id;
            this.title = title;
            this.genre = genre;
        }       

        public override string Display()
        {
            string temp = "";
            string genreString = String.Join(',', genre);
            temp += "ID: " + id + ", Title:" + title + ", Genre:" + genreString;
            return temp;
        }
    }
}
