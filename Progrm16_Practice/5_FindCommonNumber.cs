using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm16_Practice
{
	/// <summary>
	/// k개의 정렬된 배열에서 공통항목을 찾는 Solution을 완성하라. 
	/// 단, 중복은 허용하지 않는다.
	/// </summary>
	internal class FindCommonNumber
	{
		public void DoFindCommonNumber()
		{
			int[] arr1 = { 1, 5, 5, 10 };
			int[] arr2 = { 3, 4, 5, 5, 10 };
			int[] arr3 = { 5, 5, 10, 20 };

			int[] answer = FindCommonItems(arr1, arr2, arr3);
			Console.WriteLine(string.Join(", ", answer));
		}
		private int[] FindCommonItems(int[] arr1, int[] arr2, int[] arr3)
		{
			int[] compareArr = GetCommonValue(arr1, arr2);
			return GetCommonValue(compareArr, arr3);
		}

		private int[] GetCommonValue(int[] arr1, int[] arr2)
		{
			return arr1.Distinct().Where(x => arr2.Contains(x)).ToArray();
		}

	}
}
