using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm16_Practice
{
	/// <summary>
	/// Up & Down 게임 만들기
	/// </summary>
	internal class UpAndDown
	{
		/* [게임 규칙]
		 * 1.	컴퓨터는 0~999 중에 랜덤한 숫자를 뽑는다.
		 * 2.	유저는 10번의 기회가 있다.
		 * 3.	플레이어가 수를 입력 하면 컴퓨터는 그 수가 큰지, 작은지, 정답인지 알려준다.
		 * 4.	10번의 기회 소진시 게임을 종료할껀지 재시작 할껀지 선택 할수 있다.
		 */

		public void DoPlay()
		{
			while (true)
			{
				int answerNum = GetRandomNum();

				for (int i = 0; i < 10; i++)
				{
					Console.Write("입력 : ");
					int num = int.Parse(Console.ReadLine());

					if (answerNum == num)
					{
						Console.WriteLine("정답!!");
						break;
					}
					else
					{
						Console.WriteLine(answerNum - num > 0 ? "UP" : "DOWN");
					}
				}

				Console.Write("게임을 다시 시작하려면 R키를 눌러주세요.");
				var inputKey = Console.ReadKey().Key;

				if (inputKey != ConsoleKey.R)
				{
					break;
				}

				Console.WriteLine("\n\n☆★☆★☆★게임 다시 시작!★☆★☆★☆");
				Console.WriteLine("컴퓨터가 새로운 숫자를 선택합니다.!! \n");
			}
			Console.WriteLine("게임 종료!!~");
		}

		private int GetRandomNum()
		{
			Random randomObj = new Random();
			return randomObj.Next(0, 1000);
		}

	}
}
