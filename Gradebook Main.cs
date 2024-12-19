namespace Gradebook_project
{
    public class Gradebook_Main
    {

        private static void Main()
        {
            Dictionary<string, char> GradeBook = new();

            while (true)
            {
                Console.WriteLine(
                    "Welcome to the Gradebook \n" +
                    "[1] View All Grades\n" +
                    "[2] Add Student and Grade\n" +
                    "[3] Change Grade\n" +
                    "[4] Remove Student\n");

                Int32.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1:
                        ViewGrades(GradeBook);
                        break;
                    case 2:
                        AddToGradeBook(GradeBook);
                        break;
                    case 3:
                        ChangeGrade(GradeBook);
                        break;
                    case 4:
                        RemoveFromGradeBook(GradeBook);
                        break;
                    default:
                        Console.WriteLine("INVALID CHOICE");
                        break;
                }
            }
        }
        public static void ViewGrades(Dictionary<string, char> gradeBook)
        {
            if(gradeBook.Count != 0)
            {
                foreach (var grade in gradeBook)
                {
                    Console.WriteLine($"{grade.Key}: {grade.Value}");
                }
            }
            else
            {
                Console.WriteLine("No Grades have been entered in the gradebook");
            }
        }

        //add student with grade
        public static string AddStudent()
        {
            Console.WriteLine("Enter students first name: ");
            return Console.ReadLine();
        }

        public static int AddGrade()
        {
            Console.WriteLine("Enter the stuents grade: ");
            Int32.TryParse(Console.ReadLine(), out int studentGrade);
            return studentGrade;
        }

        public static void AddToGradeBook(Dictionary<string, char> gradeBook)
        {
            gradeBook.Add(AddStudent(), StudentGrade());
        }

        //remove student
        public static void RemoveFromGradeBook(Dictionary<string, char> gradeBook)
        {
            if (gradeBook.Count != 0)
            {
                Console.WriteLine("Which student would you like to remove");
                string? studentName = Console.ReadLine();
                if (gradeBook.ContainsKey(studentName))
                {
                    gradeBook.Remove(studentName);
                    Console.WriteLine($"{studentName} has been removed from the gradebook");
                }
                else
                {
                    Console.WriteLine($"{studentName} was not found in the gradebook");
                }
                
            }
            else
            {
                Console.WriteLine("The gradebook is empty");
            }
        }
        
        //Calculate students grade
        public static char StudentGrade()
        {
            int grade = AddGrade();
            GradeRange A = new(Grade.A, 90, int.MaxValue);
            GradeRange B = new(Grade.B, 80, 90);
            GradeRange C = new(Grade.C, 70, 80);
            GradeRange D = new(Grade.D, 60, 70);
            GradeRange F = new(Grade.F, 0, 60);

            if (A.IsInRange(grade))
            {
                return 'A';
            }
            else if (B.IsInRange(grade))
            {
                return 'B';
            }
            else if (C.IsInRange(grade))
            {
                return 'C';
            }
            else if(D.IsInRange(grade))
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }

        //change grade
        public static void ChangeGrade(Dictionary<string, char> gradeBook)
        {
            if (gradeBook.Count != 0)
            {
                Console.WriteLine("Whos grade do you want to change");
                string? student = Console.ReadLine();
                gradeBook[student] = StudentGrade();
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }
    }
}
