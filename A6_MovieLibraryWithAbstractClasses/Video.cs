using System;
using System.Collections.Generic;
using System.Text;

namespace A6_MovieLibraryWithAbstractClasses
{
    public class Video : Media
    {
        private int id { get; set; }
        private string title { get; set; }
        private string format { get; set; }
        private int length { get; set; }
        private int[] regions { get; set; }

        public Video(int id, string title, string format, int length, int[] regions)
        {
            this.id = id;
            this.title = title;
            this.format = format;
            this.length = length;
            this.regions = regions;
        }

        public override string Display()
        {
            string temp = "";
            string regionsString = String.Join(',', regions);
            temp += "ID: " + id + ", Title: " + title + ", Format: " + format + ", Length: " + length + ", Regions: " + regionsString;
            return temp;
        }
    }
}
