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
                throw new ArgumentException("The filename was too short", "file");

            return "The file loaded correctly";
        }
    }

}
