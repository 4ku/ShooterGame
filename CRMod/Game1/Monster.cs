using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CRMod.Game1;
using Microsoft.Xna.Framework.Input;


namespace CRMod
{
  public  class Monster
    {
        public static MouseState mspast;
        public static int width = 50;
        public static int height = 50;
        public static void CrMon(CrMod CM,bool del)
        {
            MouseState ms = Mouse.GetState();
           
                float x = CM.CrV.X + (-WinWIDTH / 2) + ms.X; float y = CM.CrV.Y + (-WinHEIGHT / 2) + ms.Y;
                Rectangle R = new Rectangle((int)x, (int)y, width,height);
                bool isInter = false; Monster m=new Monster(Vector2.Zero);
            bool fl = false;
            foreach (Monster en in enemies)
            {
                if (R.Intersects(en.rec))
                {
                    isInter = true;
                    if (del == true && en.rec.Contains(new Vector2(ms.X, ms.Y) + CM.CrV - new Vector2(WinWIDTH / 2, WinHEIGHT / 2)))
                    {
                        fl = true; m = en; break;
                    }
                    
                   
                }
            }
            if (!isInter)
            {
                Monster mon = new Monster(new Vector2(x, y));
                enemies.Add(mon);
            }
            else if (del && fl)
            {
                enemies.Remove(m);
            }
          
        }

        public Rectangle rec;
        public Vector2 Pos;
       public  Monster(Vector2 Pos)
        {
            rec = new Rectangle((int)Pos.X, (int)Pos.Y, width, height);
        }
    }
}
