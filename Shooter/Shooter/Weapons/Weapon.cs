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
    public abstract class Weapon
    {
        public bool isEnemy;
        public abstract void Taken();
        public abstract void Shoot(World world, Vector2 startPosition, Vector2 direction);
        public abstract void Update(GameTime gameTime);

    }
}
