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

		SpriteBatch spriteBatch;
		Texture2D block;
		int roomDirection;
		Color color;

		// Room constructor: Color, Which sides of room has doors.
		public Room(SpriteBatch spritebatch, Texture2D block, int roomDirection, Color color)
		{
			this.spriteBatch = spritebatch;
			this.block = block;
			this.roomDirection = roomDirection;
			this.color = color;
		}

		public void Draw()
		{
			spriteBatch.Draw(block, new Rectangle(110, 15, 622, 448), Color.DarkGreen);

			for (int i = 0; i <= 6; i++)
			{
				if (i == 0 || i == 6)
				{
					for (int k = 0; k <= 8; k++)
					{
						spriteBatch.Draw(block, new Rectangle(110 + 64 * k, 15 + 64 * i, 64, 64), Color.Green);
					}
				}
				else
				{
					spriteBatch.Draw(block, new Rectangle(110, 15 + 64 * i, 64, 64), Color.Green);
					spriteBatch.Draw(block, new Rectangle(622, 15 + 64 * i, 64, 64), Color.Green);
				}
			}
		}

	}
}
