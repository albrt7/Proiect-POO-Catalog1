using ProiectPOO1;

namespace ProiectPoo;

public class Program
{
    static void Main(string[] args)
    {
        Catalog catalog = new Catalog();
        while (true)
        {
            var student = new Student("Beto", 2);
            var disciplina = new Disciplina("Matematica", "Obligatorie", 1, 1);

            var disciplina2 = new Disciplina("Fizica", "Obligatorie", 1, 2);

            var disciplina3 = new Disciplina("Programare", "Obligatorie", 2, 1);
            
            var disciplina6 = new Disciplina("ET", "Obligatorie", 2, 2);

            var disciplina4 = new Disciplina("POO", "Facultativa", 1, 1);

            var disciplina5 = new Disciplina("PCDD", "Optionala", 2, 2);


            student.InroleazaDisciplina(disciplina);
            student.InroleazaDisciplina(disciplina2);
            student.InroleazaDisciplina(disciplina3);
            student.InroleazaDisciplina(disciplina6);
            
            catalog.AdaugaStudent(student);
            
            Console.WriteLine("Selecteaza perspectiva:");
            Console.WriteLine("1. Student");
            Console.WriteLine("2. Profesor");
            Console.WriteLine("0. Iesire");

            string optiune = Console.ReadLine();
            switch (optiune)
            {
                case "1":
                    MeniuStudent(student);
                    break;
                case "2":
                    MeniuProfesor(catalog);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Optiune invalida.");
                    break;
            }
        }

        static void MeniuStudent(Student student)
        {
        }

        static void MeniuProfesor(Catalog catalog)
        {
        }
    }
    
}