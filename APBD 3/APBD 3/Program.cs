using System.Text;
using APBD_3;
using Microsoft.VisualBasic.CompilerServices;

public class Program
{
    public static Kontenerowiec[] kontenerowce;

    public static List<Kontener> magazynKontenerow;
    public static void Main(string[] args)
    {
        kontenerowce = new Kontenerowiec[3];
        kontenerowce[0] = new Kontenerowiec(new List<Kontener>(), "Ksiezniczka", 20, 5, 17190);
        kontenerowce[1] = new Kontenerowiec(new List<Kontener>(), "Evergreen", 5, 20, 45235);
        kontenerowce[2] = new Kontenerowiec(new List<Kontener>(), "Syrenka", 15, 10, 28190);

        magazynKontenerow = new List<Kontener>();

        // string dostepnePolecenia = "Oto dostepne polecenia:\n" +
        //                    "1  ->  stworz kontener i umiesc w magazynie;\n" +
        //                    "2  ->  usun kontener z magazynu;\n" +
        //                    "3  ->  zaladuj ladunek do kontenera;\n" +
        //                    "4  ->  zaladuj kontener na statek;\n" +
        //                    "5  ->  zaladuj wszystkie konenery na statek;\n" +
        //                    "6  ->  usun konener ze statku i umiesc w magazynie;\n" +
        //                    "7  ->  rozladuj kontener w magazynie;\n" +
        //                    "8  ->  zamien kontenery miejscami;\n" +
        //                    "9  ->  przenies kontener na inny statek;\n" +
        //                    "10 ->  wypisz informacje o statkach;\n" +
        //                    "11 ->  wyswietl liste kontenerow w magazynie;\n" +
        //                    "12 ->  wyjdz z programu.";
        //

        string dostepnePolecenia1 = "Oto dostepne polecenia:\n" +
                                   "1  ->  stworz kontener i umiesc w magazynie;\n" +
                                   "2  ->  usun kontener z magazynu;\n" +
                                   "3  ->  zaladuj ladunek do kontenera;";
        string dostepnePolecenia2 = "4  ->  zaladuj kontener na statek;" +
                                    "5  ->  zaladuj wszystkie konenery na statek;\n" +
                                    "6  ->  usun konener ze statku i umiesc w magazynie";
        string dostepnePolecenia3 = "7  ->  rozladuj kontener w magazynie;\n" +
                                    "8  ->  zamien kontenery miejscami;\n" +
                                    "9  ->  przenies kontener na inny statek;";
        string dostepnePolecenia4 = "10 ->  wypisz informacje o statku;\n" +
                                    "11 ->  wyswietl liste kontenerow w magazynie;\n" +
                                    "12 ->  wyjdz z programu.";
        
                                    Console.WriteLine("Witamy w cokolwiek to jest! Masz do dyspozycji trzy kontenerowce: \n"+PokazKontenerowce());
        string polecenie;
        do
        {
            Console.WriteLine(dostepnePolecenia1);
            Console.WriteLine(dostepnePolecenia2);
            Console.WriteLine(dostepnePolecenia3);
            Console.WriteLine(dostepnePolecenia4);
            
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
                    Console.WriteLine("Podaj indeks kontenera, ktory chcesz usunac.\n"+PokazMagazyn());
                    magazynKontenerow.RemoveAt(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Pomyslnie usunieto kontener! Zanieczyszczenie w morzu++");
                    break;
                }
                case "3":
                {
                    Console.WriteLine("Podaj indeks kontenera, ktory chcesz zaladowac.\n"+PokazMagazyn());
                    try
                    {
                        magazynKontenerow[int.Parse(Console.ReadLine())].Zaladuj();

                    }
                    catch (OverfillException e)
                    {
                        Console.WriteLine(e.Message+ " Operacja nie ppwiodla sie.");
                    }
                    break;
                }
                case "4":
                {
                    Console.WriteLine("Podaj indeks kontenera, ktory chcesz zaladowac.\n"+PokazMagazyn());
                    int indeksKontenera = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine("Podaj indeks statku, na ktory chcesz zaladowac ten kontener.\n"+PokazKontenerowce());
                    int indeksKontenerowca = int.Parse(Console.ReadLine());
                    
                    int staraWielkosc = kontenerowce[indeksKontenerowca].Kontenery.Count;
                    kontenerowce[indeksKontenerowca].Zaladuj(magazynKontenerow[indeksKontenera]);
                    if (kontenerowce[indeksKontenerowca].Kontenery.Count > staraWielkosc)
                        magazynKontenerow.RemoveAt(indeksKontenera);
                    break;
                }
                case "5":
                {
                    Console.WriteLine("Podaj indeks statku, na ktory chcesz zaladowac te kontenery.\n"+PokazKontenerowce());
                    int indeksKontenerowca = int.Parse(Console.ReadLine());
                    int ile = kontenerowce[indeksKontenerowca].Zaladuj(magazynKontenerow);
                    if (ile > 0) magazynKontenerow.Slice(0, ile);
                    break;
                }
                case "6":
                {
                    Console.WriteLine("Podaj indeks statku, z ktorego chcesz zaladowac kontener.\n"+PokazKontenerowce());
                    int indeksKontenerowca = int.Parse(Console.ReadLine());
                    if (kontenerowce[indeksKontenerowca].Kontenery.Count == 0)
                    {
                        Console.WriteLine("Ten kontenerowiec nie ma jeszcze zadnych kontenerow!");
                        break;
                    }
                    Console.WriteLine("Podaj indeks kontenera, ktory chcesz wyladowac.\n"+kontenerowce[indeksKontenerowca].PokazKontenery());
                    magazynKontenerow.Add(kontenerowce[indeksKontenerowca].Wyladuj(int.Parse(Console.ReadLine())));
                    Console.WriteLine("Pomyslnie usunieto kontener "+magazynKontenerow[magazynKontenerow.Count-1].Numer+" i umieszczono w magazynie!");
                    break;
                }
                case "7":
                {
                    Console.WriteLine("Podaj indeks kontenera, ktory chcesz rozladowac.\n"+PokazMagazyn());
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
                    Console.WriteLine("Prosze podac indeks pierwszego kontenerowca do zamiany.\n"+PokazKontenerowce());
                    Kontenerowiec statek1 = kontenerowce[int.Parse(Console.ReadLine())];
                    int indeks1;
                    if (statek1.Kontenery.Count == 0)
                    {
                        Console.WriteLine("Ten statek nie ma jeszcze zadnych kontenerow, wiec nowy kontener bedzie na indeksie 0.");
                        indeks1 = 0;
                        
                    }
                    else{
                        Console.WriteLine("Prosze podac indeks kontenera, ktory chcesz zamienic.\n"+statek1.PokazKontenery());
                        indeks1 = int.Parse(Console.ReadLine());
                        
                    }
                    Kontener? kontener1 = statek1.Wyladuj(indeks1);
                    Console.WriteLine("Prosze podac indeks drugiego kontenerowca do zamiany.\n"+PokazKontenerowce());
                    Kontenerowiec statek2 = kontenerowce[int.Parse(Console.ReadLine())];
                    
                    int indeks2;
                    if (statek2.Kontenery.Count == 0)
                    {
                        Console.WriteLine("Ten statek nie ma jeszcze zadnych kontenerow, wiec drugi kontener bedzie na indeksie 0.");
                        indeks2 = 0;
                        
                    }
                    else{
                        Console.WriteLine("Prosze podac indeks drugiego kontenera do zamiany.\n"+statek2.PokazKontenery());
                        indeks2 = int.Parse(Console.ReadLine());
                        
                    } 
                    Kontener? kontener2 = statek2.Wyladuj(indeks2);
                    statek1.Kontenery.Insert(indeks1,kontener2);
                    statek2.Kontenery.Insert(indeks2,kontener1);
                    Console.WriteLine("Pomyslnie zamieniono kontenery miejscami!");
                    break;
                }
                case "9":
                {
                    Console.WriteLine("Prosze podac indeks kontenerowca, z ktorego ma byc przeniesiony kontener."+PokazKontenerowce());
                    Kontenerowiec kontenerowiecZ = kontenerowce[int.Parse(Console.ReadLine())];
                    if (kontenerowiecZ.Kontenery.Count == 0)
                    {
                        Console.WriteLine("Ten kontener nie ma zadnych kontenerow! Operacja nie powiodla sie.");
                        break;
                    }
                    Console.WriteLine("Prosze podac indeks kontenera, ktory chcesz przeniesc.\n"+kontenerowiecZ.PokazKontenery());
                    int indeksKontenera = int.Parse(Console.ReadLine());
                    Kontener kontener = kontenerowiecZ.Kontenery[indeksKontenera];
                    
                    Console.WriteLine("Prosze podac indeks kontenerowca, na ktory chcesz przeniesc ten kontener.\n"+PokazKontenerowce());
                    Kontenerowiec kontenerowiecDo = kontenerowce[int.Parse(Console.ReadLine())];
                    if (kontenerowiecDo.Kontenery.Count == kontenerowiecDo.MaksKontenery)
                    {
                        Console.WriteLine("Ten kontener ma juz maksymalna liczbe konenterow! Operacja nie powiodla sie.");
                        break;
                    }
                    try
                    {
                        kontenerowiecDo.Zaladuj(kontener);
                        kontenerowiecZ.Kontenery.RemoveAt(indeksKontenera);
                        Console.WriteLine("Pomyslnie przeniesiono kontener!");
                    }
                    catch (OverfillException e)
                    {
                        Console.WriteLine(e.Message+" Operacja nie powiodla sie.");
                    }
                    break;
                }
                case "10":
                {
                    Console.WriteLine("Prosze podac indeks kontenerowca, ktorego informacje chcesz sprawdzic.\n"+PokazKontenerowce());
                    Kontenerowiec kontenerowiec = kontenerowce[int.Parse(Console.ReadLine())];
                    Console.WriteLine(kontenerowiec);
                    if (kontenerowiec.Kontenery.Count > 0 ) Console.WriteLine("Aktualnie przewozi nastepujace kontenery:" + kontenerowiec.PokazKontenery());                    break;
                }
                case "11":
                {
                    Console.WriteLine(PokazMagazyn());
                    break;
                }
                case "12": break;
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
        Console.WriteLine("Prosze podac parametry nowego kontrolera po przecinku (bez spacji) w nastepujacej kolejnosci: " +
                          "wysokosc (w centymetrach), waga wlasna (w kilogramach), glebokosc (w centymetrach), ladownosc (w kilogramach)");
        string[] parametry = Console.ReadLine().Split(",");
        
        Console.WriteLine("Teraz wyberz typ kontenera, wpisujac odpowiednia cyfre: \n" +
                          "1 -> kontenerowiec na plyny;\n" +
                          "2 -> kontenerowiec na gaz;\n" +
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

    public static string PokazKontenerowce()
    {
        StringBuilder sb = new StringBuilder("\n____________________________________________\n");
        for (int i = 0; i < kontenerowce.Length; i++)
        {
            sb.Append(i +"-> "+kontenerowce[i]+'\n'+'\n');
        }
        sb.Append("_______________________________________________\n");
        return sb.ToString();
    }

    public static string PokazMagazyn()
    {
        StringBuilder sb = new StringBuilder("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
        for (int i = 0; i < magazynKontenerow.Count; i++)
        {
            sb.Append(i).Append(" -> ").Append(magazynKontenerow[i]).Append('\n');
        }

        sb.Append("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
        return sb.ToString();
    }
    
}
/*
-> jak ładujemuy kontenery to nie musimy ich przestawiać, tylko masa ma się zgadzać
-> termin do następnych zajęć
-> repozytorium na githubie
*/