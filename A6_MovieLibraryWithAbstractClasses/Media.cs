using System;
using System.Collections.Generic;
using System.Text;

namespace A6_MovieLibraryWithAbstractClasses
{
    public abstract class Media
    {
        public abstract int id { get; set; }
        public abstract string title { get; set; }
        public abstract string[] genres { get; set; }
        public abstract string Display();
        public abstract string Title();
        public abstract string Genres();
    }
}
