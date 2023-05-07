using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm11_Interface.Tranning.Interface
{
	public enum Direction
	{
		Right,
		Left,
		Font,
		Back, 
		Home
	}

	internal interface IMove
	{
		public void Move(Direction direction, int distance);
	}
}
