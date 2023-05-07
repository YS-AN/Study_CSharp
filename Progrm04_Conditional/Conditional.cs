using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm04_Conditional
{
	/// <summary>
	/// 조건문
	/// </summary>
	internal class Conditional
	{
		/// <summary>
		/// if문
		/// </summary>
		public void StudyCondition_IF()
		{
			//<if 기본 조건문>
			if (true) 
			{
				Console.WriteLine("조건식이 true일 경우 실행되는 블록");
			}
			else 
			{
				Console.WriteLine("조건식이 false일 경우 실행되는 블록");
			}

			//<여러 조건이 있는 if문>
			//else if라는 키워드가 따로 있는게 아니라 else와 if가 합쳐진 형태임. (else + if = else if)
			int hp = 100;
			if (hp < 10)
			{
				Console.WriteLine("체력이 부족합니다.");
			}
			else if (hp < 30) //10 ~ 29 : hp = 9, hp < 30이라는 조건은 맞지만 상위 조건문에도 부합해서 이미 실행되었기 때문에 hp < 30 아래는 확인하지 않고 스킵함. 
			{
				Console.WriteLine("체력을 비축하세요");
			}
			else if (hp < 50) //30 ~ 49
			{
				Console.WriteLine("정상 체력");
			}
			else if (hp <= 100) //50 ~ 100 
			{
				Console.WriteLine("체력이 완충되었습니다.");
			}
			else
			{
				Console.WriteLine("hp overflow - 관리자 문의");
			}
		}

		/// <summary>
		/// switch문
		/// </summary>
		public void StudyCondition_SWITCH()
		{
			//switch 조건문 기분
			string pressedKey = "a";
			switch (pressedKey) //조건값 설정
			{
				case "w": //같은 결과가 필요한 여러가지 조건은 case를 나열한 후 마지막에 break;를 써주면 됨.
				case "W":
					Console.WriteLine("위쪽으로 이동");
					break; //switch 종료
				case "a":
				case "A":
					Console.WriteLine("왼쪽으로 이동");
					break;
				case "s":
				case "S":
					Console.WriteLine("아래으로 이동");
					break;
				case "d":
				case "D":
					Console.WriteLine("오른쪽으로 이동");
					break;
				default:
					Console.WriteLine("이동하지 않음");
					break;

			}
		}

		/// <summary>
		/// 삼항연산자
		/// </summary>
		public void StudyCondition_TernaryOP()
		{
			int leftValue = 20;
			int rightValue = 10;
			int bigger = 0;

			if (leftValue > rightValue)
			{
				bigger = leftValue;
			}
			else
			{
				bigger = rightValue;
			}
			
			bigger = leftValue > rightValue ? leftValue : rightValue; //위의 if문과 동일한 동작을 함 (if문을 간추린 형태)
		}
	}
}
