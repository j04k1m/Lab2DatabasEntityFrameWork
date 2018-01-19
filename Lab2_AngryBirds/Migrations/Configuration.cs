namespace Lab2_AngryBirds.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lab2_AngryBirds.Program.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Lab2_AngryBirds.Program.MyContext context)
        {
            ////  This method will be called after migrating to the latest version.
            //var Map2 = context.Map.Add(new Map { Birds = 22, Map_Name = "Paradise" });
            //var Map3 = context.Map.Add(new Map { Birds = 30, Map_Name = "Castle" });
            //var Map4 = context.Map.Add(new Map { Birds = 15, Map_Name = "Temple" });
            //var Map5 = context.Map.Add(new Map { Birds = 9, Map_Name = "Chocolate" });


            //var player1 = context.Player.Add(new Player { Player_Name = "Steve" });
            //var player2 = context.Player.Add(new Player { Player_Name = "Bob" });
            //var player3 = context.Player.Add(new Player { Player_Name = "Carl" });
            //var player4 = context.Player.Add(new Player { Player_Name = "Borat" });
            //var player5 = context.Player.Add(new Player { Player_Name = "John" });


            //context.Points.Add(new Score { Player = player1, Map = Map1, Points = 5 });
            //context.Points.Add(new Score { Player = player1, Map = Map2, Points = 15 });
            //context.Points.Add(new Score { Player = player1, Map = Map3, Points = 25 });
            //context.Points.Add(new Score { Player = player1, Map = Map4, Points = 10 });
            //context.Points.Add(new Score { Player = player1, Map = Map5, Points = 6 });
            //context.Points.Add(new Score { Player = player2, Map = Map1, Points = 3 });
            //context.Points.Add(new Score { Player = player2, Map = Map2, Points = 18 });
            //context.Points.Add(new Score { Player = player2, Map = Map3, Points = 15 });
            //context.Points.Add(new Score { Player = player2, Map = Map4, Points = 4 });
            //context.Points.Add(new Score { Player = player2, Map = Map5, Points = 4 });
            //context.Points.Add(new Score { Player = player3, Map = Map1, Points = 5 });
            //context.Points.Add(new Score { Player = player3, Map = Map2, Points = 10 });
            //context.Points.Add(new Score { Player = player3, Map = Map3, Points = 2 });
            //context.Points.Add(new Score { Player = player3, Map = Map4, Points = 15 });
            //context.Points.Add(new Score { Player = player4, Map = Map1, Points = 9 });
            //context.Points.Add(new Score { Player = player4, Map = Map2, Points = 15 });
            //context.Points.Add(new Score { Player = player4, Map = Map3, Points = 25 });
            //context.Points.Add(new Score { Player = player5, Map = Map1, Points = 5 });
            //context.Points.Add(new Score { Player = player5, Map = Map2, Points = 15 });
            //context.Points.Add(new Score { Player = player5, Map = Map3, Points = 15 });
            //context.Points.Add(new Score { Player = player5, Map = Map4, Points = 5 });
            //context.Points.Add(new Score { Player = player5, Map = Map5, Points = 7 });          var Map1 = context.Map.Add(new Map { Birds = 8, Map_Name = "Birdemic" });
  

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
