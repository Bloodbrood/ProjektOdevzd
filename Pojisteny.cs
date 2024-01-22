using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOdevzdání
{
    //jednoduchá třída Pojištěný
    class Pojisteny
    {

        //vlastnosti pojišteného
        public string Jmeno { get; private set; }
        public string Prijmeni { get; private set; }
        public int Vek { get; private set; }
        public string TelefoniCislo { get; private set; }


        //konstruktor pro iniciaci objektu Pojištený
        public Pojisteny(string jmeno, string prijmeni, int vek, string telefoniCislo)
        {
            //přirazení Vlastností k atributum objektu
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            TelefoniCislo = telefoniCislo;

        }
        // navratová metoda pro pozdější výpis
        public override string ToString()
        {
            return $"Jméno: {Jmeno}, Příjmení: {Prijmeni}, Věk: {Vek}, Telefonní číslo: {TelefoniCislo}";
        }
    }
}
