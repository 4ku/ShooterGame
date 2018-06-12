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
    public abstract class Fire : Entity
    {
        
        // string name;

        //  MapObject Case;
        //  int reg;
          public int damage;
        public bool isEnemy;
        public RectangleV3 rec;
        public Vector2 position;
        public Vector2 direction;
        public float speed;


    }

}
