namespace APBD_3;

public class KontenerChlodniczy : Kontener
{
    public static Dictionary<string, double> listaTemperatur = new Dictionary<string, double>()
    {
        {"Bananas",13.3}, {"Chocolate",18}, {"Fish", 2}, 
        {"Meat",-15}, {"Ice cream", -18}, {"Frozen pizza", -30},
        {"Cheese", 7.2},{"Sausages", 5}, {"Butter", 20.5}, {"Eggs", 19}
    };
  
    private string rodzajProduktu;
    private double temperatura;

    public KontenerChlodniczy(int wysokosc, int masaKontenera, int glebokosc, int maksLadownosc, double temperatura, string rodzajProduktu) : base(wysokosc, masaKontenera, glebokosc, maksLadownosc)
    {
        this.temperatura = temperatura;
        rodzajKontenera = "C";
        this.rodzajProduktu = rodzajProduktu;
    }

    
    
    public void Zaladuj(int waga, string rodzajProduktu)
    {
        if (masaLadunku + waga> MaksLadownosc)
            throw new OverfillException("Masa ladunku przekracza maksymalna pojemnosc! Nie zaladowano statku.");
        if (this.rodzajProduktu!=rodzajProduktu)
        {
            Console.WriteLine("W tym kontenerze przewozi sie produkt: "+this.rodzajProduktu+", nie mozna wsadzic tam produktu "+rodzajProduktu+"!");
            return;
        }
        
        masaLadunku += waga;
    }

    public void Wyladuj()
    {
        base.Wyladuj();
    }
    
    public void Wyladuj(int ile)
    {
        base.Wyladuj(ile);
    }

    public override string ToString()
    {
        return base.ToString()+"Przewozi w srodku "+rodzajProduktu+".";
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