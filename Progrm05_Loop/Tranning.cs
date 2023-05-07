using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm05_Loop
{
	/// <summary>
	/// 조건문과 연산문 실습
	/// </summary>
	internal class Tranning
	{
		public void StartTraining0329()
		{
			//1.두 수를 비교해 더 큰 수 출력******
			Console.Write("정수 입력 : ");
			int num1 = int.Parse(Console.ReadLine());

			Console.Write("정수 입력 : ");
			int num2 = int.Parse(Console.ReadLine());

			Console.WriteLine($"더 큰 수는 {(num1 > num2 ? num1 : num2)}입니다.\n");


			//2.시험점수 입력 받아, 등급(A~F)로 출력 
			Console.Write("\n점수를 입력 : ");
			num1 = int.Parse(Console.ReadLine());

			if (num1 >= 90) { Console.WriteLine("A"); }
			else if (num1 >= 80) { Console.WriteLine("B"); }
			else if (num1 >= 70) { Console.WriteLine("C"); }
			else if (num1 >= 60) { Console.WriteLine("D"); }
			else { Console.WriteLine("F"); }
			Console.WriteLine();

			//3. 구구단 프로그램 (2~9단)
			for (int i = 2; i <= 9; i++)
			{
				for (int j = 1; j <= 9; j++)
				{
					Console.WriteLine($"{i} X {j} = {(i * j)}");
				}
				Console.WriteLine();
			}
			Console.WriteLine();


			//4.동전 교환기 
			Console.Write("동전교환기 입니다^^ 금액을 입력해주세요 : ");
			num1 = int.Parse(Console.ReadLine());
			int[] coins = { 500, 100, 50, 10 };
			int[] change_coin = new int[4];
			for (int i = 0; i < 4; i++)
			{
				change_coin[i] = num1 / coins[i];
				num1 -= change_coin[i] * coins[i];
			}

			for (int i = 0; i < 4; i++)
			{
				if (change_coin[i] > 0)
				{
					Console.Write($"{coins[i]}원 : {change_coin[i]}개 \t"); //교환된 금액 출력
				}
			}
			Console.WriteLine("\n");

			//5.별찍기
			//5-1
			string starts = "*****";
			for (int i = 1; i <= 5; i++)
			{
				Console.WriteLine($"{starts.Substring(0, i)} ");
			}
			Console.WriteLine();

			//5-2
			for (int i = 5; i >= 1; i--)
			{
				Console.WriteLine($"{starts.Substring(0, i)} ");
			}
			Console.WriteLine();

			//5-3
			string space = "    ";
			for (int i = 1; i <= 5; i++)
			{
				Console.WriteLine($"{space.Substring(0, (5 - i))}{starts.Substring(0, i)}");
			}
			Console.WriteLine("");

			//6.숫자야구
			const int LEN = 4;
			Console.WriteLine("숫자야구 숫자 입력! 숫자사이에 콤마를 입력해주세요! (ex. 1,2,3,4)");
			Console.Write("숫자 입력 : ");
			string[] inputNums = Console.ReadLine().Split(",", StringSplitOptions.TrimEntries);

			Console.WriteLine("\n☆★☆★숫자야구 게임 시작☆★☆★");
			while (true)
			{
				Console.Write("숫자 입력 : ");
				string[] answers = Console.ReadLine().Split(",", StringSplitOptions.TrimEntries);

				int ballCnt = 0;
				int sprkCnt = 0;
				bool[] sprkPnt = { false, false, false, false };

				for (int i = 0; i < LEN; i++)
				{
					if (answers[i] == inputNums[i])
					{
						sprkCnt += 1;
						sprkPnt[i] = true;
					}
				}
				if (sprkCnt == LEN)
				{
					Console.WriteLine("☆★☆★[4S] 게임 종료!!★☆★☆ ");
					break;
				}

				for (int i = 0; i < LEN; i++)
				{
					if (sprkPnt[i] == false)
					{
						for (int j = 0; j < LEN; j++)
						{
							if (answers[i] == inputNums[j])
							{
								ballCnt++;
								break;
							}
						}
					}
				}

				if (ballCnt == 0 && ballCnt == sprkCnt)
				{
					Console.WriteLine("아웃");
				}
				else
				{
					Console.WriteLine($"{sprkCnt}S, {ballCnt}B");
				}

			}
		}
	}
}
