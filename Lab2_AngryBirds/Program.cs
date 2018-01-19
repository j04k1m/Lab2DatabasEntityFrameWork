using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2_AngryBirds
{
    class Program
    {
        public class MyContext : DbContext
        {
            // konstruktorn behöver en connection string
            private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AngryBirds;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            public MyContext() : base(ConnectionString) { }
            public DbSet<Player> Player { get; set; }
            public DbSet<Map> Map { get; set; }
            public DbSet<Score> Points { get; set; }
        }

        private static void AddPlayerName(MyContext context)
        {
                Console.WriteLine("Enter Name");
                string name = Console.ReadLine(); 
            try
            {
                Player Player = new Player();
                Player.Player_Name = name;
                context.Player.Add(Player);
                context.SaveChanges();
                Console.WriteLine("Player Added");
            }
            catch
            {
                try
                {
                    //Console.WriteLine("Name already exist, try again");
                    var queryScoreSpecificName = from x in context.Points
                                                 .Include(p => p.Player)
                                                 .Include(p => p.Map)
                                                 where x.Player.Player_Name == name
                                                 select x;
                    var queryTotalScoreSpecificName = (from x in context.Points
                                                       .Include(p => p.Points)
                                                       where x.Player.Player_Name.Equals(name)
                                                       select x.Points).Sum();
                    // map points pointstotal playername mapname
                    Console.WriteLine("---------------------------------------");
                    foreach (var x in queryScoreSpecificName)
                    {
                        Console.WriteLine("Name: " + x.Player.Player_Name + "\nMap: " + x.Map.Map_Name + "\nPoints: " + x.Points +
                             "\nUnused Moves: " + (x.Map.Birds - x.Points) + "\n");
                    }
                    Console.WriteLine("Total Points: " + queryTotalScoreSpecificName + "");
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("");
                    //AddPlayerName(context);
                }
                catch
                {
                    Console.WriteLine("No score exist");
                }
            }
        }

        private static void AddMap(MyContext context)
        {

            try
            {
                Console.WriteLine("Enter Name");
                string name = Console.ReadLine(); 
                Console.WriteLine("Enter number of Birds");
                int birds = int.Parse(Console.ReadLine()); 
                Map Map = new Map();
                Map.Map_Name = name;
                Map.Birds = birds;
                context.Map.Add(Map);
                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Map already exist, try again");
                AddMap(context);
            }
        }

        private static void UpdateScore(MyContext context)
        {

            //var player = context.Points.Where(s => s.Score_Id == ScoreIdNumber).First();
            try
            {
                //Console.WriteLine("Enter Score_Id: ");
                //int ScoreIdNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Player Name");
                string PlayaName = Console.ReadLine();
                Console.WriteLine("Enter Map Name");
                string MapName = Console.ReadLine();
                Console.WriteLine("Enter New Score");
                int NewScore = int.Parse(Console.ReadLine());
                var playa = context.Points
                    .Where(a => a.Player.Player_Name == PlayaName)
                    .Where(a => a.Map.Map_Name == MapName).First();
                var playaBirds = context.Map.Where(k => k.Map_Name == MapName).First();
                int NumberofBirds = playaBirds.Birds;
                if (NewScore > NumberofBirds)
                {
                    Console.WriteLine("Number of Birds invalid\n");
                    UpdateScore(context);
                }
                else
                {
                    playa.Points = NewScore;
                    context.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Entered invalid value, try again\n");
                UpdateScore(context);
            }
        }
        
        public static void PrintPlayerTable(MyContext context)
        {
            var queryPlayerNames = from x in context.Player
                                   select x;
            Console.WriteLine("---------------------------------------");
            foreach (var x in queryPlayerNames)
            {
                Console.WriteLine("Name: " + x.Player_Name);
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("");
        }

        public static void PrintMapTable(MyContext context)
        {
            var queryMapNames = from x in context.Map
                                select x;
            Console.WriteLine("---------------------------------------");
            foreach (var x in queryMapNames)
            {
                Console.WriteLine("Name: " + x.Map_Name + " - " + "Birds: " + x.Birds);
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("");
        }

        public static void PrintScoreTable(MyContext context)
        {

            var queryScoreTableInfo = from x in context.Points
                                      .Include(s => s.Player)
                                      .Include(s => s.Map)
                                      select x;
            Console.WriteLine("---------------------------------------");
            foreach (var x in queryScoreTableInfo)
            {
                Console.WriteLine("Name: " + x.Player.Player_Name + " - " + 
                    "Map: " + x.Map.Map_Name + " - " + "Points: " + x.Points);
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            MyContext context = new MyContext();
            bool a = true;
            while (a)
            {
                bool b = true;
                while (b)
                {
                    Console.WriteLine("\n**** Welcome ****");
                    Console.WriteLine("Instructions Enter Number");
                    Console.WriteLine(" 1.Print Tables");
                    Console.WriteLine(" 2.Enter Name");
                    Console.WriteLine(" 3.Update Score");
                    Console.WriteLine(" 4.Add Map\n");
                    int Number = int.Parse(Console.ReadLine());
                    if (Number < 1 || Number > 4)
                    {
                        Console.WriteLine("\nInvalid Number");
                    }
                    //1. Print Tables
                    if (Number == 1)
                    {
                        Console.WriteLine("Instructions Enter Number");
                        Console.WriteLine(" 1.Print Player Table");
                        Console.WriteLine(" 2.Print Map Table");
                        Console.WriteLine(" 3.Print Score Table");
                        int PrintTableNumber = int.Parse(Console.ReadLine());
                        if (PrintTableNumber == 1)
                        {
                            PrintPlayerTable(context);
                            b = false;

                        }
                        if (PrintTableNumber == 2)
                        {
                            PrintMapTable(context);
                            b = false;
                        }
                        if (PrintTableNumber == 3)
                        {
                            PrintScoreTable(context);
                            b = false;
                        }
                        if (PrintTableNumber < 1 || PrintTableNumber > 3)
                        {
                            Console.WriteLine("\nInvalid Number\n");
                            b = false;
                        }
                    }
                    //2. Enter Name
                    if (Number == 2)
                    {
                        AddPlayerName(context);
                        b = false;
                    }
                    //3. Uppdate Score
                    if (Number == 3)
                    {
                        UpdateScore(context);
                        b = false;
                    }
                    //4. Add Map
                    if (Number == 4)
                    {
                        AddMap(context);
                        b = false;
                    }
                }

                //Quit or Menu
                Console.WriteLine("Press M for Menu or Random Letter for Quit");
                string menu = Console.ReadLine().ToUpper();
                if (menu == "M")
                {
                    b = true;
                }
                else
                {
                    a = false;
                }
                //End
            }
        }
    }
}
