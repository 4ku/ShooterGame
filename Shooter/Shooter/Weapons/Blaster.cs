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
    public class Blaster: Weapon
    {
        /*public float reload = 800;
        public int width;
        public int height;
        public Rectangle rectangle;
        public RectangleV2 rec2;
        public Vector2 velocity;
        public Vector2 startpos;
        public Vector2 Pos;
        Texture2D texture = blasterTex;
        public float speed = 70f;
        public float ellapsedClickTime;
        public float exTime;
        public float curExTime;
        public MouseState mspast;
        float mrel = 16;
        float mrelc = 0;
        int fl = 0;
        public override void shoot()
        {

        }
        
        */
        public float physicalFrequencyShooting = 800;
        public float ellapsedTimeFromLastShoot = 800;
        public override void Shoot(World world, Vector2 startPosition, Vector2 direction)
        {
            //if (ellapsedTimeFromLastShoot > physicalFrequencyShooting)
            if((mouseStatePast.LeftButton == ButtonState.Released || isEnemy) && ellapsedTimeFromLastShoot > physicalFrequencyShooting)
            {
                if (!isEnemy) blasterSound.Play();
                BlasterFire b = new BlasterFire(startPosition, direction, isEnemy);
                b.fl = 1;
                world.ToAdd.Add(b);
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
