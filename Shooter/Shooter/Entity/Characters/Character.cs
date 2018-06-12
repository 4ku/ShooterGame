using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shooter.Game1;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    public abstract class Character : Entity
    {
        public RectangleV3 rectangle;
        public int health;
        //public Character(int W, int H) : base(W, H)
        //{
        //    Tex = tex;
        //    reload = 1500f;
        //    speed = 1f;
        //}

        //public bool Intersect(Entity entity) { }

        //public abstract bool Check(Vector2 move);
        //public abstract void Move(Vector2 move);


        //public void SpawnRandomNearTheHero(GameTime gameTime, Map map)
        //{
        //    int min = 400; int max = 2000;
        //    Random rand = new Random(); int x; int y;

        //    x = rand.Next(-max, max);
        //    while (x + Hero.Pos.X < (CellWIDTH + 5) || (x + Hero.Pos.X > CellWIDTH * (map.width - 1) - 10) || Math.Abs(x) < min)
        //        x = rand.Next(-max, max);

        //    y = rand.Next(-max, max);
        //    while (y + Hero.Pos.Y < (CellHEIGHT + 5) || (y + Hero.Pos.Y > CellHEIGHT * (map.height - 1) - 10) || Math.Abs(y) < min)
        //        y = rand.Next(-max, max);

        //    Pos = new Vector2(x, y) + Hero.Pos;
        //}

        //public float reload;
        //public float elapsedtime = 0;


        ///стрельба монстра в героя
        //public void Shoot(GameTime gameTime, int NumWeapon)
        //{
        //    eltime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        //    if (eltime > reload)
        //    {
        //        eltime = 0f;
        //        Weapon bul = Weapon.CreateWeapon(NumWeapon, Pos);

        //        Vector2 rot = Hero.Pos - Pos; //bul.speed = 5f;
        //        float f = bul.speed / (float)Math.Sqrt(rot.X * rot.X + rot.Y * rot.Y);
        //        rot.X *= f; rot.Y *= f;
        //        bul.Velocity = rot;
        //        /* float cos = -bul.Velocity.X / bul.Velocity.Length();
        //         float sin = -bul.Velocity.Y / bul.Velocity.Length();
        //         bul.sin = sin; bul.cos = cos;*/
        //        bullets.Add(bul);
        //    }


        /// удаление пули
        // /* for (int i = 0; i < bullets.Count; i++)
        //     {
        //         bullets[i].Pos += bullets[i].Velocity;
        //         if (Vector2.Distance(bullets[i].startpos, bullets[i].Pos) >= 2500)
        //         {
        //             bullets.RemoveAt(i); i--;
        //         }
        //     }*/
        // движение монстра
        //public void Move(Map map)
        //{

        //    Vector2 rot = Hero.Pos - Pos;
        //    float f = speed / (float)Math.Sqrt(rot.X * rot.X + rot.Y * rot.Y);
        //    rot *= f;
        //    bool isInter = false;
        //    Rectangle R = new Rectangle((int)(rectangle.X + rot.X), (int)(rectangle.Y + rot.Y), width, height);
        //    foreach (Essence es in enemies)
        //    {
        //        if (R.Intersects(es.rec)) { isInter = true; break; }
        //    }
        //    if (!isInter) CheckAndMove(rot, map);
        //    Pos += rot;
        //}





        ///проверка можно ли идти в стенку(нельзя)
        //public void CheckAndMove(Vector2 move, Map map)
        //{
        //    if (move.X > 0)
        //    {
        //        int j = (int)(Pos.X + width + move.X) / CellWIDTH;
        //        int i1 = (int)(Pos.Y + 2) / CellHEIGHT; int i2 = (int)(Pos.Y + height - 2) / CellHEIGHT;
        //        if (map.ar[i1, j] == 0 && map.ar[i2, j] == 0) Pos += new Vector2(move.X, 0); else Pos = new Vector2((j - 1) * CellWIDTH + (CellWIDTH - width), Pos.Y);
        //    }
        //    else if (move.X < 0)
        //    {
        //        int j = (int)(Pos.X + move.X) / CellWIDTH;
        //        int i1 = (int)(Pos.Y + 2) / CellHEIGHT; int i2 = (int)(Pos.Y + height - 2) / CellHEIGHT;
        //        if (map.ar[i1, j] == 0 && map.ar[i2, j] == 0) Pos += new Vector2(move.X, 0); else Pos = new Vector2((j + 1) * CellWIDTH, Pos.Y);
        //    }
        //    if (move.Y > 0)
        //    {
        //        int i = (int)(Pos.Y + height + move.Y) / CellHEIGHT;
        //        int j1 = (int)(Pos.X + 2) / CellWIDTH; int j2 = (int)(Pos.X + width - 2) / CellWIDTH;
        //        if (map.ar[i, j1] == 0 && map.ar[i, j2] == 0) Pos += new Vector2(0, move.Y); else Pos = new Vector2(Pos.X, (i - 1) * CellHEIGHT + (CellHEIGHT - height));
        //    }
        //    else if (move.Y < 0)
        //    {
        //        int i = (int)(Pos.Y + move.Y) / CellHEIGHT;
        //        int j1 = (int)(Pos.X + 3) / CellWIDTH; int j2 = (int)(Pos.X + width - 3) / CellWIDTH;
        //        if (map.ar[i, j1] == 0 && map.ar[i, j2] == 0) Pos += new Vector2(0, move.Y); else Pos = new Vector2(Pos.X, (i + 1) * CellHEIGHT);
        //    }
        //}

        ///создание монстра
        //static MouseState mouseStatePast;
        //public static void CreateEnemy(CrMod CM)
        //{
        //    MouseState ms = Mouse.GetState();
        //    if (ms.RightButton == ButtonState.Pressed && mouseStatePast.RightButton == ButtonState.Released)
        //    {
        //        float x = CM.CrV.X + (-WinWIDTH / 2) + ms.X; float y = CM.CrV.Y + (-WinHEIGHT / 2) + ms.Y;
        //        Rectangle R = new Rectangle((int)x, (int)y, Monster.W, Monster.H);
        //        bool isInter = false;
        //        foreach (Monster en in enemies)
        //        {
        //            if (R.Intersects(en.rectangle)) { isInter = true; break; };
        //        }
        //        if (!isInter)
        //        {
        //            Monster mon = new Monster(50, 50, MonsteR); mon.Pos = new Vector2(x, y);
        //            enemies.Add(mon);
        //        }
        //    }
        //    mouseStatePast = ms;
        //}
    }
}
