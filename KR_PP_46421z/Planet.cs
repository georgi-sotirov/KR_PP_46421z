using System;
using System.Collections.Generic;

namespace KR_PP_46421z
{
    public class Planet
    {
        public Planet(string planetName, string terra, string liveable)
        {
            this.Planetname = planetName;
            this.Terra = terra;
            this.Live = liveable;
            this.Moons = new List<Moon>();
        }
        public Planet(string planet, List<Moon> m)
        {
            this.Planetname = planet;
            this.Moons = m;
        }
        public string Planetname { get; set; }
        public string Terra { get; set; }
        public string Live { get; set; }
        public List<Planet> Planets { get; set; }
        public List<Moon> Moons { get; set; }
        public void AddMoon(Moon m)
        {
            Moons.Add(m);
        }
        public void PrintMoons()
        {
            foreach (Moon m in Moons) Console.WriteLine(m.Moonname);
        }
    }
}
