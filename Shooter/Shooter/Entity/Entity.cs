using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shooter.Game1;
//using Shooter.Characters;
namespace Shooter
{
    public abstract class Entity
    {
        //public Entity(int width, int height)
        //{
        //    this.width = width;
        //    this.height = height;
        //    rectangle = new Rectangle(0, 0, width, height);
        //}
        //public int health;
        //public float speed;

        //public string name;
        public abstract void Update(World world, GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

        /*
        public int width;
        public int height;

        public Rectangle rectangle;
        private Vector2 position;


        

        public Vector2 Pos
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                rectangle.X = (int)value.X;
                rectangle.Y = (int)value.Y;
            }
        }
        */



    }
}
