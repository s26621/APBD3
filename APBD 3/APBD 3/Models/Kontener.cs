namespace APBD_3;

public abstract class Kontener
{
    protected int wysokosc;
    protected double masaLadunku;
    protected int masaKontenera;
    protected int glebokosc;
    protected string numer;
    protected static int ktoryKontener = 1;
    protected int maksLadownosc;
    protected string rodzajKontenera;

    public Kontener(int wysokosc, int masaKontenera, int glebokosc, int maksLadownosc)
    {
        this.wysokosc = wysokosc;
        this.masaKontenera = masaKontenera;
        this.glebokosc = glebokosc;
        this.maksLadownosc = maksLadownosc;
        masaLadunku = 0;
        numer = "KON-"+rodzajKontenera+"-"+ktoryKontener++;
    }

    public int Wysokosc
    {
        get => wysokosc;
        set => wysokosc = value;
    }

    public int MasaKontenera
    {
        get => masaKontenera;
        set => masaKontenera = value;
    }

    public int Glebokosc
    {
        get => glebokosc;
        set => glebokosc = value;
    }

    public int MaksLadownosc
    {
        get => maksLadownosc;
        set => maksLadownosc = value;
    }

 

    public double MasaLadunku
    {
        get => masaLadunku;
        set => masaLadunku = value;
    }

    public string Numer
    {
        get => numer;
        set => numer = value;
    }

    public void Zaladuj()
    {
        Console.WriteLine("Ile kg ladunku chcesz zaladowac? Aktualnie ten kontener moze pomiescic jeszcze"+(MaksLadownosc-MasaLadunku)+"kg.");
        int waga = int.Parse(Console.ReadLine());
        if (masaLadunku + waga> MaksLadownosc)
                throw new OverfillException("Masa ladunku przekracza maksymalna pojemnosc! Nie zaladowano kontenera.");
            
        masaLadunku += waga;
        Console.WriteLine("Pomyslnie zaladowano kontener!");
    }

    public void Wyladuj()
    {
        masaLadunku = 0;
        Console.WriteLine("Pomyslnie wyladowano ladunek!");
    }

    public void Wyladuj(double ile)
    {
        masaLadunku -= ile;
        if (masaLadunku < 0)
        {
            Console.WriteLine("Podano za duza liczbe! Kontener zostanie wyladowany do zera");
            masaLadunku = 0;
        }
    }

    public override string ToString()
    {
        return "Kontener " + numer + " o wysokosci "+wysokosc+
               "cm i glebokosci "+glebokosc+"cm. Ladunek = "+masaLadunku+"\\"+maksLadownosc+"kg";
    }
}



public class OverfillException : Exception
{
    public OverfillException(string? message) : base(message)
    {
    }
}