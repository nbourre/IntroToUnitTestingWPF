using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace DemoLibrary.Tests
{
    public class DataAccessTests
    {
        public class TestDataGenerator : IEnumerable<object[]>
        {
            public static IEnumerable<object[]> GetPeopleList()
            {
                yield return new object[]
                {
                    new List<PersonModel> {
                        new PersonModel { FirstName = "Nicolas", LastName = "Bourré" },
                        new PersonModel { FirstName = "Gratien", LastName = "Bourré" },
                        new PersonModel { FirstName = "Alain", LastName = "Bourré" },
                        new PersonModel { FirstName = "Denis", LastName = "Bourré" },
                    }
                };
            }

            public IEnumerator<object[]> GetEnumerator() => GetPeopleList().GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

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
            var people = GetSomePeople();

            int expected = people.Count;

            int actual = DataAccess.ConvertModelsToCSV(people).Count;

            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Source : https://hamidmosalla.com/2017/02/25/xunit-theory-working-with-inlinedata-memberdata-classdata/
        /// </summary>
        /// <param name="people"></param>
        [Theory]
        [MemberData(nameof(TestDataGenerator.GetPeopleList), MemberType = typeof(TestDataGenerator))]
        public void ConvertModelsToCSV_Theory_HasSameNumberOfLineAsPeople(List<PersonModel> people)
        {
            int expected = people.Count;

            int actual = DataAccess.ConvertModelsToCSV(people).Count;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertModelsToCSV_NullListShouldFail()
        {
            List<PersonModel> nullList = null;

            Assert.Throws<ArgumentNullException>(() => DataAccess.ConvertModelsToCSV(nullList));
        }

        private List<PersonModel> GetSomePeople()
        {
            var result = new List<PersonModel> {
                new PersonModel { FirstName = "Nicolas", LastName = "Bourré" },
                new PersonModel { FirstName = "Gratien", LastName = "Bourré" },
                new PersonModel { FirstName = "Alain", LastName = "Bourré" },
                new PersonModel { FirstName = "Denis", LastName = "Bourré" },

            };

            return result;
        }

    }
}
