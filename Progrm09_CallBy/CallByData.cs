using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm09_CallBy
{
	/// <summary>
	/// call by value, call by reference 차이
	/// </summary>
	internal class CallByData
	{
		public void StudyCallBy()
		{
			ValueType valueType1 = new ValueType() { value = 10 };
			ValueType valueType2 = valueType1; //값 복사

			valueType2.value = 20;
			Console.WriteLine(valueType1.value); //valueType2의 변수를 변경해도 valueType1에 영향일 미치지 않음

			RefType refType1 = new RefType() { value = 10 };
			RefType refType2 = refType1; //주소 복사

			refType2.value = 20;
			Console.WriteLine(refType1.value); //refType2의 변수를 변경했더니 refType1의 변수까지도 변경이 됨.
		}
	}


	//구조체 - 값 형식
	struct ValueType
	{
		public int value;
	}

	//클래스 - 참조형식
	class RefType
	{
		public int value;
	}


	/// <summary>
	/// 정적 (static)
	/// </summary>
	public class StaticArea
	{
		public static void StudyStatic()
		{
			StaticClass1 s1 = new StaticClass1();
			StaticClass1 s2 = new StaticClass1();

			//StaticClass2 s3 = new StaticClass2(); 
			//static 클래스는 이미 데이터 영역에 할당 받아있기 때문에 new를 통해 생성하지 않음
			//단 하나의 클래스라는게 이런 의미임. 인스턴스 생성 못함 > 여러 개가 될 수 없음

			//s1.staticInt = 1; //오류 : 일반 클래스 안에 있는 static변수는 단 하나이기 때문에 인스턴스로 접근할 수 없음. 클래스에시 직접적으로 변수를 호출 함
			StaticClass1.staticInt = 1;

			s1.nonStaticInt = 1;
			//StaticClass1.nonStaticInt = 1; //오류 : static이 아닌 변수는 클래스에서 직접적으로 변수를 호출할 수 없음 
		}
	}

	class StaticClass1
	{
		public static int staticInt;
		public int nonStaticInt;
	}

	static class StaticClass2
	{
		public static int staticInt;
		//public int nonStaticInt; 
		//오류 : static클래스에서는 static변수나 함수만 사용 가능. 무조건 static가 붙어야 함.
	}

	/// <summary>
	/// ref, out 키워드
	/// </summary>
	public class ConvertValtoRef
	{
		private void Swap(int left, int right)
		{
			int temp = left;
			left = right;
			right = temp;
		}

		private void Swap(ref int left, ref int right)
		{
			int temp = left;
			left = right;
			right = temp;
		}

		private void SetLeft(out int left)  // 출력 전용 매개변수, 참조형식으로 원본이 변경됨
		{
			left = 11; //반드시 값을 할당해야함
		}

		private void printBefore(int left, int right)
		{
			Console.Write($"left {left}, right : {right} -> SWAP -> ");
		}

		public void pirntSwap()
		{
			int left = 10;
			int right = 20;

			printBefore(left, right);
			Swap(left, right);
			Console.WriteLine($"left {left}, right : {right}");

			printBefore(left, right);
			Swap(ref left, ref right);
			Console.WriteLine($"left {left}, right : {right}"); //메소드 변경 값이 영향을 받음

			Console.Write($"left {left} -> SET LEFT -> ");
			SetLeft(out left);
			Console.WriteLine($"left {left}"); //메소드 변경 값이 영향을 받음
		}
	}


}
