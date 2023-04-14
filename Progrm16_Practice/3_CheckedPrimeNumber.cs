using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm16_Practice
{
	/// <summary>
	/// 주어진 숫자가 소수인지 판별하는 solution을 완성하라.
	/// </summary>
	internal class CheckedPrimeNumber
	{
		public void DoCheckedPrimeNumber()
		{
			Console.Write("입력 : ");
			int num = int.Parse(Console.ReadLine());
			PrintResult(num, IsPrime(num));

		}

		private bool IsPrime(int n)
		{
			for (int i = 2; i < n - 1; i++)
			{
				if (n % i == 0)
				{
					return false;
				}
			}
			return true;
		}

		private void PrintResult(int n, bool result)
		{
			Console.WriteLine($"{n} : {(result ? "소수" : "소수아님")}");
		}

	}
}
