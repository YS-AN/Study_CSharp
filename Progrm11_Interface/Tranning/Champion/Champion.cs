using Progrm11_Interface.Tranning.Interface;
using System.ComponentModel;

namespace Progrm11_Interface.Tranning.ChampionObject
{
	internal class Champion : GameObject, IMove
	{
		/// <summary>
		/// 챔피언 이름
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// 보유 스킬
		/// </summary>
		public Skill[] Skills { get; private set; }

		/// <summary>
		/// 최대 체력
		/// </summary>
		protected int MaxHp;

		/// <summary>
		/// 챔피언
		/// </summary>
		/// <param name="name">이름</param>
		/// <param name="hp">현재 체력</param>
		/// <param name="maxhp">최대 체력</param>
		/// <param name="damage">공격력</param>
		public Champion(string name, int hp, int maxhp, int damage) : base(hp, damage)
		{
			MaxHp = maxhp;
			Name = name;
			Skills = new Skill[4];
		}

		/// <summary>
		/// 공격
		/// </summary>
		/// <returns></returns>
		public override Skill GiveDamage(SkillButton btn)
		{
			return Skills[(int)btn];
		}

		/// <summary>
		/// 공격 받음
		/// </summary>
		/// <param name="damage"></param>
		public override void TakeDamage(Skill skill)
		{
			Hp -= skill.Damage;
			if(Hp > 0)
			{
				Console.WriteLine($"[{Name}] 데미지 입음 -> 남은 체력 {Hp}");
			}
			else
			{
				Console.WriteLine($"[{Name}] 체력이 0이 됨. Home으로 귀가 (체력 충전)");
				Hp = MaxHp; //Home으로 이동 시 체력이 max가 됨
			}
		}

		/// <summary>
		/// 이동
		/// </summary>
		/// <param name="direction">방향</param>
		/// <param name="distance">이동 거리</param>
		/// <exception cref="NotImplementedException"></exception>
		public void Move(Direction direction, int distance)
		{
			if(direction == Direction.Home)
			{
                Console.WriteLine("홈으로 귀가");
				Hp = MaxHp;
            }
			else
			{
				Console.WriteLine($"{direction}으로 {distance}만큼 이동함!");
			}
		}

		/// <summary>
		/// 체력이 늘어남
		/// </summary>
		/// <returns></returns>
		public void GetAddHp(int addValue)
		{
			Hp += addValue;
			Console.WriteLine($"{Name}의 체력이 늘어남 -> 현재 체력 {Hp}");
		}

		/// <summary>
		/// 스킬을 추가함
		/// </summary>
		/// <param name="skill"></param>
		public void AddSkill(Skill skill)
		{
			int i = (int)skill.Key;
			Skills[i] = skill;
		}
	}
}


