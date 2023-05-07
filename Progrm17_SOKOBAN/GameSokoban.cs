using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progrm17_SOKOBAN
{
	public partial class GameSokoban
	{
		/// <summary>
		/// 게임 초기화
		/// </summary>
		private void InitGameSetting()
		{
			Console.Title = "소코반 게임"; //콘솔창 타이틀 변경
			Console.CursorVisible = false; //커서 표시 여부

			SetGameMaps(); //게임 맵 세팅

			SavePoint = new MoveSave();
		}

		/// <summary>
		/// 게임 진행
		/// </summary>
		public void PlaySOKOBAN()
		{
			//게임 시작 전 세팅
			InitGameSetting();

			int level = 0;
			MapInfo mapInfo = GetMapInfo(level, 0);

			GameRender(mapInfo); //게임 화면 초기값 출력

			while (true)
			{
				Direction inputKey = GetInputKey(); //키를 입력받음

				//진행 상황 업데이트
				mapInfo = GameUpdate(inputKey, mapInfo);
				//Console.WriteLine($"({player.x}, {player.y})");

				GameRender(mapInfo); //게임 화면 재출력

				if (CheckedGameEnding(ref mapInfo))//게임이 종료 되었는지 확인
				{
					break;
				}
				level = mapInfo.Level;
			}
		}

		/// <summary>
		/// 게임 입력
		/// </summary>
		private Direction GetInputKey()
		{
			//ConsoleKeyInfo : 키를 눌렀을 때 정보를 담고 있는 구조체
			ConsoleKeyInfo info = Console.ReadKey(); //ReadKey 키를 누르는 순간 입력 완료됨
			switch (info.Key)
			{
				case ConsoleKey.UpArrow: return Direction.UP;       //방향키 : 상
				case ConsoleKey.DownArrow: return Direction.DOWN;   //방향키 : 하
				case ConsoleKey.LeftArrow: return Direction.LEFT;   //방향키 : 좌
				case ConsoleKey.RightArrow: return Direction.RIGHT; //방향키 : 우
				case ConsoleKey.R: return Direction.AGAIN;          //게임 다시시작
				case ConsoleKey.Z: return Direction.BACK;           //되돌리기
				default: return Direction.NONE; //방향키 외의 키를 입력한 경우

			}
		}

		/* 참고, 2차원배열에 넣고 그대로 맵을 그리다보니까 x,y를 반대로 생각해야함. 
            
            2차원 배열이
            1차 
            [0] -> [0, 1, 2, 3, ...]
            [1] -> [0, 1, 2, 3, ...]
            [2] -> [0, 1, 2, 3, ...]
            이런 구조라서, 

            [0, 1] [0, 2] [0, 3] [0, 4] ...
            [1, 0]
            [2, 0]
            [3, 0]
            ...
            이런 구조임. 

            근데 좌표로 받아오면 x축이 가로고, y축이 세로니까... 움직임을 넣을 때는 반대로 넣어야 함.
         */

		/// <summary>
		/// 게임 갱신 : 플레이어 위치 변경
		/// </summary>
		private MapInfo GameUpdate(Direction inputKey, MapInfo mapInfo)
		{
			int move = (inputKey == Direction.NONE || inputKey == Direction.AGAIN) ? 0 : 1;

			if (inputKey == Direction.BACK) //되돌리기
			{
				return GetUndo(mapInfo);
			}

			Point prevPoint = mapInfo.Player; //플레이어 이동 전 위치

			mapInfo.Player = GetMovePlayerPoint(inputKey, mapInfo.Player); //입력한키에 따라 플레이어를 이동시킴

			//box를 만나면 같이 이동
			if (mapInfo.Map[mapInfo.Player.y, mapInfo.Player.x] == Tile.Box)
			{
				Point moveBox = GetMovePlayerPoint(inputKey, mapInfo.Player);

				if (IsMove(mapInfo.Map[moveBox.y, moveBox.x])) //박스가 플레이어랑 같이 이동 시 이동 가능한지 확인
				{
					mapInfo.Map[mapInfo.Player.y, mapInfo.Player.x] = Tile.None; //기존 박스 위치는 공백으로 변경
					mapInfo.Map[moveBox.y, moveBox.x] = (mapInfo.Map[moveBox.y, moveBox.x] == Tile.Goal) ? Tile.BoxGoal : Tile.Box;
					//플레이어 방향과 같은 방향으로 이동함.
					//단, 이동한 위치에 골이 있으면 Tile.BoxGoal로 변경(골로 박스가 들어 감)하고, 아니면 이동 위치에 박스를 그려줌
				}
				else
				{
					mapInfo.Player = prevPoint;  //불가능하면 이동 전 플레이어 위치 반환
					return mapInfo;
				}
			}
			else if (mapInfo.Map[mapInfo.Player.y, mapInfo.Player.x] == Tile.BoxGoal) //골 밀어넣기
			{
				Point moveBox = GetMovePlayerPoint(inputKey, mapInfo.Player);

				if (mapInfo.Map[moveBox.y, moveBox.x] == Tile.Goal)
				{
					mapInfo.Map[mapInfo.Player.y, mapInfo.Player.x] = Tile.Goal; //기존 박스 위치는 공백으로 변경
					mapInfo.Map[moveBox.y, moveBox.x] = Tile.BoxGoal;
				}
				else
				{
					mapInfo.Player = prevPoint; //벽을 닿으면 이동 전 위치로 되돌림
					return mapInfo;
				}
			}
			else if (IsMove(mapInfo.Map[mapInfo.Player.y, mapInfo.Player.x], true) == false) //벽에 닿으면 이동금지
			{
				mapInfo.Player = prevPoint; //벽을 닿으면 이동 전 위치로 되돌림
				return mapInfo;
			}
			return SetMove(mapInfo, move); //아무 장애물이 없으면 그냥 플레이어만 이동시킴
		}

		/// <summary>
		/// 이동이 가능한지 확인한다
		/// </summary>
		/// <param name="mapItem"></param>
		/// <returns></returns>
		private bool IsMove(Tile mapItem, bool isChkGoal = false)
		{
			//벽이나 이미 박스가 들어간 골을 만나면 false를 반환
			switch (mapItem)
			{
				case Tile.Wall:
				case Tile.BoxGoal:
					return false;
				case Tile.Goal:
					return !isChkGoal;
				default:
					return true;
			}
		}

		/// <summary>
		/// 되돌리기
		/// </summary>
		private MapInfo GetUndo(MapInfo mapInfo)
		{
			if (SavePoint.IsPossiblePOP())
			{
				int currMove = mapInfo.Move;

				MapInfo map = SavePoint.Pop();
				map.Move = currMove + 1;

				return map;
			}
			else { return mapInfo; }
		}

		/// <summary>
		/// 플레이어 이동하면서 수행하는 동작
		/// </summary>
		/// <param name="mapInfo"></param>
		/// <param name="move"></param>
		/// <returns></returns>
		private MapInfo SetMove(MapInfo mapInfo, int move)
		{
			SavePoint.Push(mapInfo);
			mapInfo.Move += move;

			return mapInfo;
		}

		/// <summary>
		/// 입력받은 키에 따라 방향을 이동함
		/// </summary>
		/// <param name="inputKey"></param>
		/// <param name="player"></param>
		/// <returns></returns>
		private Point GetMovePlayerPoint(Direction inputKey, Point player)
		{
			switch (inputKey)
			{
				case Direction.UP: player.y--; break; //위로이동
				case Direction.DOWN: player.y++; break; //아래로이동
				case Direction.LEFT: player.x--; break; //왼쪽으로 이동
				case Direction.RIGHT: player.x++; break; //오른쪽으로 이동
			}
			return player;
		}

		/// <summary>
		/// 게임 출력
		/// </summary>
		private void GameRender(MapInfo mapInfo)
		{
			PrintGameMap(mapInfo);

			//SetCursorPosition(x, y) : 커서 위치 설정하는 메소드 
			//X가 문자기준 반칸으로 인식하고 있는 상황이라 x*2로 설정해줌
			Console.ForegroundColor = ConsoleColor.Green;
			Console.SetCursorPosition(mapInfo.Player.x * 2, mapInfo.Player.y);//플레이어 현위치로 커서 이동
			Console.Write('♠'); //플레이어 출력
		}

		/// <summary>
		/// 게임 맵 출력
		/// </summary>
		/// <param name="map"></param>
		private void PrintGameMap(MapInfo mapInfo)
		{
			Console.Clear(); //콘솔 화면 지우기 

			//map배열을 순회하면서 map에서 지정한 아이템 별로 map을 출력함
			for (int x = 0; x < mapInfo.Map.GetLength(0); x++)
			{
				for (int y = 0; y < mapInfo.Map.GetLength(1); y++)
				{
					switch (mapInfo.Map[x, y])
					{
						case Tile.Wall:
							Console.ForegroundColor = ConsoleColor.White;
							Console.Write("▩");
							break;
						case Tile.Box:
							Console.ForegroundColor = ConsoleColor.Yellow;
							Console.Write("☆");
							break;
						case Tile.Goal:
							Console.ForegroundColor = ConsoleColor.Blue;
							Console.Write("□");
							break;
						case Tile.BoxGoal:
							Console.ForegroundColor = ConsoleColor.Magenta;
							Console.Write("■");
							break;
						case Tile.None: Console.Write("　"); break;

					}
				}
				Console.WriteLine();
			}


			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine($"LEVEL : {mapInfo.Level} \t MOVE SCORE : {mapInfo.Move}\n");
			Console.WriteLine("\n되돌리기는 Z를 눌러주세요!");
		}

		/// <summary>
		/// 게임이 종료되었는지 여부를 확인
		/// </summary>
		/// <param name="map"></param>
		/// <returns></returns>
		private bool CheckedGameEnding(ref MapInfo mapInfo)
		{
			string gameResult = "";
			string printStr = "";
			int level = 0;
			bool isEnding = false;

			if (CheckedGameClear(mapInfo.Map)) //게임이 클리어 됐는지 확인
			{
				if (mapInfo.Level + 1 == FINAL_LEVEL) //현 레벨이 마지막 레벨과 같은 경우
				{
					gameResult = "\n☆★☆★☆★ [GAME CLEAR] ★☆★☆★☆\n";
					printStr = "처음부터 다시 시작하려면 R을 눌러주세요. : ";
					mapInfo.MapInfoInit();
					isEnding = true;
				}
				else
				{
					mapInfo = GetMapInfo(++mapInfo.Level, mapInfo.Move);
					SavePoint.Clear();
				}
			}
			else if (CheckedGameOver(mapInfo.Map))
			{
				gameResult = "\nㅠㅠㅠㅠㅠㅠ [GAME OVER] ㅠㅠㅠㅠㅠㅠ\n";
				printStr = "다시 도전하려면 R을 눌러주세요. : ";
				mapInfo = GetMapInfo(mapInfo.Level, mapInfo.Move);
				isEnding = true;
			}

			if (isEnding)
			{
				//PrintGameMap(mapInfo); //현재 시점의 게임 화면 출력
				Console.SetCursorPosition(mapInfo.Map.GetLength(0) * 2, mapInfo.Map.GetLength(1) + 4);

				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine(gameResult);

				Console.Write(printStr);
				isEnding = GetInputKey() == Direction.AGAIN ? false : true;
			}
			return isEnding;
		}

		/// <summary>
		/// 게임이 끝났는지 확인한다
		/// </summary>
		/// <returns></returns>
		private bool CheckedGameClear(Tile[,] map)
		{
			//빈 골이 있으면 게임은 계속 진행함
			foreach (Tile tile in map)
			{
				if (tile == Tile.Goal)
					return false;
			}
			return true;
		}

		/// <summary>
		/// 더 이상 움직일 수 있는 동작이 없는지 확인
		/// </summary>
		/// <param name="map"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		private bool CheckedGameOver(Tile[,] map)
		{
			// i).박스가 상하좌우 중 2개 이상의 벽을 만나면 더 이상 움직일 수 없다고 판단 > 게임을 종료함.
			// ii). 구석에 있는 골 2개 사이에 박스가 끼면 더 이상 움직일 수  없다고 판단 > 게임을 종료함
			for (int x = 0; x < map.GetLength(0); x++)
			{
				for (int y = 0; y < map.GetLength(1); y++)
				{
					if (map[x, y] == Tile.Box)
					{
						float endCaseCnt = 0;

						endCaseCnt += IsMove(map[x, y - 1], true) ? 0 : (map[x, y - 1] == Tile.Goal ? 0.5f : 1); //상
						endCaseCnt += IsMove(map[x, y + 1], true) ? 0 : (map[x, y + 1] == Tile.Goal ? 0.5f : 1); //하
						endCaseCnt += IsMove(map[x - 1, y], true) ? 0 : (map[x - 1, y] == Tile.Goal ? 0.5f : 1); //좌
						endCaseCnt += IsMove(map[x + 1, y], true) ? 0 : (map[x + 1, y] == Tile.Goal ? 0.5f : 1); //우

						if (endCaseCnt >= 2) { return true; }
					}
				}
			}
			return false;
		}
	}
}