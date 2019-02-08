using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace dz4ka
{
    class Program
    {
       
        static void Main(string[] args)
        {
            int size = 0;
            bool isPars;
            string firstName, lastName;
            int salary;
            DateTime workStartDate;

            Workers clerk = new Workers();

            WriteLine("Введите количество сотрудников:");
            isPars = int.TryParse(ReadLine(), out size);

            if (isPars == false)
            {
                WriteLine("Не коректный ввод");
                Environment.Exit(0);
            }
            else
            {

                List<Workers> managers = new List<Workers>();
                List<Workers> clerks = new List<Workers>();

                for (int i = 0; i < size; i++)
                {
                    WriteLine("\nВведите фамилию сотрудника:");
                    lastName = ReadLine();

                    WriteLine("\nВведите имя сотрудника:");
                    firstName = ReadLine();

                    WriteLine("\nВведите зарплату сотрудника:");
                    isPars = int.TryParse(ReadLine(), out salary);

                    WriteLine("\nВведите дату трудоустройства сотрудника:");
                    isPars = DateTime.TryParse(ReadLine(), out workStartDate);

                    clerk.firstName = firstName;
                    clerk.lastName = lastName;
                    clerk.salary = salary;
                    clerk.workStartDate = workStartDate;

                    clerks.Add(clerk);
                }


                Workers boss = new Workers();

                WriteLine("\nВведите фамилию босс:");
                lastName = ReadLine();

                WriteLine("\nВведите имя босс:");
                firstName = ReadLine();

                WriteLine("\nВведите зарплату босс:");
                isPars = int.TryParse(ReadLine(), out salary);

                WriteLine("\nВведите дату трудоустройства босс:");
                isPars = DateTime.TryParse(ReadLine(), out workStartDate);

                boss.firstName = firstName;
                boss.lastName = lastName;
                boss.salary = salary;
                boss.workStartDate = workStartDate;

                WriteLine("\nВывод всего персонала.");
                ShowAllStaff(managers, clerks, boss);

                WriteLine("\nВывод всех мэнэджеров.");
                FindManager(managers, clerks);

                WriteLine("\nВывод всего персонала после прихода босса.");
                FindAfterBoss(clerks, boss);

                ReadKey();
            }
        }
        static void ShowAllStaff(List<Workers> managers, List<Workers> clerks, Workers boss)
        {

            for (int i = 0; i < clerks.Count; i++)
            {
                WriteLine(i + ".");
                WriteLine("Имя сотрудника:" + clerks[i].firstName);
                WriteLine("Фамилия сотрудника:" + clerks[i].lastName);
                WriteLine("Зарплата:" + clerks[i].salary);
                WriteLine("Дата трудоустройства:" + clerks[i].workStartDate + "\n");
            }


            WriteLine("\n\n\n");

            WriteLine("Имя босса:" + boss.firstName);
            WriteLine("Фамилия босса:" + boss.lastName);
            WriteLine("Зарплата:" + boss.salary);
            WriteLine("Дата трудоустройства:" + boss.workStartDate + "\n");
        }

        static void FindManager(List<Workers> managers, List<Workers> clerks)
        {
            Workers manager = new Workers();

            int avgSalary = 0, salarySum = 0;

            for (int i = 0; i < clerks.Count; i++)
            {
                salarySum += clerks[i].salary;
            }

            avgSalary = salarySum / clerks.Count;

            for (int i = 0; i < clerks.Count; i++)
            {
                if (avgSalary < clerks[i].salary)
                {
                    manager.firstName = clerks[i].firstName;
                    manager.lastName = clerks[i].lastName;
                    manager.salary = clerks[i].salary;
                    manager.workStartDate = clerks[i].workStartDate;

                    managers.Add(manager);
                }
            }
            var sortedUsers = managers.OrderBy(u => u.lastName);

            WriteLine("\n\n\n");

            foreach (Workers sortedManager in sortedUsers)
            {
                WriteLine("Имя мэнеджера:" + sortedManager.firstName);
                WriteLine("Фамилия мэнеджера:" + sortedManager.lastName);
                WriteLine("Зарплата:" + sortedManager.salary);
                WriteLine("Дата трудоустройства:" + sortedManager.workStartDate + "\n");
            }

        }
        static void FindAfterBoss(List<Workers> clerks, Workers boss)
        {
            List<Workers> WorkersAfter = new List<Workers>();
            Workers clerk = new Workers();

            for (int i = 0; i < clerks.Count; i++)
            {
                if (boss.workStartDate < clerks[i].workStartDate)
                {
                    clerk.firstName = clerks[i].firstName;
                    clerk.lastName = clerks[i].lastName;
                    clerk.salary = clerks[i].salary;
                    clerk.workStartDate = clerks[i].workStartDate;

                    WorkersAfter.Add(clerk);
                }
            }
            var sortedUsers = WorkersAfter.OrderBy(u => u.lastName);

            WriteLine("\n\n\n");

            foreach (Workers sortedClerk in sortedUsers)
            {
                WriteLine("Имя сотрудника:" + sortedClerk.firstName);
                WriteLine("Фамилия сотрудника:" + sortedClerk.lastName);
                WriteLine("Зарплата:" + sortedClerk.salary);
                WriteLine("Дата трудоустройства:" + sortedClerk.workStartDate + "\n");
            }
        }
    }
}
