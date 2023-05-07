using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm07_UserDefinedType
{
	public class Tranning
	{
		public void StartTraining0331()
		{
			Play_RockPaperScissors();
			Console.WriteLine();

			Student st1 = new Student("홍길동", 19, 50, 100, 30, 73);
			Student st2 = new Student("홍길순", 10, 78, 89, 91, 56);

			st1.PrintStudentInfo();
			st2.PrintStudentInfo();
			Console.WriteLine();

			CheckedTrumpCard();
			Console.WriteLine();
		}

		/// <summary>
		/// 가위바위보
		/// </summary>
		enum RPS
		{
			Rock,
			Scissors,
			Paper,
		}

		/// <summary>
		/// 가위, 바위, 보 게임
		/// </summary>
		private void Play_RockPaperScissors()
		{
			int playerAnswer = -1;

			Console.WriteLine("☆★☆★가위바위보 게임!!☆★☆★");
			Console.Write("가위, 바위, 보 중 하나를 숫자로 입력해주세요. (바위 = 0, 가위 = 1, 보 = 2) : ");
			bool isCorrect = int.TryParse(Console.ReadLine(), out playerAnswer);

			if (isCorrect)
			{
				CheckedResult((RPS)playerAnswer);
				//CheckedResult(playerAnswer); 
			}

		}

		/// <summary>
		/// 결과 확인 및 출력
		/// </summary>
		/// <param name="player"></param>
		private void CheckedResult(RPS player)
		{
			RPS computer = (RPS)GetCoumputerAnser(); //컴퓨터 가위, 바위, 보 얻어옴

			string result;
			if (computer == player) //같으면 비김
			{
				result = "비김";
			}
			else
			{
				//가위바위보 결과 확인
				switch (player)
				{
					case RPS.Scissors:
						result = computer == RPS.Rock ? "패배" : "승리";
						break;
					case RPS.Rock:
						result = computer == RPS.Paper ? "패배" : "승리";
						break;
					case RPS.Paper:
						result = computer == RPS.Scissors ? "패배" : "승리";
						break;
					default:
						result = "입력오류"; break;
				}
			}

			Console.WriteLine($"결과 : {result}");
		}

		private void CheckedResult(int player)
		{
			int computer = (GetCoumputerAnser() + 1) % 3;

			string result;
			if (player == computer)
			{
				result = "비김";
			}
			else
			{
				result = player < computer ? "승리" : "패배";
			}
			Console.WriteLine($"가위 바위 보 결과 : {result} (컴퓨터 선택 : {(RPS)computer})");
		}

		/// <summary>
		/// 컴퓨터에서 랜덤 값 가져오기
		/// </summary>
		/// <returns></returns>
		private int GetCoumputerAnser()
		{
			Random rand = new Random();
			return rand.Next(3);
		}

		/// <summary>
		/// 학생 구조체
		/// </summary>
		struct Student
		{
			public string name;
			public int age;

			public int english; //영어
			public int korean;  //국어
			public int math;    //수학
			public int science; //과학

			private int[] scores; //점수 배열

			public Student(string name, int age, int eng, int kor, int math, int sci)
			{
				this.name = name;
				this.age = age;
				this.english = eng;
				this.korean = kor;
				this.math = math;
				this.science = sci;
				scores = new int[4] { english, korean, this.math, science };
			}

			/// <summary>
			/// 평균 점수 구하기
			/// </summary>
			/// <returns></returns>
			public float GetAverage()
			{
				return (english + korean + math + science) / 4f; //평균값을 float로 반환
			}

			/// <summary>
			/// 최고점수 구하기
			/// </summary>
			/// <returns></returns>
			public int GetMaxScore()
			{
				/*
                 //배열을 순회하며 가장 큰 수를 max변수에 저장
                int max = 0;
                for (int i = 0; i < scores.Length - 1; i++)
                {
                    for (int j = i + 1; j < scores.Length; j++)
                    {
                        max = scores[i] > scores[j] ? scores[i] : scores[j];
                    }
                }
                return max; //*/

				return scores.Max();
			}

			/// <summary>
			/// 최저점수 구하기
			/// </summary>
			/// <returns></returns>
			public int GetMinScore()
			{
				/*
                //배열을 순회하며 가장 작은 수를 min변수에 저장
                int min = 0;
                for (int i = 0; i < scores.Length - 1; i++)
                {
                    for (int j = i + 1; j < scores.Length; j++)
                    {
                        min = scores[i] < scores[j] ? scores[i] : scores[j];
                    }
                }
                return min; //*/

				return scores.Min();
			}

			/// <summary>
			/// 학생 정보 출력
			/// </summary>
			public void PrintStudentInfo()
			{
				float avg = GetAverage();
				int max = GetMaxScore();
				int min = GetMinScore();

				Console.WriteLine($"{name}({age})의 평균점수 : {avg}점, 최대점수는 {max}점, 최저점수는 {min}점 입니다.");
			}
		}


		/// <summary>
		/// 트럼프 카드 족보 출력
		/// </summary>
		private void CheckedTrumpCard()
		{
			List<TrumpCard> cards = GetCards();

			PrintCards(cards);

			bool isSamePattn = IsAllSamePattern(cards);
			bool isSeqNum = IsSequenceNumbers(cards.Select(x => x.number).OrderBy(x => x).ToList());
			PrintResult(isSamePattn, isSeqNum, cards);
		}

		/// <summary>
		/// 카드를 랜덤으로 뽑기
		/// </summary>
		/// <returns></returns>
		private List<TrumpCard> GetCards()
		{
			Random rand = new Random();

			List<TrumpCard> cards = new List<TrumpCard>();
			for (int i = 0; i < 5; i++)
			{
				int type = rand.Next(4); //카드 문양 뽑기
				int number = rand.Next(13) + 1; //카드 번호 뽑기

				cards.Add(new TrumpCard((CardPattern)type, number)); //카드를 리스트에 저장
			}
			return cards;
		}

		/// <summary>
		/// 뽑은 카드 출력
		/// </summary>
		/// <param name="cards"></param>
		private void PrintCards(List<TrumpCard> cards)
		{
			Console.WriteLine("뽑은 카드는 다음과 같습니다.");
			cards.ForEach(x => Console.WriteLine($"{x.pattern} : \t {(CardNumTxt)x.number}"));
			Console.WriteLine("*****************************************************\n");
		}

		/// <summary>
		/// 카드의 문양이 모두 같은지 확인 
		/// </summary>
		/// <param name="cards">생성된 카드 리스트</param>
		/// <returns></returns>
		private bool IsAllSamePattern(List<TrumpCard> cards)
		{
			//0번과 같은 모양의 개수를 matchedCnt변수에 저장
			int matchedCnt = cards.Where(x => x.pattern == cards[0].pattern).Count();
			return (matchedCnt == 5); //모두 같으면 matchedCnt가 5가 나옴
		}

		/// <summary>
		/// 숫자가 연속되어 있는지 확인
		/// </summary>
		/// <param name="nums">카드 숫자 리스트</param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		private bool IsSequenceNumbers(List<int> nums)
		{
			//정렬된 카드 숫자를 돌면서 숫자-인덱스가 0번째 방과 같은지 확인
			//  -> 같으면 연속된 숫자임 (1씩 증가했다는 결과니까)
			int baseNum = nums[0];
			for (int i = 1; i < nums.Count; i++)
			{
				if (baseNum != nums[i] - i)
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 결과 출력
		/// </summary>
		/// <param name="isSamePattn">카드가 모두 같은 모양인지</param>
		/// <param name="isSeqNum">카드 숫자가 연속되어있는지</param>
		/// <param name="cards">생성된 카드 리스트</param>
		private void PrintResult(bool isSamePattn, bool isSeqNum, List<TrumpCard> cards)
		{
			//모양이 같은 경우나 연속된 경우값을 enum번호로 저장
			int cardTypeNum = isSamePattn ? (isSeqNum ? 12 : 11) : (isSeqNum ? 10 : 1);

			if (cardTypeNum == 1)
			{
				//카드 번호를 같은 번호 그룹별로 묶고,
				//같은 숫자가 1개이면 버림 (같은 숫자가 몇개인지만 확인하면 되기 때문)
				var list = cards.GroupBy(g => g.number)
						   .Select(x => new
						   {
							   number = x.Key,
							   cnt = x.Count()
						   })
						   .Where(x => x.cnt > 1).ToList();


				if (list.Count == 1)  //같은 숫자 묶음이 1개인 경우
				{
					cardTypeNum = list[0].cnt; // 동일한 카드 수 = enum번호임
				}
				else if (list.Count == 2)  //같은 숫자 묶음이 2개인 경우
				{
					//동일한 카드 수 + 카드 묶음 중 묶음 카드 수가 가장 작은 수 = enum 번호
					cardTypeNum = list.Sum(x => x.cnt) + (list[0].cnt < list[1].cnt ? list[0].cnt : list[1].cnt);
				}
			}

			string result = ((TrumpCardType)cardTypeNum).ToString(); //결과를 문자열로 반환

			if (int.TryParse(result, out cardTypeNum)) //문자열로 변환되지 않으면 꽝임
			{
				Console.WriteLine("결과 : High Card");
			}
			else //변환된 값을 출력함
			{
				Console.WriteLine($"결과 : {result.Replace("_", " ")}");
			}
		}
	}
}