using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm15_EtcGrammar
{
	/// <summary>
	/// partial type클래스나 구조체 인터페이스를 분할하여 구현하는 방법
	/// </summary>
	internal partial class PartialClass
	{
	}

	/// <summary>
	/// 플레이어 - 전투 담당 
	/// </summary>
	public partial class Player
	{
		private int hp;
		private void Attack() { }
		private void Defense() { }
	}

	/// <summary>
	/// 플레이어 - 아이템 담당
	/// </summary>
	public partial class Player
	{
		private int weight;

		public void GetItem() { hp += 1; } //hp는 private로 만들었지만 접근 가능 -> partial로 분할했기 때문임 -> 내부에서는 하나로 뭉쳐서 생각하기 때문임
		public void UseItem() { }
		public void DropItem() { }
	}

	//함수도 partial로 나눌 수 있음!

	/// <summary>
	/// 선언부 : 함수가 있다는 것만 표시함
	/// </summary>
	public partial class Monster
	{
		public partial void Attack();
	}

	/// <summary>
	/// 구현부 : 함수를 실제로 구현함 
	/// </summary>
	public partial class Monster
	{
		public partial void Attack()
		{
			//TODO.Attack 메소드 내부 구현
		}
	}
}
