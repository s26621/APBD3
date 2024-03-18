namespace APBD_3;

public class KontenerNaPlyny : Kontener, IHazardNotifier
{
    public KontenerNaPlyny(int wysokosc, int masaKontenera, int glebokosc, int maksLadownosc) : base(wysokosc, masaKontenera, glebokosc, maksLadownosc)
    {
    }

    public void Zaladuj(int waga)
    {
        if (masaLadunku + waga > maksLadownosc * 0.9)
        {
            NotyfikacjaTekstowa("przekroczenie bezpiecznego ladunku", this.numer);
        }
        else
        {
            masaLadunku += waga;
        }
    }

    public string NotyfikacjaTekstowa(string typSytuacji, int numer)
    {
        return "Zaszla niebezpieczna sytuacja: " + typSytuacji + " w kontenerze numer " + numer;
    }
}