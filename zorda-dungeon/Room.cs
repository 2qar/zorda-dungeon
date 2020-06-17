using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

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
		Texture2D block;
		Texture2D floor;
		RoomDirection roomDirection;
		Color floorColor;
		Color wallColor;

		// Room constructor: block texture, floor texture, room direction, and color.
		public Room(Texture2D block, Texture2D floor, RoomDirection roomDirection, Color color)
		{
			this.block = block;
			this.floor = floor;
			this.roomDirection = roomDirection;
			this.floorColor = color;
			this.wallColor = this.floorColor;
			this.wallColor.R += 100;
			this.wallColor.G += 100;
			this.wallColor.B += 100;
		}

		public bool checkRoomDirection(RoomDirection roomDir) => ((int)this.roomDirection & (int)roomDir) > 0;

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
								spriteBatch.Draw(floor, new Rectangle(366, 15, 64, 64), floorColor);
								continue;
							}
							if (i == 6 && checkRoomDirection(RoomDirection.Down))
							{
								spriteBatch.Draw(floor, new Rectangle(366, 399, 64, 64), floorColor);
								continue;
							}
						}
						spriteBatch.Draw(block, new Rectangle(110 + 64 * k, 15 + 64 * i, 64, 64), wallColor);
					}
					else
					{
						spriteBatch.Draw(floor, new Rectangle(110 + 64 * k, 15 + 64 * i, 64, 64), floorColor);

						if (!(i == 3 && checkRoomDirection(RoomDirection.Left)))
							spriteBatch.Draw(block, new Rectangle(110, 15 + 64 * i, 64, 64), wallColor);
						else
							spriteBatch.Draw(floor, new Rectangle(110, 207, 64, 64), floorColor);

						if (!(i == 3 && checkRoomDirection(RoomDirection.Right)))
							spriteBatch.Draw(block, new Rectangle(622, 15 + 64 * i, 64, 64), wallColor);
						else
							spriteBatch.Draw(floor, new Rectangle(622, 207, 64, 64), floorColor);
					}
				}
			}
		}
	}
}
