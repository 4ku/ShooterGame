using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter
{
    public class Standart : Ability
    {
        bool flx = false;
        bool fly = false;
        RectangleV3 recX, recY;
        MainHero Hero;
        public Standart(MainHero Hero)
        {
            this.Hero = Hero;
        }
        public override void BeforeCheck(World world, GameTime gameTime)
        {
            flx = false;
            fly = false;
            recX = new RectangleV3(new Vector2((int)(Hero.position.X + Hero.move.X), (int)(Hero.position.Y)), Hero.width, Hero.height);
            recY = new RectangleV3(new Vector2((int)(Hero.position.X), (int)(Hero.position.Y + Hero.move.Y)), Hero.width, Hero.height);

        }
        public override void InCheck(World world, GameTime gameTime, Entity e)
        {
            if (e is Wall && !e.Equals(this))
            {
                Wall w = (Wall)e;
                //if (Intersects(recX, w.rectangle))
                if (w.rectangle.Intersect(recX))
                {
                    flx = true;

                    if (Hero.move.X > 0) Hero.position.X = w.rectangle.r.X - Hero.width - 3;
                    else if (Hero.move.X < 0) Hero.position.X = w.rectangle.r.X + w.CellWIDTH - 1;
                }
                if (w.rectangle.Intersect(recY))
                {
                    fly = true;
                    if (Hero.move.Y > 0) Hero.position.Y = w.rectangle.r.Y - Hero.height - 3;
                    else if (Hero.move.Y < 0) Hero.position.Y = w.rectangle.r.Y + w.CellHEIGHT - 1;
                }
            }

        }
        
        public override void AfterCheck(World world, GameTime gameTime)
        {
            if (flx) Hero.move.X = 0;
            if (fly) Hero.move.Y = 0;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Hero.texture, Hero.rectangle.r, new Rectangle(0, 0, Hero.texture.Width, Hero.texture.Height), Color.White, (float)Math.Atan2(Hero.rectangle.direction.Y, Hero.rectangle.direction.X), new Vector2(Hero.texture.Width * Hero.rectangle.kx, Hero.texture.Height * Hero.rectangle.ky), SpriteEffects.None, 0.5f);
        }

      
    }
}
