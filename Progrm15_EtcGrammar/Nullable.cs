using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm15_EtcGrammar
{
	/// <summary>
	/// Nullable 타입
	/// </summary>
	internal class Nullable
	{
		public class NullClass
		{
			public int value = 5;

			public void Func() { }
		}

		public void Test()
		{
			bool? b = null; //nullable 선언
			int? i = 20;
			if (b != null) // "값이 지정되지 않았음"의 의미로도 사용 가능
			{
				Console.WriteLine(b); // b 값이 설정되지 않았으므로 호출되지 않음
			}
			if (i.HasValue) Console.WriteLine(i); // i 값이 설정되었으므로 호출됨
												  //nullable 타입일 때만 .hasValue 사용 가능 > 값이 있으면 true
			int? a = i.GetValueOrDefault(); //값을 가져오거나 기본 값을 넣어 줌 (괄호 안에 기본 값을 세팅해 줄 수 있음)


			//Null 조건연산자
			NullClass instance = null;
			
			// instance.Func();	 // 예외발생 : instance가 null 이므로 접근할 객체가 없음 > 프로그램 종료 됨
			if(instance != null)
			{
				Console.WriteLine(instance.value);
			}

			Console.WriteLine(instance?.value); // instance가 null이면 값을 안 가져오고, null 아니면 value값 가져옴
												// -> instance?.value는 null 반환 -> 위의 if문을 요약한 형태.
			instance?.Func(); // instance?.Func()은 null 반환

			instance = new NullClass();
			Console.WriteLine(instance?.value); // instance?.value는 5 반환
			instance?.Func();  // instance?.Func()은 함수 호출


			//Null 병합연산자
			int? nullableValue = null;
			int iValue = nullableValue ?? 0; // i가 null 인경우 0 반환, 아닌경우 i 반환

			int[] array = null;
			int size = array?.Length ?? 0; // 배열이 null 인경우 0 반환, 아닌경우 배열의 크기 반환

			//풀어쓰면
			if(array != null)
				size = array.Length;
			else
				size = 0;


			//Null 병합할당연산자
			NullClass nullClass = null;
			nullClass ??= new NullClass(); // nullClass 가 null이므로 새로운 인스턴스 할당
			nullClass ??= new NullClass(); // nullClass 가 null이 아니므로 새로운 인스턴스 할당이 되지 않음
		}
	}
}