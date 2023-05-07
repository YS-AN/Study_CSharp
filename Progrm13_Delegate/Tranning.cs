using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm13_Delegate
{
	internal class Tranning
	{
		public void StartTraining0410()
		{
			Practice p = new Practice();
			p.Test();

			int[] arr_int = { 3, -2, 1, -4, 9, -8, 7, -6, 5 };
			float[] arr_float = { 1.56f, 2.72f, 3.91f, 4.35f, 5.79f };
			double[] arr_double = { 1.87d, 2.333d, 3.432d, 4.64756d, 5.2134d };

			SortArr<int> s1 = new SortArr<int>();
			s1.Sort(arr_int, s1.OrderByDesc);
			s1.PrintArr(arr_int);

			SortArr<float> s2 = new SortArr<float>();
			s2.Sort(arr_float, s2.OrderByDesc);
			s2.PrintArr(arr_float);

			SortArr<double> s3 = new SortArr<double>();
			s3.Sort(arr_double, s3.OrderByDesc);
			s3.PrintArr(arr_double);

			s1.Sort(arr_int, s1.OrderByAsc);
			s1.PrintArr(arr_int);

			s2.Sort(arr_float, s2.OrderByAsc);
			s2.PrintArr(arr_float);

			s3.Sort(arr_double, s3.OrderByAsc);
			s3.PrintArr(arr_double);
		}
	}

	public class Practice
	{
		//배열 복사 함수
		private T[] CopyArray<T>(T[] arr)
		{
			return (T[])arr.Clone();
		}

		private void PrintArr<T>(T[] arr)
		{
			foreach (var item in arr)
			{
				Console.Write($"{item}\t");
			}
			Console.WriteLine();
		}


		//델리게이트 정의
		public delegate void DelegateMethod1(float param1, float param2);

		//델리게이트 변수 생성
		public DelegateMethod1 delegate1;

		public void plus(float x, float y) { Console.WriteLine($"{x} + {y} = {x + y}"); } //더하기

		public void Minus(float x, float y) { Console.WriteLine($"{x} - {y} = {x - y}"); } //빼기

		public void Multi(float x, float y) { Console.WriteLine($"{x} x {y} = {x * y}"); } //곱하기

		public void Divide(float x, float y) { Console.WriteLine($"{x} / {y} = {x - y}"); } //나누기


		//대리자 지정자 이용해서 정렬
		public delegate int Compare(int left, int right);

		//정렬
		public void Sort(int[] array, Compare compare)
		{
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = i; j < array.Length; j++)
				{
					if (compare(array[i], array[j]) > 0)
					{
						int temp = array[i];
						array[i] = array[j];
						array[j] = temp;
					}
				}
			}
		}

		// 오름차순 정렬
		public int OrderByAsc(int a, int b)
		{
			return a - b;
		}

		// 내림차순 정렬
		public int OrderByDesc(int a, int b)
		{
			return b - a;
		}

		// 절대값 오름차순 정렬
		public int OrderByAbsAsc(int a, int b)
		{
			return OrderByAsc(Math.Abs(a), Math.Abs(b));
		}

		// 절대값 오름차순 정렬
		public int OrderByAbsDesc(int a, int b)
		{
			return OrderByDesc(Math.Abs(a), Math.Abs(b));
		}



		public void Test()
		{
			int[] arr_int = { 3, -2, 1, -4, 9, -8, 7, -6, 5 };
			float[] arr_float = { 1.56f, 2.72f, 3.91f, 4.35f, 5.79f };
			double[] arr_double = { 1.87d, 2.333d, 3.432d, 4.64756d, 5.2134d };
			string[] arr_string = { "안녕하세요", "감사해요", "잘있어요", "다시만나요" }, new_sArr = null;

			//일반화 이용 -> 배열 복사
			PrintArr(CopyArray(arr_int));
			PrintArr(CopyArray(arr_float));
			PrintArr(CopyArray(arr_double));
			new_sArr = CopyArray(arr_string);
			new_sArr[0] = "안녕히가세요!";

			PrintArr(arr_string);
			PrintArr(new_sArr);
			Console.WriteLine();

			//대리자 이용, 함수 대리 호출
			delegate1 = plus;
			delegate1.Invoke(20, 10);

			//델리게이트 체인 활용, 여러 함수 한번에 호출
			delegate1 += Minus;
			delegate1 += Multi;
			delegate1 += Divide;
			delegate1(11.75f, 51.239f);
			Console.WriteLine();

			//대리자 지정자 활용, 오름차순과 내림차순 정렬
			int[] sortArr1 = CopyArray(arr_int);
			Console.Write("오름차순 정렬 : ");
			Sort(sortArr1, OrderByAsc);
			PrintArr(sortArr1);

			Console.Write("내림차순 정렬 : ");
			Sort(sortArr1, OrderByDesc);
			PrintArr(sortArr1);

			Console.Write("절대값 + 오름차순 정렬 : ");
			Sort(sortArr1, OrderByAbsAsc);
			PrintArr(sortArr1);

			Console.Write("절대값 + 내림차순 정렬 : ");
			Sort(sortArr1, OrderByAbsDesc);
			PrintArr(sortArr1);
			Console.WriteLine();

			//Array.Sort에 지정자 활용
			int[] sortArr2 = CopyArray(arr_int);
			Array.Sort(sortArr2, (a, b) => b > a ? 1 : -1);
			PrintArr(sortArr2);
			Array.Sort(sortArr2, (a, b) => b > a ? b * -1 : a);
			PrintArr(sortArr2);
			Console.WriteLine();

			//Array.FindIndex에 지정자 활용
			int index = Array.FindIndex(sortArr2, x => x > 0); //0보다 큰 수 찾음
			Console.WriteLine($"arr[{index}] = {sortArr2[index]}");
			Console.WriteLine();
		}

	}


	//비교가능한 자료형의 배열을 매개변수로 받으며, 지정자를 매개변수로 받아 어떤자료형이든 원하는 기준으로 정렬시킬수 있는 정렬 함수 구현
	public class SortArr<T> where T : IComparable<T>, IConvertible
	{
		public delegate bool Compare(T a, T b);

		//정렬
		public void Sort(T[] array, Compare compare)
		{
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = i; j < array.Length; j++)
				{
					if (compare(array[i], array[j]))
					{
						T temp = array[i];
						array[i] = array[j];
						array[j] = temp;
					}
				}
			}
		}

		// 오름차순 정렬
		public bool OrderByAsc(T a, T b)
		{
			return a.CompareTo(b) > 0;
		}

		// 내림차순 정렬
		public bool OrderByDesc(T a, T b)
		{
			return a.CompareTo(b) < 0;
		}

		public void PrintArr(T[] arr)
		{
			foreach (var item in arr)
			{
				Console.Write($"{item}\t");
			}
			Console.WriteLine();
		}
	}
}
