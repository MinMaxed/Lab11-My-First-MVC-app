using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace MyFirstMVCApp.Models
{
    public class TimePerson
    {
        //all Keys that a person in the list of People will have. year they were awared, what thye recieved, 
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        public List<TimePerson> GetPersons(int startYear, int endYear)
        {
            ///contrustor of list of people
            List<TimePerson> people = new List<TimePerson>();

            ///set a path to somewhere within the environments current file tree
            string path = Environment.CurrentDirectory;

            ///use the previous path to go through the csv file in the wwwroot folder and assign it to a new path
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));

            ///take the new path to the csv file and reads it all into a string array
            string[] myFile = File.ReadAllLines(newPath);

            /// This is where the array of csv info gets put into the list above (people.Add). 
            /// it loops over the array, starting at 1 instead of 0 to skip past the headers of each field, 
            /// and then assigns the info to the appropriate Key's. The years are tirnerys to account for blanks or 
            /// non-ints. 
            /// //myFile gets split on each comma separator as the csv file uses those to separate things
            /// for each Key in the appropriate fields. it takes the Time Person's fields and adds it to the people
            /// list we made above. 
            for (int i = 1; i < myFile.Length; i++)
			{
                string[] fields = myFile[i].Split(',');
                people.Add(new TimePerson
                {
                    Year = Convert.ToInt32(fields[0]),
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    BirthYear = (fields[4] == "")? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "")? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8],
                });
			}
            ///lambda query to filter based on the start years and ending years of the users search, and then displays everyone
            /// who was honored in a year within that range
            List<TimePerson> listofPeople = people.Where(p => (p.Year >= startYear) && (p.Year <= endYear)).ToList();
            return listofPeople;
        }
    }
}
