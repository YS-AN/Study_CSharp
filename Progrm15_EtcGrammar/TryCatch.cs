using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm15_EtcGrammar
{
	/// <summary>
	/// 예외처리
	/// </summary>
	internal class TryCatch
	{
		public void DoTryCatch(int[] array)
		{
			try // 코드 실행 시도 부분
			{
				array[0] = 1;
				array[array.Length] = 2; // 예외를 발생시키는 코드 : 배열의 범위를 넘음 > IndexOutOfRangeException 발생
			}
			catch (IndexOutOfRangeException ex) 
			{
				Console.WriteLine("IndexOutOfRangeException");
				Console.WriteLine(ex.Message);
			}
			catch (NullReferenceException ex)
			{
				Console.WriteLine("NullReferenceException");
				Console.WriteLine(ex.Message);
			}
			catch (Exception ex) // 코드 예외 처리 부분 > 모든 Exception에 종료를 유예하고, 대해서 괄호 아래를 실행함. 
			{
				Console.WriteLine(ex.Message);  // 예외 발생상황에 대해 출력
			}
			finally // 생략가능 
			{
				// 코드 시도 후 진행하는 부분 > 정상 실행이 되었든, 오류가 났든 무조건 실행되는 부분임
				Console.WriteLine("FINALLY \n");
			}
		}

		public void Test()
		{
			DoTryCatch(new int[10]);
			DoTryCatch(null);

			try
			{
				NumberGenerator numberGenerator = new NumberGenerator();
				numberGenerator.GetType(-1);
			}
			catch (IndexOutOfRangeException ex)
			{
				Console.WriteLine("IndexOutOfRangeException : " + ex.Message);
			}
		}
		
	}

	// <throw> : 의도적 예외발생
	public class NumberGenerator
	{
		public enum MonsterType { None, Speed, Tank, Sky }
		MonsterType[] types = new MonsterType[4];

		public MonsterType GetType(int index)
		{
			if (index < 0 || index >= types.Length)
			{
				// 원하지 않은 상황에 throw 문을 통한 의도적 예외발생
				throw new IndexOutOfRangeException();
			}
			return types[index];
		}
	}
}
