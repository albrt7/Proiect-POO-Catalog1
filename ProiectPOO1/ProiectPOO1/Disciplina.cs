namespace ProiectPOO1;

public class Disciplina
{
    public string Nume { get; set; }
    public string Tip { get; set; }
    public List<Nota>Note { get; set; }
    public int An { get; set; }
    public int Semestru { get; set; }
    
    public Disciplina(string nume, string tip, int an, int semestru)
    {
        Nume = nume;
        Tip = tip;
        An = an;
        Semestru = semestru;
        Note = new List<Nota>();
    }

    public double CalculeazaMedia()
    {
        if(Note.Count == 0)
            return 0;
        return Note.Average(n => n.Valoare);
    }
}