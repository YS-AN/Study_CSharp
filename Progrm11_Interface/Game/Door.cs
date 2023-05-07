using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progrm11_Interface.Game.Interface;

namespace Progrm11_Interface.Game
{
    /// <summary>
    /// 열어서 문을 통과하거나 진입해서 다른 지역으로 갈 수 있음
    /// </summary>
    internal class Door : IOpenable, IEnterable, IHitable
    {
        public void Open()
        {
            Console.WriteLine("문을 염");
        }

        public void Close()
        {
            Console.WriteLine("문 닫음");
        }

        public void Enter()
        {
            Console.WriteLine("문을 통해 입장");
        }

        public void Exit()
        {
            Console.WriteLine("문을 통해 퇴장");
        }

        public void Hit()
        {
            Console.WriteLine("문이 부서짐");
        }
    }
}
