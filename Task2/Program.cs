using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.FindOptimalBank();
            Console.ReadKey();
        }

        /// <summary>
        /// Поиск оптимального банка
        /// </summary>
        private void FindOptimalBank()
        {
            List<Bank> banks = new List<Bank>
            {
                new Bank("A",0.1),
                new Bank("B",0.3),
                new Bank("C",0.9),
                new Bank("D",0.7),
                new Bank("E",0.2)
            };

            Console.WriteLine("Список банков:");
            foreach (Bank b in banks)
            {
                Console.WriteLine("{0}", b.Name);
            }

            int K;
            if (DateTime.IsLeapYear(DateTime.Now.Year))
                K = 366;
            else K = 365;
            Console.WriteLine("Введите количество дней начисления процентов:");
            int t = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите сумму денег на вкладе:");
            double p = int.Parse(Console.ReadLine());
            
            banks.Sort(delegate (Bank x, Bank y)
            {
                return x.GetIncome(p, t, K).CompareTo(y.GetIncome(p, t, K));
            });

            // ВНИМАНИЕ! Запись delegate (SomeType x, SomeType y)
            // {
            //     return x.GetIncome(p, t, K).CompareTo(y.GetIncome(p, t, K));
            // });
            // означает: вызывается метод-делегат, 
            // который принимает два аргумента
            // и возвращает сравнение этих аргументов
            // по определенному признаку

            Console.WriteLine("Оптимальный вариант:");

            Console.WriteLine("Банк: {0}, доход: {1:F2}", 
                banks[banks.Count - 1].Name, banks[banks.Count - 1].GetIncome(p, t, K));
        }
    }
}
