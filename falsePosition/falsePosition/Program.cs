using System;

namespace falsePosition
{
    class Program
    {
        static int loop= 10000;
        static double func(double x)
        {
            return (x * x * x -  x + 1);
        }
        static void regulaFalsi(double a, double b)
        {
            if (func(a) * func(b) >= 0)
            {
                Console.WriteLine("worng interval");
            }
            double c = a;

            for (int i = 0; i < loop; i++)
            {
                c = (a * func(b) - b * func(a))
                    / (func(b) - func(a));
                if (func(c) == 0)
                    break;
                else if (func(c) * func(a) < 0)
                    b = c;
                else
                    a = c;
            }

            Console.WriteLine("Root is : " + c);
        }
        public static void Main(String[] args)
        {
            double a, b;
            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
            regulaFalsi(a, b);
        }
    }
}
