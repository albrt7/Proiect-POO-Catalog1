namespace ProiectPOO1;

public class Catalog
{
    private List<Student> studenti;

    public Catalog()
    {
        studenti = new List<Student>();
    }

    public void AdaugaStudent(Student student)
    {
        studenti.Add(student);
    }

    public Student GasesteStudent(string nume)
    {
        return studenti.FirstOrDefault(s => s.Nume == nume);
    }
 
}