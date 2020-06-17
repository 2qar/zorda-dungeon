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

		//Constructor: Sprite texture, move speed, start position
		public Entity(Texture2D sprite, float moveSpeed, Vector2 startPos)
		{
			this.sprite = sprite;
			this.moveSpeed = moveSpeed;
			this.position = startPos;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(sprite, new Rectangle((int)position.X, (int)position.Y, 64, 64), Color.White);


		}

		public void Translate(Vector2 position)
		{
			this.position += Vector2.Normalize(position) * moveSpeed;
		}


	}
}
