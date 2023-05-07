using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm12_Generic
{
	/// <summary>
	/// 일반화 (Generic)
	/// </summary>
	internal class Generic
	{
		//일반화를 사용하지 않는 경우 -> 필요한 자료형만큼 함수를 만들어 줘야해
		public void ArrayCopy(int[] source, int[] output)
		{
			output = new int[source.Length];
			for (int i = 0; i < source.Length;) { output[i] = source[i++]; }
		}

		public void ArrayCopy(float[] source, float[] output)
		{
			output = new float[source.Length];
			for (int i = 0; i < source.Length;) { output[i] = source[i++]; }
		}

		public void ArrayCopy(double[] source, double[] output)
		{
			output = new double[source.Length];
			for (int i = 0; i < source.Length;) { output[i] = source[i++]; }
		}

		public void Test1()
		{
			int[] iSrc = { 1, 2, 3, 4, 5 }, iDst = null;
			float[] fSrc = { 1f, 2f, 3f, 4f, 5f }, fDst = null;
			double[] dSrc = { 1d, 2d, 3d, 4d, 5d }, dDst = null;

			ArrayCopy(iSrc, iDst);
			ArrayCopy(fSrc, fDst);
			ArrayCopy(dSrc, dDst);
		}

		// 일반화를 이용하면 위 함수들과 다른 자료형의 함수 또한 호환할 수 있음
		public void ArrayCopy<T>(T[] src, T[] dst)
		{
			dst = new T[src.Length];
			for (int i = 0; i < src.Length; i++) { dst[i] = src[i]; }
		}

		public void Test2()
		{
			int[] iSrc = { 1, 2, 3, 4, 5 }, iDst = null;
			float[] fSrc = { 1f, 2f, 3f, 4f, 5f }, fDst = null;
			double[] dSrc = { 1d, 2d, 3d, 4d, 5d }, dDst = null;

			// 일반화된 함수로 자료형과 무관한 함수 구현
			ArrayCopy<int>(iSrc, iDst); // 자료형을 함수 호출당시 결정
			ArrayCopy<float>(fSrc, fDst);
			ArrayCopy<double>(dSrc, dDst);

			char[] cSrc = { 'a', 'b', 'c' }, cDst = null;
			ArrayCopy(cSrc, cDst);
			//자료형을 함수 호출 당시 결정 함 -> 매개 변수를 넘겨줄 때 T가 어떤 자료형인지 알 수 있음 -> <(자료형)>생략 가능
		}


		public void Test3<T>(T param) where T : MyBase
		{
			param.Start();
		}

		public void Test4()
		{
			StructClass<int> structClass = new StructClass<int>();  // int는 구조체이므로 struct 제약조건이 있는 일반화 가능
			// ClassClass<int> classClass = new ClassClass<int>();	// error : int는 구조체이므로 class 제약조건이 있는 일반화 불가
		}
	}

	// <일반화 자료형 제약>
	// 일반화 자료형을 선언할 때 제약조건을 선언하여, 일반화가 가능한 자료형을 제한
	class StructClass<T> where T : struct { }  // T는 Value 타입
	class ClassClass<T> where T : class { }             // T는 Reference 타입
	class ParentClass { }
	class ChildClass<T> where T : ParentClass { }       // T는 파생클래스이어야 함
	class InterfaceClass<T> where T : IComparable { }   // T는 IComparable 인터페이스를 가져야 함

	public class MyBase
	{
		public void Start()
		{
			Console.WriteLine("시작");
		}
	}

	public class A
	{
		public void Start()
		{
			Console.WriteLine("시작");
		}
	}
}
