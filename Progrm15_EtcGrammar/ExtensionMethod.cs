using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm15_EtcGrammar
{
	/// <summary>
	/// 확장 메소드
	/// </summary>
	public static class ExtensionMethod
	{
		public static int WordCount(this string str) 
		{
			return str.Split(' ').Length;
		}

		public static int WordCount(this string str, int a) 
		{
			return str.Split(' ').Length;
		}

		public static void Test()
		{
			string str = "hello world";
			
			WordCount(str); //원래 함수를 호출하는 방식
			str.WordCount(); //확장 메소드 형식으로 호출
			str.WordCount(3); // 확장메소드 매개변수는 2번째부터 매개변수 형식대로 넘겨줌
		}
	}
}
