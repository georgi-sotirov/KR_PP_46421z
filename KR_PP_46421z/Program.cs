using System;
using System.Collections.Generic;
using System.Linq;

namespace KR_PP_46421z
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Galaxy> galaxies = new List<Galaxy>();
            string inputText = Console.ReadLine();
            string command = inputText.Split(" ")[0].Trim();
            while (command != "exit"){
                if(command == "add")
                {
                string obj = inputText.Split(" ")[1].Trim();
                        switch (obj)
                        {
                        case "galaxy":
                                string name = inputText.Split('[', ']')[1];
                                string type = inputText.Split(" ")[inputText.Split(" ").Length-2].Trim();
                                string age = inputText.Split(" ")[inputText.Split(" ").Length -1].Trim();

                            
                            if (galaxies.Any(x => x.Name == name))
                            {
                                Console.WriteLine("Galaxy exists!");
                            }
                            else
                            {
                                galaxies.Add(new Galaxy(name, type, age));
                            }
                            

                            break;
                        case "star":
                            string gal = inputText.Split('[', ']')[1];
                            string starName = inputText.Split('[', ']')[3];
                            double weight = double.Parse(inputText.Split(" ")[inputText.Split(" ").Length - 4].Trim());
                            double size = double.Parse(inputText.Split(" ")[inputText.Split(" ").Length - 3].Trim());
                            int temperature = int.Parse(inputText.Split(" ")[inputText.Split(" ").Length - 2].Trim());
                            double light = double.Parse(inputText.Split(" ")[inputText.Split(" ").Length - 1].Trim());
                            string clas = "";
                            if (weight >= 16 && size >= 6.6 && temperature >= 30000 && light >= 30000) clas = "O";
                            else if(weight >= 2.1 && size >= 1.8 && temperature >= 10000 && light >= 25) clas = "B";
                            else if (weight >= 1.4 && size >= 1.4 && temperature >= 7500 && light >= 5) clas = "A";
                            else if (weight >= 1.04 && size >= 1.15 && temperature >= 6000 && light >= 1.5) clas = "F";
                            else if (weight >= 0.8 && size >= 0.96 && temperature >= 5200 && light >= 0.6) clas = "G";
                            else if (weight >= 0.45 && size > 0.7 && temperature >= 3700 && light > 0.08) clas = "K";
                            else if (weight >= 0.08 && size <= 0.7 && temperature >= 2400 && light <= 0.08) clas = "M";


                            Star star = new Star(starName, clas, weight, size, temperature, light);
                            if (galaxies.Any(x => x.Name == gal))
                            {
                                galaxies.Find(x => x.Name == gal).AddStar(star);
                            }
                            else
                            {
                                galaxies.Add(new Galaxy(gal, new List<Star>() { star }));
                            }

                            break;
                        case "planet":
                            string strNm = inputText.Split('[', ']')[1];
                            string planetName = inputText.Split('[', ']')[3];
                            string terra = inputText.Split(" ")[inputText.Split(" ").Length - 2].Trim();
                            string liveable = inputText.Split(" ")[inputText.Split(" ").Length - 1].Trim();

                            Planet planet = new Planet(planetName, terra, liveable);
                            foreach (Galaxy g in galaxies)
                            {
                                if (g.Stars.Any(x => x.Starname == strNm))
                                {
                                    g.Stars.Find(x => x.Starname == strNm).AddPlanet(planet);
                                }
                            }

                            break;
                        case "moon":
                            string planetNm= inputText.Split('[', ']')[1];
                            string moonName = inputText.Split('[', ']')[3];
                            Moon moon = new Moon(moonName);
                            foreach (Galaxy g in galaxies)
                            {
                                foreach (Star s in g.Stars)
                                {
                                    if (s.Planets.Any(x => x.Planetname == planetNm))
                                    {
                                        s.Planets.Find(x => x.Planetname == planetNm).AddMoon(moon);
                                    }
                                }
                            }
                            break;
                    } 
                }
                else if(command == "stats")
                {
                    int galCount = galaxies.Count;
                    int starCount = 0;
                    int planetCount = 0;
                    int moonCount = 0;
                    foreach(Galaxy g in galaxies)
                    {
                        starCount += g.Stars.Count;
                        foreach (Star s in g.Stars)
                        {
                            planetCount += s.Planets.Count;

                            foreach (Planet p in s.Planets)
                            {
                                moonCount += p.Moons.Count;
                            }
                        }
                    }
                        
                    Console.WriteLine("--- Stats --- \n" +
                        $"Galaxies: {galaxies.Count} \n" +
                        $"Stars: {starCount} \n" +
                        $"Planets: {planetCount} \n" +
                        $"Moons: {moonCount} \n" +
                        "--- End of stats ---");
                }
                else if(command == "list")
                {
                    string obj = inputText.Split(" ")[1].Trim();
                    switch (obj)
                    {
                        case "galaxies":
                            Console.WriteLine("--- List of all researched galaxies ---");
                            foreach (Galaxy g in galaxies) g.PrintGalaxies();
                            Console.WriteLine("--- End of galaxies list ---");
                            break;
                        case "stars":
                            Console.WriteLine("--- List of all researched stars ---");
                            foreach (Galaxy g in galaxies)
                            {
                                g.PrintStars();  
                            }
                            Console.WriteLine("--- End of stars list ---");
                            break;
                        case "planets":
                            Console.WriteLine("--- List of all researched planets ---");
                            foreach (Galaxy g in galaxies)
                            {
                                foreach (Star s in g.Stars)
                                {
                                    s.PrintPlanets();
                                }
                            }
                            Console.WriteLine("--- End of stars list ---");
                            break;
                        case "moons":
                            Console.WriteLine("--- List of all researched moons ---");
                            foreach (Galaxy g in galaxies)
                            {
                                foreach (Star s in g.Stars)
                                {
                                    foreach(Planet p in s.Planets) p.PrintMoons();
                                }
                            }
                            Console.WriteLine("--- End of moons list ---");
                            break;
                    }
                }
                else if(command == "print")
                {
                    string galaxy = inputText.Split('[', ']')[1];
                    if (galaxies.Any(x => x.Name == galaxy))
                    {
                        Galaxy ga = galaxies.Find(x => x.Name == galaxy);
                        Console.WriteLine($"---Data for {galaxy} galaxy---");

                        Console.WriteLine($"Type: {ga.Type} \n" +
                        $"Age: {ga.Age} \n" +
                                "Stars:");
                        foreach (Star s in ga.Stars)
                        {
                            Console.WriteLine($"\t-\t Name: {s.Starname} \n" +
                                              $"\t\t Class: {s.Clas} ({s.Weight} {s.Size} {s.Temp} {s.Light}) n" +
                                             "\t\t Planets:");
                            foreach (Planet p in s.Planets)
                            {
                                Console.WriteLine($"\t\t\to\t Name: {p.Planetname} \n" +
                                    $"\t\t\t\t Type: {p.Terra} \n" +
                                    $"\t\t\t\t Support life: {p.Live} \n" +
                                    "\t\t\t\t Moons:");
                                foreach (Moon m in p.Moons)
                                {
                                    Console.WriteLine($"\t\t\t\t\u2022\t {m.Moonname}");
                                }
                            }
                        }
                        Console.WriteLine($"---End of data for {galaxy} galaxy---");
                    }
                }
                
                inputText = Console.ReadLine();
                command = inputText.Split(" ")[0].Trim();
            }
        }
    }
}
