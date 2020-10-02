using System;
using System.Collections.Generic;
using System.Text;

namespace DemoLibrary
{
    public static class Examples
    {
        public static string ExampleLoadTextFile(string file)
        {
            if (file.Length < 10)
                //throw new System.IO.FileNotFoundException();
                throw new ArgumentException("Filename what to short", "file");

            return "The file loaded correctly";
        }
    }

}
