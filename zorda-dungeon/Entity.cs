using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace zorda_dungeon
{

	public class Entity
	{
		SpriteBatch spriteBatch;
		Texture2D sprite;
		Vector2 position;
		float moveSpeed;
		Rectangle sourceRectangle;

		//Constructor: Sprite texture, move speed, 
		public Entity(SpriteBatch spriteBatch, Texture2D sprite, float moveSpeed)
		{
			this.spriteBatch = spriteBatch;
			this.sprite = sprite;
			this.moveSpeed = moveSpeed;
		}


	}
}
