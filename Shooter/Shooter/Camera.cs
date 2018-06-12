using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Shooter.World;
using static Shooter.Game1;

namespace Shooter
{
    class Camera
    {
        public Matrix transform;
        Viewport view;
        Vector2 screenTopLeft;
        public Camera(Viewport view)
        {
            this.view = view;
        }
        public void Update(GameTime gameTime, Vector2 screenCentre)
        {
            screenTopLeft = screenCentre + new Vector2(-WinWIDTH / 2, -WinHEIGHT / 2);
            transform = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                Matrix.CreateTranslation(new Vector3(-screenTopLeft.X, -screenTopLeft.Y, 0));
        }
    }
}
