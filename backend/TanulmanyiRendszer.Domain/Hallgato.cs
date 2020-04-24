using System;
using System.Collections.Generic;
using System.Text;

namespace TanulmanyiRendszer.Domain
{
    public class Hallgato
    {
        public string Kar { get; set; }
        public string Szak { get; set; }
        public KepzesiSzint Kepzes { get; set; }
    }
}
