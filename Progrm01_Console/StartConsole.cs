using System;
using System.Timers;

namespace Progrm01_Console
{
    /// <summary>
    /// console : 콘솔 프로그램 : 텍스트 형태로 입출력을 진행하는 프로그램
    /// </summary>
    internal class StartConsole
    {
        private static int _index = 0;
        private static string _printText;

        public void ReadAndWrite()
        {
            Console.WriteLine("who?"); //글자 입력
            var val = Console.ReadLine(); //엔터 입력할 때까지의 값을 입력 받음 / Console.Read() : 한글자만 입력 받음

            Console.WriteLine($"안녕하세요! 마스터님!!");

            //Console.WriteLine($"예?!?!?! 저는 그저 말하는 {val}인데요?!?!?!?");

            System.Timers.Timer timer = new System.Timers.Timer(1000);
            
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            timer.AutoReset = true;
            timer.Enabled = true;

            for (;;)
            {
                _printText = GetPrintText($"저는 그저 말하는 {val}인데요?!?!?!?");

                if (_index == 3)
                {
                    break;
                }

            }

            timer.Stop();
            timer.Dispose();
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine(_printText);
            _index++;
        }

        private string GetPrintText(string str)
		{
			switch (_index)
			{
                case 0: return "예?!?!?!";
                case 1: return str;
                default:return "";
            }
		}
    }
}