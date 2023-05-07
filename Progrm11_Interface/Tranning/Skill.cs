using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm11_Interface.Tranning
{
	public enum SkillButton
	{
		Q,
		W,
		E,
		R,
		None
	}

	public class Skill
	{
		/// <summary>
		/// 스킬 이름
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// 키보드 자판 -> 누르면 스킬 나옴
		/// </summary>
		public SkillButton Key { get; private set; }

		/// <summary>
		/// 쿨타임
		/// </summary>
		public int CoolTime { get; private set; }

		/// <summary>
		/// 공격력
		/// </summary>
		public int Damage { get; private set; }

		public Skill(string name, int coolTime, int damage)
		{
			this.Name = name;
			this.CoolTime = coolTime;
			this.Damage = damage;
		}

		public Skill(string name, SkillButton btn, int coolTime, int damage) : this(name, coolTime, damage)
		{
			this.Key = btn;
		}

		/// <summary>
		/// 쿨타임을 줄임
		/// </summary>
		/// <param name="time"></param>
		public void ReducedCoolTime(int time)
		{
			CoolTime -= time;
		}

		/// <summary>
		/// 공격력을 올림
		/// </summary>
		/// <param name="addPower"></param>
		public void IncreaseDamage(int addPower)
		{
			Damage += addPower;
		}
	}
}
