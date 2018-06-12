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

namespace Shooter
{
    public class Settings:Menu
    {
        public Button Play;
        public Button back;
        List<Button> but;
        int count = 1;
      
        int height = 100;
        int otstupH;
        int width;
        int x; int y;
        public Settings()
        {
            if (count == 1) otstupH = WinHEIGHT / 2;
                else otstupH = (WinHEIGHT * 3 / 4 - count * height) / (count - 1);
            
          
            but = new List<Button>();

            width = 300;
            x = (WinWIDTH - width) / 2; y = WinHEIGHT / 8;
            Play = new Button(new Rectangle(x, y, width, height), PlayAct, PlayP);
            but.Add(Play);

            width = 100;
            back = new Button(new Rectangle(100, 100, width, height), backTex, backTex);

        }
        public override void Update(Game1 game)
        {
            foreach (Button b in but) b.CheckCursor();
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && mouseStatePast.LeftButton == ButtonState.Released)
            {
                if (Play.rectangle.Contains(mouseState.Position))
                {
                    isGame = true;
                } else if (back.rectangle.Contains(mouseState.Position))
                {
                    menu = new MainMenu();
                }
               
            }
           mouseStatePast = mouseState;

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
          //  spriteBatch.Begin();
            foreach (Button b in but) b.Draw(spriteBatch);
            // spriteBatch.End();
            spriteBatch.Draw(backTex, back.rectangle, Color.White);
        }
    }
}
