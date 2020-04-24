using System;
using System.Collections.Generic;
using System.Text;

namespace TanulmanyiRendszer.Domain
{
    public class Vizsgaidopont
    {
        public Kurzus Kurzus { get; set; }
        public DateTime Idopont { get; set; }
        public string Helyszin { get; set; }
        public int Limit { get; set; }
    }
}