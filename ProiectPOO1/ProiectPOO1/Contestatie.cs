namespace ProiectPOO1;

public class Contestatie
{
    public string Disciplina { get; set; }
    public string Status {get; set;}
    public string Rezultat { get; set; }

    public Contestatie(string disciplina)
    {
        Disciplina = disciplina;
        Status = "In asteptare";
        Rezultat = "";
    }
}