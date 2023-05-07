using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progrm11_Interface.Game.Interface;

namespace Progrm11_Interface.Game
{
    public class Player
    {
        public void Open(IOpenable openable) //열 수 있는 객체면 뭐든 연다 > 인터페이스를 통한 상호작용
        {
            openable.Open();
        }

        public void Close(IOpenable openable) //닫을 수 있는 객체면 뭐든 닫는다
        {
            openable.Close();
        }

        public void Enter(IEnterable enterable) //들어갈 수 있는 객체면 뭐든 들어간다
        {
            enterable.Enter();
        }

        public void Exit(IEnterable enterable) //나갈 수 있는 객체면 뭐든 나간다
        {
            enterable.Exit();
        }

        public void Attack(IHitable hitable)
        {
            hitable.Hit();
        }


    }
}
