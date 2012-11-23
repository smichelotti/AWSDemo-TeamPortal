using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TeamPortal.Models
{
    public class TeamPortalDbInitializer : CreateDatabaseIfNotExists<TeamPortalWebContext>
    {
        protected override void Seed(TeamPortalWebContext context)
        {
            SeedStates(context);

            var team1 = new Team { Id = 1, TeamName = "Sharks" };
            var team2 = new Team { Id = 2, TeamName = "Warriors" };
            var team3 = new Team { Id = 3, TeamName = "Hoyas" };
            var team4 = new Team { Id = 4, TeamName = "Heat" };
            var team5 = new Team { Id = 5, TeamName = "Hawks" };

            context.Teams.Add(team1);
            context.Teams.Add(team2);
            context.Teams.Add(team3);
            context.Teams.Add(team4);
            context.Teams.Add(team5);
            context.SaveChanges();

            //var mdId = context.States.Single(x => x.Name == "Maryland").Id;

            context.Players.Add(CreatePlayer(team1.Id, "Justin", "Michelotti", 12));
            context.Players.Add(CreatePlayer(team1.Id, "Jeff", "Smith", 3));
            context.Players.Add(CreatePlayer(team1.Id, "Joey", "Johnson", 25));
            context.Players.Add(CreatePlayer(team1.Id, "Matthew", "Williams", 5));
            context.Players.Add(CreatePlayer(team1.Id, "Will", "Jones", 50));
            context.Players.Add(CreatePlayer(team1.Id, "Zach", "Brown", 10));

            context.Players.Add(CreatePlayer(team2.Id, "Desmond", "Davis", 23));
            context.Players.Add(CreatePlayer(team2.Id, "Tyler", "Miller", 0));
            context.Players.Add(CreatePlayer(team2.Id, "Finn", "Wilson", 32));
            context.Players.Add(CreatePlayer(team2.Id, "Cameron", "Moore", 4));
            context.Players.Add(CreatePlayer(team2.Id, "Connor", "Taylor", 2));

            context.Players.Add(CreatePlayer(team3.Id, "James", "Anderson", 1));
            context.Players.Add(CreatePlayer(team3.Id, "John", "Jackson", 10));
            context.Players.Add(CreatePlayer(team3.Id, "Robert", "White", 21));
            context.Players.Add(CreatePlayer(team3.Id, "Michael", "Harris", 22));
            context.Players.Add(CreatePlayer(team3.Id, "David", "Martin", 33));

            context.Players.Add(CreatePlayer(team4.Id, "Richard", "Thompson", 42));
            context.Players.Add(CreatePlayer(team4.Id, "Charles", "Robinson", 51));
            context.Players.Add(CreatePlayer(team4.Id, "Joseph", "Garcia", 44));
            context.Players.Add(CreatePlayer(team4.Id, "Tom", "Clark", 33));
            context.Players.Add(CreatePlayer(team4.Id, "Dan", "Lewis", 24));

            context.Players.Add(CreatePlayer(team5.Id, "Paul", "Lee", 11));
            context.Players.Add(CreatePlayer(team5.Id, "Mark", "Walker", 13));
            context.Players.Add(CreatePlayer(team5.Id, "George", "Hall", 34));
            context.Players.Add(CreatePlayer(team5.Id, "Brian", "Allen", 30));
            context.Players.Add(CreatePlayer(team5.Id, "Kevin", "Young", 25));


            context.SaveChanges();
        }

        private static Player CreatePlayer(int teamId, string firstName, string lastName, int jerseyNumber)
        {
            return new Player
            {
                Id = Guid.NewGuid(),
                TeamId = teamId,
                FirstName = firstName,
                LastName = lastName,
                JerseyNumber = jerseyNumber,
                EmailAddress = firstName.ToLower() + "@gmail.com",
                StreetAddress = "123 Main Street",
                City = "Baltimore",
                StateId = 21,
                PostalCode = "12345",
                PhotoUri = "/roster-images/75c66656-311f-4974-a53c-d0e95b1c1ba3.jpg"
            };
        }

        private static void SeedStates(TeamPortalWebContext context)
        {
            context.States.Add(new State { Id = 1, Name = "Alabama" });
            context.States.Add(new State { Id = 2, Name = "Alaska" });
            context.States.Add(new State { Id = 3, Name = "Arizona" });
            context.States.Add(new State { Id = 4, Name = "Arkansas" });
            context.States.Add(new State { Id = 5, Name = "California" });
            context.States.Add(new State { Id = 6, Name = "Colorado" });
            context.States.Add(new State { Id = 7, Name = "Connecticut" });
            context.States.Add(new State { Id = 8, Name = "Delaware" });
            context.States.Add(new State { Id = 9, Name = "District of Columbia" });
            context.States.Add(new State { Id = 10, Name = "Florida" });
            context.States.Add(new State { Id = 11, Name = "Georgia" });
            context.States.Add(new State { Id = 12, Name = "Hawaii" });
            context.States.Add(new State { Id = 13, Name = "Idaho" });
            context.States.Add(new State { Id = 14, Name = "Illinois" });
            context.States.Add(new State { Id = 15, Name = "Indiana" });
            context.States.Add(new State { Id = 16, Name = "Iowa" });
            context.States.Add(new State { Id = 17, Name = "Kansas" });
            context.States.Add(new State { Id = 18, Name = "Kentucky" });
            context.States.Add(new State { Id = 19, Name = "Louisiana" });
            context.States.Add(new State { Id = 20, Name = "Maine" });
            context.States.Add(new State { Id = 21, Name = "Maryland" });
            context.States.Add(new State { Id = 22, Name = "Massachusetts" });
            context.States.Add(new State { Id = 23, Name = "Michigan" });
            context.States.Add(new State { Id = 24, Name = "Minnesota" });
            context.States.Add(new State { Id = 25, Name = "Mississippi" });
            context.States.Add(new State { Id = 26, Name = "Missouri" });
            context.States.Add(new State { Id = 27, Name = "Montana" });
            context.States.Add(new State { Id = 28, Name = "Nebraska" });
            context.States.Add(new State { Id = 29, Name = "Nevada" });
            context.States.Add(new State { Id = 30, Name = "New Hampshire" });
            context.States.Add(new State { Id = 31, Name = "New Jersey" });
            context.States.Add(new State { Id = 32, Name = "New Mexico" });
            context.States.Add(new State { Id = 33, Name = "New York" });
            context.States.Add(new State { Id = 34, Name = "North Carolina" });
            context.States.Add(new State { Id = 35, Name = "North Dakota" });
            context.States.Add(new State { Id = 36, Name = "Ohio" });
            context.States.Add(new State { Id = 37, Name = "Oklahoma" });
            context.States.Add(new State { Id = 38, Name = "Oregon" });
            context.States.Add(new State { Id = 39, Name = "Pennsylvania" });
            context.States.Add(new State { Id = 40, Name = "Rhode Island" });
            context.States.Add(new State { Id = 41, Name = "South Carolina" });
            context.States.Add(new State { Id = 42, Name = "South Dakota" });
            context.States.Add(new State { Id = 43, Name = "Tennessee" });
            context.States.Add(new State { Id = 44, Name = "Texas" });
            context.States.Add(new State { Id = 45, Name = "Utah" });
            context.States.Add(new State { Id = 46, Name = "Vermont" });
            context.States.Add(new State { Id = 47, Name = "Virginia" });
            context.States.Add(new State { Id = 48, Name = "Washington" });
            context.States.Add(new State { Id = 49, Name = "West Virginia" });
            context.States.Add(new State { Id = 50, Name = "Wisconsin" });
            context.States.Add(new State { Id = 51, Name = "Wyoming" });

            context.SaveChanges();
        }
    }
}