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
using static Shooter.TexturePack;
using static Shooter.Monster;
using static Shooter.Game1;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
namespace Shooter
{
    public class MainMenu : Menu
    {
        public Button Play;
        public Button CrMod;
        public Button Settings;
        public Button Exit;
        List<Button> but;
      
        int count = 4;
       
        int height = 100;
        int otstupH;
        int width;
        int x; int y;
        Texture2D Background;
        public MainMenu()
        {
            //MediaPlayer.Play(MainSound);
          
            Background = MainMenuTex;
            otstupH = (WinHEIGHT* 3 / 4  - count * height) / (count - 1);
           
            but = new List<Button>();

            width = 300;
            x = (WinWIDTH - width) / 2; y = WinHEIGHT / 8;
            Play = new Button(new Rectangle(x,y, width,height), PlayAct, PlayP);
            but.Add(Play);

            width = 200;
            x = (WinWIDTH - width) / 2; y += otstupH+height;
            CrMod = new Button(new Rectangle(x, y, width, height), CrModAct, CrModP);
            but.Add(CrMod);

            width = 200;
            x = (WinWIDTH - width) / 2; y += otstupH + height;
            Settings = new Button(new Rectangle(x, y, width, height), SettingsTexAct, SettingsTex);
            but.Add(Settings);
           
            width = 200;
            x = (WinWIDTH - width) / 2; y += otstupH + height;
            Exit = new Button(new Rectangle(x, y, width, height), ExitAct, ExitP);
            but.Add(Exit);
        }
        public override void Update(Game1 game)
        {
            foreach (Button b in but) b.CheckCursor();
            mouseState = Mouse.GetState();
         
            if (mouseState.LeftButton == ButtonState.Pressed && mouseStatePast.LeftButton == ButtonState.Released)
            {
                if (Play.rectangle.Contains(mouseState.Position))
                {
                    menu = new Play();
                    //isGame = true;
                }
                else if (CrMod.rectangle.Contains(mouseState.Position))
                {
                    // Process pr=Process.Start(@"C:\Users\Андрей\Desktop\Проекты\CRMod\Game1\bin\Windows\x86\Debug\Game1.exe");
                    game.Exit();
                    Game game1 = new CRMod.Game1();
                     game1.Run();
                   
                    // while (Process.GetProcessById(pr.Id) != null) { }
                    //Process.GetCurrentProcess().WaitForInputIdle(;
                } else if (Settings.rectangle.Contains(mouseState.Position))
                {
                    menu = new Settings();
                } else if (Exit.rectangle.Contains(mouseState.Position))
                {
                    game.Exit();
                }
            }
            mouseStatePast = mouseState;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Begin();
            spriteBatch.Draw(Background, new Rectangle(0, 0, WinWIDTH, WinHEIGHT), Color.White);//,new Rectangle(0,0,Background.Width,Background.Height),)
            foreach (Button b in but) b.Draw(spriteBatch);
           // spriteBatch.End();
        }
    }
}
