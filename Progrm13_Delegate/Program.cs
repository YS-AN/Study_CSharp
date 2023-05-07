namespace Progrm13_Delegate
{
	internal class Program
	{
		static void Main(string[] args)
		{
			StudyDelegate studyDelegate = new StudyDelegate();

			studyDelegate.Test1();
			studyDelegate.Test2();
			
			studyDelegate.Test_Func();
			studyDelegate.Test_Action();
			studyDelegate.Test_Predi();

			Specifier specifier = new Specifier();
			specifier.Test();

			Lamda lamda = new Lamda();
			lamda.Test();
		}
	}
}