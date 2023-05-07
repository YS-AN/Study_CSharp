using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm07_UserDefinedType
{
	/// <summary>
	/// 트럼프 카드
	/// </summary>
	public class TrumpCard
	{
		public int number { get; set; }
		public CardPattern pattern { get; set; }

		public TrumpCard(CardPattern pattern, int number)
		{
			this.number = number;
			this.pattern = pattern;
		}
	}
}
