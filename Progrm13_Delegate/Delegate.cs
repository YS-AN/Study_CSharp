using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm13_Delegate
{
	/// <summary>
	/// 델리게이트
	/// </summary>
	internal class StudyDelegate
	{
		//델리게이트 정의
		public delegate float DelegateMethod1(float param1, float param2);
		public delegate void DelegateMethod2(string message);
		public delegate int DelegateMethod3(int param1, int param2);

		//델리게이트 변수 생성
		public DelegateMethod1 delegate1;
		public DelegateMethod2 delegate2;
		public DelegateMethod3 delegate3;


		public float plus(float x, float y) { return x + y; }

		public float Minus(float x, float y) { return x - y; }

		public float Multi(float x, float y) { return x * y; }

		public float Divide(float x, float y) { return x / y; }

		public void Message(string message) { Console.WriteLine(message); }

		//델리게이트 사용
		public void Test1()
		{
			delegate1 = new DelegateMethod1(plus); //델리게이트 인스턴스 생성 (근데 이렇게 new해서 생성하는 건 잘 안 쓰긴 함)
			delegate2 = Message; //델리게이트에 함수를 담아 둠

			//결과가 동일함 
			Console.WriteLine(plus(11.75f, 51.239f));
			Console.WriteLine(delegate1(11.75f, 51.239f));  // Plus(20, 10)과 같은 행동임을 알 수 있음

			delegate2("메시지11"); //델리게이트 간단하게 사용하는 방법임

			delegate1.Invoke(20, 10); //델리게이트 정석 방법 : invoke를 통해 호출해야 함.
			delegate2.Invoke("메시지22");

			//delegate3 = Minus; //오류 : 델리게이트에 함수를 넣을 때는 반환형과 매개변수가 일치하는 함수만 넣을 수 있음

			//delegate float DelegateMethod4(float param1, float param2);
			//오류 : 델리게이트도 함수의 일종이기 때문에 함수 안에서 생성 할 수 없음

			Console.WriteLine(Minus(11.75f, 51.239f));
			Console.WriteLine(Multi(11.75f, 51.239f));
			Console.WriteLine(Divide(11.75f, 51.239f));
		}

		//델리게이트 체인
		public delegate void DelegateChain();

		public void Func1() { Console.WriteLine("FUNC1"); }
		public void Func2() { Console.WriteLine("FUNC2"); }
		public void Func3() { Console.WriteLine("FUNC3"); }

		public void Test2()
		{
			Console.WriteLine("델리게이트 체인 생성");
			DelegateChain delegateChain;
			delegateChain = Func1;
			delegateChain += Func2; // Func2를 추가 할당
			delegateChain += Func3; // Func2를 추가 할당
			delegateChain(); //=> 추가 할당 후 델리게이트를 호출하면, 할당 순서대로 메소드가 호출 된다.

			Console.WriteLine("\n할당 했던 기능 제거");
			delegateChain -= Func2;
			delegateChain();

			Console.WriteLine("\n델리게이트에 할당되지 않은 함수 제거");
			delegateChain -= Func2; //할당되지 않은 함수 제거하려고 해도 오류 나지 않음 -> 없으면 안 빼감 
			delegateChain();

			Console.WriteLine("\n함수 중복 호출");
			delegateChain += Func1; //Func1가 두번 호출 됨
			delegateChain();

			Console.WriteLine("\n중복된 함수 중 하나를 제거한다면");// 가장 마지막에 등록 된 Func1이 제거 됨 (LIFO)
			delegateChain -= Func1;
			delegateChain();

			Console.WriteLine("\n=연산자를 통해 델리게이트에 할당");
			delegateChain = Func3; //=연산자는 덮어쓰기 개념임. -> 기존에 할당 되었던 체인이 다 사라지고 =으로 할당한 Func3만 남음
			delegateChain();
		}

		//일반화 델리게이트

		//Func 델리게이트
		Func<int, int, int> funcDelegate;
		int Func1(int left, int right) { return left + right; }

		public void Test_Func()
		{
			funcDelegate = Func1;
		}

		// Action 델리게이트
		static Action<string> actionDelegate;
		static void Func2(string str) { Console.WriteLine(str); }

		public void Test_Action()
		{
			actionDelegate = Func2;
		}

		// Predicate 델리게이트
		static Predicate<string> predicateDelegate;
		static bool Func3(string str) { return str.Contains(' '); }
		public void Test_Predi()
		{
			predicateDelegate = Func3;
		}
	}
}

