using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace zorda_dungeon
{

	public class Player : Entity
	{

		public Player(Texture2D sprite, float moveSpeed, Vector2 startPos) : base(sprite, moveSpeed, startPos)
		{
			
		}
	}


}
