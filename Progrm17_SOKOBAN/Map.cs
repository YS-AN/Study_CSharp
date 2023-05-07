using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm17_SOKOBAN
{
	public partial class GameSokoban
	{
		const int FINAL_LEVEL = 3;

		static MapInfo[] Maps = new MapInfo[FINAL_LEVEL];

		void SetGameMaps()
		{
			Maps[0] = new MapInfo(new Tile[8, 8] {
				{ Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall},
				{ Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Goal, Tile.Wall},
				{ Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.Box,  Tile.None, Tile.None, Tile.Wall},
				{ Tile.Wall, Tile.None, Tile.None, Tile.Wall, Tile.Wall, Tile.None, Tile.Goal, Tile.Wall},
				{ Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall},
				{ Tile.Wall, Tile.None, Tile.Box,  Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall},
				{ Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall},
				{ Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall},
			}, new Point(1, 1), 0);

			Maps[1] = new MapInfo(new Tile[8, 8] {
				{ Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.None, Tile.None},
				{ Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall, Tile.None, Tile.None},
				{ Tile.Wall, Tile.None, Tile.Box,  Tile.Box,  Tile.None, Tile.Wall, Tile.Wall, Tile.Wall},
				{ Tile.Wall, Tile.Wall, Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall},
				{ Tile.None, Tile.None, Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall},
				{ Tile.None, Tile.None, Tile.Wall, Tile.None, Tile.None, Tile.Goal, Tile.None, Tile.Wall},
				{ Tile.None, Tile.None, Tile.Wall, Tile.Wall, Tile.None, Tile.Goal, Tile.Wall, Tile.Wall},
				{ Tile.None, Tile.None, Tile.None, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.None},
			}, new Point(5, 4), 1);

			Maps[2] = new MapInfo(new Tile[7, 7] {
				{ Tile.None, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall},
				{ Tile.Wall, Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall},
				{ Tile.Wall, Tile.None, Tile.None, Tile.Box,  Tile.Wall, Tile.None, Tile.Wall},
				{ Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.Box,  Tile.None, Tile.Wall},
				{ Tile.Wall, Tile.Wall, Tile.None, Tile.Goal, Tile.None, Tile.Goal,  Tile.Wall},
				{ Tile.None, Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall},
				{ Tile.None, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall},
			}, new Point(5, 5), 2);
			/*
			Maps[1] = new MapInfo(new Tile[11, 12] {
				{ Tile.None, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None },
				{ Tile.None, Tile.Wall, Tile.None, Tile.None, Tile.Wall, Tile.None, Tile.None, Tile.Wall, Tile.Wall, Tile.Wall, Tile.None, Tile.None },
				{ Tile.None, Tile.Wall, Tile.None, Tile.None, Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall, Tile.Wall, Tile.Wall },
				{ Tile.None, Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.None, Tile.None, Tile.Wall, Tile.None, Tile.None, Tile.None, Tile.Wall },
				{ Tile.None, Tile.Wall, Tile.Wall, Tile.None, Tile.Wall, Tile.None, Tile.Box,  Tile.None, Tile.Box,  Tile.None, Tile.None, Tile.Wall },
			});*/
		}

		/// <summary>
		/// 플레이어 위치를 나타낼 구조체
		/// </summary>
		struct Point
		{
			public int x;
			public int y;

			public Point(int x, int y)
			{
				this.x = x;
				this.y = y;
			}
		}

		struct MapInfo
		{
			/// <summary>
			/// 게임 맵
			/// </summary>
			public Tile[,] Map;

			/// <summary>
			/// 플레이어 처음 시작 위치
			/// </summary>
			public Point Player;

			/// <summary>
			/// 이동 횟수
			/// </summary>
			public int Move;

			/// <summary>
			/// 레벨
			/// </summary>
			public int Level;

			public MapInfo(Tile[,] map, Point player, int level)
			{
				Map = map;
				Player = player;
				Level = level;
				Move = 0;
			}

			/// <summary>
			/// MapInfo 초기화
			/// </summary>
			public void MapInfoInit()
			{
				Level = 0;
				Move = 0;
				Map = (Tile[,])Maps[0].Map.Clone();
				Player = new Point();
				Player.x = Maps[0].Player.x;
				Player.y = Maps[0].Player.x;

				SavePoint.Clear();
			}
		}

		/// <summary>
		/// 게임 맵 가져오기
		/// </summary>
		/// <param name="level">가져올 레벨</param>
		/// <param name="move">움직임 수</param>
		/// <returns></returns>
		static MapInfo GetMapInfo(int level, int move)
		{
			MapInfo map = new MapInfo();
			map.Level = level;
			map.Move = move;
			map.Player = new Point();
			map.Player.x = Maps[level].Player.x;
			map.Player.y = Maps[level].Player.y;
			map.Map = (Tile[,])Maps[level].Map.Clone();

			return map;
		}

		/// <summary>
		/// MapInfo 복사
		/// </summary>
		/// <param name="origin"></param>
		/// <returns></returns>
		static MapInfo CopyMapInfo(MapInfo origin)
		{
			MapInfo map = new MapInfo();
			map.Level = origin.Level;
			map.Move = origin.Move;
			map.Map = (Tile[,])origin.Map.Clone();
			map.Player = origin.Player;

			return map;
		}
	}
}
