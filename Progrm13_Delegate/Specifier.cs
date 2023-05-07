using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm13_Delegate
{
	/// <summary>
	/// 델리게이트 - 대리자
	/// </summary>
	internal class Specifier
	{
		//대리자의 지정자로 사용

		public delegate int Compare(int left, int right); //미완성 상태의 함수로 만들어 둠

		// Bubble 정렬 알고리즘
		//매개변수로 델리게이트 지정자를 받음 -> 메소드 선언 당시에는 compare가 무슨 동작을 하는지 알 수 없음. -> compare에 어떤 행동을 할지를 담은 함수를 넘겨 줌. 
		public void Sort(int[] array, Compare compare)
		{
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = i; j < array.Length; j++)
				{
					if (compare(array[i], array[j]) > 0) //매개변수를 전달, 
					{
						int temp = array[i];
						array[i] = array[j];
						array[j] = temp;
					}
				}
			}
		}

		// 오름차순 정렬
		public int AscendingOrder(int left, int right)
		{
			return left - right;
		}

		// 내림차순 정렬
		public int DescendingOrder(int left, int right)
		{
			return right - left;
		}

		// 절대값 정렬
		public int AbsoluteOrder(int left, int right)
		{
			return DescendingOrder(Math.Abs(left), Math.Abs(right));
		}

		public void PrintArray(int[] array)
		{
			foreach (int item in array) { Console.Write($"{item}\t"); }
			Console.WriteLine();
		}

		public void Test()
		{
			int[] array = { 3, -2, 1, -4, 9, -8, 7, -6, 5 };

			//함수 자체를 넘겨주면서 함수를 완성 시킴
			Sort(array, AscendingOrder); PrintArray(array);
			Sort(array, DescendingOrder); PrintArray(array);
			Sort(array, AbsoluteOrder); PrintArray(array);
		}
	}
}
