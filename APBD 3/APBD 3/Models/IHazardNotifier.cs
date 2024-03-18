namespace APBD_3;

public interface IHazardNotifier
{
    public string NotyfikacjaTekstowa(string typSytuacji, int numer)
    {
        return "Zaszla niebezpieczna sytuacja: " + typSytuacji + " w kontenerze numer " + numer;
    }
}