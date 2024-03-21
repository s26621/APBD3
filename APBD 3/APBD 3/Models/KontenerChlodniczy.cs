namespace APBD_3;

public class KontenerChlodniczy : Kontener
{
    public static Dictionary<string, double> listaTemperatur = new Dictionary<string, double>()
    {
        {"Banany",13.3}, {"Czekolada",18}, {"Ryby", 2}, 
        {"Mieso",-15}, {"Lody", -18}, {"Mrozona pizza", -30},
        {"Ser", 7.2},{"Kielbasa", 5}, {"Maslo", 20.5}, {"Jajka", 19}
    };
  
    private string rodzajProduktu;
    private double temperatura;

    public KontenerChlodniczy(int wysokosc, int masaKontenera, int glebokosc, int maksLadownosc, double temperatura, string rodzajProduktu) : base(wysokosc, masaKontenera, glebokosc, maksLadownosc)
    {
        this.temperatura = temperatura;
        rodzajKontenera = "C";
        this.rodzajProduktu = rodzajProduktu;
        numer = "KON-"+rodzajKontenera+"-"+ktoryKontener++;
    }
    
    public KontenerChlodniczy(int wysokosc, int masaKontenera, int glebokosc, int maksLadownosc, double temperatura, string rodzajProduktu, int masaLadunku) : base(wysokosc, masaKontenera, glebokosc, maksLadownosc, masaLadunku)
    {
        this.temperatura = temperatura;
        rodzajKontenera = "C";
        this.rodzajProduktu = rodzajProduktu;
        numer = "KON-"+rodzajKontenera+"-"+ktoryKontener++;
    }
    
    
    public void Zaladuj()
    {
        Console.WriteLine("Ile kg ladunku chcesz zaladowac? Aktualnie ten kontener moze pomiescic jeszcze"+(MaksLadownosc-MasaLadunku)+"kg.");
        int waga = int.Parse(Console.ReadLine());
        Console.WriteLine("Jaki rodzaj ladunku chcesz zaladowac?");
        string rodzajProduktu = Console.ReadLine();
        if (masaLadunku + waga> MaksLadownosc)
            throw new OverfillException("Masa ladunku przekracza maksymalna pojemnosc! Nie zaladowano statku.");
        if (this.rodzajProduktu!=rodzajProduktu)
        {
            Console.WriteLine("W tym kontenerze przewozi sie produkt: "+this.rodzajProduktu+", nie mozna wsadzic tam produktu "+rodzajProduktu+"!");
            return;
        }
        
        masaLadunku += waga;
    }
    

    public override string ToString()
    {
        return base.ToString()+" Sluzy do przewozenia produktu "+rodzajProduktu+" i w srodku ma temeprature "+temperatura+" stopni.";
    }

    public string RodzajProduktu
    {
        get => rodzajProduktu;
        set => rodzajProduktu = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double Temperatura
    {
        get => temperatura;
        set
        {
            double minTemp = listaTemperatur[rodzajProduktu];
            if(value < minTemp)
                Console.WriteLine("Ta temperatura bylaby za niska dla produktu "+rodzajProduktu+
                                  ", ktory wymaga temperatury conajmniej "+minTemp+"stopni!");
            else
            {
                temperatura = value;
            }
        }
    }
}