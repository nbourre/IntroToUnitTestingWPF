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
            List<PersonModel> people = GetAllPeople();

            AddPersonToPeopleList(people, person);

            var lines = ConvertModelsToCSV(people);

            File.WriteAllLines(personTextFile, lines);
        }

        public static void AddPersonToPeopleList(List<PersonModel> people, PersonModel person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                throw new ArgumentException("Invalid paramater", "FirstName");
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                throw new ArgumentException("Invalid paramater", "LastName");
            }

            people.Add(person);
        }

        public static List<string> ConvertModelsToCSV(List<PersonModel> people)
        {
            if (people == null)
                throw new ArgumentNullException("People cannot be null");

            List<string> output = new List<string>();

            foreach (PersonModel user in people)
                output.Add($"{user.FirstName},{user.LastName}");

            return output;
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
