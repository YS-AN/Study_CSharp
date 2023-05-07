using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm14_Event.Architecture
{
	/// <summary>
	/// 폴링 방식
	/// </summary>
	public class PollingPlayer
	{
		// <폴링 방식>
		// 대상 인스턴스의 상황을 확인하기 위해 매 프레임마다 계속해서 확인함

		// 클래스의 개방폐쇄 원칙은 잘 지켜졌지만,
		// 확인되는 대상의 변경사항이 없는 상황에서도 확인을 진행하기 때문에
		// 프레임마다 필요없는 연산이 낭비될 수 있음
		// ex)  플레이어의 체력의 변경사항이 없을 때에도, UI에서는 확인하는 작업이 필요함

		// 개방폐쇄원칙 준수 O / 불필요한연산 제거 X
		
		// -> 객체가 너무 많아지면 매 프레임마다 확인해야 할 사항도 늘어나기 떄문에 프레임 드랍이 발생할 수 있음


		public int _HP = 100;

		public int HP { get; private set; }

		public void Hit(int damage)
		{
			Console.WriteLine("플레이어가 데미지를 받아 체력이 {0}이 되었습니다.", HP);
			HP -= damage;
		}

		public void Heal(int heal)
		{
			Console.WriteLine("플레이어가 힐을 받아 체력이 {0}이 되었습니다.", HP);
			HP += heal;
		}
	}

	public class PollingUI
	{
		private PollingPlayer player; //UI가 플레이어를 알고 있게 함

		public void SetTarget(PollingPlayer player) { this.player = player; }

		public void Update()
		{
			if (player == null)
				return;

			// 실시간 확인을 위해서는 플레이어의 체력을 갱신하기 위해 플레이어를 계속해서 확인해줘야함
			// EX.10초에 체력이 변경 된다고 하면 1초마다 UI가 플레이어를 확인해주다가 10초가 됐을 때 체력을 변경해줘야함
			Console.WriteLine("UI가 체력을 {0}으로 설정합니다.", player.HP);
		}
	}
}
