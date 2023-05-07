﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm14_Event.Architecture
{
	/// <summary>
	/// 함수 Call방식
	/// </summary>
	internal class FuncCall
	{
		// <함수 Call 방식>
		// 필요로 하는 순간에 인스턴스의 함수를 호출하여 진행

		// 프레임마다 불필요한 연산을 진행하지는 않았지만
		// 플레이어의 체력의 변경사항을 확인하는 클래스가 생길때마다
		// 플레이어의 코드가 수정되어야 한다는 점에서
		// 클래스의 개방폐쇄의 원칙에 위배됨
		// ex)  플레이어의 체력에 따라 음악이 바뀌는 BGM 클래스를 추가할 경우,
		//      플레이어의 코드에서도 BGM 클래스가 추가되어야 함

		// OCP 개방폐쇄의 원칙(Open-Closed Principle)
		// 클래스를 설계할 때 확장에 대해 열려있고 수정에 대해서는 닫혀있어야 한다는 원칙

		// 개방폐쇄원칙 준수 X / 불필요한연산 제거 O

		public class OCPPlayer
		{
			public OCPUI ui; //플레이어가 모든 기능 객체를 알고 있음
			public OCPSound sound; //플레이어 클래스에서 사운드 클래스를 가지고 있어야만, 사운드 함수를 사용할 수 있음.
		
			public int _HP = 100;

			public int HP { get; private set; }

			public void Hit(int damage)
			{
				Console.WriteLine("플레이어가 데미지를 받아 체력이 {0}이 되었습니다.", HP);
				HP -= damage;
				
				ui.ChangeHP(HP); // 플레이어가 직접 함수를 호출해서 ui의 체력을 변경시킴
								 //기능이 추가 될 때마다 플레이어 소스에 수정되어야 하는 포인트가 늘어남
			}

			public void Heal(int heal)
			{
				Console.WriteLine("플레이어가 힐을 받아 체력이 {0}이 되었습니다.", HP);
				HP += heal;

				ui.ChangeHP(HP); // 플레이어가 직접 함수를 호출해서 ui의 체력을 변경시킴
			}
		}

		public class OCPUI
		{
			public void ChangeHP(int hp)
			{
				Console.WriteLine("UI의 체력을 {0}으로 변경합니다.", hp);
			}
		}

		public class OCPSound
		{
			public void Sound()
			{
				Console.WriteLine("BGM~");
			}
		}
	}
}
