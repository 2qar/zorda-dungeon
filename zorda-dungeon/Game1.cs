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
        Room setRoom;

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
            for (int i = 0; i < this.rooms.Length; i++)
                this.rooms[i] = new Room[5];

            this.statues = new Entity[2];

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

            this.blockSpr = new Texture2D(spriteBatch.GraphicsDevice, 64, 64);

            using (var stream = TitleContainer.OpenStream("Block.png"))
            {
                this.blockSpr = Texture2D.FromStream(this.GraphicsDevice, stream);
            }
            using (var stream = TitleContainer.OpenStream("Floor.png"))
            {
                this.floorSpr = Texture2D.FromStream(this.GraphicsDevice, stream);
            }
            using (var stream = TitleContainer.OpenStream("CyclopsPlayer.png"))
            {
                this.playerSpr = Texture2D.FromStream(this.GraphicsDevice, stream);
            }

            this.rooms[2][2] = new Room(this.blockSpr, this.floorSpr, RoomDirection.Up | RoomDirection.Left | RoomDirection.Right | RoomDirection.Down, Color.Gainsboro);
            this.rooms[2][3] = new Room(this.blockSpr, this.floorSpr, RoomDirection.Up | RoomDirection.Down, Color.DarkRed);

            this.setRoom = this.rooms[2][2];
            this.setRoom.markActive(true);
            foreach (Entity[] E in this.setRoom.walls)
            {
                foreach (Entity W in E)
                {
                    if (W != null)
                    {
                        Console.WriteLine(W.active);
                    }
                }
            }



            this.player = new Player(playerSpr, blockSpr, 2f, new Vector2(374f, 208f));

            player.active = true;
            

            this.statues[0] = new Entity(this.blockSpr, this.blockSpr, new Vector2(200, 100), Color.Gray);
            this.statues[1] = new Entity(this.blockSpr, this.blockSpr, new Vector2(534, 100), Color.Gray);

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

            PlayerMovement();
            
            foreach (Entity E in this.statues)
                if (this.player.Intersects(E))
                {
                    this.player.Translate(this.player.velocity * -1);
                }

            CollisionDetection();


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        void PlayerMovement()
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

        void CollisionDetection()
        {
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
                                    if (T.GetType() == new Door().GetType())
                                    {
                                        Door D = (Door)T;

                                        switch (D.roomDir)
                                        {
                                            case RoomDirection.Left:

                                                break;
                                            case RoomDirection.Up:
                                                if (this.player.Intersects(D))
                                                {
                                                    ExitingAnimation(D.roomDir);
                                                    this.player.position = new Vector2(374f, 399f);
                                                    this.setRoom.markActive(false);
                                                    this.setRoom = rooms[2][2];
                                                    this.setRoom.markActive(true);
                                                    EnteringAnimation(D.roomDir);
                                                }
                                                break;
                                            case RoomDirection.Right:

                                                break;
                                            case RoomDirection.Down:
                                                if (this.player.Intersects(D))
                                                {
                                                    ExitingAnimation(D.roomDir);
                                                    this.player.position = new Vector2(374f, 25f);
                                                    this.setRoom.markActive(false);
                                                    this.setRoom = rooms[2][3];
                                                    this.setRoom.markActive(true);
                                                    EnteringAnimation(D.roomDir);
                                                }
                                                break;

                                        }
                                    }

                                    if (this.player.Intersects(T))
                                        this.player.Translate(this.player.velocity * -1);
                                }
                            }
                        }
                    }
                }
            }
        }

        void EnteringAnimation(RoomDirection roomDir)
        {

        }

        void ExitingAnimation(RoomDirection roomDir)
        {

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            this.setRoom.Draw(spriteBatch);
            

            foreach (Entity E in this.statues)
            {
                E.Draw(this.spriteBatch);
            }

            this.player.Draw(spriteBatch);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
