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
		RoomDirection roomDirection;
		Color floorColor;
		Color wallColor;

		// Room constructor: block texture, room direction, and color.
		public Room(Texture2D block, RoomDirection roomDirection, Color color)
		{
			this.block = block;
			this.roomDirection = roomDirection;
			this.floorColor = color;
			this.wallColor = this.floorColor;
			this.wallColor.A += 120;
		}

		public bool checkRoomDirection(RoomDirection roomDir)
		{
			if (((int)this.roomDirection & (int)roomDir) > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(block, new Rectangle(64, -20, 668, 520), floorColor);

			for (int i = 0; i <= 6; i++)
			{
				if (i == 0 || i == 6)
				{
					for (int k = 0; k <= 8; k++)
					{
						if (k == 4)
						{
							if (i == 0 && checkRoomDirection(RoomDirection.Up)) 
								continue;

							if (i == 6 && checkRoomDirection(RoomDirection.Down))
								continue;

						}
						spriteBatch.Draw(block, new Rectangle(110 + 64 * k, 15 + 64 * i, 64, 64), wallColor);
					}
				}
				else
				{
					if (!(i == 3 && checkRoomDirection(RoomDirection.Left)))
						spriteBatch.Draw(block, new Rectangle(110, 15 + 64 * i, 64, 64), wallColor);

					if (!(i == 3 && checkRoomDirection(RoomDirection.Right)))
						spriteBatch.Draw(block, new Rectangle(622, 15 + 64 * i, 64, 64), wallColor);

				}
			}
		}

	}
}
