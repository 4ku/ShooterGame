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
    public class BulletFire : Fire
    {
        Texture2D texture = bulletTex;
        public int width = 60;
        public int height = 15;
        public float speed = 15f;

        public float currentExistingTime; //время существования
        public float existingTime = 5000; //положенное время существования
        public BulletFire(Vector2 startPosition, Vector2 direction, bool isEnemy)
        {
            this.damage = 1;
            this.position = startPosition;
            this.direction = direction;
            this.direction.Normalize();
            this.currentExistingTime = 0;
            rec = new RectangleV3(startPosition, 0.5f,0.5f, direction, width, height);
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
                            world.ToKill.Add(this);
                }
                else if (isEnemy)
                {
                    if (e is MainHero && isEnemy)
                    {
                        MainHero h = (MainHero)e;
                      //  if (Intersects(rec2, h.rectangle))
                        if(rec.Intersect(h.rectangle))
                        {
                            h.health -= damage; damageHeroSound.Play();
                            world.ToKill.Add(this);
                            damageHeroSound.Play(0.8f, 0f, 0f);
                            
                        }
                    }
                }
                else
                {
                    if (e is Enemy && !isEnemy)
                    {
                        Enemy en = (Enemy)e;
                       // if (Intersects(rec2, en.rectangle))
                       if(rec.Intersect(en.rectangle))
                        {
                            en.health -= damage;
                            world.ToKill.Add(this);
                            damageMonSound.Play(1f,0f,0f);
                        }
                    }
                }
            }

            position += direction * speed;
            rec.r.X = (int) position.X; rec.r.Y = (int)position.Y;
          

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
            spriteBatch.Draw(texture, rec.r, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, (float)Math.Atan2(direction.Y, direction.X) + (float)Math.PI, new Vector2(texture.Width* rec.kx, texture.Height*rec.ky), SpriteEffects.None, 1f);
        }
    }

}
