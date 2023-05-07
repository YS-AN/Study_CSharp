using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm02_DataType
{
	/// <summary>
	/// 배열
	/// </summary>
	internal class ArrayType
	{
		public void StudyArrayType()
		{
			int[] iArr; //int배열 선언
			iArr = new int[200]; //int 데이터를 200개 가지는 배열을 선언함 

			//선언과 동시에 초기화
			int[] iArr2 = new int[200];
			int[] iArr3 = { 1, 2, 3, 4, 5 }; //각 배열의 요소 값까지 초기화 하는 방법. 

			//배열의 접근 - index
			iArr[19] = 200;
			iArr[3] = iArr[19];

			//다차원 배열의 선언
			int[,] iMat = new int[8, 8]; //2차원 배열
			int[,,] iCube = new int[3, 3, 3]; //3차원 배열

			//다차원 배열 접근
			iMat[5, 4] = 10;
			iCube[0, 1, 2] = 7;
		}
	}
}
