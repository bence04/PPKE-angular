using System;
using System.Collections.Generic;
using System.Text;

namespace TanulmanyiRendszer.Domain
{
    public class Oktato
    {
        public string Kar { get; set; }
        public string Tanszek { get; set; }
        public OktatoiFokozat Fokozat { get; set; }
    }
}
