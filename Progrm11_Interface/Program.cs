using Progrm11_Interface.Game;

namespace Progrm11_Interface
{
    internal class Program
	{
		static void Main(string[] args)
		{
			//InterfaceBasic.cs : 인터페이스 기초
			//InterfaceArchitecture.cs : 인터페이스 분리 원칙

			PlayProgram playProgram = new PlayProgram();
			playProgram.Main();

			Tranning.Game game = new Tranning.Game();
			game.PlayGame();
		}
	}
}