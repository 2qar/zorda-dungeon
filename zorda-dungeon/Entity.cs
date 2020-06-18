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
		public Vector2 position;
		public Vector2 velocity;
		public float moveSpeed;
		public Color color;
		public Boolean active;

		//Constructor: Sprite texture, hitbox texture, move speed, start position
		
		public Entity()
		{

		}
		public Entity(Texture2D sprite, Texture2D hitbox, Vector2 startPos)
		{
			this.sprite = sprite;
			this.hitbox = hitbox;
			this.position = startPos;
			this.color = Color.White;
		}
		public Entity(Texture2D sprite, Texture2D hitbox, Vector2 startPos, Color color)
		{
			this.sprite = sprite;
			this.hitbox = hitbox;
			this.position = startPos;
			this.color = color;
		}
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

			spriteBatch.Draw(sprite, new Rectangle((int)position.X, (int)position.Y, sprite.Bounds.Width, sprite.Bounds.Height), this.color);
			//spriteBatch.Draw(hitbox, new Rectangle((int)position.X, (int)position.Y, sprite.Bounds.Width, sprite.Bounds.Height), Color.FromNonPremultiplied(150, 0, 0, 50));

		}

		public void Translate(Vector2 position)
		{
			this.velocity = Vector2.Normalize(position) * moveSpeed;
			this.position += this.velocity;

			
		}

		public bool Intersects(Entity entity)
		{
			if (!(entity.active))
				return false;

			Rectangle ourHitbox = new Rectangle((int)this.position.X, (int)this.position.Y, this.sprite.Bounds.Width, this.sprite.Bounds.Height);
			Rectangle theirHitbox = new Rectangle((int)entity.position.X, (int)entity.position.Y, entity.sprite.Bounds.Width, entity.sprite.Bounds.Height);

			return (ourHitbox.Intersects(theirHitbox));
			
		}

	}
}
