using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm01_Console
{
	/// <summary>
	/// 콘솔 입출력 실습
	/// </summary>
	internal class Tranning
	{
		public void StartTraining0327()
		{
			//1. Hellow world! - 출력 확인
			Console.WriteLine("Hellow world!");  //콘솔 창에 "Hellow world!"라는 문자열을 출력한다. 문자열 출력 후 엔터까지 함께 

			//2. 안녕하세요 - 출력 확인
			Console.WriteLine("안녕하세요!"); //콘솔 창에 "안녕하세요!"라는 문자열을 출력한다. 

			//3.ReadLine을 통해 입력 확인
			Console.Write("입력 test 1 : ");
			Console.ReadLine(); //데이터를 입력 받는다. (엔터가 치면 입력 종료)

			//4. int 변수에 10 저장
			int val = 10; //val라는 이름을 가진 int자료형에 10이란 값을 초기화 한다.
			Console.WriteLine(val); //val자료형 값을 출력한다.

			//5.ReadLine을 통해 입력한 값 변수에 저장
			Console.Write("입력 test 2 : ");
			string str = Console.ReadLine(); //값을 입력 받아 str이라는 문자열 자료형에 저장한다

			//6. ReadLine을 통해 입력한 값을 그대로 다시 출력하는 프로그램 작성
			Console.WriteLine(str); //str자료형에 저장된 데이터를 출력한다.
		}
	}
}
