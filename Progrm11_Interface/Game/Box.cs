using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progrm11_Interface.Game.Interface;

namespace Progrm11_Interface.Game
{
    /// <summary>
    /// 열면 보상이 나오는 객체
    /// </summary>
    internal class Box : IOpenable, IHitable
    {
        public void Open()
        {
            Console.WriteLine("박스를 열기");
        }

        public void Close()
        {
            Console.WriteLine("박스를 닫기");
        }

        public void Hit()
        {
            Console.WriteLine("2대 맞으면 부서짐");
        }
    }
}
