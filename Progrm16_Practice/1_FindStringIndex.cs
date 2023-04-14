using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm16_Practice
{
	/// <summary>
	/// 문자열 속에 문자 찾기
	/// </summary>
	internal class FindStringIndex
	{
		public void DoFindStringIndex()
		{
			Console.Write("입력 : ");
			string inputStr = Console.ReadLine();

			Console.Write("찾을 값 입력 : ");
			string findStr = Console.ReadLine();

			Console.WriteLine(inputStr.IndexOf(findStr));

		}
	}
}