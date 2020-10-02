using System;
using System.Collections.Generic;
using System.IO;

namespace DemoLibrary
{
    public static class DataAccess
    {
        private static string personTextFile = "PersonText.txt";

        public static void AddNewPerson(PersonModel person)
        {
            List<string> lines = new List<string>();
            List<PersonModel> people = GetAllPeople();

            foreach(PersonModel user in people)
            {
                lines.Add($"{user.FirstName}, {user.LastName}");
            }

            File.WriteAllLines(personTextFile, lines);
        }


        public static List<PersonModel> GetAllPeople()
        {
            List<PersonModel> output = new List<PersonModel>();
            string[] content = File.ReadAllLines(personTextFile);

            foreach (string line in content)
            {
                string[] data;
                
                data = line.Split(",");

                PersonModel tempPerson = new PersonModel
                {
                    FirstName = data[0],
                    LastName = data[1]
                };

                output.Add(tempPerson);
            }

            return output;
        }
    }

}
