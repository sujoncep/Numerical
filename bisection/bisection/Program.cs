using System;

namespace bisection
{
    class Program
    {
        static float EPSILON = (float)0.01;
        static double func(double x)
        {
            return x * x * x -
                   x * x + 2;
        }
        static void bisection(double a,
                              double b)
        {
            if (func(a) * func(b) >= 0)
            {
                Console.WriteLine("worng interval");
                return;
            }

            double c = a;
            while ((b - a) >= EPSILON)
            {
                c = (a + b) / 2;

                if (func(c) == 0.0)
                    break;

                else if (func(c) * func(a) < 0)
                    b = c;
                else
                    a = c;
            }

            Console.WriteLine("root is : " + c);
        }

        static public void Main()
        {
            double a, b;
            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
         
            bisection(a, b);
        }
    }
}
