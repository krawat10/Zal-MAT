using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Przedmioty
    {
        public enum EnumPrzedmioty { Waluta, Surowiec }
        public struct CenaJednostkowa { }
        public double Ilosc { get; set; }
        public double Cena { get; set; }


        public Przedmioty()
        { }

        public Przedmioty (double _ilosc)
        {
            this.Ilosc = _ilosc;        
        }

    }
}
