using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm16_Practice
{
	/// <summary>
	/// 사용자가 입력한 양의 정수의 각 자리수의 합을 구하는 Solution 을 완성하라.
	/// </summary>
	internal class DigitalSum
	{
		public void DoDigitalSum()
		{
			Console.Write("입력 : ");
			int num = int.Parse(Console.ReadLine());
			Console.WriteLine($"출력 : {SumOfDigits(num)}");
		}

		private int SumOfDigits(int num)
		{
			int max = Convert.ToInt32(Math.Pow(10, (num.ToString().Length - 1)));
			int sum = 0;

			for (; max >= 1;)
			{
				int val = num / max;
				sum += val;
				num -= Convert.ToInt32((val * max));

				max /= 10;
			}
			return sum;
		}
	}
}
