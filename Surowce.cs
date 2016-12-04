using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{


    public class Surowce : Przedmioty, IPrzedmioty
    {
        public enum EnumSurowce { Ropa , Gaz, Koks }
        public static new double[] CenaJednostkowa = { 2.8, 2.2, 1.2 };        
        public static string MetrSzescienny = string.Format("m{0}", 3.ToSuperscriptNumber());
        public static string Kilogram = "kg";
        public EnumSurowce ChooseSurowce  { get; set; } //Tu wybiera nazwe surowca
        public string ChooseJednostka { get; set; } //Tu jego jednostke


        public Surowce()
        { }
        //Konstruktor, nie podaje ceny surowca, bo automatycznie oblicza go z z działania CenaJednostkowa*Ilość
        public Surowce(double _ilosc, EnumSurowce _ChooseSurowce, string _ChooseJednostka) : base(_ilosc)
        {
            this.ChooseSurowce = _ChooseSurowce;
            this.ChooseJednostka = _ChooseJednostka;
            this.Cena = _ilosc * CenaJednostkowa[(int)_ChooseSurowce];
            this.Ilosc = _ilosc;
        }

    }
}
