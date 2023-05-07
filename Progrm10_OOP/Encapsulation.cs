using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming
{
	/// <summary>
	/// 캡슐화
	/// > 객체를 상태와 기능으로 묶는 것을 의미
	/// > 정보은닉 : 객체의 내부 상태와 기능을 숨기고, 허용한 상태와 기능만의 액세스 허용
	/// </summary>
	internal class Encapsulation
	{
		int variable; //멤버변수
		void Function() { }//멤버함수

		public void StudyEncapsulation()
		{
			Player player = new Player(100, 100);
			player.TakeDamage(20);
			player.UseMagic(10);
			player.hp = 30; //public이기 때문에 접근 가능
			//player.mp = 30; //오류. private이기 때문에 접근 불가능
		} 
		
	}

	public class Player
	{
		public int hp;
		int mp; //접근제한지 지정X -> private임

		public Player(int hp, int mp)
		{
			this.hp = hp;
			this.mp = mp;
		}

		public void TakeDamage(int damage)
		{
			hp -= damage;
		}

		public void UseMagic(int cost)
		{
			mp -= cost;
		}
	}
}
