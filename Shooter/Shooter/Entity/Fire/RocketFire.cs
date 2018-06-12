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
using static Shooter.SomeGeom;
namespace Shooter
{
    public class RocketFire :Fire
    {
        //public override void Update(GameTime gameTime)
        //{

        //}

        //public override void Draw(SpriteBatch spriteBatch)
        //{

        //}
        /* public static float Reload = 50;

         public Rocket(int W, int H, Vector2 Spos, Texture2D tx) : base(W, H, Spos, tx)
         {
             //rec.Width = 30; rec.Height = 25;
             speed = 1f;
             exTime = 3000 * 100 / speed;
             Pos = Hero.Pos;
             startpos =Hero.Pos ;
             NumWeapon = 4;
         }

         public static void Draw(GameTime gameTime, SpriteBatch spriteBatch, Weapon bul)
         {
             spriteBatch.Draw(rocket, bul.rec, new Rectangle(0, 0, rocket.Width, rocket.Height), Color.White, (float)Math.Atan2(bul.Velocity.Y, bul.Velocity.X) + (float)Math.PI, new Vector2(rocket.Width / 2, rocket.Height / 2), SpriteEffects.None, 1f);

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


        Texture2D texture = rocketTex;
        public int width = 40;
        public int height = 20;
        public float speed = 5f;

        public float currentExistingTime; //время существования
        public float existingTime = 8000; //положенное время существования
        public RocketFire(Vector2 startPosition, Vector2 direction, bool isEnemy)
        {
            this.damage = 3;
            this.position = startPosition;
            this.direction = direction;
            this.direction.Normalize();
            this.currentExistingTime = 0;
            rec = new RectangleV3(startPosition, 0.5f, 0.5f, direction, width, height);
            this.isEnemy = isEnemy;
        }

        public override void Update(World world, GameTime gameTime)
        {
            foreach (Entity e in world.entities)
            {
                if (e is Wall)
                {
                    Wall wall = (Wall)e;
                    // if (Intersects(rec2, wall.rectangle))
                    if (rec.Intersect(wall.rectangle))
                    {
                        world.ToKill.Add(this);
                        world.ToKill.Add(wall);
                        WallBreakSound.Play();
                    }
                }
                else if (isEnemy)
                {
                    if (e is MainHero && isEnemy)
                    {
                        MainHero h = (MainHero)e;
                        //  if (Intersects(rec2, h.rectangle))
                        if (rec.Intersect(h.rectangle))
                        {
                            h.health -= damage;
                            world.ToKill.Add(this);
                            damageHeroSound.Play();
                        }
                    }
                }
                else
                {
                    if (e is Enemy && !isEnemy)
                    {
                        Enemy en = (Enemy)e;
                        // if (Intersects(rec2, en.rectangle))
                        if (rec.Intersect(en.rectangle))
                        {
                            en.health -= damage;
                            world.ToKill.Add(this);
                            damageMonSound.Play();
                        }
                    }
                }
            }

            position += direction * speed;
            rec.r.X = (int)position.X; rec.r.Y = (int)position.Y;


            currentExistingTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (currentExistingTime >= existingTime)
            {
                world.ToKill.Add(this);
            }
            //else
            //{
            //    rec2 = new RectangleV2(direction, 60, 25, position);
            //    rectangle.X = (int)position.X; rectangle.Y = (int)position.Y;

            //}

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(texture, rec.r, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, (float)Math.Atan2(direction.Y, direction.X) + (float)Math.PI, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 1f);
            spriteBatch.Draw(texture, rec.r, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, (float)Math.Atan2(direction.Y, direction.X) + (float)Math.PI, new Vector2(texture.Width * rec.kx, texture.Height * rec.ky), SpriteEffects.None, 1f);
        }

    }

}