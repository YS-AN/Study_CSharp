using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm03_Operator
{
	/// <summary>
	/// 연산자
	/// </summary>
	public class Operator
	{
		public void StudyOperator()
		{
			//<이진연산자>-----------------------------------------
			Console.WriteLine($"4 + 5 = {(4 + 5)}"); //더하기
			Console.WriteLine($"4 - 5 = {(4 - 5)}"); //빼기
			Console.WriteLine($"4 * 5 = {(4 * 5)}"); //곱하기

			//정수 나누기 정수이기 때문에 결과도 정수로 나옴. 소수점을 보고 싶다면 나누는 값 중 최소 하나 이상이 소수점이어야함 
			Console.WriteLine($"5 / 3 = {(5 / 3)}");
			Console.WriteLine($"5f / 3 = {(5f / 3)}");

			Console.WriteLine($"5 / 3 = {(13 % 3)}"); //나머지 값을 출력함 
			Console.WriteLine();


			//<단항 연산자>-----------------------------------------
			int iVal = 3;
			iVal = +iVal;
			Console.WriteLine($"+iVal = {+iVal}");
			Console.WriteLine($"-iVal = {-iVal}");

			Console.WriteLine($"{iVal} -> ++iVal = {++iVal}"); // [OUTPUT] 3 -> ++iVal = 4
			Console.WriteLine($"{iVal} -> iVal++ = {iVal++}"); // [OUTPUT] 4 -> iVal++ = 4

			Console.WriteLine($"{iVal} -> --iVal = {--iVal}"); // [OUTPUT] 5 -> --iVal = 4
			Console.WriteLine($"{iVal} -> iVal-- = {iVal--}"); // [OUTPUT] 4 -> iVal-- = 4
			Console.WriteLine();

			//<대입 연산자>-----------------------------------------
			iVal = 10;

			//<복합 대입 연산자>-----------------------------------------
			// x op= y; 형태임
			Console.WriteLine($"{(iVal)} > iVal += 3 : {(iVal)}"); //더하기
			Console.WriteLine($"{(iVal)} > iVal -= 3 : {(iVal)}"); //빼기
			Console.WriteLine($"{(iVal)} > iVal *= 3 : {(iVal)}"); //곱하기
			Console.WriteLine($"{(iVal)} > iVal /= 3 = {(iVal)}"); //나누기
			Console.WriteLine($"{(iVal)} > iVal %= 3 = {(iVal)}"); //나머지
			Console.WriteLine();

			// <비교 연산자>-----------------------------------------
			bool bVal;
			bVal = 3 > 1; // > : 왼쪽 피연산자가 더 클 경우 true
			bVal = 3 < 1; // < : 왼쪽 피연산자가 더 작을 경우 true
			bVal = 3 >= 1; // >= : 왼쪽 피연산자가 더 크거나 같은 경우 true
			bVal = 3 <= 1; // <= : 왼쪽 피연산자가 더 작거나 같은 경우 true
			bVal = 3 == 1; // == : 두 피연산자가 같은 경우 true
			bVal = 3 != 1; // != : 두 피연산자가 다를 경우 true

			//<논리 연산자>-----------------------------------------
			Console.WriteLine($"!false : {!false}"); // !(Not) : 피연산자의 논리 부정을 반환
			Console.WriteLine($"true && false : {true && false}"); // &&(And) : 두 피연산자가 모두 true 일 경우 true
			Console.WriteLine($"true || false : {true || false}"); // ||(Or) : 두 피연산자가 모두 false 일 경우 false
			Console.WriteLine($"true ^ false : {true ^ false}"); // ^(Xor) : 두 피연산자가 다를 경우 true
			Console.WriteLine();

			//<조건부 논리 연산자>----------------------------------
			iVal = 10;
			bVal = false && (++iVal > 5); //앞이 false라서 뒤는 무조건 무시 (보는게 의미 없음)
			Console.WriteLine(iVal);  // [OUTPUT] : 10

			iVal = 10;
			bVal = true || (++iVal > 5); //앞이 true라 뒤는 무조건 무시 (보는게 의미 없음)
			Console.WriteLine(iVal);  // [OUTPUT] : 10

			Console.WriteLine();

			//<비트연산자>-----------------------------------------
			Console.WriteLine($"~0x3F : {~0x3F}"); // ~(비트 보수) : 데이터를 비트단위로 보수 연산 (보수 : 0->1, 1->0)

			Console.WriteLine($"0x11 & 0x83 : {(0x11 & 0x83)}"); // &(And) : 데이터를 비트단위로 And 연산
			Console.WriteLine($"0x11 | 0x83 : {(0x11 | 0x83)}"); // |(Or) : 데이터를 비트단위로 Or 연산
			Console.WriteLine($"0x11 ^ 0x83 : {(0x11 ^ 0x83)}"); // ^(Xor) : 데이터를 비트단위로 Xor 연산
			Console.WriteLine();

			// <비트 쉬프트 연산자>
			Console.WriteLine($"{0x20} -> 0x20 << 2 = {(0x20 << 2)}"); //비트를 왼쪽으로 이동 (0x20 = 32 > 32 x 4 = 128)
			Console.WriteLine($"{0x20} -> 0x20 >> 2 = {(0x20 >> 2)}"); //비트를 오른쪽으로 이동 (0x20 = 32 > 32 / 4 = 8)동 -> 2진수 이동 -> 2나누기 효과)
		}
	}
}
