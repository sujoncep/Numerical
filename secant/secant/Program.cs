using System;

namespace secant
{
    class Secent
    {
        static float Accuracy = (float)0.0001;


        static double fun(double x)
        {
            return x * x * x -x- 1;
        }


        static void secent(double a,
                              double b)
        {
            if (a > b || fun(a) * fun(b) >= 0)
            {
                Console.WriteLine("Invalid Input");
                return;
            }

            double c = 0;
            while (Math.Abs(b - a) >= Accuracy)
            {

                c = a - (fun(a) * ((b - a) / (fun(b) - fun(a))));


                if (fun(c) == 0.0)
                    break;


                else
                    a = b;
                b = c;

            }


            Console.WriteLine("The value of " +
                              "root is : " + c);
        }


        static public void Main()
        {

            double a = -3, b = 2;
            secent(a, b);
        }
    }
}
