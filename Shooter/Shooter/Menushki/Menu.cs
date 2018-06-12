using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using static Shooter.Game1;
using Shooter;
using static Shooter.TexturePack;
using static Shooter.Monster;
namespace Shooter
{
   public abstract class Menu
    {
        public abstract void Update(Game1 game);
        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
