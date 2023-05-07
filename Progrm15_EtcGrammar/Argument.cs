using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm15_EtcGrammar
{
	internal class Argument
	{
		//Named Parameter : 이름으로 호출--------------------------------------
		public void Func1(int iParam, float fParam, string strParam) { }

		public void Test()
		{
			Func1(1, 3f, "asdf"); //기본 호출 방법

			Func1(strParam: "asdf", iParam: 1, fParam: 3f); //Named Parameter 호출 방법
		}

		//Optional Parameter : 초기 값 세팅------------------------------------
		public void Func2(int param1, int param2 = 9, int param3 = 5) { }

		public void Test2()
		{
			//값이 있으면 덮어써지고, 값이 없으면 초기 값으로 들어감
			Func2(3, 5, 7); // = Func2(3, 5, 7);
			Func2(3, 5);    // = Func2(3, 5, 5);
			Func2(3);       // = Func2(3, 9, 5);
		}

		//Params Parameter : 유동적 매개변수-----------------------------------
		public void Func3(params int[] prms) { } //배열로 받음

		public void Test3()
		{
			Func3(1, 2, 3, 4, 5);
			Func3(1, 2, 3);
			Func3(); //안 집어 넣어도 돼
		}

		//in & out parameter : 입력 또는 출력 전용 설정 ------------------------
		public void Func4(in int inPrm, out int outPrm) //입력 전용 변수 
		{
			//param = 10;  //오류 : 입력전용이기 때문에 함수 내에서 값 변경은 불가함

			outPrm = inPrm; //출력 전용은 함수 내부에서 1회 이상 값 세팅 되어야 함. (한번도 값이 세팅되지 않으면 오류남)
		}

		public void Test4()
		{
			int inVal;
			int outVal;
			//Func4(inVal, out outVal); 
			// 오류 : 입력 전용은 초기화 되지 않은 변수는 넘겨줄 수 없음
			// 변수 앞에 in 키워드는 생략이 가능하지만 out 키워드는 생략할 수 없음. 

			inVal = 5;
			Func4(inVal, out outVal); //in은 생략 가능.
			Func4(6, out outVal); 
			//in은 직접적으로 값을 넘겨줘도 됨.
			//out은 값이 담겨서 나올 거라 무조건 변수를 넘겨줘야 함.
		}
	}
}
