namespace Progrm01_Console
{
	internal class Program
	{
		static void Main(string[] args)
		{
			StartConsole startConsole = new StartConsole();
			startConsole.ReadAndWrite();

			Tranning tranning = new Tranning();
			tranning.StartTraining0327();
		}
	}
}