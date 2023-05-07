using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progrm14_Event.Basic;
using Progrm14_Event.Architecture;

namespace Progrm14_Event
{
	internal class StudyEvent
	{
		public void Test()
		{
			EventDeclAndCons();
			Console.WriteLine();

			UseEvent();
			Console.WriteLine();

			EventArchitecture();
			Console.WriteLine();
		}

		/// <summary>
		/// 이벤트 선언과 제약사항
		/// </summary>
		private void EventDeclAndCons()
		{
			EventBroadCaster broadCaster = new EventBroadCaster(); //이벤트 발생지

			EventListener listener1 = new EventListener("사운드 매니저");
			EventListener listener2 = new EventListener("이팩트 매니저");
			EventListener listener3 = new EventListener("UI 매니저");

			//이벤트 발생 시, 반응하고자 하는 함수를 추가해 줌
			//이벤트 제약사향1 : 무조건 +=, -=를 통해서만 함수를 추가하거나 제거
			broadCaster.OnEvent += listener1.ReceiveMessage;
			broadCaster.OnEvent += listener2.ReceiveMessage;
			broadCaster.OnEvent += listener3.ReceiveMessage;

			//이벤트 제약사항2 : 외부에서 이벤트 발생 불가
			//broadCaster.OnEvent("데미지 받음"); //델리게이트를 통해서도 호출 가능, but 외부에서 호출 가능
			broadCaster.Progress("데미지 받음"); //이벤트 변수로 선언하면 onEvent를 직접적으로 호출할 수 없음 
		}

		/// <summary>
		/// 이벤트 활용 : 코인 넣으면 이후 동작이 실행
		/// </summary>
		private void UseEvent()
		{
			Player player = new Player();
			SFX sfx = new SFX();
			VFX vfx = new VFX();
			UI ui = new UI();

			player.OnGetCoin += sfx.CoinSound;
			player.OnGetCoin += vfx.CoinEffect;
			player.OnGetCoin += ui.CoinUI;
			player.GetCoin();
			Console.WriteLine();

			player.OnGetCoin -= sfx.CoinSound; //사운드 기능 제거
			player.GetCoin();

			player.OnSetCoin += sfx.CoinSound;
			player.SetCoin(123);
		}

		/// <summary>
		/// 설계에서의 이벤트
		/// </summary>
		private void EventArchitecture()
		{

		}
	}

	public class EventBroadCaster
	{
		public delegate void EventDelegate(string msg);
		//public EventDelegate OnEvent; //델리게이트 변수
		public event EventDelegate OnEvent; //이벤트 변수 -> 델리게이트 통해 이벤트 변수 생성 (대라자 역할)

		public void Progress(string msg)
		{
			if (OnEvent != null)
			{
				Console.WriteLine("이벤트 발생!");
				OnEvent(msg); //이벤트 발생
			}
			//onEvent?.Invoke(msg); //? null조건 연산자 : null이 아니면 수행하고, null이면 수행 안 함. if문 간단히 표현한 것 

		}

		public void Hit()
		{
			OnEvent("데미지 받음");
		}
	}

	public class EventListener
	{
		public string name;

		public EventListener(string name)
		{
			this.name = name;
		}

		public void ReceiveMessage(string msg)
		{
			Console.WriteLine($"{name} -> {msg} 이벤트를 받음");
		}
	}

}
