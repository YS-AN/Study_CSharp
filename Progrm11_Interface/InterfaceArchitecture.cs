using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm11_Interface
{
	// 인터페이스 분리 원칙 1 : 인터페이스는 하나의 큰 인터페이스로 구현하기보다 작은 단위들로 분리시켜 구성함
	// 잘못된 인터페이스 사용 예제
	public interface IMonster
	{
		void DropItem();
		void Move();
		void TakeDamage(int damage);
	}

	public class MonsterPlant1 : IMonster
	{
		public void DropItem()
		{
			Console.WriteLine("씨앗을 떨어뜨립니다.");
		}
		public void Move()
		{
			//식물인데... 움직일 수 있나...?  -> 의도에 벗어남 + 불필요한 함수의 정의
		}
		public void TakeDamage(int damage)  
		{
			// 데미지를 받지 않는 몬스터이지만 TakeDamage가 포함된 상태
			Console.WriteLine("아파.....ㅠ");
		}
	}

	//만약, 박스도 아이템을 떨구고, 움직이고, 데미지도 입는다면? -> 몬스터가 아닌데...? 의도에서 벗어남.
	public class BoxItem1 : IMonster
	{
		public void DropItem()
		{
			Console.WriteLine("드랍템 떨어뜨립니다.");
		}
		public void Move()
		{
			Console.WriteLine("한칸씩 이동함");
		}
		public void TakeDamage(int damage)  
		{
			Console.WriteLine("데미지를 받을 때마다 박스가 작아짐");
		}
	}

	//인터페이스의 분리
	//인터페이스를 작은 단위로 분리하면 적절하게 의도에 맞게 사용이 가능함
	public interface IItemDropable
	{
		void DropItem();
	}

	public interface IMoveable
	{
		void Move();
	}

	public interface ITakeDamageable
	{
		void TakeDamage(int damage);
	}

	public class MonsterPlant2 : IItemDropable, ITakeDamageable //적절하게 원하는 기능만 받아옴
	{
		public void DropItem()
		{
			Console.WriteLine("씨앗을 떨어뜨립니다.");
		}

		public void TakeDamage(int damage)
		{
			// 데미지를 받지 않는 몬스터이지만 TakeDamage가 포함된 상태
			Console.WriteLine("아파.....ㅠ");
		}
	}

	public class BoxItem2 : IItemDropable
	{
		public void DropItem()
		{
			Console.WriteLine("드랍템 떨어뜨립니다.");
		}
	}

	//인터페이스 분리의 원칙 2 : 사용하지 않을 인터페이스는 포함하지 않음
	// 인터페이스를 포함하지만 사용하지 않을 경우 포함하지 않도록 함   -> 함수가 있다는 것은 그 인터페이스의 고유 기능이라고 판단할 수 있기 때문
	// 개발자 입장에서 인터페이스를 포함하는 경우 해당 기능이 구현되었다고 파악하게 됨
	// ex. 지형이 이동하지 않는다면 인터페이스를 포함하지 않는 것이 가독성과 의미가 정확함
	// 코드 해석에 오해의 소지가 있을 만한 여지를 남기지 마라!

	public class Ground : IMoveable
	{
		public void Move()  //필요하지 않지만 포함 시키면 코드를 보는 사람 입장에서 땅이 움직일 수 있다라고 해석할 여지가 있음
		{
			
		}
	}


}
