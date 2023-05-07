using Progrm11_Interface.Tranning.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm11_Interface.Tranning
{
	/// <summary>
	/// 게임의 기본 동작 정의
	/// </summary>
	internal abstract class GameObject : IDamageable
	{
		/// <summary>
		/// 체력
		/// </summary>
		protected int Hp;

		/// <summary>
		/// 데미지
		/// </summary>
		protected int Damage;

		public GameObject(int hp, int damage)
		{
			Hp = hp;
			Damage = damage;
		}

		public abstract void TakeDamage(Skill skill);

		public abstract Skill GiveDamage(SkillButton btn);
	}
}
