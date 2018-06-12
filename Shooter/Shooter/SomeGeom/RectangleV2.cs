using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using static Shooter.Game1;
using Shooter;
namespace Shooter
{
  public  class RectangleV2
    {
        public int x1, y1, x2, y2, x3, y3, x4, y4, width, height;
       public float cos, sin;
        public Vector2 Pos;
        //public RectangleV2(int x1,int y1,int x2,int y2,int x3,int y3,int x4,int y4,int PosX,int PosY)
        public RectangleV2(Vector2 Velocity, int width, int height, Vector2 Pos)
        {

            cos = Velocity.X / Velocity.Length();
            sin = Velocity.Y / Velocity.Length();

             x1 = (int)(Pos.X + (width * cos - height * sin) / 2);
             y1 = (int)(Pos.Y + (width * sin + height * cos) / 2);

            x2 = (int)(Pos.X + (width * cos + height * sin) / 2);
             y2 = (int)(Pos.Y + (width * sin - height * cos) / 2);

            x3 = (int)(Pos.X - (width * cos + height * sin) / 2);
             y3 = (int)(Pos.Y - (width * sin - height * cos) / 2);

             x4 = (int)(Pos.X - (width * cos - height * sin) / 2);
             y4 = (int)(Pos.Y - (width * sin + height * cos) / 2);

            this.width = width;
            this.height = height;
            this.Pos = Pos;
        }
      
       
    }
}
