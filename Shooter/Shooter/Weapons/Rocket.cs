using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Shooter.Game1;
using static Shooter.World;
using static Shooter.TexturePack;

namespace Shooter
{
    public class Rocket: Weapon
    {
        //public override void Update(GameTime gameTime)
        //{

        //}

        //public override void Draw(SpriteBatch spriteBatch)
        //{

        //}
        /*public static float Reload = 50;

        public Rocket(int W, int H, Vector2 Spos, Texture2D tx) : base(W, H, Spos, tx)
        {
            //rec.Width = 30; rec.Height = 25;
            speed = 1f;
            exTime = 3000 * 100 / speed;
            /*Pos = Hero.Pos;
            startpos =Hero.Pos ;
            NumWeapon = 4;
        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch, Weapon bul)
        {
            spriteBatch.Draw(rocket, bul.rec, new Rectangle(0, 0, rocket.Width, rocket.Height), Color.White, (float)Math.Atan2(bul.Velocity.Y, bul.Velocity.X) + (float)Math.PI, new Vector2(rocket.Width / 2, rocket.Height / 2), SpriteEffects.None, 1f);
        }
        public void Update(Map map)
        {
            int j1 = (int)Pos.X / CellWIDTH; int i1 = (int)Pos.Y / CellHEIGHT;
            int j2 = (int)(Pos.X + (width * cos) / 2) / CellWIDTH; int i2 = (int)(Pos.Y + (width * sin) / 2) / CellHEIGHT;
          //  int j3 = (int)(Pos.X + (W * cos) / 4) / CellWIDTH; int i3 = (int)(Pos.Y - (W * sin) / 4) / CellHEIGHT;

            if (map.ar[i2, j2] == 1)
            {
                health = 0;
                map.ar[i2, j2] = 0;
            } else if (map.ar[i1, j1] == 1)
            {
                health = 0;
                map.ar[i1, j1] = 0;
            }
        }*/
        public float physicalFrequencyShooting = 0;
        public float ellapsedTimeFromLastShoot = 0;
        public override void Shoot(World world, Vector2 startPosition, Vector2 direction)
        {
            //   if (ellapsedTimeFromLastShoot > physicalFrequencyShooting)
            if ((mouseStatePast.LeftButton == ButtonState.Released || isEnemy) && ellapsedTimeFromLastShoot > physicalFrequencyShooting)
            {
                if (!isEnemy) rocketSound.Play();
                world.ToAdd.Add(new RocketFire(startPosition, direction, isEnemy));
                ellapsedTimeFromLastShoot = 0;
            }
        }

        public override void Update(GameTime gameTime)
        {
            ellapsedTimeFromLastShoot += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public override void Taken()
        {
           
        }

    }

}