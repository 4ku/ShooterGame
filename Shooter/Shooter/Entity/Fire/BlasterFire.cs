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


    public class BlasterFire: Fire
    {
        //public float reload = 800;
        public static int width=46;
        public static int height=8;
       // public Rectangle rectangle;
        public Vector2 startPosition;
       // Texture2D texture = blasterTex;
        public static float speed = 45f;
       // public float ellapsedClickTime;
        public static float existingTime = 1000;
        public float currentExistingTime;
     
        static float mrel = -1;
        float mrelc = 0;
        public int fl = 0;
      
        public BlasterFire(Vector2 startPosition, Vector2 direction, bool isEnemy)
        {
            damage = 1;
            this.startPosition = startPosition;
            this.position = startPosition;
            this.direction = direction;
            this.direction.Normalize();
            this.currentExistingTime = 0;
            rec = new RectangleV3(startPosition, 0.5f, 0.5f, direction, width, height);
            this.isEnemy = isEnemy;
            

        }
        //public override Fire New(int width, int height, Vector2 startpos, Vector2 endpos)
        //{
        //    return new BlasterFire(startpos, endpos, true);
        //}
        //public override void Shoot(World world, GameTime gameTime, Vector2 startPos)
        //{
        //    MouseState ms = Mouse.GetState();
        //    ellapsedClickTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

        //    if (ms.LeftButton == ButtonState.Pressed && mouseStatePast.LeftButton == ButtonState.Released && ellapsedClickTime > reload)
        //    {
        //        ellapsedClickTime = 0; Vector2 endPos = new Vector2((int)startPos.X + (-WinWIDTH / 2) + ms.Position.X, startPos.Y + ms.Position.Y + (-WinHEIGHT / 2));
        //        BlasterFire bul = new BlasterFire(130, 15, startPos, endPos);
        //        bul.isEn = false;
        //        world.ToAdd.Add(bul);
        //    }
        //    mouseStatePast = ms;

        //}
        public object Clone()
        {
            // BlasterFire b = new BlasterFire(startPosition, direction, isEnemy);
            BlasterFire b = (BlasterFire) MemberwiseClone();
            b.rec = new RectangleV3(new Vector2(rec.r.X, rec.r.Y), rec.kx, rec.ky, rec.direction, rec.r.Width, rec.r.Height);
            return b;

        }
       
        public override void Update(World world, GameTime gameTime)
        {
            foreach (Entity e in world.entities)
            {
                if (e is Wall)
                {
                    Wall wall = (Wall)e;
                    if (rec.Intersect(wall.rectangle))
                        world.ToKill.Add(this);
                }
                else if (isEnemy)
                {
                    if (e is MainHero)
                    {
                        MainHero h = (MainHero)e;
                        if (rec.Intersect(h.rectangle))
                        {
                            h.health -= damage;
                            damageHeroSound.Play(0.8f, 0f, 0f);
                            //world.ToKill.Add(this);
                        }
                    }
                }
                else
                {
                    if (e is Enemy)
                    {
                        Enemy en = (Enemy)e;
                        if (rec.Intersect(en.rectangle))
                        {
                            en.health -= damage;
                            damageMonSound.Play(0.8f, 0f, 0f);
                            //world.ToKill.Add(this);
                        }
                    }
                }
            }


            position += direction*speed;
            currentExistingTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            rec.r.X = (int)position.X; rec.r.Y = (int)position.Y;

            if (currentExistingTime >= existingTime)
            {
                world.ToKill.Add(this);
            }
            //else
            //{
            //    rec2 = new RectangleV2(velocity, width, height, position);
            //    rectangle.X = (int)position.X;
            //    rectangle.Y = (int)position.Y;
            //}

            if (fl == 1)
            {
                mrelc += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (currentExistingTime < existingTime && mrelc > mrel)
                {
                    
                    mrelc = 0;
                    BlasterFire bl = (BlasterFire)Clone();
                    fl = 0;
                    bl.position = startPosition;                      
                    bl.rec.r.X = (int)startPosition.X; bl.rec.r.Y = (int)startPosition.Y;    //КЛОНИРОВАТЬ!!!!
                    world.ToAdd.Add(bl);

                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(blasterTex, new Rectangle((int) position.X,(int) position.Y,width,height), new Rectangle(0, 0, blasterTex.Width, blasterTex.Height), Color.White, (float)Math.Atan2(direction.Y, direction.X) + (float)Math.PI, new Vector2(blasterTex.Width * rec.kx, blasterTex.Height * rec.ky), SpriteEffects.None, 1f);

        }

    }
}
