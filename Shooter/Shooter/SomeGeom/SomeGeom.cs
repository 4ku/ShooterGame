using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using static Shooter.Game1;
using Shooter;
using static Shooter.TexturePack;
namespace Shooter
{
    public static class SomeGeom
    {
        public static bool Intersects(RectangleV2 rec1, RectangleV2 rec2)
        {

            int Xmin = -rec1.width / 2; int Xmax = rec1.width / 2;
            int Ymin = -rec1.height / 2; int Ymax = rec1.height / 2;
            int x = (int)(rec1.cos * (rec2.x1 - rec1.Pos.X) + rec1.sin * (rec2.y1 - rec1.Pos.Y)); int y = (int)(-rec1.sin * (rec2.x1 - rec1.Pos.X) + rec1.cos * (rec2.y1 - rec1.Pos.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(rec1.cos * (rec2.x2 - rec1.Pos.X) + rec1.sin * (rec2.y2 - rec1.Pos.Y)); y = (int)(-rec1.sin * (rec2.x2 - rec1.Pos.X) + rec1.cos * (rec2.y2 - rec1.Pos.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(rec1.cos * (rec2.x3 - rec1.Pos.X) + rec1.sin * (rec2.y3 - rec1.Pos.Y)); y = (int)(-rec1.sin * (rec2.x3 - rec1.Pos.X) + rec1.cos * (rec2.y3 - rec1.Pos.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(rec1.cos * (rec2.x4 - rec1.Pos.X) + rec1.sin * (rec2.y4 - rec1.Pos.Y)); y = (int)(-rec1.sin * (rec2.x4 - rec1.Pos.X) + rec1.cos * (rec2.y4 - rec1.Pos.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(rec1.cos * (rec2.Pos.X - rec1.Pos.X) + rec1.sin * (rec2.Pos.Y - rec1.Pos.Y)); y = (int)(-rec1.sin * (rec2.Pos.X - rec1.Pos.X) + rec1.cos * (rec2.Pos.Y - rec1.Pos.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;


            Xmin = -rec2.width / 2; Xmax = rec2.width / 2;
            Ymin = -rec2.height / 2; Ymax = rec2.height / 2;

            x = (int)(rec2.cos * (rec1.x1 - rec2.Pos.X) + rec2.sin * (rec1.y1 - rec2.Pos.Y)); y = (int)(-rec2.sin * (rec1.x1 - rec2.Pos.X) + rec2.cos * (rec1.y1 - rec2.Pos.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(rec2.cos * (rec1.x2 - rec2.Pos.X) + rec2.sin * (rec1.y2 - rec2.Pos.Y)); y = (int)(-rec2.sin * (rec1.x2 - rec2.Pos.X) + rec2.cos * (rec1.y2 - rec2.Pos.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(rec2.cos * (rec1.x3 - rec2.Pos.X) + rec2.sin * (rec1.y3 - rec2.Pos.Y)); y = (int)(-rec2.sin * (rec1.x3 - rec2.Pos.X) + rec2.cos * (rec1.y3 - rec2.Pos.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(rec2.cos * (rec1.x4 - rec2.Pos.X) + rec2.sin * (rec1.y4 - rec2.Pos.Y)); y = (int)(-rec2.sin * (rec1.x4 - rec2.Pos.X) + rec2.cos * (rec1.y4 - rec2.Pos.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(rec2.cos * (rec1.Pos.X - rec2.Pos.X) + rec2.sin * (rec1.Pos.Y - rec2.Pos.Y)); y = (int)(-rec2.sin * (rec1.Pos.X - rec2.Pos.X) + rec2.cos * (rec1.Pos.Y - rec2.Pos.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            return false;


        }
        public static bool Intersects(RectangleV2 rec2, Rectangle r)
        {
            int posx = (int)(rec2.cos * rec2.Pos.X + rec2.sin * rec2.Pos.Y);
            int posy = (int)(-rec2.sin * rec2.Pos.X + rec2.cos * rec2.Pos.Y);
            int Xmin = posx - rec2.width / 2; int Xmax = posx + rec2.width / 2;
            int Ymin = posy - rec2.height / 2; int Ymax = posy + rec2.height / 2;

            int x = (int)(rec2.cos * r.X + rec2.sin * r.Y); int y = (int)(-rec2.sin * r.X + rec2.cos * r.Y);
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(rec2.cos * r.X + rec2.sin * (r.Y + r.Height)); y = (int)(-rec2.sin * r.X + rec2.cos * (r.Y + r.Height));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(rec2.cos * (r.X + r.Width) + rec2.sin * r.Y); y = (int)(-rec2.sin * (r.X + r.Width) + rec2.cos * r.Y);
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(rec2.cos * (r.X + r.Width) + rec2.sin * (r.Y + r.Height)); y = (int)(-rec2.sin * (r.X + r.Width) + rec2.cos * (r.Y + r.Height));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;

            Xmin = r.X; Xmax = (r.X + r.Width);
            Ymin = r.Y; Ymax = (r.Y + r.Height);

            x = rec2.x1; y = rec2.y1;
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = rec2.x2; y = rec2.y2;
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = rec2.x3; y = rec2.y3;
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = rec2.x4; y = rec2.y4;
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            return false;
        }
        public static bool Intersects(Rectangle r1, Rectangle r2)
        {
            if (r1.Intersects(r2)) return true;
            else return false;
        }
    }
}
