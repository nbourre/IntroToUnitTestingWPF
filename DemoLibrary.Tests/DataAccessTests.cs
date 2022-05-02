using System;
using System.Collections.Generic;
using Xunit;

namespace DemoLibrary.Tests
{
    public class DataAccessTests
    {
        public static IEnumerable<object[]> people = new List<object[]>
        {
                new object[] { new List<PersonModel> {
                        new PersonModel { FirstName = "Nick", LastName = "Corey" },
                        new PersonModel { FirstName = "Matt", LastName = "St-Tienne" },
                        new PersonModel { FirstName = "James", LastName = "St-Te" }
                    }
                },
                new object[] { new List<PersonModel> {
                        new PersonModel { FirstName = "Stevens", LastName = "St-John" },
                        new PersonModel { FirstName = "Lyne", LastName = "TurtleBeach" },
                        new PersonModel { FirstName = "Marco", LastName = "Chewy" }
                    }
                },

        };

        [Fact]
        public void AddPersonToPeopleList_ShouldWork()
        {
            PersonModel newPerson = new PersonModel { FirstName = "Nick", LastName = "Corey" };
            List<PersonModel> people = new List<PersonModel>();

            DataAccess.AddPersonToPeopleList(people, newPerson);

            Assert.True(people.Count == 1);
            Assert.Contains<PersonModel>(newPerson, people);

        }

        [Theory]
        [InlineData("Nick", "", "LastName")]
        [InlineData("", "Corey", "FirstName")]
        public void AddPersonToPeopleList_ShouldFail(string firstName, string lastName, string param)
        {
            PersonModel newPerson = new PersonModel { FirstName = firstName, LastName = lastName };
            List<PersonModel> people = new List<PersonModel>();

            Assert.Throws<ArgumentException>(param, () => DataAccess.AddPersonToPeopleList(people, newPerson));
        }

        [Fact]
        public void ConvertModelsToCSV_HasSameNumberOfLineAsPeople()
        {
            var people = new List<PersonModel>
            {
                new PersonModel { FirstName = "Nick", LastName = "Corey" },
                new PersonModel { FirstName = "Matt", LastName = "St-Meu" },
                new PersonModel { FirstName = "James", LastName = "St-Mie" }
            };

            var expected = 3;

            var actual = DataAccess.ConvertModelsToCSV(people).Count;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(people))]
        public void ConvertModelsToCSV_HasSameNumberOfLineAsPeople__theory(List<PersonModel> _people)
        {
            var expected = _people.Count;

            var actual = DataAccess.ConvertModelsToCSV(_people).Count;

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void ConvertModelsToCSV_NullListShouldFail ()
        {
            List<PersonModel> nullList = null;
            Assert.Throws<ArgumentNullException>(() => DataAccess.ConvertModelsToCSV(nullList));
        }

    }
}
