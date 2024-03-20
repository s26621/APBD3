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
                           "1  ->  stworz kontener i umiesc w magazynie;\n" +
                           "2  ->  usun kontener z magazynu;\n" +
                           "3  ->  zaladuj ladunek do kontenera;\n" +
                           "4  ->  zaladuj kontener na statek;\n" +
                           "5  ->  zaladuj wszystkie konenery na statek;\n" +
                           "6  ->  usun konener ze statku i umiesc w magazynie;\n" +
                           "7  ->  rozladuj kontener w magazynie;\n" +
                           "8  ->  zamien kontenery miejscami;\n" +
                           "9  ->  przenies kontener na inny statek;\n" +
                           "10 ->  wypisz informacje o danym kontenerze;\n" +
                           "11 ->  wypisz informacje o statku i jego ladunku;\n" +
                           "12 ->  wyswietl liste kontenerow w magazynie;\n" +
                           "13 ->  wyjdz z programu.";
        
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
                    if (magazynKontenerow.Count==0)
                    {
                        Console.WriteLine("W magazynie nie ma jeszcze zadnych kontenerow!");
                        break;
                    }
                    Console.WriteLine("Ktory z kontenerow chcesz usunac? Podaj indeks liczac od zera\n"+magazynKontenerow);
                    magazynKontenerow.RemoveAt(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Pomyslnie usunieto kontener! Zanieczyszczenie w morzu++");
                    break;
                }
                case "3":
                {
                    Console.WriteLine("Do ktorego z koneterow chcesz zaladowac? Podaj indeks liczac od zera.\n"+magazynKontenerow);
                    magazynKontenerow[int.Parse(Console.ReadLine())].Zaladuj();
                    break;
                }
                case "4":
                {
                    Console.WriteLine("Ktory kontener chcesz zaladowac? Podaj indeks liczac od zera.\n"+magazynKontenerow);
                    int indeksKontenera = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Na ktory statek chcesz zaladowac ten kontener? Podaj indeks liczac od zera.\n"+kontenerowce);
                    int indeksKontenerowca = int.Parse(Console.ReadLine());
                    
                    int staraWielkosc = kontenerowce[indeksKontenerowca].Kontenery.Count;
                    kontenerowce[indeksKontenerowca].Zaladuj(magazynKontenerow[indeksKontenera]);
                    if (kontenerowce[indeksKontenerowca].Kontenery.Count > staraWielkosc)
                        magazynKontenerow.RemoveAt(indeksKontenera);
                    break;
                }
                case "5":
                {
                    Console.WriteLine("Na ktory statek chcesz zaladowac kontenery? Podaj indeks liczac od zera.\n"+kontenerowce);
                    int indeksKontenerowca = int.Parse(Console.ReadLine());
                    int ile = kontenerowce[indeksKontenerowca].Zaladuj(magazynKontenerow);
                    if (ile > 0) magazynKontenerow.Slice(0, ile);
                    break;
                }
                case "6":
                {
                    Console.WriteLine("Z ktorego statku chcesz wyladowac kontener? Podaj indeks liczac od zera.\n"+kontenerowce);
                    int indeksKontenerowca = int.Parse(Console.ReadLine());
                    if (kontenerowce[indeksKontenerowca].Kontenery.Count == 0)
                    {
                        Console.WriteLine("Ten kontenerowiec nie ma jeszcze zadnych kontenerow!");
                        break;
                    }
                    Console.WriteLine("Ktory kontener chcesz wyladowac? Podaj indeks od zera.\n"+kontenerowce[indeksKontenerowca].Kontenery);
                    magazynKontenerow.Add(kontenerowce[indeksKontenerowca].Wyladuj(int.Parse(Console.ReadLine())));
                    Console.WriteLine("Pomyslnie usunieto kontener "+magazynKontenerow[magazynKontenerow.Count-1].Numer+" i umieszczono w magazynie!");
                    break;
                }
                case "7":
                {
                    Console.WriteLine("Ktory kontener chcesz rozladowac? Podaj indeks liczac od zera.\n"+magazynKontenerow);
                    Kontener kontener = magazynKontenerow[int.Parse(Console.ReadLine())];
                    Console.WriteLine("Ile ladunku chcesz wyladowac? Aktualnie ten kontener ma "+kontener.MasaLadunku+"kg ladunku. " +
                                      "Wpisz -1, aby rozladowac wszystko");
                    int ile = int.Parse(Console.ReadLine());
                    if(ile == -1) kontener.Wyladuj();
                    else kontener.Wyladuj(ile);
                    Console.WriteLine("Pomyslnie wyladowano kontener!");
                    break;
                }
                case "8":
                {
                    Console.WriteLine("Prosze podac indeks pierwszego kontenerowca do zamiany, liczac od zera.\n"+kontenerowce);
                    Kontenerowiec statek1 = kontenerowce[int.Parse(Console.ReadLine())];
                    int indeks1;
                    if (statek1.Kontenery.Count == 0)
                    {
                        Console.WriteLine("Ten statek nie ma jeszcze zadnych kontenerow, wiec drugi kontener bedzie na indeksie 0.");
                        indeks1 = 0;
                        
                    }
                    else{
                        Console.WriteLine("Ktory z kontenerow chcesz zamienic? Podaj indeks liczac od zera.\n");
                        indeks1 = int.Parse(Console.ReadLine());
                        
                    }
                    Kontener? kontener1 = statek1.Wyladuj(indeks1);
                    Console.WriteLine("Prosze podac indeks drugiego kontenerowca do zamiany, liczac od zera.\n");
                    Kontenerowiec statek2 = kontenerowce[int.Parse(Console.ReadLine())];
                    
                    int indeks2;
                    if (statek2.Kontenery.Count == 0)
                    {
                        Console.WriteLine("Ten statek nie ma jeszcze zadnych kontenerow, wiec drugi kontener bedzie na indeksie 0.");
                        indeks2 = 0;
                        
                    }
                    else{
                        Console.WriteLine("Ktory z kontenerow chcesz zamienic? Podaj indeks liczac od zera.\n");
                        indeks2 = int.Parse(Console.ReadLine());
                        
                    } 
                    Kontener? kontener2 = statek2.Wyladuj(indeks2);
                    statek1.Kontenery.Insert(indeks1,kontener2);
                    statek2.Kontenery.Insert(indeks2,kontener1);
                    Console.WriteLine("Pomyslnie zamieniono kontenery miejscami!");
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
                    Console.WriteLine("Prosze podac rodzaj produktu ktore moze przewozic kontener z listy: \n"+
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
    
    
    
}
/*
-> jak ładujemuy kontenery to nie musimy ich przestawiać, tylko masa ma się zgadzać
-> termin do następnych zajęć
-> repozytorium na githubie
*/