using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Shooter;
using static Shooter.TexturePack;
namespace Shooter
{
    class Wall: MapObject
    {
        public int x, y;
        public int CellWIDTH = 60;
        public int CellHEIGHT = 60;
        public Texture2D texture;
        public RectangleV3 rectangle;
        public Wall(int x, int y)
        {
            //name = "wall";
            texture = iron;
            this.y = y;
            this.x = x;
            // rectangle = new Rectangle(x * CellWIDTH, y * CellHEIGHT, CellWIDTH, CellHEIGHT);
            rectangle = new RectangleV3(new Vector2(x * CellWIDTH, y * CellHEIGHT), CellWIDTH, CellHEIGHT);
        }
        public override void Update(World world, GameTime gameTime)
        {
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            // spriteBatch.Draw(texture, new Rectangle(x * CellWIDTH, y * CellHEIGHT, CellWIDTH, CellHEIGHT), new Rectangle(0, 0, iron.Width, iron.Height), Color.White);
          //  spriteBatch.Draw(texture, rectangle.r, new Rectangle(0, 0, iron.Width, iron.Height), Color.White);
            spriteBatch.Draw(texture, rectangle.r, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, (float)Math.Atan2(rectangle.direction.Y, rectangle.direction.X), new Vector2(texture.Width * rectangle.kx, texture.Height * rectangle.ky), SpriteEffects.None, 1f);
        }

    }
}
