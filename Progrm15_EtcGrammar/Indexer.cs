using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm15_EtcGrammar
{
	/// <summary>
	/// 인덱서 정의
	/// </summary>
	public class IndexClass
	{
		private int[] data = new int[10];

		//this의 배열로 만듦 = 인덱서 -> 배열의 getter, setter임
		public int this[int index] 
		{
			get
			{
				if (index < 0 || index >= data.Length)
					throw new IndexOutOfRangeException();
				else
					return data[index];
			}
			set
			{
				if (index < 0 || index >= data.Length)
					throw new IndexOutOfRangeException();
				else
					data[index] = value;
			}
		}
	}
	public class Indexer
	{
		public void Test()
		{
			IndexClass instance = new IndexClass();

			// 인덱서를 통한 배열방식의 접근
			instance[5] = 20;       // set 접근
			int i = instance[5];    // get 접근
		}
	}
}




