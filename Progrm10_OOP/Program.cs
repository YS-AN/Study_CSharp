using Programming;

namespace Progrm10_OOP
{
	/// <summary>
	/// 객체지향 프로그래밍
	/// </summary>
	internal class Program
	{
		static void Main(string[] args)
		{
			Encapsulation encapsulation = new Encapsulation();
			encapsulation.StudyEncapsulation();

			Inheritance inheritance = new Inheritance();
			inheritance.StudyInheritance();

			Abstraction abstraction = new Abstraction();
			abstraction.StudyAbstraction();

			Polymorphism polymorphism = new Polymorphism();
			polymorphism.StudyPolymorphism();

			Tranning tranning = new Tranning();
			tranning.StartTraining0406();
		}
	}
}