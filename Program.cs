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
            Console.WriteLine($"��'�: {Name}");
            Console.WriteLine($"��������: {Salary}");
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
            Console.WriteLine($"���� ������: {WorkExperience} ����");
            Console.WriteLine($"�������� �� ����: {ExperienceBonus}");
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
            Console.WriteLine($"������: {Position}");
            Console.WriteLine($"��������: {Salary}");
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

            EmployeeStaff staff = new EmployeeStaff("����", 1500, 5, 200);
            Worker worker = new Worker("�����", 1200, "�����");


            staff.DisplayStaffInfo();
            double totalIncomeStaff = staff.CalculateTotalIncome();
            Console.WriteLine($"�������� ����� ���������: {totalIncomeStaff}\n");


            worker.DisplayWorkerInfo();
            double[] salaries = { 1200, 1300, 1250, 1350, 1400, 1450 };
            double averageSalary = worker.CalculateAverageSalary(salaries);
            Console.WriteLine($"������� �������� �������� �� 6 ������: {averageSalary}");
        }
    }
}
