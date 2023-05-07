using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm15_EtcGrammar
{
	internal class Additional
	{
		public void TypeDefMethod()
		{
			//기본 자료형의 메소드
			//기본 자료형은 구조체 또는 클래스로 구성됨.
			//이 구조체와 클래스 안에 메소드로 기능이 구현됨. 
			string str = "abc def pine apple"; // string을 단순히 문자열을 보관하는 변수로만 생각하지 X -> 미리 만들어진 기능들을 활용하기
			
			//[예시]
			str.ToUpper(); //대문자로 변환
			str.ToLower(); //소문자로 변환
			str.Split(" "); //문자 기준으로 문자열 쪼개기
			str.Replace("a", "1"); //문자 교체

			int[] arr = { 1, 2, 3, 4, 5 };
			arr.Max(); //최대값
			arr.Min(); //최소값
			arr.Average(); //평균값
		}

		public void TypeDefStaticMethod()
		{
			//기본자료형의 static 메서드
			//변수 이름에서 직접적으로 호출하는 메소드
			int.Parse("12"); //int형 변환하는 static메소드

			String.Compare("abc", "abd"); //문자열 비교

			int[] arr = { 1, 3, 5, 4, 2 };
			Array.Sort(arr); //배열 정렬
			Array.Reverse(arr); //배열 반전
		}

		public void OF_Operator()
		{
			//of연산자
			//프로그래밍적 외 정보를 추출하는 방법
			int intVal = 20;

			Console.WriteLine(nameof(intVal)); //변수명을 가져옴

			Console.WriteLine(sizeof(int)); //자료형의 크기를 구함
			Console.WriteLine(sizeof(double));

			//typeof 연산자도 있음 > 타입을 알려줌
		}
	}
}
