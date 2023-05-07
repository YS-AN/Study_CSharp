using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm02_DataType
{
	internal class Tranning
	{
		public void StartTraining0328()
		{
			int iVal = 0;
			float fVal1, fVal2;

			Console.Write("정수를 입력하세요 : ");
			iVal = int.Parse(Console.ReadLine());  //정수를 입력 받음
			Console.WriteLine($"{iVal} + 10 = {(iVal + 10)}"); //정수를 int형으로 변환해서 10을 더해줌.

			Console.WriteLine("\n\n****사칙연산 계산****");
			Console.Write("정수1 입력하세요 : ");
			fVal1 = float.Parse(Console.ReadLine()); //정수를 입력받아 int형으로 변환
			Console.Write("정수2 입력하세요 : ");
			fVal2 = float.Parse(Console.ReadLine()); //정수를 입력받아 int형으로 변환

			Console.WriteLine($"{fVal1} + {fVal2} = {fVal1 + fVal2}"); // 더하기
			Console.WriteLine($"{fVal1} - {fVal2} = {fVal1 - fVal2}"); // 빼기
			Console.WriteLine($"{fVal1} * {fVal2} = {fVal1 * fVal2}"); // 곱하기
			Console.WriteLine($"{fVal1} / {fVal2} = {fVal1 / fVal2}"); // 나누기
			Console.WriteLine("****사칙연산 계산 끝****\n\n");

			Console.Write("세자리 입력하세요 : ");
			iVal = int.Parse(Console.ReadLine()); //정수를 입력 받음
			Console.WriteLine($"2번째 자리 수 : {((iVal % 100) / 10)}"); //정수로만 나누기 때문에 결과값도 소수점 절사해서 나옴. 
			//뒤에서 2번째 자리를 구하기 위해 100의 자리에서 나눠서 나머지만 구한 후 10을 나눠줌. 10을 나눌 때 정수만 받으면 십의 자리만 추출 가능함
		}
	}
}
