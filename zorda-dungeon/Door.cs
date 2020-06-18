using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace zorda_dungeon
{

	public class Door : Entity
	{

		public RoomDirection roomDir;

		public Door() : base()
		{

		}
		public Door(Texture2D sprite, Texture2D hitbox, Vector2 startPos, RoomDirection roomDir) : base(sprite, hitbox, startPos)
		{
			this.roomDir = roomDir;

		}

	}
}
