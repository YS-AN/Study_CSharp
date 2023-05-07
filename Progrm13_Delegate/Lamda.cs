using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm13_Delegate
{
	/// <summary>
	/// 람다식
	/// </summary>
	internal class Lamda
	{
		public delegate void DelegateTest(string str);

		public DelegateTest OnAction;

		public void Func(string str) { Console.WriteLine(str); }

		public void Test()
		{
			//함수를 통한 연결
			OnAction += Func;

			// 무명메서드
			OnAction += delegate (string str) { Console.WriteLine(str); }; //반환형은 쓰지 않음 (델리게이트보면 알 수 있기 때문)

			//람다식
			OnAction += (str) => { Console.WriteLine(str); };
			OnAction += str => Console.WriteLine(str); // 매개변수나 함수내용이 하나만 있을 경우 괄호 생략 가능

			//람다식 -> 메소드에서 바로 사용 
			int[] array = new int[5];
			Array.Find(array, x => x > 3); //array 중 3보다 큰 수 찾아줘!
		}
	}
}
