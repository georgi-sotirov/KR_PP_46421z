using System;
using System.Collections.Generic;

namespace KR_PP_46421z
{
    public class Moon
    {
        public Moon(string name)
        {
            this.Moonname = name;
        }
        public string Moonname { get; set; }
        public List<Moon> Moons { get; set; }
    }
}
