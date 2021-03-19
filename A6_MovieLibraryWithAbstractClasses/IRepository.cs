using System;
using System.Collections.Generic;
using System.Text;

namespace A6_MovieLibraryWithAbstractClasses
{
    public interface IRepository
    {
        public void WritetoFile(MediaList mediaList, Movie movie);

        public void ReadFile(MediaList mediaList, Type type);
    }
}
