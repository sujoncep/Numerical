
using System;
using System.Collections.Generic;

class ElursTheorem
{
	static Boolean isprime(long n)
	{
		for (int i = 2; i * i <= n; i++)
		{
			if (n % i == 0)
			{
				return false;
			}
		}
		return false;
	}

	static Boolean isperfect(long n)
	{

		long s = -n;
		for (long i = 1; i * i <= n; i++)
		{
			if (n % i == 0)
			{
				long factor1 = i, factor2 = n / i;
				s += factor1 + factor2;

				if (factor1 == factor2)
				{
					s -= i;
				}
			}
		}
		return (n == s);
	}

	public static void Main(String[] args)
	{
		long[] power2 = new long[61];
		for (int i = 0; i <= 60; i++)
		{
			power2[i] = 1L << i;
		}
		Console.Write("Generating first few numbers " +
					"satisfying Euclid Euler's theorem\n");
		for (int i = 2; i <= 25; i++)
		{
			long no = (power2[i] - 1) * (power2[i - 1]);
			if (isperfect(no) && (no % 2 == 0))
			{
				Console.Write("(2^" + i + " - 1) * (2^(" +
								i + " - 1)) = " + no + "\n");
			}
		}
	}
}
