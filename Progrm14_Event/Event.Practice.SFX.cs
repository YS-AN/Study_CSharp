using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm14_Event.Basic
{
	/// <summary>
	/// 사운드 이펙트
	/// </summary>
	public class SFX
	{
		public void CoinSound()
		{
			Console.WriteLine("코인을 얻는 음악을 재생");
		}

		public void CoinSound(int coin)
		{
			Console.WriteLine($"코인을 얻는 음악을 재생 x {coin}");
		}
	}
}
