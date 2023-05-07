using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm15_EtcGrammar
{
	/// <summary>
	/// 문자열
	/// </summary>
	internal class StringClass
	{
		public void Test()
		{
			UserString();

			StringImmutable();

			StringFragmentation();
		}

		public void UserString()
		{
			// string 사용
			string str = "abcde";
			Console.WriteLine(str);

			// string은 char의 순차적 집합으로 표현 > 순차적 집합이기 때문에 문자열을 배열처럼 접근이 가능함. (한글자씩 접근하는 방법)
			Console.WriteLine(str[1]);  // output : b
			Console.WriteLine(str[3]);  // output : d

			// 단, 배열식으로 접근하여 문자를 변경 불가 (문자열 배열은 읽기 전용이기 때문임)
			// str[1] = 'a'; //오류. 
		}

		
		//string의 불변성
		public void StringImmutable()
		{
			string str = "abced"; // 힙영역에 abced 문자열을 저장하며 이를 str이 참조함
			str = "abc";		  // 새로운 힙영역에 abc 문자열을 저장하며 이름 str이 참조함
			str = str + "123";    // 새로운 힙영역에 abc123 문자열을 저장하며 이를 str이 참조함

			string str2 = str;  // class 이지만 string은 값형식처럼 사용되어야 하기 때문에 힙영역에 abc123 문자열을 복사하여 str2가 참조하도록 함	
		}

		//메모리 파편화
		public void StringFragmentation()
		{ 
			// 문자열을 붙이는 방법은 권장하지 않음. ===================
			Console.WriteLine("abc" + 123 + "def");
			// 위처럼 "abc123def" 문자열을 만들어 내기 위해 "abc", "def", "abc123" 이 힙영역에 버려지게 됨

			
			//GC에 부담되지 않도록 사용하는 방법 =======================

			// 1. string Format
			Console.WriteLine(String.Format("abc{0}def", 123)); // string.Format은 가비지컬렉터에 부담되지 않도록 설계됨

			// 2.string $
			Console.WriteLine($"abc{123}def"); // string.Format의 간단한 표현방식

			// 3.Console의 문자열 오버로딩
			Console.WriteLine("abc{0}def", 123); // Console.WriteLine의 문자열 출력방식을 달리하면 가비지컬렉터에 부담되지 않도록 설계됨


			// 반복하면서 문자열을 합쳐야 하는 경우에는
			string str = "";
			for (int i = 0; i < 10; i++)
			{
				str += i;
			}
			//for문을 돌면서 문자열을 합치면 반복마다 힙영역에 데이터를 버리게 됨 > 메모리 낭비

			// 이런 경우는 StringBuilder를 사용함.
			// StringBuilder는 일정 버퍼를 사용하는 방식으로 가비지컬레터에 부담되지 않도록 설계되어 있음
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < 10; i++)
			{
				sb.Append(i); 
			}
			str = sb.ToString();
		}
	}
}