using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm10_OOP
{
	internal class Tranning
	{
		public void StartTraining0406()
		{
			Player player = new Player();

			Oak oak = new Oak("오크1", 3000); //오크 몬스터 생성
			Slime slime = new Slime("슬라임", 50); //슬라임 몬스터 생성

			player.Attack(oak, 10);
			player.Attack(slime, 10);
		}
	}

	public abstract class Skill
	{
		protected string haveSkill;

		public Skill(string haveSkill)
		{
			this.haveSkill = haveSkill;
		}

		/// <summary>
		/// 몬스터 스킬
		/// </summary>
		public abstract void GetHaveSkill();
	}

	public abstract class Monster : Skill
	{
		public string Name { get; protected set; }
		public int Hp { get; protected set; }

		/// <summary>
		/// 몬스터 추상화
		/// </summary>
		/// <param Name="Name">이름</param>
		/// <param Name="Hp">체력</param>
		public Monster(string Name, int Hp, string haveSkill) : base(haveSkill)
		{
			this.Name = Name;
			this.Hp = Hp;
		}

		/// <summary>
		/// 데미지 받는 추상 클래스 
		/// </summary>
		/// <param Name="damage"></param>
		public abstract void TakeDamage(int damage);

	}

	public class Player
	{
		public void Attack(Monster monster, int damage)
		{
			Console.WriteLine($"{monster.Name} 공격받음. ");
			monster.TakeDamage(damage);
			Console.WriteLine($"체력 : {monster.Hp} 남음");
			Console.WriteLine($"{monster.Name} 역공!!");
			monster.GetHaveSkill();
			Console.WriteLine();
		}
	}


	/// <summary>
	/// 오크 클래스
	/// </summary>
	public class Oak : Monster
	{
		public Oak(string Name, int Hp) : base(Name, Hp, "강타") { }

		/// <summary>
		/// 구체화 : 오크 클래스 데미지를 입으면 체력이 하락하고 분노 메시지가 나옴 
		/// </summary>
		/// <param Name="damage"></param>
		public override void TakeDamage(int damage)
		{
			Hp -= (damage * 10);
			Console.WriteLine("분노 : (╬▔皿▔)╯(╬▔皿▔)╯(╬▔皿▔)╯(╬▔皿▔)╯");
		}

		/// <summary>
		/// 구체화 : 오크가 가지고 있는 고유 스킬
		/// </summary>
		public override void GetHaveSkill()
		{
			Console.WriteLine($"{haveSkill} : ( o｀ω′)ノ───────────3");
		}
	}

	/// <summary>
	/// 슬라임 클래스
	/// </summary>
	public class Slime : Monster
	{
		public Slime(string Name, int Hp) : base(Name, Hp, "분열") { }

		/// <summary>
		/// 구체화 : 슬라임 클래스 데미지를 입으면 체력이 하락하고 분노 메시지가 나옴
		/// </summary>
		/// <param Name="damage"></param>
		public override void TakeDamage(int damage)
		{
			Hp -= (damage * 2);
			Console.WriteLine("독 : (￣┰￣*)(￣┰￣*)(￣┰￣*)");
		}

		/// <summary>
		/// 구체화 : 슬라임이 가지고 있는 고유 스킬
		/// </summary>
		public override void GetHaveSkill()
		{
			Console.WriteLine($"{haveSkill} : ( o ( o ( o ㅁ o ) o ) o )");
		}
	}
}
