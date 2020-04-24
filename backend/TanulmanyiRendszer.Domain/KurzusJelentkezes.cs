using System;
using System.Collections.Generic;
using System.Text;

namespace TanulmanyiRendszer.Domain
{
    public class KurzusJelentkezes
    {
        public Hallgato Hallgato { get; set; }
        public Kurzus Kurzus { get; set; }
        public int Erdemjegy { get; set; }
        public bool KreditetSzerzett { get; set; }
        public DateTime Idopont { get; set; }
    }
}