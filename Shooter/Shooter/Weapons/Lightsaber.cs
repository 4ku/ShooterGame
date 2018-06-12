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
    public class Lightsaber :Weapon
    {

        public bool created;
        //public Entity en;
        LightsaberFire saber;
        public override void Shoot(World world, Vector2 startPosition, Vector2 direction)
        {
            if (created == false && (mouseStatePast.LeftButton == ButtonState.Released || isEnemy))
            {
                created = true;
                direction.Normalize();
                if (!isEnemy) saberSound.Play();
                float angle = (float)Math.Acos(direction.X);
                if (direction.Y < 0) angle*= -1;

                Vector2 v = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
                v *= (float)Math.Sqrt(world.Hero.width * world.Hero.width / 4 + world.Hero.height * world.Hero.height / 4);
                startPosition = startPosition + v;
                //direction = new Vector2(mouseState.Position.X + (-WinWIDTH / 2) - v.X, mouseState.Position.Y + (-WinHEIGHT / 2) - v.Y);

                saber = new LightsaberFire(startPosition, direction, isEnemy, this);
                saber.angle = angle;
                world.ToAdd.Add(saber);
            } else if(created == true)
            {
            //    world.ToKill.Add(saber);
                Vector2 v = new Vector2((float)Math.Cos(saber.angle), (float)Math.Sin(saber.angle));
                v *= (float)Math.Sqrt(world.Hero.width * world.Hero.width / 4 + world.Hero.height * world.Hero.height / 4);
                saber.position = startPosition + v;
                // saber.rec.r.X = (int)saber.position.X; saber.rec.r.Y = (int)saber.position.Y;
                direction -= v; //new Vector2(mouseState.Position.X + (-WinWIDTH / 2) - v.X, mouseState.Position.Y + (-WinHEIGHT / 2) - v.Y);
                saber.rec = new RectangleV3(saber.position, 0.5f, 0.5f, direction, saber.width, saber.height);
                saber.direction = direction ;
               // world.ToAdd.Add(saber);
            }

           /*  float angle = (float)Math.Acos(direction.X);
            if (direction.Y < 0) angle *= -1;

            Vector2 v = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            v *= (float)Math.Sqrt(world.Hero.width * world.Hero.width / 4 + world.Hero.height * world.Hero.height / 4);
            startPosition += v;
            //direction = new Vector2(mouseState.Position.X + (-WinWIDTH / 2) - v.X, mouseState.Position.Y + (-WinHEIGHT / 2) - v.Y);
            LightsaberFire l = new LightsaberFire(startPosition, direction, isEnemy, this);
            l.angle = angle;
            world.ToAdd.Add(l);*/
        }

        public override void Taken()
        {
            if (!isEnemy) saberSound.Play();
        }

        public override void Update(GameTime gameTime)
        {
          
        }
        /*
        public int width;
        public int height;
        public Rectangle rectangle;
        public RectangleV2 rec2;
        public Vector2 Velocity;
        public Vector2 startpos;
        public Vector2 Pos;
        Texture2D texture = blasterTex;
        MouseState mspast;
       
        public LightsaberFire()
        {
            mspast = Mouse.GetState();
        }
        public LightsaberFire(int width, int height, Vector2 startpos, Vector2 endpos)
        {
          
            this.width = width;
            this.height = height;
            this.startpos = startpos;
            Pos = startpos;
            rectangle = new Rectangle((int)startpos.X, (int)startpos.Y, width, height);
             Velocity = new Vector2(endpos.X-startpos.X , endpos.Y-startpos.Y);
            rec2 = new RectangleV2(Velocity, width, height, startpos);
            damage = 1;
        }
        public override Fire New(int width, int height, Vector2 startpos, Vector2 endpos)
        {
           return new LightsaberFire(width,  height, startpos,  endpos);
        }
        public override void Shoot(World world, GameTime gameTime, Vector2 startPos)
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
           
        }

    


        public override void Update(World world, GameTime gameTime)
        {
                 MouseState ms = Mouse.GetState();
                if (ms.LeftButton == ButtonState.Released) world.ToKill.Add(this); 
           

                Pos = world.Hero.position;
                rectangle.X = (int)Pos.X; rectangle.Y = (int)Pos.Y;
                rec2 = new RectangleV2(Velocity, width, height, Pos);
                Velocity = new Vector2(ms.Position.X + (-WinWIDTH / 2), ms.Position.Y + (-WinHEIGHT / 2));

                foreach (Entity e in world.entities)
                {
                    if (e is Wall)
                    {
                        Wall wall = (Wall)e;
                        if (Intersects(rec2, wall.rectangle)) world.ToKill.Add(this);
                    }
                    else if(e is BulletFire)
                    {
                    BulletFire bul = (BulletFire)e;

                    if (Intersects(rec2, bul.rec2))
                    {
                        float cos = (Velocity.X * bul.direction.X + Velocity.Y * bul.direction.Y) / (bul.direction.Length() * Velocity.Length());
                        float k = cos * bul.direction.Length() / Velocity.Length();
                        Vector2 V1 = new Vector2(Velocity.X * k, Velocity.Y * k);
                        Vector2 V2 = new Vector2(); V2 = bul.direction - V1;
                        bul.direction = V1 - V2;
                        while (Intersects(rec2,bul.rec2))
                        {
                            bul.position += bul.direction;
                            bul.rec2= new RectangleV2(bul.direction, bul.width, bul.height, bul.position);
                        }
                        bul.isEn = false;



                    }


                }
                    else
                    
                    
                    if (isEn)
                    {
                        if (e is MainHero)
                        {
                            MainHero h = (MainHero)e;
                            if (Intersects(rec2, h.rectangle))
                            {
                                h.health -= damage;
                                //world.ToKill.Add(this);
                            }
                        }
                    }
                    else if(!isEn)
                    {
                        if (e is Enemy)
                        {
                            Enemy en = (Enemy)e;
                            if (Intersects(rec2, en.rectangle))
                            {
                                en.health -= damage;
                                //world.ToKill.Add(this);
                            }
                        }
                    }
                }


                


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
            spriteBatch.Draw(texture, rectangle, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, (float)Math.Atan2(Velocity.Y, Velocity.X) + (float)Math.PI, new Vector2(texture.Width / 2, texture.Height / 2), SpriteEffects.None, 1f);

        }
        */
    }
}
