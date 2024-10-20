using System;

namespace EmployeeHierarchy
{

    abstract class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }


        protected Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }


        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Ім'я: {Name}");
            Console.WriteLine($"Зарплата: {Salary}");
        }


        public virtual double CalculateTotalIncome()
        {
            return Salary;
        }
    }


    class EmployeeStaff : Employee
    {
        public int WorkExperience { get; set; }
        public double ExperienceBonus { get; set; }


        public EmployeeStaff(string name, double salary, int workExperience, double experienceBonus)
            : base(name, salary)
        {
            WorkExperience = workExperience;
            ExperienceBonus = experienceBonus;
        }


        public void DisplayStaffInfo()
        {
            DisplayInfo();
            Console.WriteLine($"Стаж роботи: {WorkExperience} років");
            Console.WriteLine($"Надбавка за стаж: {ExperienceBonus}");
        }


        public override double CalculateTotalIncome()
        {
            return Salary + ExperienceBonus;
        }
    }


    class Worker : Employee
    {
        public string Position { get; set; }


        public Worker(string name, double salary, string position)
            : base(name, salary)
        {
            Position = position;
        }


        public void DisplayWorkerInfo()
        {
            Console.WriteLine($"Посада: {Position}");
            Console.WriteLine($"Зарплата: {Salary}");
        }

        public double CalculateAverageSalary(double[] salaries)
        {
            double totalSalary = 0;
            foreach (var salary in salaries)
            {
                totalSalary += salary;
            }
            return totalSalary / salaries.Length;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            EmployeeStaff staff = new EmployeeStaff("Іван", 1500, 5, 200);
            Worker worker = new Worker("Петро", 1200, "Токар");


            staff.DisplayStaffInfo();
            double totalIncomeStaff = staff.CalculateTotalIncome();
            Console.WriteLine($"Сукупний дохід службовця: {totalIncomeStaff}\n");


            worker.DisplayWorkerInfo();
            double[] salaries = { 1200, 1300, 1250, 1350, 1400, 1450 };
            double averageSalary = worker.CalculateAverageSalary(salaries);
            Console.WriteLine($"Середня зарплата робочого за 6 місяців: {averageSalary}");
        }
    }
}
