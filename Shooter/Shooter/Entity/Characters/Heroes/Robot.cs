using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Shooter.World;
using static Shooter.Game1;
using static Shooter.SomeGeom;
using static Shooter.TexturePack;
using Microsoft.Xna.Framework.Input;

namespace Shooter
{
    public class Robot : MainHero
    {

        public Robot(Texture2D Texture, Vector2 StartPos): base(Texture, StartPos)
        {
            abilities.Add(new Standart(this));

        }
        public void Move()
        {
            position.X += move.X;
            position.Y += move.Y;
            rectangle.r.X = (int)position.X;
            rectangle.r.Y = (int)position.Y;
        }

        public void Check(World world,GameTime gameTime)
        {
            foreach(Ability a in abilities) a.BeforeCheck(world,gameTime);
            foreach (Entity e in world.entities)
            {
                foreach (Ability a in abilities) a.InCheck(world, gameTime,e);
            }
            foreach (Ability a in abilities) a.AfterCheck(world, gameTime);
          
        }
        public override void Update(World world, GameTime gameTime)
        {
            base.Update(world, gameTime);
            Check(world,gameTime);
             Move();
        }
        public override void Draw(SpriteBatch spriteBatch) 
        {
            base.Draw(spriteBatch);
            foreach (Ability a in abilities) a.Draw(spriteBatch);
        }

    }
}
