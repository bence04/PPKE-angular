using System;
using System.Collections.Generic;
using System.Text;

namespace TanulmanyiRendszer.Domain
{
    public class VizsgaJelentkezes
    {
        public Hallgato Hallgato { get; set; }
        public Vizsgaidopont Vizsga { get; set; }
        public bool Megjelent { get; set; }
        public int Erdemjegy { get; set; }
        public DateTime Idopont { get; set; }
    }
}