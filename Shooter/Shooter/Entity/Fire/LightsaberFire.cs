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
    public class LightsaberFire:Fire
    {
      
        public int width=300;
        public int height=7;
        public float angle=-(float)Math.PI/2;
       /* public Rectangle rectangle;
        public RectangleV2 rec2;
        public Vector2 Velocity;
        public Vector2 startpos;
        public Vector2 Pos;*/
        Texture2D texture = blasterTex;
        // MouseState mspast;

        /* public LightsaberFire()
         {
             mspast = Mouse.GetState();
         }*/

        Lightsaber lightsaber;
        public LightsaberFire(Vector2 startPosition, Vector2 direction, bool isEnemy,Lightsaber lightsaber)
        {
            this.lightsaber = lightsaber;
            this.damage = 1;
            this.position = startPosition;
            this.direction = direction;
          
            // rec2 = new RectangleV2(direction, width, height, startPosition);
            // rectangle = new Rectangle((int)startPosition.X, (int)startPosition.Y, width, height);
            rec = new RectangleV3(startPosition, 0.5f, 0.5f, direction, width, height);
            this.isEnemy = isEnemy;


          /*  this.width = width;
            this.height = height;
            this.startpos = startpos;
            Pos = startpos;
            rectangle = new Rectangle((int)startpos.X, (int)startpos.Y, width, height);
             Velocity = new Vector2(endpos.X-startpos.X , endpos.Y-startpos.Y);
            rec2 = new RectangleV2(Velocity, width, height, startpos);
            damage = 1;*/
        }
      /*  public override Fire New(int width, int height, Vector2 startpos, Vector2 endpos)
        {
           return new LightsaberFire(width,  height, startpos,  endpos);
        }*/
       /* public void Shoot(World world, GameTime gameTime, Vector2 startPos)
        {
            MouseState ms = Mouse.GetState();
           
            if (ms.LeftButton == ButtonState.Pressed && mspast.LeftButton == ButtonState.Released)
            {
                Vector2 endPos = new Vector2((int)startPos.X + (-WinWIDTH / 2) + ms.Position.X, startPos.Y + ms.Position.Y + (-WinHEIGHT / 2));
                LightsaberFire bul = new LightsaberFire(300, 8, startPos,endPos);
                bul.isEn = false;
                world.ToAdd.Add(bul);

            }
            mspast = ms;
           
        }*/

    


        public override void Update(World world, GameTime gameTime)
        {
                 mouseState = Mouse.GetState();
            if (!lightsaber.isEnemy && mouseState.LeftButton == ButtonState.Released)
            {
                world.ToKill.Add(this); lightsaber.created = false;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))angle+=(float)Math.PI/30 ;
            if (Keyboard.GetState().IsKeyDown(Keys.Q)) angle -= (float)Math.PI / 30;

            /* Vector2 v = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
             v *= (float)Math.Sqrt(world.Hero.width * world.Hero.width / 4 + world.Hero.height * world.Hero.height / 4);
             position = world.Hero.position+v;
                 //rec.r.X = (int)position.X; rec.r.Y = (int)position.Y;
                 direction = new Vector2(mouseState.Position.X + (-WinWIDTH / 2)-v.X, mouseState.Position.Y + (-WinHEIGHT / 2) - v.Y);
                 rec = new RectangleV3(position, 0.5f, 0.5f, direction, width, height);*/

            foreach (Entity e in world.entities)
            {
                if (e is Wall)
                {
                    Wall wall = (Wall)e;
                    if (rec.Intersect(wall.rectangle))
                    {
                        world.ToKill.Add(this); lightsaber.created = false;
                    }
                }
                else if (e is Fire)
                {
                    Fire bul = (Fire)e;
                   

                    if (rec.Intersect(bul.rec) && !(e is LightsaberFire))
                    {
                        float cos = (direction.X * bul.direction.X + direction.Y * bul.direction.Y) / (bul.direction.Length() * direction.Length());
                        float k = cos * bul.direction.Length() / direction.Length();
                        Vector2 V1 = new Vector2(direction.X * k, direction.Y * k);
                        Vector2 V2 = new Vector2(); V2 = bul.direction - V1;
                        bul.direction = V1 - V2;
                        if (bul.speed != 0)
                        {
                            while (rec.Intersect(bul.rec))
                            {
                                bul.position += bul.direction * bul.speed;
                                bul.rec.r.X = (int)bul.position.X; bul.rec.r.Y = (int)bul.position.Y;
                            }
                        }
                        bul.isEnemy = isEnemy;
                       
                    }


                }
                else if (isEnemy)
                {
                    if (e is MainHero)
                    {
                        MainHero h = (MainHero)e;
                        if (rec.Intersect(h.rectangle))
                        {
                            h.health -= damage;
                            damageHeroSound.Play();
                            //world.ToKill.Add(this);
                        }
                    }
                }
                else if (!isEnemy)
                {
                    if (e is Enemy)
                    {
                        Enemy en = (Enemy)e;
                        if (rec.Intersect(en.rectangle))
                        {
                            damageMonSound.Play();
                            en.health -= damage;
                            //world.ToKill.Add(this);
                        }
                    }
                }
            }
          //  world.ToKill.Add(this);





            //for (int i = 0; i < bullets.Count; i++)
            //{


            //    // bul.CrRecV2();
            //    if (w.Intersects(bullets[i]))
            //    {
            //        float cos = (w.Velocity.X * bullets[i].Velocity.X + w.Velocity.Y * bullets[i].Velocity.Y) / (bullets[i].Velocity.Length() * w.Velocity.Length());
            //        float k = cos * bullets[i].Velocity.Length() / w.Velocity.Length();
            //        Vector2 V1 = new Vector2(w.Velocity.X * k, w.Velocity.Y * k);
            //        Vector2 V2 = new Vector2(); V2 = bullets[i].Velocity - V1;
            //        bullets[i].Velocity = V1 - V2;
            //        while (bullets[i].Intersects(w))
            //        {
            //            bullets[i].Pos += bullets[i].Velocity;
            //            bullets[i].CrRecV2();
            //        }
            //        bulletsHero.Add(bullets[i]);
            //        bullets.Remove(bullets[i]);

            //        i--;

            //    }

            //}
            //world.Intersects(); world.ToKill();

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
           // spriteBatch.Draw(texture, rectangle, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, (float)Math.Atan2(Velocity.Y, Velocity.X) + (float)Math.PI, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 1f);
            spriteBatch.Draw(texture, rec.r, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, (float)Math.Atan2(direction.Y, direction.X) , new Vector2(texture.Width * rec.kx, texture.Height * rec.ky), SpriteEffects.None, 1f);
            spriteBatch.Draw(blasterTex, new Rectangle(rec.r.X, rec.r.Y, 5, 5),new Rectangle(0, 0, blasterTex.Width, blasterTex.Height), Color.Red, 0f, new Vector2(texture.Width * rec.kx, texture.Height * rec.ky), SpriteEffects.None, 1.5f);

        }

    }
}
