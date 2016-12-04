using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    

    public class Waluty : Przedmioty, IPrzedmioty
    {
        public static new double[] CenaJednostkowa = { 30.2, 23.2, 21.2 }; //odpowiednio dla EUR, USD, CHF
        public enum EnumWaluty { Euro, Dollar, Frank } 
        public enum Skrot { EUR, USD, CHF }
        public EnumWaluty ChooseWaluta { get; set; }
        public Skrot ChooseSkrot { get; set; }


        public Waluty() { }
        
        public Waluty(double _ilosc, EnumWaluty _ChooseWaluta, Skrot _ChooseSkrot) : base(_ilosc)
        {            
            this.ChooseWaluta = _ChooseWaluta;
            this.ChooseSkrot = _ChooseSkrot;
            this.Cena = _ilosc * CenaJednostkowa[(int)_ChooseWaluta]; //po wybranej walucie wybierze odpowiednią Cene Jednostkową
            this.Ilosc = _ilosc;
        }

    }
}
