using System;
using System.Collections.Generic;
using System.Text;

namespace A6_MovieLibraryWithAbstractClasses
{
    public class Show : Media
    {
        private int id { get; set; }
        private string title { get; set; }
        private int season { get; set; }
        private int episode { get; set; }
        private string[] writers { get; set; }

        public Show(int id, string title, int season, int episode, string[] writers)
        {
            this.id = id;
            this.title = title;
            this.season = season;
            this.episode = episode;
            this.writers = writers;
        }

        public override string Display()
        {
            string temp = "";
            string writersString = String.Join(',', writers);
            temp += "ID: " + id + ", Title:" + title + ", Season:" + season + ", Episode: " + episode + ", Writers:" + writersString;
            return temp;
        }
    }
}
