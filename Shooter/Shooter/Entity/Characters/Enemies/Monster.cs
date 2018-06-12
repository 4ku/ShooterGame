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
    public class Monster : Enemy
    {
        public int width=50;
        public int height=50;
        public Vector2 position;
        public Texture2D texture = monsterTex;
        // public int health;
        public float speed;
        public Weapon gun;
        public static float elapsedSpawnTime = 0;
        public static float reloadSpawn = 2000;
        public float elapsedReloadTime = 0;
        public float reloadGun = 1500;
        Vector2 move;


        public Monster( Vector2 StartPos)
        {
            position = StartPos;
            speed = 7f;
            health = 1;
            rectangle = new RectangleV3(new Vector2((int)position.X, (int)position.Y), width, height);
            gun = new Lightsaber();
            gun.isEnemy = true;
        }
     /*   ~Monster()
        {
            if(gun is Lightsaber)
            {
              
            }
        }*/

        public static void RandomSpawn(World world, GameTime gameTime)
        {
            elapsedSpawnTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedSpawnTime > reloadSpawn)
            {
                elapsedSpawnTime = 0f;

                int min = 400; int max = 1200;
                Random rand = new Random();
                int x; int y;

                x = rand.Next(-max, max);
                y = rand.Next(-max, max);
                RectangleV3 rec = new RectangleV3(new Vector2(x, y) + world.Hero.position, 50, 50);
                //Rectangle rec = new Rectangle(x, y, width, height);

                while (IntersectsWithCharAndWalls(rec, world.entities)
                    || Math.Abs(y)* Math.Abs(y) + Math.Abs(x) * Math.Abs(x) < min*min)
                {
                    x = rand.Next(-max, max);
                    y = rand.Next(-max, max);
                    rec = new RectangleV3(new Vector2(x, y) + world.Hero.position, 50, 50);
                }

                Monster mon = new Monster(new Vector2(x, y) + world.Hero.position);
               mon.gun= crGun(world);
                mon.gun.isEnemy = true;
                world.entities.Add(mon);
            }
        }
        static Weapon crGun(World world)
        {
            switch (world.Hero.numCurrentGun)
            {
               case 0: return new Pistol();
                    break;
                case 1: return new Blaster();
                    break;
                case 2:  return new Lightsaber();
                    break;
                case 3: return new Rocket();
                    break;

                default: return null;
            }
        }
        static bool IntersectsWithCharAndWalls(RectangleV3 r, List<Entity> list)
        {
            foreach (Entity e in list)
            {
                if (e is Wall)
                {
                    Wall wall = (Wall)e;
                    if (r.Intersect(wall.rectangle))
                        return true;
                }
                else if (e is Character)
                {
                    Character ch = (Character)e;
                    if (r.Intersect(ch.rectangle)) return true;
                }
            }
            return false;
        }
        public void Move(World world)
        {
            move = world.Hero.position - position;
            move.Normalize();
            move *= this.speed;
        }
        public void Check(World world)
        {
            bool flx = false;
            bool fly = false;
            RectangleV3 recX = new RectangleV3(new Vector2((int)(position.X + move.X), (int)(position.Y)), width, height);
            RectangleV3 recY = new RectangleV3(new Vector2((int)(position.X), (int)(position.Y + move.Y)), width, height);

            foreach (Entity e in world.entities)
            {
                if (!e.Equals(this))
                {
                    if (e is Wall)
                    {
                        Wall w = (Wall)e;
                        //if (Intersects(recX, w.rectangle))
                        if (w.rectangle.Intersect(recX))
                            flx = true;
                        if (w.rectangle.Intersect(recY))
                            fly = true;
                    }
                    else if (e is Character)
                    {
                        Character ch = (Character)e;
                        if (ch.rectangle.Intersect(recX))
                            flx = true;
                        if (ch.rectangle.Intersect(recY))
                            fly = true;
                    }

                }
            }
            if (!flx)
            {
                //rectangle.Move(new Vector2(move.X, 0));
                position.X += move.X;
            }
            if (!fly)
            {
                //rectangle.Move(new Vector2(0, move.Y));
                position.Y += move.Y;
            }
            rectangle.r.X = (int)position.X;
            rectangle.r.Y = (int)position.Y;
        }

        public void Shoot(World world, GameTime gameTime)
        {
           elapsedReloadTime += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsedReloadTime > reloadGun)
            {
                elapsedReloadTime = 0f;
                gun.Shoot(world, position, world.Hero.position - this.position);

            }

        }
        public override void Update(World world, GameTime gameTime)
        {
            Move(world);
            Check(world);
            Shoot(world, gameTime);
            gun.Update(gameTime);
            if (health <= 0)
                world.ToKill.Add(this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
           // spriteBatch.Draw(texture, rectangle, new Rectangle(0, 0, texture.Width, texture.Height), Color.White);
            spriteBatch.Draw(texture, rectangle.r, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, (float)Math.Atan2(rectangle.direction.Y, rectangle.direction.X), new Vector2(texture.Width * rectangle.kx, texture.Height * rectangle.ky), SpriteEffects.None, 1f);
        }

    }
}
