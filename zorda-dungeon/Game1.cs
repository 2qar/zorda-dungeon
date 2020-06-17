using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Runtime.Remoting.Messaging;

namespace zorda_dungeon
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D blockSpr;
        Texture2D playerSpr;
        Player player;
        Texture2D floorSpr;

        Room[][] rooms;
        Entity[] statues;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            rooms = new Room[5][];
            for (int i = 0; i < rooms.Length; i++)
                rooms[i] = new Room[5];

            statues = new Entity[2];

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            blockSpr = new Texture2D(spriteBatch.GraphicsDevice, 64, 64);

            using (var stream = TitleContainer.OpenStream("Block.png"))
            {
                blockSpr = Texture2D.FromStream(this.GraphicsDevice, stream);
            }
            using (var stream = TitleContainer.OpenStream("Floor.png"))
            {
                floorSpr = Texture2D.FromStream(this.GraphicsDevice, stream);
            }
            using (var stream = TitleContainer.OpenStream("CyclopsPlayer.png"))
            {
                playerSpr = Texture2D.FromStream(this.GraphicsDevice, stream);
            }

            this.rooms[2][2] = new Room(blockSpr, floorSpr, RoomDirection.Up | RoomDirection.Left | RoomDirection.Right | RoomDirection.Down, Color.DarkGreen);


            this.player = new Player(playerSpr, blockSpr, 2f, new Vector2(368f, 208f));

            this.statues[0] = new Entity(blockSpr, blockSpr, new Vector2(200, 100), Color.Gray);
            this.statues[1] = new Entity(blockSpr, blockSpr, new Vector2(534, 100), Color.Gray);

            // TODO: use this.Content to load your game content here

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

            // TODO: Unload any non ContentManager content here

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            playerMovement();
            
            foreach (Entity E in this.statues)
                if (this.player.Intersects(E))
                {
                    Console.WriteLine("intersecting");
                    this.player.Translate(this.player.velocity * -1);
                }

            foreach (Room[] R in this.rooms)
            {
                foreach (Room K in R)
                {
                    if (K != null)
                    {
                        foreach (Entity[] E in K.walls)
                        {
                            foreach (Entity T in E)
                            {
                                if (T != null)
                                {
                                    if (this.player.Intersects(T))
                                    {
                                        Console.WriteLine("intersecting");
                                        this.player.Translate(this.player.velocity * -1);
                                    }
                                }
                            }
                        }
                    }
                }
            }



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        void playerMovement()
        {
            if (GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
                player.Translate(new Vector2(0f, -1f));

            else if (GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
                player.Translate(new Vector2(0f, 1f));

            else if (GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
                player.Translate(new Vector2(1f, 0f));

            else if (GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
                player.Translate(new Vector2(-1f, 0f));
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            foreach (Room[] R in this.rooms) 
            {
                foreach (Room K in R)
                {
                    if (K != null)
                        K.Draw(spriteBatch);
                }
            }
            

            foreach (Entity E in this.statues)
            {
                E.Draw(this.spriteBatch);
            }

            player.Draw(spriteBatch);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
