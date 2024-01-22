using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOdevzdání
{
    class SpravcePojistenych
    {
        // Kolekce pro uchování seznamu pojištěných osob
        private List<Pojisteny> seznamPojistenych;

        // Konstruktor třídy, inicializace seznamu
        public SpravcePojistenych()
        {
            seznamPojistenych = new List<Pojisteny>();
        }

        // Metoda pro přidání nového pojištěného do seznamu
        public void PridejPojisteneho(string jmeno, string prijmeni, int vek, string telefoniCislo)
        {
            // Vytvoření nové instance třídy Pojisteny
            Pojisteny pojisteny = new Pojisteny(jmeno, prijmeni, vek, telefoniCislo);
            // Přidání pojištěného do seznamu
            seznamPojistenych.Add(pojisteny);
        }

        // Metoda pro získání všech pojištěných osob jako List
        public List<Pojisteny> ZiskejVsechnyPojistene()
        {
            // Vytvoření nového Listu, který obsahuje kopii seznamu pojištěných
            return new List<Pojisteny>(seznamPojistenych);
        }

        // Metoda pro vyhledání pojištěných osob podle jména a příjmení
        public List<Pojisteny> NajdiPojisteneho(string hledaneJmeno, string hledanePrijmeni)
        {
            if (string.IsNullOrWhiteSpace(hledaneJmeno) && string.IsNullOrWhiteSpace(hledanePrijmeni))
            {
                Console.WriteLine("Chyba: Zadáno neplatné jméno a příjmení.");
                return new List<Pojisteny>();
            }

            List<Pojisteny> nalezeniPojisteni = seznamPojistenych
                .Where(p => string.IsNullOrWhiteSpace(hledaneJmeno) || p.Jmeno.ToLower().Contains(hledaneJmeno.ToLower()))
                .Where(p => string.IsNullOrWhiteSpace(hledanePrijmeni) || p.Prijmeni.ToLower().Contains(hledanePrijmeni.ToLower()))
                .ToList();

            return nalezeniPojisteni;
        }
    }
}