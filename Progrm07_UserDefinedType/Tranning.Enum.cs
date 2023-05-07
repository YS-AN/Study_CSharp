using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm07_UserDefinedType
{
	/// <summary>
	/// 카드 문양
	/// </summary>
	public enum CardPattern
	{
		Diamond,
		Heart,
		Clover,
		Spade
	}

	/// <summary>
	/// 카드 Number 
	/// </summary>
	public enum CardNumTxt
	{
		J = 11,
		Q = 12,
		K = 13,
	}

	/// <summary>
	/// 트럼프 카드 족보
	/// </summary>
	enum TrumpCardType
	{
		/// <summary>
		/// 꽝 = 1
		/// </summary>
		High_Card = 1,

		/// <summary>
		/// 같은 숫자 2장 = 2
		/// </summary>
		One_Pair,

		/// <summary>
		/// 같은 숫자 3장 = 3
		/// </summary>
		Trips,

		/// <summary>
		/// 같은 숫자 4장 = 4
		/// </summary>
		Four_of_a_Kind,

		/// <summary>
		/// 같은 숫자 2장 + 2장 = 6
		/// </summary>
		Two_Pair = 6,

		/// <summary>
		/// 같은 숫자 3장 + 같은 숫자 2장 = 7
		/// </summary>
		Full_House,

		/// <summary>
		/// 연속 된 숫자 5장 = 10
		/// </summary>
		Straight = 10,

		/// <summary>
		/// 카드 무늬 다 같음 = 11
		/// </summary>
		Flush,

		/// <summary>
		/// 연속 된 숫자 5장 + 같은 무늬 = 12
		/// </summary>
		Straight_Flush
	}
}
