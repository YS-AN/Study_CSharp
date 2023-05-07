using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm11_Interface
{
	internal interface IInterfaceBasic1
	{
		void BasicFunc1();
		void BasicFunc2();
	}

	internal interface IInterfaceBasic2
	{
		void BasicFunc1();
		void BasicFunc3();
		void BasicFunc4()
		{
			Console.WriteLine("BasicFunc4");
		}
	}


	//인터페이스의 다중 상속--------------------------------------------
	public interface Life
	{
		public void Breathe();
	}

	public interface LandCreatures : Life
	{
		public void Run();
	}

	public interface AquaticLife : Life
	{
		public void swim();
	}

	public class frog : LandCreatures, AquaticLife
	{
		public void Breathe()
		{
			Console.WriteLine("땅과 물에서 숨을 쉼");
		}

		public void Run()
		{
			Console.WriteLine("달림");
		}

		public void swim()
		{
			Console.WriteLine("헤엄침");
		}
	}
	//------------------------------------------------------------------


	// 추상클래스 VS 인터페이스-------------------------------------------

	/*계약조건 
	 * 1. 출입 가능
	 * 2. 창문 여닫기 가능
	 * 3. 전등 전원 온, 오프 가능
	*/

	/// <summary>
	/// 출입 가능
	/// </summary>
	public interface IAccessible
	{
		void Enter();
		void Exit();
	}

	/// <summary>
	/// 창문 여닫기 가능
	/// </summary>
	public interface IWindow
	{
		void OpenWindow();
		void CloseWindow();
	}

	/// <summary>
	/// 전등 전원 온, 오프 가능
	/// </summary>
	public interface ILightable
	{
		void TurnOnLight();
		void TurnOffLight();
	}

	public abstract class Building : IAccessible, IWindow, ILightable
	{
		public void Enter()
		{
			Console.WriteLine("건물에 들어갑니다.");
		}
		public void Exit()
		{
			Console.WriteLine("건물에서 나갑니다.");
		}
		public abstract void OpenWindow();
		public abstract void CloseWindow();
		public abstract void TurnOnLight();
		public abstract void TurnOffLight();
	}

	/// <summary>
	/// 은행은 건물이다 -> 말이 됨 -> 상속으로 구현
	/// 만약, 부모클래스인 건물을 수정할 경우, 자식클래스인 은행도 영향을 받음
	/// </summary>
	public class Bank : Building
	{
		public override void OpenWindow() { }
		public override void CloseWindow() { }

		public override void TurnOnLight() { }
		public override void TurnOffLight() { }
	}

	/// <summary>
	/// 기차는 건물이다 -> 말이 안 됨 -> 인터페이스로 구현
	/// 만약, 기차가 창문이 없거나 불이 들어오지 않을 경우 인터페이스를 포함하지 않도록 수정
	/// </summary>
	public class Train : IAccessible, ILightable
	{
		public void Enter() { }
		public void Exit() { }
		
		public void TurnOnLight() { }
		public void TurnOffLight() { }
	}
}

