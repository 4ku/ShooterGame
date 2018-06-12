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
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
namespace Shooter
{
    public class Pistol : Weapon
    {
        /*
        public float Reload = 50;
        public int width;
        public int height;
        public Rectangle rectangle;
        public RectangleV2 rec2;
        public Vector2 Velocity;
        public Vector2 startpos;
        public Vector2 Pos;
        Texture2D texture = bulletTex;
        public float speed = 15f;
        public float ellapsedClickTime;
        public float exTime;
        public float curExTime;
        public MouseState mspast;
        */
        public float physicalFrequencyShooting = 100;
        public float ellapsedTimeFromLastShoot = 0;
        public override void Shoot(World world, Vector2 startPosition, Vector2 direction)
        {
            //if (ellapsedTimeFromLastShoot > physicalFrequencyShooting)
            if ((mouseStatePast.LeftButton == ButtonState.Released || isEnemy) && ellapsedTimeFromLastShoot > physicalFrequencyShooting)
            {
                //    if (!isEnemy) MediaPlayer.Play(piu);
                if (!isEnemy) piu.Play(0.5f, 0, 0);
                world.ToAdd.Add(new BulletFire(startPosition, direction, isEnemy));
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
