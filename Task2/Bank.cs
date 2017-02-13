namespace Task2
{
    public class Bank
    {
        public string Name { get; private set; }            // название банка
        public double InterestRate { get; private set; }    // процентная ставка

        public Bank(string name, double interestRate)
        {
            Name = name;
            InterestRate = interestRate;
        }

        /// <summary>
        /// Вычислить доход:
        /// </summary>
        public double GetIncome(double p, int t, int K)
        {
            double S = p * (1 + (InterestRate * t) / (K * 100));
            return S;
        }
    }
}
