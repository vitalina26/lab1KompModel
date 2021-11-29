using System;


namespace lab1KompModel
{
    class Program
    {
        static int SimpsRunk = 4;
        static double epsilon = 0.0001;
        static double a = 1;
        static double b = Math.Pow((Math.PI/ epsilon) - 1, 1.0 / 3);
        static double f(double x)
        {
            return Math.Atan(x) / (1 + x * x * x);
        }
        static double x(double i, double h)
        {

            return a + (h * i);
        }
        static double I(double h, int n)
        {
            double sum_odd = 0;
            double sum_pair = 0;
            for (int i = 1; i <= n/2 ; i++)
            {
                sum_odd += f(x((2 * i - 1), h));
                sum_pair += f(x((2 * i), h));

            }
            return h * (f(a) + 2 * sum_pair + 2 * sum_odd + f(b) ) / 3;
        }  
        static void Main(string[] args)
        {
            double  Ih, Ih_twice_less;
            bool condition = true;
            int n = 4;
            double h = (b - a) / n;
            double RoungeMistake;

            while (condition)
            {
                
                Ih = I(h, n);
                Ih_twice_less = I(h/2, 2*n);
                RoungeMistake = Math.Abs(Ih_twice_less - Ih) / (Math.Pow(2, SimpsRunk) - 1 );
                if (RoungeMistake <= epsilon/2 )
                {
                    Console.WriteLine($" \n Approximate value of the integral : { Ih_twice_less }" +
                        $" \n calculated to the nearest 0.0001 (by approximating the integral with a step : { h/2 }) " +
                        $" \n and mistake according to Rung's rule : { RoungeMistake } \n ");
                    condition = false;
                }
                else
                {
                    Console.WriteLine($"Approximate value of the integral  : { Ih_twice_less } (by approximating the integral with a step : { h / 2 } )" +
                        $" \n and mistake according to Rung's rule : { RoungeMistake } ");
                    n *= 2;
                    h /= 2;
                }

            }
        }
    }
}
