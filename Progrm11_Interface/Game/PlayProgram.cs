using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progrm11_Interface.Game.Interface;

namespace Progrm11_Interface.Game
{
    internal class PlayProgram
    {
        public void Main()
        {
            Player play = new Player();
            Box box = new Box();
            Door door = new Door();
            Dungeon dungeon = new Dungeon();

            play.Open(box);
            play.Close(box);

            play.Enter(dungeon);
            play.Exit(dungeon);

            play.Open(door);
            play.Close(door);
            play.Enter(door);
            play.Exit(door);

            //이후에 추가되는 기능에 대해 유동적으로 처리가 가능함
            //삭제도 마찬가지임. 만약 door에서 hit이 필요 없어지면 IHitable을 삭제하면 돼! 
            // -> 상호작용의 규약이 생기는 것임
            play.Attack(door);
            play.Attack(box);
        }
    }
}
