using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace zorda_dungeon
{

	public class Entity
	{
		Texture2D sprite;
		Vector2 position;
		float moveSpeed;
		Rectangle sourceRectangle;

		//Constructor: Sprite texture, move speed, 
		public Entity(Texture2D sprite, float moveSpeed)
		{
			this.sprite = sprite;
			this.moveSpeed = moveSpeed;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(sprite, new Rectangle(368, 208, 64, 64), Color.White);


		}


	}
}
