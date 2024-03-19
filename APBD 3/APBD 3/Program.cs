using APBD_3;
using Microsoft.VisualBasic.CompilerServices;

public class Program{
    public static void Main(string[] args)
    {
        Kontenerowiec[] kontenerowce = new Kontenerowiec[3];
        kontenerowce[0] = new Kontenerowiec(new List<Kontener>(), "Ksiezniczka", 20, 5, 17190);
        kontenerowce[1] = new Kontenerowiec(new List<Kontener>(), "Evergreen", 5, 20, 45235);
        kontenerowce[2] = new Kontenerowiec(new List<Kontener>(), "Syrenka", 15, 10, 28190);

        List<Kontener> magazynKontenerow = new List<Kontener>();

        string dostepnePolecenia = "Oto dostepne polecenia:\n" +
                           "1  ->  stworz kontener;\n" +
                           "2  ->  usun kontener;\n" +
                           "3  ->  zaladuj ladunek do kontenera;\n" +
                           "4  ->  zaladuj kontener na statek;\n" +
                           "5  ->  zaladuj wszystkie konenery na statek;\n" +
                           "6  ->  usun konener ze statku;\n" +
                           "7  ->  rozladuj kontener;\n" +
                           "8  ->  zamien kontenery;\n" +
                           "9  ->  przenies kontener na inny statek;\n" +
                           "10 ->  wypisz informacje o danym kontenerze;\n" +
                           "11 ->  wypisz informacje o statku i jego ladunku;\n" +
                           "12 ->  wyjdz z programu.";
        
        Console.WriteLine("Witamy w cokolwiek to jest! Masz do dyspozycji trzy kontenerowce: "+kontenerowce.ToString());
        string polecenie;
        do
        {
            Console.WriteLine(dostepnePolecenia);
            polecenie = Console.ReadLine();
            switch (polecenie)
            {
                case "1":
                {
                    magazynKontenerow.Add(StworzKontener());
                    Console.WriteLine("Pomysnie dodano nowy kontener!");
                    break;
                }
                case "2":
                {
                    Console.WriteLine("Ktory z kontenerow chcesz usunac?\n"+magazynKontenerow);
                    magazynKontenerow.RemoveAt(int.Parse(Console.ReadLine()));
                    //jeszcze nie koniec
                    break;
                }
                default:
                {
                    Console.WriteLine("Nie rozpoznano polecenia, prosze wpisac ponownie.");
                    break;
                }
            }
        } while (polecenie != "12");


    }

    public static Kontener StworzKontener()
    {
        Console.WriteLine("Prosze podac parametry nowego kontrolera po przechinku (bez spacji) w nastepujacej kolejnosci: " +
                          "wysokosc (w centymetrach), waga wlasna (w kilogramach), glebokosc (w centymetrach), ladownosc (w kilogramach)");
        string[] parametry = Console.ReadLine().Split(",");
        
        Console.WriteLine("Teraz wyberz typ kontenera, wpisujac odpowiednia cyfre: \n" +
                          "1 -> kontenerowiec na plyny" +
                          "2 -> kontenerowiec na gaz" +
                          "3 -> kontenerowiec chlodniczy");
        string wybor;
        do
        {
            wybor = Console.ReadLine();
            switch (wybor)
            {
                case "1" : return new KontenerNaPlyny(int.Parse(parametry[0]), int.Parse(parametry[1]),
                        int.Parse(parametry[2]), int.Parse(parametry[3]));
                case "2":
                {
                    Console.WriteLine("Prosze podac cisnienie w srodku kontenera (w atmosferach):");
                    return new KontenerNaGaz(int.Parse(parametry[0]), int.Parse(parametry[1]),
                        int.Parse(parametry[2]), int.Parse(parametry[3]),Int32.Parse(Console.ReadLine()));
                }
                case "3":
                {
                    Console.WriteLine("Prosze podac rodzaj produktu do zaladowania z listy: \n"+
                                      "Bananas, Chocolate, Fish, Meat, Ice cream, Frozen pizza, Cheese, Sausages, Butter, Eggs");
                    string rodzajProduktu = Console.ReadLine();
                    while (!KontenerChlodniczy.listaTemperatur.ContainsKey(rodzajProduktu))
                    {
                        Console.WriteLine("Nie znaleziono rodzaju o podanej nazwie. Prosze wpisac ponownie.");
                        rodzajProduktu = Console.ReadLine();
                    }
                    
                    
                    
                    Console.WriteLine("Prosze podac temperature w kontenerze. Minimalna temperatura dla produktu "+rodzajProduktu+
                                      " wynosi "+KontenerChlodniczy.listaTemperatur[rodzajProduktu]);
                    double temperatura = Double.Parse(Console.ReadLine());
                    if (temperatura < KontenerChlodniczy.listaTemperatur[rodzajProduktu])
                    {
                        Console.WriteLine("Podano za niska temperature. Ustawiam temperature na wartosc minimalna.");
                        temperatura = KontenerChlodniczy.listaTemperatur[rodzajProduktu];
                    }

                    return new KontenerChlodniczy(int.Parse(parametry[0]), int.Parse(parametry[1]),
                        int.Parse(parametry[2]), int.Parse(parametry[3]), temperatura, rodzajProduktu);
                }
                default:
                {
                    Console.WriteLine("Nie rozpoznano polecenia, prosze sprobowac ponownie.");
                    break;
                }
            }
        } while (true);
    }

    public static void ZaladujDoKontenera(Kontener kontener)
    {
        Console.WriteLine("Ile ladunku chcesz zaladowac? Aktualnie ten kontener moze pomiescic jeszcze "+(kontener.MaksLadownosc-kontener.MasaLadunku)+"kg.");
        kontener.Zaladuj(int.Parse(Console.ReadLine()));
    }
    
    
}
/*
-> jak ładujemuy kontenery to nie musimy ich przestawiać, tylko masa ma się zgadzać
-> termin do następnych zajęć
-> repozytorium na githubie
*/