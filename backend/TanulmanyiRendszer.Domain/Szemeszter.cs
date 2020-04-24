using System;
using System.Collections.Generic;
using System.Text;

namespace TanulmanyiRendszer.Domain
{
    public class Szemeszter : EntityBase
    {
        public string Megnevezes { get; set; }
        public DateTime Kezdet { get; set; }
        public DateTime Veg { get; set; }
        public DateTime TargyjelentkezesKezdet { get; set; }
        public DateTime TargyJelentkezesVeg { get; set; }
        public DateTime VizsgajelentkezesKezdet { get; set; }
        public DateTime VizsgajelentkezesVeg { get; set; }
    }
}