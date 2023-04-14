using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm16_Practice
{
	/// <summary>
	/// 문자열을 입력받으면 단어의 갯수를 출력하기
	/// </summary>
	internal class CountString
	{
		public void DoCountString()
		{
			Console.Write("입력 : ");
			string inputStr = Console.ReadLine();
			Console.WriteLine(inputStr.Trim().Split(" ").Length);
		}
	}
}
