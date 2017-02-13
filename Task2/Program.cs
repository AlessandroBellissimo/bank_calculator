using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        List<Bank> banks;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
            Console.ReadKey();
        }

        private void Run()
        {
            InitBanks();
            DisplayBanks();
            int K, t, p;
            ReadParameters(out K, out t, out p);
            ChooseBankToGetIncome(K, t, p);
            FindOptimalBank(K, t, p);
        }

        /// <summary>
        /// Инициализация списка банков
        /// </summary>
        private void InitBanks()
        {
            banks = new List<Bank>
            {
                new Bank("Mizahi",0.1),
                new Bank("Liumi",0.3),
                new Bank("Diskont",0.9),
                new Bank("Apoalim",0.7),
                new Bank("SomeBank",0.2)
            };
        }

        /// <summary>
        /// Чтение входных параметров
        /// </summary>
        private void ReadParameters(out int K, out int t, out int p)
        {
            if (DateTime.IsLeapYear(DateTime.Now.Year))
                K = 366;
            else K = 365;
            Console.WriteLine("Введите количество дней начисления процентов:");
            t = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите сумму денег на вкладе:");
            p = int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Отображение списка банков
        /// </summary>
        private void DisplayBanks()
        {
            Console.WriteLine("Список банков:");
            foreach (Bank b in banks)
            {
                Console.WriteLine("{0}", b.Name);
            }
        }

        /// <summary>
        /// Выбор банка для получения информации о доходе
        /// </summary>
        private void ChooseBankToGetIncome(int k, int t, int p)
        {
            Console.WriteLine("Выберите банк из списка:");
            string bname;
            bool found = false;

            while (found != true)
            {
                bname = Console.ReadLine();
                int count = 0;
                Bank bank = null;
                foreach (Bank b in banks)
                {
                    if (bname != b.Name)
                    {
                        count++;
                        continue;
                    }
                    else
                    {
                        bank = b;
                        break;
                    }
                }
                if (count == banks.Count)
                {
                    Console.WriteLine("Такого банка нет в списке. Выберите банк из списка");
                }
                else
                {
                    found = true;
                    Console.WriteLine("Банк: {0}, доход: {1:F2}", 
                        bank.Name, bank.GetIncome(p, t, k));
                }
            }
        }

        /// <summary>
        /// Поиск оптимального банка
        /// </summary>
        private void FindOptimalBank(int K, int t, int p)
        {

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
