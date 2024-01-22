namespace ProjektOdevzdání
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_____________________________________");
            Console.WriteLine();
            Console.WriteLine("\n \tEvidence pojistěných\n");
            Console.WriteLine("_____________________________________");

            // Vytvoření instance SpravcePojistenych pro správu seznamu pojistěných
            SpravcePojistenych spravcePojistenych = new SpravcePojistenych();

            int volba;

            do
            {
                Console.WriteLine();
                Console.WriteLine("\tProsím Zvolte akci: ");
                Console.WriteLine();
                Console.WriteLine("1.  Přidání nového pojištěného: ");
                Console.WriteLine("2.  Výpis všech pojištěných: ");
                Console.WriteLine("3.  Vyhledat pojistěného: ");
                Console.WriteLine("4.  Ukončení aplikace: ");

                if (!int.TryParse(Console.ReadLine(), out volba))
                {
                    Console.WriteLine("Neplatný vstup. Zadejte číslo volby.");
                    continue;
                }

                switch (volba)
                {
                    // Přidání nového pojištěného
                    case 1:
                        Console.WriteLine("Zvolili jste možnost pro přidání nového pojistěného: ");

                        // Načtení a validace jména
                        Console.WriteLine("Zadejte prosím křestní jméno: ");
                        string jmeno = Console.ReadLine().Trim();
                        if (string.IsNullOrEmpty(jmeno))
                        {
                            Console.WriteLine("Neplatné jméno. Zkuste to znovu.");
                            continue;
                        }

                        // Načtení a validace příjmení
                        Console.WriteLine("Zadejte prosím příjmení:");
                        string prijmeni = Console.ReadLine().Trim();
                        if (string.IsNullOrEmpty(prijmeni))
                        {
                            Console.WriteLine("Neplatné Příjmení. Zkuste to znovu.");
                            continue;
                        }

                        // Načtení a validace věku
                        Console.WriteLine("Zadejte prosím věk:");
                        string vekString = Console.ReadLine().Trim();
                        if (string.IsNullOrEmpty(vekString) || !int.TryParse(vekString, out int vek) || vek < 0)
                        {
                            Console.WriteLine("Neplatný věk. Zadejte prosím platné číslo.");
                            continue;
                        }

                        // Načtení a validace telefonního čísla
                        Console.WriteLine("Zadejte prosím telefonní číslo: (např. 775422883)");
                        string telefoniCislo = Console.ReadLine().Trim();
                        if (telefoniCislo.Length != 9 || !int.TryParse(telefoniCislo, out _))
                        {
                            Console.WriteLine("Neplatné zadání, zkontrolujte, zda jste dodrželi zadaný formát " + '\n' +
                                              "(je potřeba zadat devítimístné telefonní číslo bez předčíslí a mezer).");
                            continue;
                        }

                        Console.WriteLine("\nData byla uložena, Vyberte další volbu.\n");

                        // Přidání nového pojištěného do správce
                        spravcePojistenych.PridejPojisteneho(jmeno, prijmeni, vek, telefoniCislo);
                        break;

                    // Výpis všech pojištěných
                    case 2:
                        var vsechnyPojistene = spravcePojistenych.ZiskejVsechnyPojistene();
                        Console.WriteLine("Seznam všech pojistenych:");
                        foreach (var pojisteny in vsechnyPojistene)
                        {
                            Console.WriteLine($" {pojisteny}");
                        }
                        break;

                    // Vyhledání pojištěného podle jména a příjmení
                    case 3:
                        Console.WriteLine("Zadejte křestní jméno pojistěného:");
                        string hledaneJmeno = Console.ReadLine();
                        Console.WriteLine("Zadejte Příjmení:");
                        string hledanePrijmeni = Console.ReadLine();

                        var nalezeni = spravcePojistenych.NajdiPojisteneho(hledaneJmeno, hledanePrijmeni);

                        if (nalezeni.Count > 0)
                        {
                            Console.WriteLine("Nalezení pojištění:");

                            foreach (var nalezenyPojisteny in nalezeni)
                            {
                                Console.WriteLine($" {nalezenyPojisteny}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Pojištěný nebyl nalezen.");
                        }
                        break;


                    // Ukončení aplikace
                    case 4:
                        Console.WriteLine("Ukončuji program.");
                        break;

                    // Neznámá volba
                    default:
                        Console.WriteLine("Neznámá volba. Zadejte platnou volbu.");
                        break;
                }

            } while (volba != 4);
        }
    }
}


