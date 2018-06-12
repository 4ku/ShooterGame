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

namespace Shooter
{
   public abstract class Ability
    {
       
        public abstract void BeforeCheck(World world, GameTime gameTime);
        public abstract void InCheck(World world, GameTime gameTime,Entity e);
        public abstract void AfterCheck(World world, GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
