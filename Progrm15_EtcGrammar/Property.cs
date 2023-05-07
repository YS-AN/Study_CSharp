using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm15_EtcGrammar
{
	/// <summary>
	/// 프로퍼티
	/// </summary>
	public class Student
	{
		public event Action<int> OnChangeScore;

		//score의 get, set 구현 (읽기 전용으로 구현) ------------------------
		//멤버변수가 외부 객체와 상호작용 하는 경우 get & set 함수를 구현해 주는 것이 일반적임
		private int score;

		public int GetScore()
		{
			return score;
		}

		private void SetScore(int score)
		{
			this.score = score;
			OnChangeScore?.Invoke(score);
		}
		//-------------------------------------------------

		//프로퍼티로 구현 ----------------------------------
		public int Score 
		{ 
			get { return score; } 
			set 
			{ 
				score = value; 
				OnChangeScore?.Invoke(value); //set 안에서 이벤트를 발생시킬 수 있음
			} 
		}
		public int Name { get; set; } //더 간소화한 형태 > 내부에서 처리할 때는 자동으로 변수를 만들어 준다고 생각하면 돼. 저장소이자 get & set 구문이라고 생각하면 돼

		public int Age { get; private set; } //읽기 전용 형태. 읽는 건 public, 쓰는 건 private

		public DateTime Birth { get { return new DateTime(2000, 1, 1); } } //클래스 내부에서도 값을 세팅할 수 없음. 무조건 get에서 지정한 반환값을 돌려줌
	}

	public class Property
	{
		public void Test()
		{
			Student std = new Student();
			std.Score = 30;// 프로퍼티는 그냥 변수 쓰 듯 쓰면 됨.

			//아래 2줄은 동일한 동작을 하는 함수 임
			Console.WriteLine(std.Score);
			Console.WriteLine(std.GetScore());
		}
	}
}
