using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm17_SOKOBAN
{
	public partial class GameSokoban
	{
		static MoveSave SavePoint;

		struct MoveSave
		{
			private int top;
			private MapInfo[] Back;

			public MoveSave()
			{
				top = -1;
				Back = new MapInfo[200];
			}

			public void Push(MapInfo mapInfo)
			{
				if (top < Back.Length)
				{
					Back[++top] = CopyMapInfo(mapInfo);
				}
			}

			public MapInfo Pop()
			{
				return top >= 0 ? Back[top--] : new MapInfo(new Tile[1, 1], new Point(), -1);
			}

			public bool IsPossiblePOP()
			{
				return (top >= 0);
			}

			public bool IsPossiblePush()
			{
				return (top < Back.Length);
			}

			public void Clear()
			{
				SavePoint = new MoveSave();
			}
		}
	}
}
