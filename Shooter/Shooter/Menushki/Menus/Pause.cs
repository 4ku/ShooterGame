using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System.Windows;
using Shooter;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using static Shooter.TexturePack;
using static Shooter.Monster;
using static Shooter.Game1;

namespace Shooter
{
   public class Pause : Menu
    {
        public Button Play;
        public Button Settings;
        public Button MainMenu;
        public Button Exit;
        List<Button> but;
        int count = 4;
       
        KeyboardState kspast;
        int height = 100;
        int otstupH;
        int width;
        int x; int y;
        Texture2D Background;
        Vector2 position;
        public Pause(Vector2 position)
        {
            Background = PauseTex;
            this.position = position;
            otstupH = (WinHEIGHT * 3 / 4 - count * height) / (count - 1);
            kspast = Keyboard.GetState();
            but = new List<Button>();

            width = 300;
            x = (WinWIDTH - width) / 2; y = WinHEIGHT / 8;
            Play = new Button(new Rectangle(x, y, width, height), PlayAct, PlayP);
            but.Add(Play);
            
            width = 200;
            x = (WinWIDTH - width) / 2; y += otstupH + height;
            Settings = new Button(new Rectangle(x, y, width, height), SettingsTexAct, SettingsTex);
            but.Add(Settings);

            width = 200;
            x = (WinWIDTH - width) / 2; y += otstupH + height;
            MainMenu = new Button(new Rectangle(x, y, width, height), mainMenuButTex, mainMenuButTex);
            but.Add(MainMenu);

            width = 200;
            x = (WinWIDTH - width) / 2; y += otstupH + height;
            Exit = new Button(new Rectangle(x, y, width, height), ExitAct, ExitP);
            but.Add(Exit);
        }
        public override void Update(Game1 game)
        {
            foreach (Button b in but) b.CheckCursor();
            mouseState = Mouse.GetState();
            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Escape) && kspast.IsKeyUp(Keys.Escape)) 
            {
                isGame = true; MediaPlayer.Stop();
            }

            if (mouseState.LeftButton == ButtonState.Pressed && mouseStatePast.LeftButton == ButtonState.Released)
            {
                if (Play.rectangle.Contains(mouseState.Position))
                {
                    isGame = true; MediaPlayer.Stop();
                }
                else if (Settings.rectangle.Contains(mouseState.Position))
                {
                    menu = new Settings();
                }
                else if (Exit.rectangle.Contains(mouseState.Position))
                {
                    game.Exit();
                } else if (MainMenu.rectangle.Contains(mouseState.Position))
                {

                    game.Exit();
                    Game game1 = new Game1();
                    game1.Run();
                }
            }
            mouseStatePast = mouseState;
            kspast = ks;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            //spriteBatch.Draw(Background, new Rectangle((int)position.X, (int)position.Y, WinWIDTH, WinHEIGHT),new Rectangle(0,0,Background.Width,Background.Height),Color.White,0f,Vector2.Zero,SpriteEffects.None,0.1f);
            spriteBatch.Draw(Background, new Rectangle(0, 0, WinWIDTH, WinHEIGHT), new Rectangle(0, 0, Background.Width, Background.Height), Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.1f);
            foreach (Button b in but) b.Draw(spriteBatch);

           // spriteBatch.End();
        }
    }
}
