namespace ProiectPOO1;

public class Student
{
    public string Nume { get; set; }
    public int An { get; set; }
    public List<Disciplina> Discipline { get; set; }
    public List<Contestatie> Contestatii { get; set; }

    public Student(string nume, int an)
    {
        Nume = nume;
        An = an;
        Discipline = new List<Disciplina>();
        Contestatii = new List<Contestatie>();
    }

    public void InroleazaDisciplina(Disciplina disciplina)
    {
        Discipline.Add(disciplina);
    }

    public void TrimiteContestatie(string disciplina)
    {
        Contestatii.Add(new Contestatie(disciplina));
    }

    public void ActualizeazaContestatie(string disciplina, string status, string rezultat)
    {
        var contestatie = Contestatii.FirstOrDefault(c => c.Disciplina == disciplina && c.Status == "In asteptare");
        if (contestatie != null)
        {
            contestatie.Status = status;
            contestatie.Rezultat = rezultat;
        }
    }

    public void VizualizeazaContestatii()
    {
        Console.WriteLine("Lista contestatii:");
        foreach (var contestatie in Contestatii)
        {
            Console.WriteLine($"Disciplina: {contestatie.Disciplina}, Status: {contestatie.Status}, Rezultat: {contestatie.Rezultat}");
        }
    }

    
    
}