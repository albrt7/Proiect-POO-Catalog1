namespace ProiectPOO1;

public class Nota
{
    public string Tip { get; set; }
    public double Valoare { get; set; }

    public Nota(string tip, double valoare)
    {
        Tip = tip;
        Valoare = valoare;
    }
}