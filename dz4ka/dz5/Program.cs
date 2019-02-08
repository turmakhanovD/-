using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace dz5
{
    class Program
    {
        const int ZERO = 0, ONE = 1, THREE = 3, minimumSalaryInKazahstan = 56568;

        static void Main(string[] args)
        {

            ConsoleKey button;
            int count = ONE, incomePerFamilyMember;
            bool isPars, isContinue = true;
            string fullName, groupName;
            double avgMark;

            List<Student> students = new List<Student>();
            Student student = new Student();

            Student.Gender gender = new Student.Gender();
            Student.StudyForm studyForm = new Student.StudyForm();

            while (isContinue == true)
            {

                WriteLine("\nВведите полное имя студента:");
                fullName = ReadLine();

                WriteLine("\nВведите группу студента:");
                groupName = ReadLine();

                WriteLine("\nВведите средний балл:");
                isPars = double.TryParse(ReadLine(), out avgMark);

                WriteLine("\nВведите зарплату на члена семьй:\n");
                isPars = int.TryParse(ReadLine(), out incomePerFamilyMember);


                WriteLine("\nНажимите 1 если вы мужчина, 2 если женщина:\n");
                button = ReadKey().Key;

                if (button == ConsoleKey.D1)
                {
                    gender = Student.Gender.Male;
                }
                else if (button == ConsoleKey.D2)
                {
                    gender = Student.Gender.Female;
                }
                else
                {
                    WriteLine("Не коректный ввод");
                    Environment.Exit(ZERO);
                    ReadKey();
                }

                WriteLine("\nНажимите 1 если вы на очной форме обучение, 2 если на заочной:\n");
                button = ReadKey().Key;

                if (button == ConsoleKey.D1)
                {
                    studyForm = Student.StudyForm.Intramural;
                }
                else if (button == ConsoleKey.D2)
                {
                    studyForm = Student.StudyForm.Correspondence;
                }
                else
                {
                    WriteLine("Не корекнтый ввод");
                    Environment.Exit(ZERO);
                    ReadKey();
                }



                student.FullName = fullName;
                student.GroupName = groupName;
                student.AvgMark = avgMark;
                student.IncomePerFamilyMember = incomePerFamilyMember;
                student.GenderSave = (int)gender;
                student.StudyFormSave = (int)studyForm;


                students.Add(student);

                WriteLine("\nНажимите ESC если хотите прекратить ввод данных, если хотите продолжить нажимите на любую кнопку");
                button = ReadKey().Key;

                if (button == ConsoleKey.Escape)
                {
                    isContinue = false;
                }
                else
                {
                    isContinue = true;
                }

                Clear();

            }

            WriteLine("Полный вывод информаций.");
            foreach (Student i in students)
            {
                WriteLine("\n" + count + ".Полное имя студента: " + i.FullName);
                WriteLine("  Группа студента: " + i.GroupName);
                WriteLine("  Средний балл студента:" + i.AvgMark);
                WriteLine("  Зарплата на члена семьй: " + i.IncomePerFamilyMember);
                WriteLine("  Пол студента: " + i.GenderSave);
                WriteLine("  Форма обучение студента:" + i.StudyFormSave);
                count++;
            }
            List<Student> minSalaryStudents = new List<Student>();
            List<Student> avgSortStudents = new List<Student>();

            foreach (Student i in students)
            {
                if (i.IncomePerFamilyMember < minimumSalaryInKazahstan)
                {
                    minSalaryStudents.Add(i);
                }
                else
                {
                    avgSortStudents.Add(i);
                }
            }
            var sortedStudents = avgSortStudents.OrderBy(u => u.AvgMark);

            count = ONE;

            WriteLine("\nВывод студентов, меньше минимального дохода на члена семьи, для выдачи комнаты.");
            foreach (Student i in minSalaryStudents)
            {
                WriteLine("\n" + count + ".Полное имя студента: " + i.FullName);
                WriteLine("  Группа студента: " + i.GroupName);
                WriteLine("  Средний балл студента:" + i.AvgMark);
                WriteLine("  Зарплата на члена семьй: " + i.IncomePerFamilyMember);
                WriteLine("  Пол студента: " + i.GenderSave);
                WriteLine("  Форма обучение студента:" + i.StudyFormSave);
                count++;
            }

            WriteLine("\nВывод студентов, с высокими баллами, для выдачи комнаты");
            foreach (Student i in minSalaryStudents)
            {
                WriteLine("\n" + count + ".Полное имя студента: " + i.FullName);
                WriteLine("  Группа студента: " + i.GroupName);
                WriteLine("  Средний балл студента:" + i.AvgMark);
                WriteLine("  Зарплата на члена семьй: " + i.IncomePerFamilyMember);
                WriteLine("  Пол студента: " + i.GenderSave);
                WriteLine("  Форма обучение студента:" + i.StudyFormSave);
                count++;
            }
            ReadKey();
        }
    }
}