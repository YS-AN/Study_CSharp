using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm14_Event.Basic
{
	internal class Player
	{
		public event Action OnGetCoin;
		public event Action<int> OnSetCoin;
		//Action 델리게이트가 반환형이 없고, 파라미터를 받을 수 있음
		//파라미터는 < > 안에 변수타입으로 지정함. -> 최대 16개의 파라미터를 받을 수 있음

		public void GetCoin()
		{
			Console.WriteLine("플레이어가 코인을 얻음");

			//코인 먹은 후 행동
			//1.사운드 들림
			//2.이펙트로 반짝반짝
			//3. UI도 코인이 올라야함
			//  -> 직접 메소드 호출로 발생하는 것보단 코인만 먹으면 이후 행동은 이벤트로 태움

			//if (OnGetCoin != null) OnGetCoin(); //oinGetCoin이 Null이 아니면 진행
			OnGetCoin?.Invoke();
		}

		public void SetCoin(int coin)
		{
			Console.WriteLine($"{coin}이 추가 됨");
			OnSetCoin?.Invoke(coin);
		}
	}
}

