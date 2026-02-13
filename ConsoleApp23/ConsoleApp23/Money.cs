using System;
    public class Money
    {
        public int Count5000 { get; private set; }
        public int Count1000 { get; private set; }
        public int Count500 { get; private set; }
        public int Count100 { get; private set; }
        public int Count50 { get; private set; }
        public int Count10 { get; private set; }
        public int Count5 { get; private set; }
        public int Count2 { get; private set; }
        public int Count1 { get; private set; }

        public int Count50kop { get; private set; }
        public int Count10kop { get; private set; }
        public int Count5kop { get; private set; }
        public int Count1kop { get; private set; }

        public Money(decimal amount)
        {
            if (amount < 0)
                throw new ArgumentException("Сумма не может быть отрицательной");

            long kopecks = (long)(amount * 100);

            Count5000 = (int)(kopecks / 500000); kopecks %= 500000;
            Count1000 = (int)(kopecks / 100000); kopecks %= 100000;
            Count500 = (int)(kopecks / 50000); kopecks %= 50000;
            Count100 = (int)(kopecks / 10000); kopecks %= 10000;
            Count50 = (int)(kopecks / 5000); kopecks %= 5000;
            Count10 = (int)(kopecks / 1000); kopecks %= 1000;
            Count5 = (int)(kopecks / 500); kopecks %= 500;
            Count2 = (int)(kopecks / 200); kopecks %= 200;
            Count1 = (int)(kopecks / 100); kopecks %= 100;

            Count50kop = (int)(kopecks / 50); kopecks %= 50;
            Count10kop = (int)(kopecks / 10); kopecks %= 10;
            Count5kop = (int)(kopecks / 5); kopecks %= 5;
            Count1kop = (int)kopecks;
        }

        private decimal GetTotal()
        {
            return
                Count5000 * 5000m +
                Count1000 * 1000m +
                Count500 * 500m +
                Count100 * 100m +
                Count50 * 50m +
                Count10 * 10m +
                Count5 * 5m +
                Count2 * 2m +
                Count1 * 1m +
                Count50kop * 0.5m +
                Count10kop * 0.1m +
                Count5kop * 0.05m +
                Count1kop * 0.01m;
        }

        public static Money operator +(Money a, Money b)
        {
            return new Money(a.GetTotal() + b.GetTotal());
        }

        public static Money operator -(Money a, Money b)
        {
            return new Money(a.GetTotal() - b.GetTotal());
        }

        public static Money operator *(Money m, decimal factor)
        {
            return new Money(m.GetTotal() * factor);
        }

        public static Money operator /(Money m, decimal divisor)
        {
            if (divisor == 0) throw new DivideByZeroException();
            return new Money(m.GetTotal() / divisor);
        }

        public static decimal operator /(Money a, Money b)
        {
            if (b.GetTotal() == 0) throw new DivideByZeroException();
            return a.GetTotal() / b.GetTotal();
        }

        public static bool operator >(Money a, Money b) => a.GetTotal() > b.GetTotal();
        public static bool operator <(Money a, Money b) => a.GetTotal() < b.GetTotal();
        public static bool operator >=(Money a, Money b) => a.GetTotal() >= b.GetTotal();
        public static bool operator <=(Money a, Money b) => a.GetTotal() <= b.GetTotal();

        public override string ToString()
        {
            decimal total = GetTotal();
            long rub = (long)total;
            int kop = (int)((total - rub) * 100);
            return $"{rub:N0},{kop:00}";
        }
    }
