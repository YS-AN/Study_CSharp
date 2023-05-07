using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm06_Function
{
	internal class Tranning
	{
		public void StartTraining0330()
		{
			int num1 = 24;
			int num2 = 40;

			Console.WriteLine($"{num1}, {num2} 중 더 큰 수는 {GetBigger(num1, num2)}\n");
			Console.WriteLine($"[3,5,1,9,4] 중 최대값은 {GetMaxNum(new int[] { 3, 5, 1, 9, 4 })}\n");
			Console.WriteLine($"{num1}, {num2}의 최대 공약수는 {GetGCD(num1, num2)}\n");
			Console.WriteLine($"{num1}, {num2}의 최소 공배수는 {GetLCM(num1, num2)}\n");

			bool cmpVal = ListAverCompare(new int[] { 5, 1, 8, 2, 4 }, new int[] { 3, 5, 1, 9, 4 });
			Console.WriteLine($"왼쪽이 더 큰가요? {cmpVal}\n");

			PlayBullsAndCows();
		}

		//1. 두 정수 중 더 큰 수 반환
		private int GetBigger(int left, int right)
		{
			return left > right ? left : right; //두 수를 비교해서 큰 수를 반환
		}

		//2. 최대값을 반환 
		private int GetMaxNum(int[] arr)
		{
			//n과 n+1~Length까지 비교하는 하면서 큰 수를 찾아내는 방식
			//0번 : 1~Length까지 비교
			//1번 : 2~Length까지 비교
			// ...
			//n번 : n+1~Length까지 비교

			int maxVal = 0;

			for (int i = 0; i < arr.Length - 1; i++)
			{
				for (int j = i + 1; j < arr.Length; j++)
				{
					maxVal = arr[i] > arr[j] ? arr[i] : arr[j]; //두 수를 비교해서 큰 수를 maxVal에 넣어줌 
				}
			}

			return maxVal;
		}

		//3. 두 수의 최대 공약수 (유클리드 호제법)
		//유클리드 호제법
		//	: 2개의 자연수(또는 정식) a, b에 대해서 a를 b로 나눈 나머지를 r이라 하면(단, a>b), a와 b의 최대공약수는 b와 r의 최대공약수와 같다. 
		private int GetGCD(int num1, int num2)
		{
			int max = num1 > num2 ? num1 : num2;
			int min = num1 < num2 ? num1 : num2;
			int mod = max;

			while (mod != 0)
			{
				mod = max % min;
				max = min;
				min = mod;
			}
			return max;
		}

		//4 두 수의 최소 공배수 (최소공배수 = 두수의 곱 / 최대 공약수)
		private int GetLCM(int num1, int num2)
		{
			int gcd = GetGCD(num1, num2); //최대 공약수는 유클리드 호제법 활용
			return (num1 * num2) / gcd;
		}

		//5.두 배열의 평균 비교, 왼쪽이 크면 true, 작은 경우 false
		private int GetAverage(int[] arr)
		{
			int sum = 0;
			//전체 배열을 돌면서 배열 전체의 합을 구한다.
			foreach (int item in arr)
			{
				sum += item;
			}

			return sum / arr.Length; //배열의 합에서 배열의 개수를 나누면 평균이 나온다 (배열 길이 = 배열 개수)
		}

		private bool ListAverCompare(int[] leftArr, int[] rightArr)
		{
			//두 수의 평균을 구한다.
			int leftAvg = GetAverage(leftArr);
			int rightAvg = GetAverage(rightArr);

			return (leftAvg > rightAvg); //부등호도 논리 연산자라 결과 값이 bool 형식으로 리턴된다.
		}

		//6.숫자 야구 게임 함수로 정리하기
		const int NUM_CNT = 4; //야구 개임 전체 공 개수
		private void PlayBullsAndCows()
		{
			int[] inputNums = GetBallNumer();

			Console.WriteLine("\n☆★☆★숫자야구 게임 시작☆★☆★");
			Console.WriteLine("\n숫자 입력 시 반드시 콤마로 구분해주세요!!!");
			//Console.WriteLine($"{inputNums[0]} / {inputNums[1]} / {inputNums[2]} / {inputNums[3]}");

			while (true)
			{
				Console.Write("숫자 입력 : ");
				int[] answers = Convert_IntArray(Console.ReadLine().Split(",", StringSplitOptions.TrimEntries));


				bool[] strkPnt = { false, false, false, false };
				int strkCnt = GetStrike(inputNums, answers, strkPnt);

				if (strkCnt == NUM_CNT)
				{
					Console.WriteLine("☆★☆★[4S] 게임 종료!!★☆★☆ ");
					break;
				}

				int ballCnt = GetBallCnt(inputNums, answers, strkPnt);

				PrintResult(ballCnt, strkCnt);
			}
		}

		/// <summary>
		/// 랜덤으로 숫자 값을 받아옴
		/// </summary>
		/// <returns></returns>
		private int[] GetBallNumer()
		{
			Random rand = new Random();
			int[] balls = new int[NUM_CNT];

			for (int i = 0; i < NUM_CNT; i++)
			{
				int random_number = rand.Next(100) + 1;

				for (int j = 0; j < i; j++)
				{
					if (balls[j] == random_number)
					{
						random_number = rand.Next(100) + 1;
						j = 0;
					}
				}

				balls[i] = random_number;
			}

			return balls;
		}

		/// <summary>
		/// 입력된 문자를 숫자형으로 변환함
		/// </summary>
		/// <param name="arr">사용자 입력 값</param>
		/// <returns></returns>
		private int[] Convert_IntArray(string[] arr)
		{
			int[] retArr = new int[arr.Length];

			for (int i = 0; i < arr.Length; i++)
			{
				retArr[i] = int.Parse(arr[i]);
			}
			return retArr;
		}

		/// <summary>
		/// 입력된 숫자 중 스트라이크 개수를 확인해 반환
		/// </summary>
		/// <param name="inputNums">랜덤으로 받은 수</param>
		/// <param name="answers">사용자 입력 값</param>
		/// <param name="strkPnt">스트라이크 여부</param>
		/// <returns></returns>
		private int GetStrike(int[] inputNums, int[] answers, bool[] strkPnt)
		{
			int strkCnt = 0;
			for (int i = 0; i < NUM_CNT; i++)
			{
				if (answers[i] == inputNums[i])
				{
					strkCnt += 1;
					strkPnt[i] = true;
				}
			}
			return strkCnt;
		}

		/// <summary>
		/// 입력된 숫자 중 볼 개수를 확인해 반환
		/// </summary>
		/// <param name="inputNums">랜덤으로 받은 수</param>
		/// <param name="answers">사용자 입력 값</param>
		/// <param name="strkPnt">스트라이크 여부</param>
		/// <returns></returns>
		private int GetBallCnt(int[] inputNums, int[] answers, bool[] strkPnt)
		{
			int ballCnt = 0;
			for (int i = 0; i < NUM_CNT; i++)
			{
				if (strkPnt[i] == false)
				{
					for (int j = 0; j < NUM_CNT; j++)
					{
						if (answers[i] == inputNums[j])
						{
							ballCnt++;
							break;
						}
					}
				}
			}
			return ballCnt;
		}

		/// <summary>
		/// 결과 값 출력
		/// </summary>
		/// <param name="ballCnt">볼 개수</param>
		/// <param name="sprkCnt">스트라이크 개수</param>
		private void PrintResult(int ballCnt, int sprkCnt)
		{
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
