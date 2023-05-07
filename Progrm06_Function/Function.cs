using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm06_Function
{
	/// <summary>
	/// 함수
	/// </summary>
	internal class Function
	{
		public void StudyFunction()
		{
			//반복된 작업 간소화 - 반환형 있음
			Console.WriteLine($"가한 데미지는 {TrueDamage(100, 1.2f, 12)}"); //함수호출
			Console.WriteLine($"가한 데미지는 {TrueDamage(100, 2.5f, 12)}");

			//반복된 작업 간소화 - 반환형 없음
			MakeFood("밀가루");
			MakeFood("버터");
			MakeFood("우유");

			int val = ChkReturnFunc1(); //val = 10, ∵ChkReturnFunc1가 10을 반환하기 때문
			ChkReturnFunc2();

			//메개변수에 따라 결과 값이 달라짐
			Console.WriteLine($"ADD : {Add(10, 20)}");   //ADD : 30
			Console.WriteLine($"ADD : {Add(100, 200)}"); //ADD : 300
			//Console.WriteLine($"ADD : {Add(.2f, 3.2f)}"); //오류. 매개변수는 자료형 맞춰야함

			Func3();

			Func4();
		}

		void Func1() { } //리턴값과 매개변수가 없는 함수 형태 + 접근제한자 생략
		int Func2(int a, int b) { return a + b; } //리턴값과 매개변수가 있는 형태

		//매개변수로 ap, buff, ammor을 받고, float로 반환을 하는 TrueDamage함수 정의
		float TrueDamage(int ap, float buff, int ammor)
		{
			float result;
			result = (ap * buff) - ammor;
			return result;
		}

		//매개변수 food를 받고, 값을 반환하지 않는 MakeFood함수 정의
		void MakeFood(string food)
		{
			Console.WriteLine($"\n{food} 뚜껑열어!!!!!!");
			Console.WriteLine($"{food} 투입!!!!!!!!!!");
			Console.WriteLine($"{food} 뚜껑닫아!!!!!!\n");
		}

		//함수 리턴 : 자료형
		int ChkReturnFunc1()
		{
			Console.WriteLine("RETURN 전"); 
			return 10; //10을 리턴하고, 함수를 종료함.
			Console.WriteLine("RETURN 후"); //return에서 함수가 완료되므로 실행되지 않음
		}

		//함수 리턴 : void
		void ChkReturnFunc2()
		{
			Console.WriteLine("RETURN 전");
			return;
			Console.WriteLine("RETURN 후"); 
			//void는 리턴이 필요하지 않지만, 그래도 return을 만나면 함수가 종료되기 때문에 수행되지 않음. 
		}

		int Add(int a, int b)
		{
			return a + b;
		}

		// 함수 호출스택
		// 호출 순서 : (1) -> (2) -> (7) -> (8) -> (9) -> (4) -> (5) -> (6) -> (10) -> (3)
		void Func3()
		{                                   // (1)
			Func3_2();                      // (2)
		}                                   // (3)
		void Func3_1()
		{									// (4)
			Console.WriteLine("Func3_1");   // (5)
			//Func3();
		}									// (6)
		void Func3_2()
		{									// (7)
			Console.WriteLine("Func3_2");	// (8)
			Func3_1();						// (9)
		}									// (10)

		
		//오버로딩
		void Func4()
		{
			Console.WriteLine(Minus(10, 5));
			Console.WriteLine(Minus(10, 5, 1));
			Console.WriteLine(Minus(1.1f, 0.3f));
			Console.WriteLine(Minus(1.1, 0.2));
		}

		int Minus(int num1, int num2) { return num1 - num2; }

		int Minus(int num1, int num2, int num3) { return num1 - num2 - num3; }

		float Minus(float num1, float num2) { return num1 - num2; }

		double Minus(double num1, double num2) { return num1 - num2; }
	}
}
