using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm17_SOKOBAN
{
	/// <summary>
	/// 방향정보를 담은 enum
	/// </summary>
	enum Direction
	{
		UP,
		DOWN,
		LEFT,
		RIGHT,
		AGAIN,
		BACK,
		NONE
	}

	/// <summary>
	/// 게임 맵에 필요한 요소 enum
	/// </summary>
	enum Tile
	{
		Wall,
		Box,
		Goal,
		BoxGoal,
		None
	}
}
