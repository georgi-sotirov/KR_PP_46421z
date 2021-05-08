using System;
using System.Collections.Generic;

namespace KR_PP_46421z
{
    public class Star
    {
        public Star(string starName, string clas, double weight, double size, int temperature, double light)
        {
            this.Starname = starName;
            this.Clas = clas;
            this.Weight = weight;
            this.Size = size/2;
            this.Temp = temperature;
            this.Light = light;
            this.Planets = new List<Planet>();
        }
        public Star(string star, List<Planet> p)
        {
            this.Starname = star;
            this.Planets = p;
        }
        public string Starname { get; set; }
        public string Clas { get; set; }
        public double Weight { get; set; }
        public double Size { get; set; }
        public int Temp { get; set; }
        public double Light { get; set; }
        public List<Star> Stars { get; set; }
        public List<Planet> Planets { get; set; }
        public void AddPlanet(Planet pl)
        {
            Planets.Add(pl);
        }
        public void PrintPlanets()
        {
            foreach (Planet p in Planets) Console.WriteLine(p.Planetname);
        }
    }
}
