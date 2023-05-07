using Progrm11_Interface.Tranning.Interface;
using System.ComponentModel;

namespace Progrm11_Interface.Tranning.ChampionObject
{
	/// <summary>
	/// 마나 쓰는 챔피언
	/// </summary>
	internal class ChampionWithMana : Champion
	{
		/// <summary>
		/// 마나 최대값
		/// </summary>
		private int MaxMana;

		/// <summary>
		/// 마나
		/// </summary>
		private int Mana;

		/// <summary>
		/// 마나 사용량
		/// </summary>
		private int ManaUsage;

		/// <summary>
		/// 챔피언
		/// </summary>
		/// <param name="name">이름</param>
		/// <param name="hp">현재 체력</param>
		/// <param name="maxhp">최대 체력</param>
		/// <param name="damage">공격력</param>
		/// <param name="mana">현재 마나</param>
		/// <param name="maxMana">최대 마나</param>
		/// <param name="manaUsage">마나 사용량</param>
		public ChampionWithMana(string name, int hp, int maxhp, int damage, int mana, int maxMana, int manaUsage) : base(name, maxhp, hp, damage)
		{
			Mana = mana;
			MaxMana = maxMana;
			ManaUsage = manaUsage;
		}

		public override Skill GiveDamage(SkillButton btn)
		{
			Mana -= ManaUsage;
			return base.GiveDamage(btn);
		}

		/// <summary>
		/// 한 번 쓰는 마나 사용량이 줄어듦
		/// </summary>
		/// <param name="reducedNum"></param>
		public void ReducedManaUsage(int reducedNum)
		{
			ManaUsage -= (ManaUsage - reducedNum > 10) ? reducedNum : 0;
		}

		/// <summary>
		/// 마나가 늘어남
		/// </summary>
		/// <returns></returns>
		public void GetAddMana(int addValue)
		{
			MaxMana += addValue;
			Console.WriteLine($"{Name}의 마나가 늘어남 -> 최대 마나량 {MaxMana} / 현재 마나 {Mana}");
		}
	}
}


