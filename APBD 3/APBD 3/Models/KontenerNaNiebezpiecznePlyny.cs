namespace APBD_3;

public class KontenerNaNiebezpiecznePlyny : KontenerNaPlyny, IHazardNotifier
{
    public KontenerNaNiebezpiecznePlyny(int wysokosc, int masaKontenera, int glebokosc, int maksLadownosc) : base(wysokosc, masaKontenera, glebokosc, maksLadownosc)
    {
        rodzajKontenera = "CN";
        numer = "KON-"+rodzajKontenera+"-"+ktoryKontener++;
    }
    public void Zaladuj(int waga)
    {
        if (masaLadunku + waga > maksLadownosc * 0.5)
        {
            NotyfikacjaTekstowa("przekroczenie bezpiecznego ladunku", this.numer);
        }
        else
        {
            masaLadunku += waga;
        }
    }
}