//using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CRMod.Game1;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace CRMod
{
    public class CrMod
    {
        public Vector2 CrV = new Vector2(1000,1000);
        MouseState mspast;
        KeyboardState kspast;
        public int speed = 10;
        public bool isEn;
        public int actState = 0;
        public List<string> files;
        int state;
        Vector2 MHPos;
        public void Update(Map map)
        {
            MouseState ms = Mouse.GetState();
            bool del;
            if (state == 1)
            {
                if (ms.LeftButton == ButtonState.Pressed && mspast.LeftButton == ButtonState.Released)
                {
                    int j = (int)(CrV.X + (-WinWIDTH / 2) + ms.X) / CellWIDTH;
                    int i = (int)(CrV.Y + (-WinHEIGHT / 2) + ms.Y) / CellHEIGHT;
                    if (i >= 0 && j >= 0) map.ar[i, j] = (map.ar[i, j] + 1) % 2;
                }
                del = true;
                if (ms.RightButton == ButtonState.Pressed && mspast.RightButton == ButtonState.Released) Monster.CrMon(this,del);



            }
            else if (state == 2)
            {
                del = false;
                if (ms.LeftButton == ButtonState.Pressed) // && mspast.LeftButton == ButtonState.Released)
                {
                    int j = (int)(CrV.X + (-WinWIDTH / 2) + ms.X) / CellWIDTH;
                    int i = (int)(CrV.Y + (-WinHEIGHT / 2) + ms.Y) / CellHEIGHT;
                    if (i >= 0 && j >= 0) map.ar[i, j] = 1;
                }
                if (ms.RightButton == ButtonState.Pressed) Monster.CrMon(this,del);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && kspast.IsKeyUp(Keys.Space)) state = (state % 2) + 1;
            if (Keyboard.GetState().IsKeyDown(Keys.Q) && kspast.IsKeyUp(Keys.Q)) Save(map);
            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && kspast.IsKeyUp(Keys.Enter)) isEn = false;
            int c = files.Count();
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && kspast.IsKeyUp(Keys.Up)) actState = (actState + c - 1) % c;
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && kspast.IsKeyUp(Keys.Down)) actState = (actState + c + 1) % c;
            if (Keyboard.GetState().IsKeyDown(Keys.C) && kspast.IsKeyUp(Keys.C)) delete();
            if(ms.MiddleButton == ButtonState.Pressed && mspast.MiddleButton == ButtonState.Released)
            {
                MHPos =new Vector2( ms.X,ms.Y) + CrV - new Vector2(WinWIDTH / 2,WinHEIGHT/2);
            }
                /* if (Keyboard.GetState().IsKeyDown(Keys.F))
                 {
                     actState = (actState + 1) % actState;
                 }*/

                mspast = ms; kspast = Keyboard.GetState();
        }
        public CrMod()
        {
            isEn = false; speed = 20; state = 1;
            find();
        }
        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    // CheckAndMove(Hero, new Vector2(Hero.speed, -Hero.speed));
                    CrV += new Vector2(speed, -speed);
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    //CheckAndMove(Hero, new Vector2(-Hero.speed, -Hero.speed));
                    CrV += new Vector2(-speed, -speed);
                }
                else CrV += new Vector2(0, -speed);

            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    //CheckAndMove(Hero, new Vector2(Hero.speed, Hero.speed));
                    CrV += new Vector2(speed, speed);
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    //CheckAndMove(Hero, new Vector2(-Hero.speed, Hero.speed));
                    CrV += new Vector2(-speed, speed);
                }
                else CrV += new Vector2(0, speed);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                //CheckAndMove(Hero, new Vector2(Hero.speed, 0));
                CrV += new Vector2(speed, 0);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                // CheckAndMove(Hero, new Vector2(-Hero.speed, 0));
                CrV += new Vector2(-speed, 0);
            }
        }
        public Map Read()
        {

            int n; int m;
            string[] lines = File.ReadAllLines(files[actState]);//(@"C:\Users\Андрей\Documents\Visual Studio 2015\Projects\Shooter\Shooter\Content\Map.txt");
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
            s = lines[n+1].Split(' ');
            int count= int.Parse(s[0]);
            enemies = new List<Monster>();
            for(int i=n+2;i<n+2+ count; i++)
            {
                s = lines[i].Split(' ');
                switch (s[0])
                {
                    case "Mon":
                        enemies.Add(new Monster(new Vector2(int.Parse(s[1]), int.Parse(s[2]))));
                        break;
                }
            }
            s = lines[n + 2 + count].Split(' ');
            MHPos.X= int.Parse(s[0]); MHPos.Y = int.Parse(s[1]);
            return new Map(ar, n, m);

        }
        public void Save(Map map)
        {
            if (actState == 0)
            {
                string s = "maps/Map" + files.Count() + ".txt";
                FileStream fs = File.Create(s);//, map.height * map.width * 25);//map.height*map.width*20,new FileOptions(),new System.Security.AccessControl.FileSecurity().);
                files.Add(s);
                actState = files.Count() - 1;

                fs.Close();

            }
            /* Stream myStream;
             using (myStream = File.Open(files[actState], FileMode.OpenOrCreate, FileAccess.ReadWrite))
             {*/
            FileInfo fi = new FileInfo(files[actState]);
            using (StreamWriter sr = fi.CreateText())//(@"C:\Users\Андрей\Documents\Visual Studio 2015\Projects\Shooter\Shooter\Content\Map.txt"))
            {


                sr.WriteLine(map.height + " " + map.width);
                for (int i = 0; i < map.height; i++)
                {
                    string s = "";
                    for (int j = 0; j < map.width; j++)
                    {
                        s += map.ar[i, j] + " ";
                    }
                    sr.WriteLine(s);
                }
                sr.WriteLine(enemies.Count);
               foreach(Monster e in enemies)
                {
                    sr.WriteLine("Mon " + e.rec.X + " " + e.rec.Y);
                }
                sr.WriteLine((int)MHPos.X+" "+(int)MHPos.Y);


            }

        }
        public void delete()
        {

            if (actState != 0)
            {
                File.Delete(files[actState]);
                files.Remove(files[actState]);
                actState--;
            }
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < files.Count(); i++)
            {

                if (i == actState) spriteBatch.DrawString(font, files[i].ToUpper(), new Vector2(CrV.X - WinWIDTH / 2 + 10, CrV.Y - WinHEIGHT / 2 + i * 20), Color.Yellow);
                else spriteBatch.DrawString(font, files[i], new Vector2(CrV.X - WinWIDTH / 2 + 10, CrV.Y - WinHEIGHT / 2 + i * 20), Color.Yellow);
            }
            spriteBatch.DrawString(font, "press Q to save current map to selected file", new Vector2(CrV.X - WinWIDTH / 2 + 200, CrV.Y - WinHEIGHT / 2), Color.Yellow);
            spriteBatch.DrawString(font, "press R to read a map from selected file", new Vector2(CrV.X - WinWIDTH / 2 + 200, CrV.Y - WinHEIGHT / 2 + 20), Color.Yellow);
            spriteBatch.DrawString(font, "press C to delete selected file", new Vector2(CrV.X - WinWIDTH / 2 + 200, CrV.Y - WinHEIGHT / 2 + 40), Color.Yellow);
            spriteBatch.Draw(robot, new Rectangle((int)MHPos.X,(int) MHPos.Y, 57, 57),Color.White);
        }
        public void find()
        {
            string[] F;
            F = Directory.GetFiles("maps", "*.txt");
            files = F.ToList();
            files.Insert(0, "Create new map");

        }

    }
}
