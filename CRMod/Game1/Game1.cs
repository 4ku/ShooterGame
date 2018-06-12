using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
namespace CRMod
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public Map map;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static int WinWIDTH;
        public static int WinHEIGHT;
        public static int NumCellWIDTH = 30;
        public static int NumCellHEIGHT = 14;
        public static int CellWIDTH;
        public static int CellHEIGHT;
        public static SpriteFont font;
       
        public Texture2D MonsteR;
        Camera camera;
        CrMod CM;
        public static Texture2D metal;
        public static Texture2D robot;
        public static Texture2D iron;
        public static List<Monster> enemies;
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
            map = new Map(); map.MapGener(70, 70);
            camera = new Camera(GraphicsDevice.Viewport);
            WinWIDTH = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            WinHEIGHT = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            //  CellWIDTH = WinWIDTH / NumCellWIDTH;
            // CellHEIGHT = WinHEIGHT / NumCellHEIGHT;
            CellWIDTH = 60; CellHEIGHT = 60;
            CM = new CrMod();
           
            MonsteR = Content.Load<Texture2D>("monster");
            enemies = new List<Monster>();
            graphics.PreferredBackBufferWidth = WinWIDTH;
            graphics.PreferredBackBufferHeight = WinHEIGHT;
           
            Window.Position = new Point(0, 0);
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("font");
            iron = Content.Load<Texture2D>("iron");
            metal = Content.Load<Texture2D>("metal");
           robot = Content.Load<Texture2D>("robot");
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
            CM.Move(); CM.Update(map);
            camera.Update(CM.CrV);
            if (Keyboard.GetState().IsKeyDown(Keys.R) && CM.actState != 0) map = CM.Read();
           // Monster.CrMon(CM);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,
           null, null, null, null, camera.transform);
            map.Draw(gameTime, spriteBatch);
            //spriteBatch.Draw(Hero.Tex, Hero.rec, new Rectangle(0, 0, Hero.Tex.Width, Hero.Tex.Height), Color.CornflowerBlue);
            foreach (Monster mon in enemies)
            {
               spriteBatch.Draw(MonsteR, mon.rec, new Rectangle(0, 0, MonsteR.Width, MonsteR.Height), Color.White);
            }
            CM.Draw(gameTime, spriteBatch);
            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
