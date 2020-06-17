using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq.Expressions;

namespace zorda_dungeon
{

	public class Entity
	{
		Texture2D sprite;
		Texture2D hitbox;
		Vector2 position;
		public Vector2 velocity;
		float moveSpeed;
		Color color;

		//Constructor: Sprite texture, hitbox texture, move speed, start position
		public Entity(Texture2D sprite, Texture2D hitbox, float moveSpeed, Vector2 startPos)
		{
			this.sprite = sprite;
			this.hitbox = hitbox;
			this.moveSpeed = moveSpeed;
			this.position = startPos;
			this.color = Color.White;
		}

		public Entity(Texture2D sprite, Texture2D hitbox, float moveSpeed, Vector2 startPos, Color color)
		{
			this.sprite = sprite;
			this.hitbox = hitbox;
			this.moveSpeed = moveSpeed;
			this.position = startPos;
			this.color = color;
		}


		public void Draw(SpriteBatch spriteBatch)
		{

			spriteBatch.Draw(sprite, new Rectangle((int)position.X, (int)position.Y, 64, 64), this.color);
			spriteBatch.Draw(hitbox, new Rectangle((int)position.X + sprite.Bounds.Left, (int)position.Y + sprite.Bounds.Top, sprite.Bounds.Right, sprite.Bounds.Bottom), Color.FromNonPremultiplied(150, 0, 0, 50));

		}

		public void Translate(Vector2 position)
		{
			this.velocity = Vector2.Normalize(position) * moveSpeed;
			this.position += this.velocity;

			
		}

		public bool Intersects(Entity entity)
		{
			if (this.hitbox.Bounds.Intersects(entity.hitbox.Bounds)) 
			{
				return true;
			}
			else
			{
				return false;
			}
		}


	}
}
