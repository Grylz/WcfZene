using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeneszamok.Models
{
    public class Eloado
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Nemzetiseg { get; set; }
        public bool Szolo { get; set; }


        public override string ToString()
        {
            return $"{Id} Név: {Nev} ({Nemzetiseg})";
        }

        public Eloado(){}
    }
}
