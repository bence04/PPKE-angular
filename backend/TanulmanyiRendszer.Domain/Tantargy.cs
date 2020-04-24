using System;
using System.Collections.Generic;
using System.Text;

namespace TanulmanyiRendszer.Domain
{
    public class Tantargy
    {
        public string Nev { get; set; }
        public string Kar { get; set; }
        public string Szak { get; set; }
        public string Tanszek { get; set; }
        public Oktato Oktato { get; set; }
        public int KreditSzam { get; set; }
        public TargyTipus Tipus { get; set; }
    }
}