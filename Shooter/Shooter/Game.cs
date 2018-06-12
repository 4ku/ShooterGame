using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
using static Shooter.TexturePack;
using System.Collections;
using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
namespace Shooter
{
     public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public static bool isGame;
        public static MouseState mouseState;
        public static MouseState mouseStatePast;
        //Menu[] menus;
        public static int WinWIDTH;
        public static int WinHEIGHT;
        
        public World world;
        public static Menu menu;
        public Map map;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            MediaPlayer.Volume = 0.4f;
            WinWIDTH = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
           WinHEIGHT = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            graphics.PreferredBackBufferWidth = WinWIDTH;
            graphics.PreferredBackBufferHeight = WinHEIGHT;
            isGame = false;
          
            //  graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            Window.Position = new Point(0, 0);
           // Window.IsBorderless = true;
            world = new World(this); //сделать выбор мира
            mouseState = mouseStatePast = Mouse.GetState();
            ///////куда-то вот этот кусок кода уберем
           /* int h = 40, w = 40;
            int[,] ar = new int[h, w];
            for (int i = 0; i < h; i++) { ar[i, 0] = 1; ar[i, w - 1] = 1; }
            for (int i = 0; i < w; i++) { ar[0, i] = 1; ar[h - 1, i] = 1; }
            ar[0, 1] = 0; ar[0, 2] = 0; ar[10, 10] = 1;*/
          /*  map= new Map();
            map.MapGener(50, 50);
            world.Initialize(map);*/
            ///////

            menu = new MainMenu();
            base.Initialize();
        }
       
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            MediaPlayer.Play(MainSound);
            
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            //  if (Keyboard.GetState().IsKeyDown(Keys.Escape)) Exit();
           
            if (isGame == true)
            {
                world.Update(gameTime);
               
            }
            else
            {
                menu.Update(this);
                
            }
          
            base.Update(gameTime);
            
        }

        protected override void Draw(GameTime gameTime)
        {
           
            GraphicsDevice.Clear(Color.Bisque);

            if (isGame == true)
                world.Draw(spriteBatch);
            else {
                spriteBatch.Begin();
                menu.Draw(spriteBatch);
                spriteBatch.End();
            }
          
            base.Draw(gameTime);
          
        }
    }
}
