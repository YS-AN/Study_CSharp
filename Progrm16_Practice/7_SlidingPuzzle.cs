using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm16_Practice
{
	/// <summary>
	/// 슬라이드 퍼즐 만들기
	/// </summary>
	internal class SlidingPuzzle
	{
		/* [게임 규칙]
		 * 1.	5x5 판을 생성하고 랜덤한 숫자를 배치한다.
		 * 2.	시작위치는 상관없으며 ArrowKey입력시 해당 방향으로 이동한다.
		 * 3.	단, 밖으로 벗어날 수 없다.
		 * 4.	아래 예시는 0이 움직이는 것으로 가정한다.
		*/

		const int LEN = 5;

		public void DoPlay()
		{
			int[,] map = SetMap();
			PrintMap(map);

			(int, int) currentPoint = (LEN - 1, LEN - 1);
			Direction direction = Direction.None;

			while (true)
			{
				direction = GetInputKey();
				currentPoint = Move(direction, map, currentPoint);

				if (IsFinishedGame(map))
				{
					PrintMap(map);
					Console.WriteLine("\n 게임 종료!!");
					break;
				}
				PrintMap(map);
			}

		}

		enum Direction
		{
			Left,
			UP,
			Right,
			Donw,
			None
		}

		/// <summary>
		/// 맵 생성
		/// </summary>
		/// <returns></returns>
		private int[,] SetMap()
		{
			int max = LEN * LEN;
			int lastIndex = max - 1;
			int[] setNum = new int[max];

			for (int i = 1; i < max; i++)
			{
				int index = GetRandomNum(0, lastIndex);

				while (setNum[index] != 0)
				{
					index = GetRandomNum(0, lastIndex);
				}
				setNum[index] = i;
			}

			int k = 0;
			int[,] map = new int[LEN, LEN];
			for (int i = 0; i < LEN; i++)
			{
				for (int j = 0; j < LEN; j++)
				{
					map[i, j] = setNum[k++];
				}
			}
			return map;
		}

		/// <summary>
		/// 맵에 들어갈 숫자를 랜덤으로 가져옴
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		private int GetRandomNum(int min, int max)
		{
			Random randomObj = new Random();
			return randomObj.Next(min, max);
		}

		/// <summary>
		/// 맵 출력
		/// </summary>
		/// <param name="map"></param>
		private void PrintMap(int[,] map)
		{
			Console.Clear();

			for (int i = 0; i < LEN; i++)
			{
				for (int j = 0; j < LEN; j++)
				{
					Console.Write(string.Format("{0}\t", map[i, j]));
				}
				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine();
			}
			Console.WriteLine("← : 왼쪽 / → : 오른쪽 / ↑ : 위쪽 / ↓ : 아래쪽");
		}

		/// <summary>
		/// 방향키값 받아오기
		/// </summary>
		/// <returns></returns>
		private Direction GetInputKey()
		{
			Direction direction = Direction.None;

			while (direction == Direction.None)
			{
				var inputKey = Console.ReadKey().Key;
				direction = ConvertKey(inputKey);
			}

			return direction;
		}

		/// <summary>
		/// 방향 키 값을 enum 값으로 변경함
		/// </summary>
		/// <param name="consoleKey">입력한 키 값</param>
		/// <returns></returns>
		private Direction ConvertKey(ConsoleKey consoleKey)
		{
			int keyNum = (int)consoleKey;

			if (keyNum < 37 || keyNum > 40)
			{
				return Direction.None;
			}
			return (Direction)keyNum - 37;
		}

		/// <summary>
		/// 맵 움직임 동작 구현
		/// </summary>
		/// <param name="direction">방향키</param>
		/// <param name="map">맵</param>
		/// <param name="currentPoint">현재 위치</param>
		/// <returns>움직인 이후의 현재 위치를 반환</returns>
		private (int, int) Move(Direction direction, int[,] map, (int, int) currentPoint)
		{
			int currentVal = map[currentPoint.Item1, currentPoint.Item2];
			int x = currentPoint.Item1;
			int y = currentPoint.Item2;

			switch (direction)
			{
				case Direction.UP:
					x = (x - 1) < 0 ? x : x - 1;
					break;
				case Direction.Donw:
					x = (x + 1) >= LEN ? x : x + 1;
					break;
				case Direction.Left:
					y = (y - 1) < 0 ? y : y - 1;
					break;
				case Direction.Right:
					y = (y + 1) >= LEN ? y : y + 1;
					break;
			}

			if (currentVal != map[x, y])
			{
				map[currentPoint.Item1, currentPoint.Item2] = map[x, y];
				map[x, y] = currentVal;
			}

			return (x, y);
		}

		/// <summary>
		/// 게임이 종료 되었는지 확인함.
		/// </summary>
		/// <param name="map"></param>
		/// <returns></returns>
		private bool IsFinishedGame(int[,] map)
		{
			int max = LEN * LEN;
			int[] result = Changed2to1(map);

			if (result[0] != 1) { return false; }
			else if (result[max - 1] != 0) { return false; }
			else if (result[max - 2] != max - 1) { return false; }
			else
			{
				for (int i = 1; i < result.Length - 2; i++)
				{
					if (result[i] + 1 != result[i + 1])
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>
		/// 2차원 배열을 1차원 배열로 변경
		/// </summary>
		/// <param name="map"></param>
		/// <returns></returns>
		private int[] Changed2to1(int[,] map)
		{
			int max = LEN * LEN;
			int[] result = new int[max];
			int index = 0;

			for (int i = 0; i < LEN; i++)
			{
				for (int j = 0; j < LEN; j++)
				{
					result[index++] = map[i, j];
				}
			}

			return result;
		}
	}
}
