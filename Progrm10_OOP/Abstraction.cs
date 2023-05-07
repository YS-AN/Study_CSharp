using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm10_OOP
{
	/// <summary>
	/// 추상화
	/// > 관련 특성 및 엔터티의 상호 작용을 클래스로 모델링하여 시스템의 추상적 표현을 정의
	/// </summary>
	internal class Abstraction
	{
		public void StudyAbstraction()
		{
			// Animal animal = new Animal(); // 오류 : 추상클래스의 인스턴스는 생성불가
			Animal bird = new Bird(); // 추상클래스를 구체화시킨 자식클래스의 인스턴스는 생성가능
			Animal dog = new Dog();

			bird.Cry(); //출력 : 짹짹
			dog.Cry();  //출력 : 멍멍
		}
	}

	public abstract class Animal
	{
		public abstract void Cry(); //추상 함수 > 내용 정의X
	}

	public class Bird : Animal
	{

		public override void Cry() //추상 함수 내용 실체화
		{
			Console.WriteLine("짹짹");
		}
	}

	public class Dog : Animal
	{
		public override void Cry() //추상 함수 내용 실체화
		{
			Console.WriteLine("멍멍");
		}
	}
}
