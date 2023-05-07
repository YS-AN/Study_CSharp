namespace Progrm09_CallBy
{
	internal class Program
	{
		static void Main(string[] args)
		{
			CallByData callByData = new CallByData();
			callByData.StudyCallBy();

			StaticArea.StudyStatic();

			ConvertValtoRef cnvrtValtoRef = new ConvertValtoRef();
			cnvrtValtoRef.pirntSwap();
		}
	}
}