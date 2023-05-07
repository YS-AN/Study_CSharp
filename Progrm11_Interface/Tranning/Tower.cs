using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm11_Interface.Tranning
{
	internal class Tower : GameObject
	{
		public bool IsAvailable { get; private set; }

		public Tower(int hp, int damage) : base(hp, damage)
		{
			IsAvailable = true;
		}

		public override Skill GiveDamage(SkillButton btn)
		{
			return new Skill("때리기", 0, 100);
		}

		public override void TakeDamage(Skill skill)
		{
			Hp -= skill.Damage;
			if (Hp <= 0)
			{
				IsAvailable = false;
				Console.WriteLine("체력이 바닥남. 포탑이 무너집니다.");
			}
			else
			{
				Console.WriteLine($"데미지를 받아 체력이 감소합니다. 남은 체력 {Hp}");
			}
		}
	}
}
