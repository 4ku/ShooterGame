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
using System.IO;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Shooter
{
   public class Load:Menu
    {
        public Button back;
        public List<string> files;
       
        int count;

        int height = 100;
        int otstupH;
        int width;//=WinWIDTH*3/8;
        int x; int y;
        KeyboardState kspast;
        int actState;
        public Load()
        {
            kspast = Keyboard.GetState();
            find();
            if (count == 1) otstupH = WinHEIGHT / 2;
            else otstupH = (WinHEIGHT * 3 / 4 - count * height) / (count - 1);
            y = WinHEIGHT / 4;

            width = 100;
            back = new Button(new Rectangle(100, 100, width, height), backTex, backTex);

        }

        public void find()
        {
            string[] F;
            //Directory.SetCurrentDirectory(@"\CRMod\Game1\bin\Windows\x86\Debug");
            F = Directory.GetFiles("maps", "*.txt");
            files = F.ToList();
            count = files.Count;
        }
        public override void Update(Game1 game)
        {
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && mouseStatePast.LeftButton == ButtonState.Released)
            {
                /*  if (Play.rectangle.Contains(mouseState.Position))
                  {
                      isGame = true;
                  }
                  else*/
                if (back.rectangle.Contains(mouseState.Position))
                {
                    menu = new Play();
                }

            }
            mouseStatePast = mouseState;

            int c = files.Count();
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && kspast.IsKeyUp(Keys.Up)) actState = (actState + c - 1) % c;
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && kspast.IsKeyUp(Keys.Down)) actState = (actState + c + 1) % c;

            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && kspast.IsKeyUp(Keys.Enter))
            {
                //загрузить карту
                int n; int m;
                string[] lines = File.ReadAllLines(files[actState]);
                string[] s = lines[0].Split(' ');
                n = int.Parse(s[0]); m = int.Parse(s[1]);
                int[,] ar = new int[n, m];
                for (int i = 1; i <= n; i++)
                {
                    s = lines[i].Split(' ');
                    for (int j = 0; j < m; j++)
                    {
                        ar[i - 1, j] = int.Parse(s[j]);
                    }
                }
                game.world.entities = new List<Entity>();
              

                s = lines[n + 1].Split(' ');
                int count = int.Parse(s[0]);
            
                for (int i = n + 2; i < n + 2 + count; i++)
                {
                    s = lines[i].Split(' ');
                    switch (s[0])
                    {
                        case "Mon":
                            game.world.entities.Add(new Monster(new Vector2(int.Parse(s[1]), int.Parse(s[2]))));
                            break;
                    }
                }
                
               
                 game.world.map=new Map(ar);
                game.world.map.LoadMap(game.world);

                s = lines[n + 2 + count].Split(' ');
                Vector2 vector = new Vector2(int.Parse(s[0]), int.Parse(s[1]));
                Robot her = new Robot(robot, vector);
                game.world.entities.Add(her);
                game.world.Hero = her;
               isGame = true; MediaPlayer.Stop();
            }
                kspast = Keyboard.GetState();

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
           
            spriteBatch.Draw(backTex, back.rectangle, Color.White);

            for (int i = 0; i < files.Count(); i++)
            {

                if (i == actState) spriteBatch.DrawString(font, files[i].ToUpper(), new Vector2(WinWIDTH*3/8,y+otstupH*i), Color.Red);
                else spriteBatch.DrawString(font, files[i], new Vector2(WinWIDTH * 3 / 8, y + otstupH * i), Color.Red);
            }

        }
    }
}
