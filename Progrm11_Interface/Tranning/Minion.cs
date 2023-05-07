using Progrm11_Interface.Tranning.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm11_Interface.Tranning
{
	internal class Minion : GameObject, IMove
	{
		public bool IsLive { get; private set;}

		public Minion(int hp, int damage) : base(hp, damage)
		{
			IsLive = true;
		}

		public override Skill GiveDamage(SkillButton btn)
		{
			return new Skill("때리기", 0, 10);
		}

		public override void TakeDamage(Skill skill)
		{
			Hp -= skill.Damage;
			if(Hp <= 0)
			{
				IsLive = false;
				Console.WriteLine("체력이 바닥남 -> 미니언 죽음");
			}
			else
			{
				Console.WriteLine($"데미지를 받아 체력이 감소합니다. 남은 체력 {Hp}");
			}
		}

		public void Move(Direction direction, int distance)
		{
			Console.WriteLine($"미니언이 {direction}으로 {distance}만큼 이동함!");
		}		
	}
}
