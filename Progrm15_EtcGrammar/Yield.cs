using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm15_EtcGrammar
{
	/// <summary>
	/// Yield 
	/// </summary>
	internal class Yield
	{
		//Yield = 양보
		// 반복기를 통해 데이터 집합을 하나씩 리턴할 때 사용
		// 일시정지 효과

		//yield 사용하는 경우
		// 1. 반환할 데이터의 양이 커서 한꺼번에 반환하는 것보다 분할해서 반환하는 것이 효율적인 경우
		// 2. 함수가 무제한의 데이터를 리턴할 경우
		// 3. 이전단계까지의 결과에서 다음까지만의 계산이 필요한 경우

		//IEnumerable : 반복할 수 있다라는 행동에 대한 c#의 인터페이스임
		public IEnumerable<int> GetNumber()
		{
			Console.WriteLine("[GetNumber] 10");
			yield return 10;
			Console.WriteLine("[GetNumber] 20");
			yield return 20;
			Console.WriteLine("[GetNumber] 30");
			yield return 30;
			Console.WriteLine("[GetNumber] 40");
			yield return 40;
			Console.WriteLine("[GetNumber] 50");
			yield return 50;
		}

		public class Test_IEnumerable : IEnumerable<int>
		{
			public IEnumerator<int> GetEnumerator()
			{
				throw new NotImplementedException();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				throw new NotImplementedException();
			}
		}

		public void Test()
		{
			//foreach반복문은 IEnumerable 인터페이스가 포함된 데이터 집합을 반복하는 방식임
			// IEnumerable을 상속받은 모든 데이터를 foreach에 들어갈 수 있음

			//Test_IEnumerable testEnumer = new Test_IEnumerable();
			//foreach (int num in testEnumer) { } // IEnumerable을 포함하고 있으니 그냥 클래스라도 들어감

			foreach (int num in GetNumber())
			{
				Console.WriteLine($"{num} - FOREACH");
			}
			//분명 return을 받아 값을 가져왔는데 그 다음 호출에는 10이 아닌 20을, 20 다음에는 30을 불러와
			// > reutrn 마지막 위치를 기억하고 있다가 그 다음 행부터 return을 만날 때까지 수행함. 
			// > return 만나면 그 행에서 일지성지하고, 값 리턴해줌 > 그 다음 호출 때까지 다시 일지정지 상태임. 

			// return 위치에서 일시정지만 하는거지 실행 순서는 순차적이기 때문에 스파게티 소스가 되진 않음

			foreach (int num in Repeater(5))
				Console.WriteLine(num);

			foreach(int num in UntilPlus(new int[5] { 1, 3, 5, -1, 4}))
				Console.WriteLine(num);

		}

		//yield 형식
		// yield return : 반복에서 다음을 제공
		// 무한히 반복하는 형태에서도 사용 가능함
		IEnumerable<int> Repeater(int count)
		{
			for (int i = 0; i < count + 10; i++)
			{
				yield return i; //다음을 제공함. 
			}
		}


		//yiedl break; 반복의 끝
		IEnumerable<int> UntilPlus(IEnumerable<int> numbers)
		{
			foreach (int n in numbers)
			{
				if (n > 0)
				{
					yield return n;
				}
				else
				{
					yield break;
				}
				Console.WriteLine(n);
			}
		}
	}
}
