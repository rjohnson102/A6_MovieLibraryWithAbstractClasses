using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Json.Net;
using System.Linq;

namespace A6_MovieLibraryWithAbstractClasses
{
    class JSONFile : IRepository
    {

        public string Path { get; set; }

        public JSONFile(string path)
        {
            this.Path = path;
        }
        public void ReadFile(MediaList mediaList, Type type)
        {
            Console.WriteLine();
            foreach (Media m in mediaList.medias)
            {
                if (m.GetType() == type)
                {
                    Console.WriteLine(m.Display());
                }
                else if(m.GetType().IsSubclassOf(type) == true)
                {
                    Console.WriteLine(m.Display());
                }
            }
        }

        public void WritetoFile(MediaList mediaList, Movie movie)
        {

            JSONFile jsonfile = new JSONFile("media.json");
                        

            using (StreamWriter outputFile = new StreamWriter(jsonfile.Path))
            {
                foreach (Media media in mediaList.medias)
                {
                    var temp = JsonNet.Serialize(media);
                    outputFile.WriteLine(temp);
                }
                outputFile.Close();
            }
        }       
    }
}
