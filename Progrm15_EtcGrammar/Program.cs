namespace Progrm15_EtcGrammar
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Additional additional = new Additional();
			additional.TypeDefMethod();
			additional.TypeDefStaticMethod();
			additional.OF_Operator();

			Argument argument = new Argument();
		

			ExtensionMethod.Test();

			Indexer indexer = new Indexer();
			indexer.Test();

			Nullable nullable = new Nullable();
			nullable.Test();

			Yield y = new Yield();
			y.Test();

			Console.WriteLine();

			TryCatch tryCatch = new TryCatch();
			tryCatch.Test();

			Console.WriteLine();
		}
	}
}