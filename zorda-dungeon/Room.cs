using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Runtime.Remoting.Messaging;

namespace zorda_dungeon
{
	public enum RoomDirection 
	{
		Left = 1,
		Up = 2,
		Right = 4,
		Down = 8
	}

	public class Room
	{
		Texture2D blockSpr;
		Texture2D floorSpr;
		RoomDirection roomDirection;
		Color floorColor;
		Color wallColor;
		public Entity[][] walls;

		// Room constructor: block texture, floor texture, room direction, and color.
		public Room(Texture2D blockSpr, Texture2D floorSpr, RoomDirection roomDirection, Color color)
		{
			this.blockSpr = blockSpr;
			this.floorSpr = floorSpr;
			this.roomDirection = roomDirection;
			this.floorColor = color;
			this.wallColor = this.floorColor;
			this.wallColor.R += 100;
			this.wallColor.G += 100;
			this.wallColor.B += 100;

			walls = new Entity[11][];
			for (int i = 0; i < walls.Length; i++)
				walls[i] = new Entity[9];

		}

		public bool checkRoomDirection(RoomDirection roomDir) => ((int)this.roomDirection & (int)roomDir) > 0;

		public void markActive(Boolean active)
		{
			foreach (Entity[] E in this.walls)
			{
				foreach (Entity Q in E)
				{
					if (Q != null)
					{
						Q.active = active;
					}
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			for (int i = 0; i <= 6; i++)
			{
				for (int k = 0; k <= 8; k++)
				{
					if (i == 0 || i == 6)
					{
						if (k == 4)
						{
							if (i == 0 && checkRoomDirection(RoomDirection.Up))
							{
								walls[k][i] = new Door(this.blockSpr, this.blockSpr, new Vector2(366, 15 - 64), RoomDirection.Up);
								spriteBatch.Draw(floorSpr, new Rectangle(366, 15, 64, 64), floorColor);
								continue;
							}
							if (i == 6 && checkRoomDirection(RoomDirection.Down))
							{
								walls[k][i] = new Door(this.blockSpr, this.blockSpr, new Vector2(366, 399 + 64), RoomDirection.Down);
								spriteBatch.Draw(floorSpr, new Rectangle(366, 399, 64, 64), floorColor);
								continue;
							}
						}
						walls[k][i] = new Entity(this.blockSpr, this.blockSpr, new Vector2(110 + 64 * k, 15 + 64 * i), wallColor);
						walls[k][i].Draw(spriteBatch);
					}
					else
					{
						spriteBatch.Draw(floorSpr, new Rectangle(110 + 64 * k, 15 + 64 * i, 64, 64), floorColor);

						if (!(i == 3 && checkRoomDirection(RoomDirection.Left)))
						{
							walls[1][i] = new Entity(this.blockSpr, this.blockSpr, new Vector2(110, 15 + 64 * i), wallColor);
							walls[1][i].Draw(spriteBatch);
						}
						else
						{
							walls[0][i] = new Door(this.blockSpr, this.blockSpr, new Vector2(44, 15 + 64 * i), RoomDirection.Left);
							spriteBatch.Draw(floorSpr, new Rectangle(110, 207, 64, 64), floorColor);
						}

						if (!(i == 3 && checkRoomDirection(RoomDirection.Right)))
						{
							walls[9][i] = new Entity(this.blockSpr, this.blockSpr, new Vector2(622, 15 + 64 * i), wallColor);
							walls[9][i].Draw(spriteBatch);
						}
						else
						{
							walls[10][i] = new Door(this.blockSpr, this.blockSpr, new Vector2(686, 15 + 64 * i), RoomDirection.Right);
							spriteBatch.Draw(floorSpr, new Rectangle(622, 207, 64, 64), floorColor);
						}
					}
				}
			}
		}
	}
}
