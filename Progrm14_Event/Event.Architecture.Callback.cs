using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm14_Event.Architecture
{
	/// <summary>
	/// Callback 방식
	/// </summary>
	internal class Callback
	{
		// <Callback 방식>
		// 호출 당할 함수를 미리 보관한 후 필요로 하는 순간 보관한 함수들을 호출하여 진행

		// event : 이벤트를 호출 당하기 위한 역할
		// 함수 : 이벤트를 호출 당했을 때 수행할 행동들.

		// 클래스의 개방폐쇄 원칙이 잘 지켜졌으며,
		// 프레임마다 필요없는 연산이 낭비되지 않음

		// 개방폐쇄원칙 준수 O / 불필요한연산 제거 O

		//플레이어 입장에서는 그냥 이벤트만 마련해둠
		//객체는 이벤트만 바라보다가 이벤트에서 알림이 오면 함수들이 수행 됨.
		//하지만 콜백 방식은 상대적으로 느림. 이벤트 따라가서 함수를 다 확인 해야함. -> 느린 것 정도는 감수 할 수있는 정도의 이점이 있음
		//순서가 지켜지지 않고, 이벤트 등록하는 동작이 한번 더 늘어남. 

		public class EventPlayer
		{
			public delegate void OnChangeHPHandler(int hp);
			public event OnChangeHPHandler OnChangeHP;

			// 2. Event의 프로퍼티 응용
			public int HP { get; private set; } = 100;

			public void Hit(int damage)
			{
				Console.WriteLine("플레이어가 데미지를 받아 체력이 {0}이 되었습니다.", HP);
				HP -= damage;

				// 이벤트에 추가한 함수들을 호출
				OnChangeHP?.Invoke(HP);
			}

			public void Heal(int heal)
			{
				Console.WriteLine("플레이어가 힐을 받아 체력이 {0}이 되었습니다.", HP);
				HP += heal;

				// 이벤트에 추가한 함수들을 호출
				OnChangeHP?.Invoke(HP);
			}
		}

		public class EventUI
		{
			public void ChangeHP(int hp)
			{
				Console.WriteLine("UI의 체력을 {0}으로 변경합니다.", hp);
			}
		}
	}
}
