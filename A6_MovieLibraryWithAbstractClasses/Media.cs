using System;
using System.Collections.Generic;
using System.Text;

namespace A6_MovieLibraryWithAbstractClasses
{
    public abstract class Media
    {
        public int id { get; set; }
        public string title { get; set; }
        public abstract string Display();
    }
}
