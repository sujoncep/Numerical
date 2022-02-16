using System;

namespace NewtonRaf
{
    class Program
    {
        public delegate double F_x_(double x);

        static void Main(string[] args)
        {
            double xstart = -1.5;
            NewtonRaphson(xstart, new F_x_(Poly), new F_x_(DevPoly));

            Console.ReadKey();
        }

        static void NewtonRaphson(double startvalue, F_x_ XFunc, F_x_ DevXFunc)
        {
            const int cMaxIterations = 1000;

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetWindowSize(79, 30);

            double Xn, Xn1 = 0.0;
            string Title = "NEWTON-RAPHSON";
            Title = Title.PadRight(Console.WindowWidth);
            Console.WriteLine(Title);
            string linestr = string.Empty;
            linestr = linestr.PadRight(Console.WindowWidth, '-');
            Console.WriteLine(linestr);
            Console.WriteLine("| {0,-15}| {1,-15} | {2,-15} | {3,-15} |       ", "Iteration", "x", "f(x)", "f'(x)");
            Console.WriteLine(linestr);
            Console.WriteLine("|     {0,-10} | {1,15:0.00000} | {2,15:0.00000} | {3,15:0.00000} |       ", 0, startvalue, XFunc(startvalue), DevXFunc(startvalue));

            Xn = startvalue;

            for (int iter = 1; iter < cMaxIterations; iter++)
            {
                Xn1 = Xn - XFunc(Xn) / DevXFunc(Xn); 

                Console.WriteLine("|     {0,-10} | {1,15:0.00000} | {2,15:0.00000} | {3,15:0.00000} |       ", iter, Xn1, XFunc(Xn1), DevXFunc(Xn1));
                if (Math.Abs(Xn - Xn1) < 0.0000001)
                {
                    Console.WriteLine(linestr);
                    Console.WriteLine("Root = {0,15:0.00000}".PadRight(Console.WindowWidth), Xn1);
                    break;
                }
                else
                {
                    Xn = Xn1;
                }
            }
            Console.ResetColor();
        }

        static double Poly(double x)
        {
            return x * x * x - 5.0 * x + 5.0;
        }

        static double DevPoly(double x)
        {
            return 3.0 * x * x - 5.0;
        }
    }
}