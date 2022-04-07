using Exeercício_Composição_1.Entities;
using Exeercício_Composição_1.Entities.Enums;
using System;

namespace Exeercício_Composição_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o nome do departamento: ");
            string depName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite os dados do trabalhador: ");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Nível (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Salário Base: R$");
            double baseSalary = double.Parse(Console.ReadLine());

            Department dep = new Department(depName);
            Worker worker = new Worker(name, level, baseSalary, dep);
            
            Console.WriteLine();
            Console.Write("Quantos contratos teve esse trabalhador? ");
            int n = int.Parse(Console.ReadLine());

            for (int i =1; i <= n; i++)
            {
                Console.WriteLine("Digite os dados do contrato #" + i + ": ");
                Console.Write("Data (DD/MM/AAAA): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: R$");
                double salaryPerHour = double.Parse(Console.ReadLine());
                Console.Write("Duração (horas): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, salaryPerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Coloque mês e ano para calcular o ganho (MM/AAAA): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3, 4));

            Console.WriteLine("Nome: " + worker.Name);
            Console.WriteLine("Departamento: " + worker.Department.Name);
            Console.WriteLine("Ganhos de " + monthAndYear + ": R$" + worker.Income(year, month).ToString("F2"));


        }
    }
}
