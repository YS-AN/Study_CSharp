using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm07_UserDefinedType
{
	/// <summary>
	/// 사용자 정의 자료형
	/// </summary>
	internal class UserDefType
	{
		public void StudyUserDefinedType()
		{
			StudyEnum(); Console.WriteLine();
			BitEnum(); Console.WriteLine();
			StudyTuple(); Console.WriteLine();
			StudyStruct(); Console.WriteLine();
		}

		enum Attack
		{
			Fire = 0,
			Water = 1,
			Grass = 2,
			Electricity = 3
		}

		private void StudyEnum()
		{
			//0:불, 1:물, 2:풀 3:전기...
			int userAttack = 0;
			int monsterAttack = 1;
			if (userAttack == 0 && monsterAttack == 1)
			{
				Console.WriteLine("두배 데미지 받음");
			}
			// -> 이런 식으로 정의해서 사용하면 나중에 어떤 공격이 몇번이었는지 기억하는데 한계가 있음 

			Attack user = Attack.Fire;
			Attack monster = Attack.Water;
			if (user == Attack.Fire && monster == Attack.Water)
			{
				Console.WriteLine("두배 데미지 받음");
			}
			// 열거형으로 변화 -> 의도하는 바를 확실히 알 수 있음

			Console.WriteLine((Attack)0); //정수를 열거형으로 변환 가능
			Console.WriteLine((Attack)10); //열거형에 없는 값을 넣으면 그냥 숫자로 나옴.
		}

		//열거형 비트플래그 사용
		[Flags] // 열거형을 비트플래그로 사용
		enum Day
		{
			None = 0b_0000_0000,        // 0
			Monday = 0b_0000_0001,      // 1
			Tuesday = 0b_0000_0010,     // 2 
			Wednesday = 0b_0000_0100,   // 4
			Thursday = 0b_0000_1000,    // 8
			Friday = 0b_0001_0000,      // 16
			Saturday = 0b_0010_0000,    // 32
			Sunday = 0b_0100_0000,      // 64
			Weekend = Saturday | Sunday //요소를 여러개 포함하는게 가능함
		}

		private void BitEnum()
		{
			Day meetingDays = Day.Monday | Day.Wednesday;
			Console.WriteLine(meetingDays);     // Monday, Wednesday

			meetingDays |= Day.Friday;          // 비트마스킹을 이용한 추가
			Console.WriteLine(meetingDays);     // Monday, Wednesday, Friday

			meetingDays &= ~Day.Wednesday;      // 비트마스킹을 이용한 제거
			Console.WriteLine(meetingDays);     // Monday, Friday

			bool isMeetingOnMonday = (meetingDays & Day.Monday) != Day.None;    // 비트마스킹을 이용한 확인
			Console.WriteLine(isMeetingOnMonday);   // true

			//숫자로 넣어도 연산해서 나옴. 
			Console.WriteLine((Day)3); // 3 = 1 + 2 -> 11 = 01 | 10 -> mon, tue

			Console.WriteLine($"{meetingDays} -> {meetingDays |= Day.None}"); //0인 None는 적용되지 않음
		}

		private void StudyTuple()
		{
			string name;
			int age;
			string address;
			//이 묶음이 변하지 않는데 매번 변수를 지정해서 사용하기 귀찮을 때
			//튜플을 사용
			(string, int, string) t1 = ("홍길동", 20, "서울시 강동구 천호동"); //이름 지정하지 않음
			Console.WriteLine($"튜플의 데이터는 {t1.Item1}, {t1.Item2}, {t1.Item3}");

			//이름을 지정한 경우
			(string nm, int age, string adr) t2 = ("홍길순", 21, "서울시 송파구 풍납동");
			Console.WriteLine($"튜플의 데이터는 {t2.nm}, {t2.age}, {t2.adr}"); //이름으로 접근 가능
			Console.WriteLine($"튜플의 데이터는 {t2.Item1}, {t2.Item2}, {t2.Item3}"); //Item으로도 접근 가능 

			//튜플의 비교
			(int a, double b) left1 = (5, 10);
			(double a, int b) right1 = (5, 10);
			Console.WriteLine(left1 == right1); // output : false

			(int a, double b) left2 = (10, 5);
			(double a, int b) right2 = (5, 10);
			Console.WriteLine(left2 == right2);
			//요소의 이름은 같아도 데이터 순서 기준으로 비교하기 때문에 false가 나옴
		}

		struct Student
		{
			public string name;
			public int math;
			public int english;
			public int programming;

			public float GetAverage()
			{
				return (math + english + programming) / 3f;
			}
		}

		//private void StudyStruct()
		//{
		//	Student hong; // 구조체 선언

		//	hong.name = "HongGilDong"; //구조체 변수에 접근
		//	hong.math = 10;
		//	hong.english = 10;
		//	hong.programming = 100;

		//	float avg = hong.GetAverage(); //구조체 함수에 접근
		//	Console.WriteLine(avg);
		//}

		enum Job { Warrior, Mage, Archor }
		struct Player
		{
			public string name;
			public Job job;
			public int hp;
			public int mp;

			public Player(string name, Job job) //반환형이 없음 + 구조체랑 이름 똑같음 (4)
			{//(5)
			 //데이터를 초기화
				this.name = name; //this는 자기 자신(구조체의 변수)를 가리킴
				this.job = job;

				switch (job)
				{
					case Job.Warrior: hp = 100; mp = 10; break;
					case Job.Mage: hp = 20; mp = 100; break;
					case Job.Archor: hp = 50; mp = 50; break;
					default: hp = 0; mp = 0; break;
				}
			} //(6)

			public Player(string name, Job job, int hp, int mp) //초기화도 오버로딩 가능
			{
				this.name = name;
				this.job = job;
				this.hp = hp;
				this.mp = mp;
			}

			//매개변수 구성이 같은 초기화로 먼저 방문 후 다시 돌아옴
			public Player(string name, Job job, int hp) : this(name, job) //(1)
			{
				this.hp = hp;   //(2)
				this.mp = 0;    //(3)
			}

			public void PrintPlaySpec()
			{
				Console.WriteLine($"player {name}의 직업은{job}, hp는 {hp}, mp는 {mp}입니다.");
			}
		}

		private void StudyStruct()
		{
			Player p1 = new Player("김전사", Job.Warrior);
			Player p2 = new Player("이법사", Job.Mage);
			Player p3 = new Player("박궁수", Job.Archor, 70, 70);
			Player p4 = new Player();
			Player p5 = new Player("홍길동", Job.Archor, 30);

			p1.PrintPlaySpec();
			p2.PrintPlaySpec();
			p3.PrintPlaySpec();
			p4.PrintPlaySpec();
			p5.PrintPlaySpec();

			/* 결과
				player 김전사의 직업은Warrior, hp는 100, mp는 10입니다.
				player 이법사의 직업은Mage, hp는 20, mp는 100입니다.
				player 박궁수의 직업은Archor, hp는 70, mp는 70입니다.
				player 의 직업은Warrior, hp는 0, mp는 0입니다.
				player 홍길동의 직업은Archor, hp는 30, mp는 0입니다.
			 */
		}
	}
}
