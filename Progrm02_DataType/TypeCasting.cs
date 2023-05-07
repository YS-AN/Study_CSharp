using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm02_DataType
{
	/// <summary>
	/// 형변한
	/// </summary>
	internal class TypeCasting
	{
		public void StartTypeCasting()
		{
			int iVal = (int)166.666666f; //정수는 소수점을 저장할 수 없기 때문에 소수점자리 절사

			float fVal = 3;//부동소수점형 변수에 정수 데이터를 넣은 경우, 자동으로 형 변환이 됨. 
			double dVal = 1.2f; //double은 float를 포함하는 큰 범위라 자동으로 형 변환이 됨. 

			fVal = (float)iVal;
			//일반적으로 변수의 형변환 같은 경우 자동형변환이 가능하다 하더라도 형변환을 적어줌
			//명시적으로 적어주는 과정을 통해 의도적으로 형변환을 진행했음을 나타냄. 

			//문자열 변환 > Parse를 이용해야함.
			string text = "142";
			iVal = int.Parse(text); //int.Parse를 통해 string자료형을 int형 자료형으로 사용한다 

			text = "abc";
			//iVal = int.Parse(text); //형변환이 불가능한 문자열을 변환하려 하는 경우 예외처리 발생 
			bool success = int.TryParse(text, out iVal); // 변환 가능 여부를 반환. 변환값은 iVal에 들어감. 

			Console.WriteLine($"처리 결과 : {success}, 값 : {iVal}");


			//char의 경우에는 숫자로 변환이 가능함. 

			int iVal2 = (int)'한';
			Console.WriteLine(iVal2); //유니코드 값이 반환 됨.

			int iVal3 = (int)'A';
			Console.WriteLine(iVal3); //아스키코드 값이 반환 됨
		}
	}
}
