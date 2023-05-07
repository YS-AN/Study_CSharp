﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm02_DataType
{
	/// <summary>
	/// 변수 : 컴퓨터가 데이터를 저장하는 곳
	/// </summary>
	internal class DataType
	{
		/*
		 * 자료의 형태를 저장
		 * 데이터가 메모리에 저장되는 형태와 처리되는 방식을 명시하는 역할
		 * 0과 1만으로 구성된 컴퓨터에게 여러 형태의 자료를 저장하기위한 방법
		 * 
		 * [자료형의 종류]
		 * <논리형>
		 *	bool : true, false
		 *	
		 * <정수형> 
		 *	byte :	1byte, 부호없는 정수 (1byte = 8bit -> 0 ~ 255)
		 *	int  :	4byte, 부호있는 정수 (-2^31 ~ 2^31-1)
		 *	uint :	4byte, 부호없는 정수 (0 ~ 2^32-1) : 보통 마이너스 값이 들어오지 못하게 막거나 더 큰 수를 더 빠른 속도로 처리하기 위해 사용함
		 *	long :	8byte, 부호있는 정수 (-2^63 ~ 2^63-1)
		 *	ulong :	8byte, 부호없는 정수 (0 ~ 2^64-1)
		 *	- 분석 방식 : 2의 보수체계의 2진수 
		 *	
		 *	.
		 *	<부동소수점형>
		 *	float	: 4byte, 부동소수 (+-1.5e-45 ~ 3.4e38)
		 *	double	: 8byte, 부동소수 (+-5.0e-324 ~ 1.7e308)
		 *	- 보통은 double를 많이 쓰는 편이지만,  게임 개발은 실시간으로 빠른 지원이 더 중요하기 때문에 float를 더 많이 사용하는 편임. 
		 *	
		 *	<문자형>
		 *	char	: 16bit, 유니코드
		 *	string	: 유니코드 문자열 
		 *	
		 *	** byte가 커지면 처리 속도가 느려지니 적절하게 변수를 정해서 사용하면 됨
		 *	
		 ************************************************************************************************************************************************
		 *
		 * 변수 (Variable)
		 * 데이터를 저장하기 위해 프로그램에 의해 이름을 할당받은 메모리 공간
		 * 데이터를 저장할 수 있는 메모리 공간을 의미, 저장도니 값은 변경이 가능함
		 * 
		 * <변수 선언 및 초기화>
		 * [자료형] [변수명] = (초기화 값);
		 * 
		 * <변수명으로 사용하지 못하는 경우>
		 * 예약어를 변수명으로 사용하는 경우 (ex. int int = 1;)
		 * 숫자로 시작하는 변수명을 사용하는 경우 (ex. int 1val = 1;)
		 * 이미 위에서 선언한 변수명을 다시 선언하는 경우 (중복선언 불가)
		 * 
		 * <변수의 저장>
		 * 변수를 좌측값으로 배치
		 * 
		 * <변수의 데이터 불러오기>
		 * 변수를 우측값으로 배치
		 * 변수를 데이터가 필요한 곳에 배치
		 ************************************************************************************************************************************************
		 *  
		 * 상수 (Constant)
		 * 프로그램이 실행되는 동안 변경할 수 없는 데이터
		 * 프로그램에서 값이 변경되기를 원하지 않는 데이터가 있을 경우 사용
		 * 데이터 불러오기만 가능함. 
		 * 
		 * <상수 선언 및 초기화>
		 * const [자료형] [상수명] = 초기값; > 상수는 초기화 없이 사용이 불가능함 
		 ************************************************************************************************************************************************ 
		 *
		 * 유니티는 보통 카멜식을 많이 사용함
		 */

		public void StudyDataType()
		{
			int intVal = 10; //변수선언 + 초기화 : int자료형의 이름인 intVal를 만들어 10의 데이터를 담아 보관한다고 선언함.
			float floatVal;

			Console.WriteLine($"intVal = {intVal}");
			//Console.WriteLine($"floatVal = {floatVal}"); //오류 : 변수에 값을 선언하지 않은 상태에서 출력을 하려고 하면 오류가 남

			//변수의 저장
			intVal = 5; 
			floatVal = 1.2f; // 그냥 소수점은 double가 기본형태임. float로 사용할 경우에는 이거 double아니고 float라는 걸 알려주기 위해 뒤에 "f"를 붙임
			Console.WriteLine($"intVal = {intVal}");
			Console.WriteLine($"floatVal = {floatVal}");

			//변수의 데이터 불러오기
			int otherIntVal = intVal; // otherIntVal 변수에 intVal 변수를 저장하는 것 > otherIntVal = 5와 같은 행위
			Console.WriteLine($"otherIntVal = {intVal}");

			const int MAX = 100; //상수 선언
			//MAX = 200;  //오류 : 상수는 데이터 변경 불가능함. 
			Console.WriteLine($"MAX = {MAX}");
		}

	}
}