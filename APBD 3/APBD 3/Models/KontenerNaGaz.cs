namespace APBD_3;

public class KontenerNaGaz : Kontener, IHazardNotifier
{
    private int _cisnienie;

    public KontenerNaGaz(int wysokosc, int masaKontenera, int glebokosc, int maksLadownosc, int cisnienie) : base(wysokosc, masaKontenera, glebokosc, maksLadownosc)
    {
        this._cisnienie = cisnienie;
        rodzajKontenera = "G";
        numer = "KON-"+rodzajKontenera+"-"+ktoryKontener++;
    }

    public int Cisnienie
    {
        get => _cisnienie;
        set => _cisnienie = value;
    }

    public void Wyladuj()
    {
        this.masaLadunku = maksLadownosc * 0.05;
        Console.WriteLine("Trzeba bylo zostawic 5% ze wzgledu na " +
                          "reguly bezpieczenstwa dotyczace kontenerow na gaz.");
    }

    public void Wyladuj(double ile)
    {
        if (masaLadunku - ile < masaLadunku * 0.05)
            NotyfikacjaTekstowa("proba wyladowania gazu ponad norme", numer);
    }
    
    public string NotyfikacjaTekstowa(string typSytuacji, string numer)
    {
        return "Zaszla niebezpieczna sytuacja: " + typSytuacji + " w kontenerze " + numer+". Operacja nie powiodla sie.";
    }
}