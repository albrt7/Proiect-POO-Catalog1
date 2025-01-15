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

}