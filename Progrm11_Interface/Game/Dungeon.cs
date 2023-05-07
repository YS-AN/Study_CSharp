using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progrm11_Interface.Game.Interface;

namespace Progrm11_Interface.Game
{
    /// <summary>
    /// 진입해서 다른 지역으로 이동하는 객체
    /// </summary>
    internal class Dungeon : IEnterable
    {
        public void Enter()
        {
            Console.WriteLine("던전 입장");
        }

        public void Exit()
        {
            Console.WriteLine("던전 퇴장");
        }
    }
}
