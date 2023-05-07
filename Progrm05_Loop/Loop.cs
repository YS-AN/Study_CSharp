using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm05_Loop
{
	/// <summary>
	/// 반복문
	/// </summary>
	internal class Loop
	{
		public void StudyLoop()
		{
			int n = 0; 
			while (n < 5)
			{
				Console.WriteLine($"[while] 반복문 반복 n : {(n++)}");
			}
			Console.WriteLine();

			do
			{
				//n이 5이지만 do while은 일단 실행 후 조건 체크이기 때문에 출력 됨. 
				Console.WriteLine($"[do ~ while] 반복문 반복 n : {(n++)}");
			} while (n < 5);
			Console.WriteLine();

			//for문
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine($"[for] 반복문 반복 i : {i}");
			}
			Console.WriteLine();

			//foreach문
			int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			foreach(int item in arr)
			{
				Console.WriteLine($"[foreach] 현재요소 : {item}");
			}
			Console.WriteLine();

			//break문 - 가장 가까운 반복문 즉시 종료
			//소수 찾기 -> 나눠 떨어지는 값이 나오면 소수가 아님 > break;
			int primeNumber = 7;
			for (n = 2; n <primeNumber; n++)
			{
				if(primeNumber % n == 0)
				{
					Console.WriteLine($"n = {n} -> 소수가 아닙니다. \n");
					break;
				}
			}
			if (primeNumber == n) { Console.WriteLine($"{primeNumber}는 소수입니다. \n"); }

			//continue문 - 가장 가까운 반복문 처음으로 이동 
			//홀수일 때만 작업
			n = 0;
			while(n < 100)
			{
				if(n % 2 == 0) { continue; }

				//todo.홀수일 때만 할 작업 
			}

		}
	}
}
