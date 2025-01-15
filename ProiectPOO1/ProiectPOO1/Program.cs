using ProiectPOO1;

namespace ProiectPoo;

public class Program
{
    static void Main(string[] args)
    {
        Catalog catalog = new Catalog();
       
            var student = new Student("Beto", 2);
            
            var disciplina = new Disciplina("Matematica", "Obligatorie", 1, 1);

            var disciplina2 = new Disciplina("Fizica", "Obligatorie", 1, 2);

            var disciplina3 = new Disciplina("Programare", "Obligatorie", 2, 1);
            
            var disciplina6 = new Disciplina("ET", "Obligatorie", 2, 2);

            var disciplina4 = new Disciplina("POO", "Facultativa", 1, 1);

            var disciplina5 = new Disciplina("PCDD", "Optionala", 2, 2);
            while (true) {

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
                    MeniuStudent(student,catalog);
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

        static void MeniuStudent(Student student, Catalog catalog)

        {
            while (true)
            {
                Console.WriteLine("\nMeniu Student:");
                Console.WriteLine("1. Vizualizeaza notele");
                Console.WriteLine("2. Inroleaza te la o disciplina");
                Console.WriteLine("3. Calculeaza media anuala");
                Console.WriteLine("4. Calculeaza media multianuala");
                Console.WriteLine("5. Calculeaza media la o disciplina");
                Console.WriteLine("6. Trimite contestatie");
                Console.WriteLine("7. Vizualizeaza contestatii");
                Console.WriteLine("0. Inapoi");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                    Console.Write("Anul (0 pentru toate): ");
                    int an = int.Parse(Console.ReadLine());
                    Console.Write("Semestrul (0 pentru toate): ");
                    int semestru = int.Parse(Console.ReadLine());
                    Console.Write("Disciplina (lasati gol pentru toate): ");
                    string disciplina = Console.ReadLine();
                    student.VizualizeazaNoteAnSemestruDisciplina(an, semestru, disciplina);
                    break;
                    
                    case "2":
                        Console.Write("Introdu numele disciplinei: ");
                        string numeDisciplina = Console.ReadLine();
                        Console.Write("Introdu tipul disciplinei (Obligatorie/Optionala/Facultativa): ");
                        string tipDisciplina = Console.ReadLine();
                        Console.Write("Introdu anul disciplinei: ");
                        int anDisciplina = int.Parse(Console.ReadLine());
                        Console.Write("Introdu semestrul disciplinei: ");
                        int semestruDisciplina = int.Parse(Console.ReadLine());

                        var disciplinaNoua = new Disciplina(numeDisciplina, tipDisciplina, anDisciplina,
                            semestruDisciplina);
                        student.InroleazaDisciplina(disciplinaNoua);
                        Console.WriteLine("Te-ai inrolat la disciplina cu succes.");
                        break;
                   
                    case "3":
                        Console.Write("Introdu anul pentru care doresti media: ");
                        if (int.TryParse(Console.ReadLine(), out int anCurent))
                        {
                            double mediaAnuala = student.CalculeazaMediaAnuala(anCurent);
                            Console.WriteLine($"Media anuala pentru anul {anCurent} este: {mediaAnuala:F2}");
                        }
                        else
                        {
                            Console.WriteLine("Anul introdus nu este valid.");
                        }
                        break;

                    case "4":
                        double mediaMultianuala = student.CalculeazaMediaMultianuala();
                        Console.WriteLine($"Media multianuala este: {mediaMultianuala:F2}");
                        break;



                    case "5":
                        Console.Write("Introduceti numele disciplinei pentru care doriti să calculati media: ");
                        string disciplinaSelectata = Console.ReadLine();
                        double media = student.CalculeazaMediaDisciplina(disciplinaSelectata);
                        Console.WriteLine($"Media la disciplina {disciplinaSelectata} este: {media:F2}");
                        break;
                    case "6":
                        Console.Write("Disciplina pentru care trimiti contestatia: ");
                        string disciplinaContestatie = Console.ReadLine();
                        student.TrimiteContestatie(disciplinaContestatie);
                        Console.WriteLine("Contestatia a fost trimisa.");
                        break;
                    case "7":
                        break;
                    case "0":
                        student.VizualizeazaContestatii();
                        return;
                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }
            }
        }

        static void MeniuProfesor(Catalog catalog)
        {
            while (true)
            {
                Console.WriteLine("\nMeniu Profesor:");
                Console.WriteLine("1. Noteaza un student");
                Console.WriteLine("2. Rezolva contestatii");
                Console.WriteLine("0. Inapoi");

                string optiune = Console.ReadLine();
                switch (optiune)
                {
                    case "1":
                        Console.Write("Numele studentului: ");
                        string numeStudent = Console.ReadLine();
                        var student = catalog.GasesteStudent(numeStudent);
                        if (student != null)
                        {
                            Console.Write("Disciplina: ");
                            string numeDisciplina = Console.ReadLine();
                            var disciplina = student.Discipline.FirstOrDefault(d => d.Nume == numeDisciplina);
                            if (disciplina != null)
                            {
                                Console.Write("Tip nota (Activitate/Examen): ");
                                string tipNota = Console.ReadLine();
                                Console.Write("Valoare nota: ");
                                double valoareNota = double.Parse(Console.ReadLine());
                                disciplina.Note.Add(new Nota(tipNota, valoareNota));
                                Console.WriteLine("Nota a fost adaugata.");
                                student.PublicaNoteInCarnet(numeDisciplina);
                            }
                            
                            else
                            {
                                Console.WriteLine("Disciplina nu a fost gasita.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Studentul nu a fost gasit.");
                        }
                        break;
                    case "2":
                        Console.Write("Numele studentului: ");
                        numeStudent = Console.ReadLine();
                        student = catalog.GasesteStudent(numeStudent);
                        if (student != null)
                        {
                            Console.Write("Disciplina contestata: ");
                            string disciplinaContestata = Console.ReadLine();
                            Console.Write("Status (Aprobat/Respins): ");
                            string status = Console.ReadLine();
                            Console.Write("Rezultat: ");
                            string rezultat = Console.ReadLine();
                            student.ActualizeazaContestatie(disciplinaContestata, status, rezultat);
                            Console.WriteLine("Contestatia a fost actualizata.");
                        }
                        else
                        {
                            Console.WriteLine("Studentul nu a fost gasit.");
                        }
                        break;

                    case "0":
                        return;
                    default:
                        Console.WriteLine("Optiune invalida.");
                        break;
                }
            }
        }
    }
}