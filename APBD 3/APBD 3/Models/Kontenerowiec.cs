using System.Text;

namespace APBD_3;

public class Kontenerowiec
{
    private List<Kontener> kontenery;
    private string nazwa;
    private double maksymalnaPredkosc;
    private int maksKontenery;
    // w tonach!!!!!!!!
    private double maksymalnyUdzwig;
    private double aktualnyUdzwig;

    public Kontenerowiec(List<Kontener> kontenery, string nazwa, double maksymalnaPredkosc, int maksKontenery, int maksymalnyUdzwig)
    {
        this.kontenery = kontenery;
        this.nazwa = nazwa;
        this.maksymalnaPredkosc = maksymalnaPredkosc;
        this.maksKontenery = maksKontenery;
        this.maksymalnyUdzwig = maksymalnyUdzwig;
        aktualnyUdzwig = 0;
    }

    public void Zaladuj(Kontener kontener)
    {
        
        if (aktualnyUdzwig + (kontener.MasaKontenera + kontener.MasaLadunku)*0.001 > maksymalnyUdzwig)
        {
            Console.WriteLine("Kontener przekroczyl maksymalny udzwig statku. " +
                              "Aktualnie statek moze uniesc jeszcze "+(maksymalnyUdzwig-aktualnyUdzwig)+" ton. " +
                              "Nie zaladowano kontenera");
        }else if(kontenery.Count > maksKontenery)
        {
            Console.WriteLine("Ten kontenerowiec nie moze pomiescic wiecej niz " + maksKontenery +
                              " kontenerow. Nie zaladowano kontenera.");
        }
        else
        {
            kontenery.Add(kontener);
            aktualnyUdzwig += (kontener.MasaKontenera + kontener.MasaLadunku) * 0.001;
            Console.WriteLine("Pomyslnie zaladowano kontener"+kontener.Numer+"!");
        }

    }
    
    
    public void ZaladujPrzygotowanie(Kontener kontener)
    {
        
        // if (aktualnyUdzwig + (kontener.MasaKontenera + kontener.MasaLadunku)*0.001 > maksymalnyUdzwig)
        // {
        //     Console.WriteLine("Kontener przekroczyl maksymalny udzwig statku. " +
        //                       "Aktualnie statek moze uniesc jeszcze "+(maksymalnyUdzwig-aktualnyUdzwig)+" ton. " +
        //                       "Nie zaladowano kontenera");
        //
        // }
        // else 
        // {
            kontenery.Add(kontener);
            aktualnyUdzwig += (kontener.MasaKontenera + kontener.MasaLadunku) * 0.001;
        //}
    }

    public int Zaladuj(List<Kontener> kontenery)
    {
        int ile = 0;
        foreach (var kontener in kontenery)
        {
            int staryRozmiar = this.kontenery.Count;
            Zaladuj(kontener);
            if (this.kontenery.Count==staryRozmiar) break;
            ile++;
        }
        Console.WriteLine("Pomyslnie dodano "+ile+" na "+kontenery.Count+" kontenerow.");
        return ile;
    }
    

    public Kontener Wyladuj(int ktory)
    {
        Kontener temp = kontenery[ktory];
        kontenery.RemoveAt(ktory);
        aktualnyUdzwig -= (temp.MasaKontenera + temp.MasaLadunku) * 0.001;
        return temp;
    }

    public List<Kontener> WyladujWszystkie()
    {
        List<Kontener> temp = kontenery;
        kontenery.Clear();
        aktualnyUdzwig = 0;
        return temp;
    }

    public Kontener Zamien(int ktory, Kontener kontener)
    {
        Kontener temp = Wyladuj(ktory);
        kontenery.Insert(ktory,kontener);
        return temp;
    }

    public string PokazKontenery()
    {
        StringBuilder sb = new StringBuilder("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n");
        for (int i = 0; i < kontenery.Count; i++)
        {
            sb.Append(i).Append(" -> ").Append(kontenery[i]).Append('\n');
        }

        sb.Append("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        return sb.ToString();
    }

    public override string ToString()
    {
        var s = "Kontenerowiec " + nazwa + " ma maksymalna predkosc "+maksymalnaPredkosc+" wezlow, " +
                   "aktualnie przewozi "+kontenery.Count + " kontenerow na maksymalne "+maksKontenery+" o wadze "+aktualnyUdzwig+"kg na maksymalne "+maksymalnyUdzwig+"kg.";
        //if(kontenery.Count > 0 ) return s + " Aktualnie przewozi nastepujace kontenery:" + PokazKontenery();
        return s;
    }

    public List<Kontener> Kontenery
    {
        get => kontenery;
        set => kontenery = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Nazwa
    {
        get => nazwa;
        set => nazwa = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double MaksymalnaPredkosc
    {
        get => maksymalnaPredkosc;
        set => maksymalnaPredkosc = value;
    }

    public int MaksKontenery
    {
        get => maksKontenery;
        set => maksKontenery = value;
    }

    public double MaksymalnyUdzwig
    {
        get => maksymalnyUdzwig;
        set => maksymalnyUdzwig = value;
    }

    public double AktualnyUdzwig
    {
        get => aktualnyUdzwig;
        set => aktualnyUdzwig = value;
    }
}