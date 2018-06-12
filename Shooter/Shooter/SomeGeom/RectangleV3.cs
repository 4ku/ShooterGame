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
    public class RectangleV3
    {
        public Vector2 centre;//центр вращения
        public Vector2 direction;
        public Rectangle r;
        public int x1, y1, x2, y2, x3, y3, x4, y4;
        public float kx, ky;
        float cos;
        float sin;
        public RectangleV3(Vector2 position, float kx, float ky, Vector2 direction, int w, int h) // kx и ky задают центр вращения 
        {
            // this.centre = centre;
            this.kx = kx;
            this.ky = ky;
            this.direction = direction;
            r = new Rectangle ((int)position.X, (int)position.Y, w, h);


            cos = direction.X / direction.Length();
            sin = direction.Y / direction.Length();

            centre.X = kx * r.Width;
            centre.Y = ky * r.Height;
           //  kx = centre.X / r.Width;
           //  ky = centre.Y / r.Height;
            x1 = (int)((r.Width * cos*(1- kx) - r.Height * sin * ky) );
            y1 = (int)( (r.Width * sin * (1 - kx) + r.Height * cos * ky) );

            x2 = (int)( (r.Width * cos * (1 - kx) + r.Height * sin *(1- ky)));
            y2 = (int)( (r.Width * sin * (1 - kx) - r.Height * cos * (1 - ky)));

            x3 = (int)(- (r.Width * cos * kx + r.Height * sin * ky) );
            y3 = (int)(- (r.Width * sin * kx - r.Height * cos * ky) );

            x4 = (int)( - (r.Width * cos * kx - r.Height * sin * (1 - ky)));
            y4 = (int)( - (r.Width * sin * kx + r.Height * cos * (1 - ky)));
        }
        public RectangleV3(Vector2 position, int w, int h)
        {
            r = new Rectangle((int)position.X, (int)position.Y, w, h);
            kx = 0.5f;
            ky = 0.5f;
            centre.X =kx * r.Width;
            centre.Y = ky * r.Height;
            direction = new Vector2(1, 0);
           
            cos = direction.X / direction.Length();
            sin = direction.Y / direction.Length();

           
            x1 = (int)((r.Width * cos * (1 - kx) - r.Height * sin * ky));
            y1 = (int)((r.Width * sin * (1 - kx) + r.Height * cos * ky));

            x2 = (int)( (r.Width * cos * (1 - kx) + r.Height * sin * (1 - ky)));
            y2 = (int)( (r.Width * sin * (1 - kx) - r.Height * cos * (1 - ky)));

            x3 = (int)( - (r.Width * cos * kx + r.Height * sin * ky));
            y3 = (int)( - (r.Width * sin * kx - r.Height * cos * ky));

            x4 = (int)( - (r.Width * cos * kx - r.Height * sin * (1 - ky)));
            y4 = (int)(- (r.Width * sin * kx + r.Height * cos * (1 - ky)));
        }

        public void Move(Vector2 v)
        {
            r.X += (int)v.X;
            r.Y += (int)v.Y;
        }

        public void Turn(Vector2 direction)
        {
            float cos;
            float sin;
            this.direction = direction;
            cos = direction.X / direction.Length();
            sin = direction.Y / direction.Length();
        }

        public bool Intersect(RectangleV3 rectangle)
        {
            int Xmin = (int) - centre.X; int Xmax = r.Width-(int)centre.X;
            int Ymin = (int) - centre.Y; int Ymax = r.Height-(int)centre.Y;
            Vector2 V = new Vector2(rectangle.r.X - r.X, rectangle.r.Y - r.Y);
            
            int x = (int)(cos * (rectangle.x1 + V.X) + sin * (rectangle.y1 + V.Y)); int y = (int)(-sin * (rectangle.x1 + V.X) + cos * (rectangle.y1 + V.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(cos * (rectangle.x2 + V.X) + sin * (rectangle.y2 + V.Y));  y = (int)(-sin * (rectangle.x2 + V.X) + cos * (rectangle.y2 + V.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(cos * (rectangle.x3 + V.X) + sin * (rectangle.y3 + V.Y));  y = (int)(-sin * (rectangle.x3 + V.X) + cos * (rectangle.y3 + V.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(cos * (rectangle.x4 + V.X) + sin * (rectangle.y4 + V.Y));  y = (int)(-sin * (rectangle.x4 + V.X) + cos * (rectangle.y4 + V.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            //x = (int)(cos * (rectangle.centre.X + V.X) + sin * (rectangle.centre.Y + V.Y)); y = (int)(-sin * (rectangle.centre.X + V.X) + cos * (rectangle.centre.Y + V.Y));
            //if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;

            Xmin = (int)-rectangle.centre.X; Xmax = rectangle.r.Width - (int)rectangle.centre.X;
            Ymin = (int)-rectangle.centre.Y; Ymax = rectangle.r.Height - (int)rectangle.centre.Y;
            V = new Vector2(r.X - rectangle.r.X , r.Y - rectangle.r.Y);

            x = (int)(rectangle.cos * (x1 + V.X) + rectangle.sin * (y1 + V.Y)); y = (int)(-rectangle.sin * (x1 + V.X) + rectangle.cos * (y1 + V.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(rectangle.cos * (x2 + V.X) + rectangle.sin * (y2 + V.Y)); y = (int)(-rectangle.sin * (x2 + V.X) + rectangle.cos * (y2 + V.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(rectangle.cos * (x3 + V.X) + rectangle.sin * (y3 + V.Y)); y = (int)(-rectangle.sin * (x3 + V.X) + rectangle.cos * (y3 + V.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            x = (int)(rectangle.cos * (x4 + V.X) + rectangle.sin * (y4 + V.Y)); y = (int)(-rectangle.sin * (x4 + V.X) + rectangle.cos * (y4 + V.Y));
            if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
           // x = (int)(rectangle.cos * (centre.X + V.X) + rectangle.sin * (centre.Y + V.Y)); y = (int)(-rectangle.sin * (centre.X + V.X) + rectangle.cos * (centre.Y + V.Y));
           // if (Xmin <= x && Xmax >= x && Ymin <= y && Ymax >= y) return true;
            return false;

        }


    }
}
