using System;

namespace NumericalAllCodes
{
    class Program
    {
        static double accurecy = 0.001;
        static int loop = 10000;

        static double func(double x)
        {
            return x * x * x - x * x + 2;
        }
        static double func2(double x)
        {
            return x * x - 3;
        }
        static double func3(double x)
        {
            return x * x / 3;
        }

        static double firstDerivFunc(double x)
        {
            return 3 * x * x - 2 * x;
        }

        static double secondDerivFunc(double x)
        {
            return 6 * x - 2 ;
        }
        static void IntervalChecker(double a, double b)
        {
            if (func(a) * func(b) >= 0)
            {
                Console.WriteLine("Worng interval");
            }
        } 
        //bisection
        static void bisection(double a,double b)
        {
            IntervalChecker( a, b);
            double c = a;
            while ((b - a) >= accurecy)
            {
                c = (a + b) / 2;

                if (func(c) == 0.0)
                    break;

                else if (func(c) * func(a) < 0)
                    b = c;
                else
                    a = c;
            }
            Console.WriteLine("Root Using Bisection Method is : " + c);
        }

        //regulaFalsi
        static void regulaFalsi(double a, double b)
        {
            IntervalChecker(a, b);
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
            Console.WriteLine("Root Using regulaFalsi Method is : " + c);
        }
        // newtonRaphson
        static void newtonRaphson(double x)
        {
            double h = func(x) / firstDerivFunc(x);
            while (Math.Abs(h) >= accurecy)
            {
                h = func(x) / firstDerivFunc(x);
                x = x - h;
            }
            Console.WriteLine("Root Using NewtonRaphson Method is : " + x);
        }
        // Halley's method
        static void halleys(double x)
        {
            double h =( 2 * func(x) * firstDerivFunc(x))/ 
                (2 * firstDerivFunc(x) * firstDerivFunc(x) - func(x) * secondDerivFunc(x));
            while (Math.Abs(h) >= accurecy)
            {
                
                h = (2 * func(x) * firstDerivFunc(x)) / 
                    (2 * firstDerivFunc(x) * firstDerivFunc(x) - func(x) * secondDerivFunc(x));
                x = x - h;

            }
            Console.WriteLine("Root Using Halley's Method is : " + x);
        }

        //mularMethod

        static void muller(double a, double b, double c)
        {
            double d = 0;
            for (int i = 0; i < 1000; i++)
            {
                double d1 = func2(a) - func2(c);
                double d2 = func2(b) - func2(c);
                double h1 = a - c;
                double h2 = b - c;
                double a0 = func2(c);
                double a1 = (((d2 * Math.Pow(h1, 2)) - (d1 * Math.Pow(h2, 2)))
                            / ((h1 * h2) * (h1 - h2)));
                double a2 = (((d1 * h2) - (d2 * h1)) / ((h1 * h2) * (h1 - h2)));
                double x = ((-2 * a0) / (a1 + Math.Abs(Math.Sqrt(a1 * a1 - 4 * a0 * a2))));
                double y = ((-2 * a0) / (a1 - Math.Abs(Math.Sqrt(a1 * a1 - 4 * a0 * a2))));
                if (x >= y)
                    d = x + c;
                else
                    d = y + c;
                if (d == c)
                {
                    Console.WriteLine("Root Using Mullar Method is : " + d);
                    break;
                }
                else
                a = b;
                b = c;
                c = d;
            }
        }

        //FixedPoint
        static void FixedPoint(double a, double b)
        {
            double d = 0;
            IntervalChecker(a, b);
            for (int i = 0; i < 1000; i++)
            {
                if (Math.Abs(func2(a)) > Math.Abs(func2(b)))
                    d = a;
                else
                    d = b;
                double c = func3(d);
                if (Math.Abs(c) <= accurecy)
                    break;
                else
                    d = c;
            }
            Console.WriteLine("Root Using FixedPoint Method is : " +d);
        }

        //Steffensen's method

        static void steffensenMethod(double a, double b)
        {
            IntervalChecker(a, b);
            double d = 0;
            double c = (a + b) / 2;
            for (int i = 0; i < 1000; i++)
            {
                d = c - ((func2(c) * func2(c)) / ((func2(c + func2(c))) - func2(c)));
                if (Math.Abs(func2(d)) <= accurecy)
                    break;
                else
                    c = Math.Abs(d);
            }
            Console.WriteLine("Root Using Steffensen's Method is : " + d);
        }

        //SecantMethod

        static void secentMethod(double a, double b)
        {
            IntervalChecker(a, b);
            double c = 0;
            while (Math.Abs(b - a) >= accurecy)
            {
                c = a - (func(a) * ((b - a) / (func(b) - func(a))));
                if (func(c) == 0.0)
                    break;
                else
                a = b;
                b = c;
            }
            Console.WriteLine("Root Using SecantMethod Method is : " + c);
        }

        //main program
        public static void Main()
        {
            double a=-2, b=3, c=5, xstart = -1.5;
            //bisection(a, b);
            //regulaFalsi(a, b);
            //newtonRaphson(xstart);
            //halleys(xstart);
            //muller(a, b, c);
            //FixedPoint(a, b);
            //steffensenMethod(a, b);
            //secentMethod(a, b);

        }
    }
}
