namespace APBD_3;

public abstract class Kontener
{
    protected int wysokosc;
    protected double masaLadunku;
    protected int masaKontenera;
    protected int glebokosc;
    protected int numer;
    protected static int ktoryKontener = 1;
    protected int maksLadownosc;

    public Kontener(int wysokosc, int masaKontenera, int glebokosc, int maksLadownosc)
    {
        this.wysokosc = wysokosc;
        this.masaKontenera = masaKontenera;
        this.glebokosc = glebokosc;
        this.maksLadownosc = maksLadownosc;
        masaLadunku = 0;
        numer = ktoryKontener++;
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

    private int Numer
    {
        get => numer;
        set => numer = value;
    }

    public void Zaladuj(int waga)
    {
        if (masaLadunku + waga> MaksLadownosc)
                throw new OverfillException("Masa ladunku przekracza maksymalna pojemnosc! Nie zaladowano statku.");
            
        masaLadunku += waga;
            
    }

    public void Wyladuj()
    {
        masaLadunku = 0;
    }

    public void Wyladuj(double ile)
    {
        masaLadunku -= ile;
        if (masaLadunku < 0) masaLadunku = 0;
    }
}



public class OverfillException : Exception
{
    public OverfillException(string? message) : base(message)
    {
    }
}