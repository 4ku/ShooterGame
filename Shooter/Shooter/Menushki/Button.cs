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
    public class Button 
    {
        public Texture2D active;
        public Texture2D passive;
        public Texture2D texture;
        public Rectangle rectangle;
        bool isAct;

        public Button(Rectangle rectangle, Texture2D active, Texture2D passive)
        {
            this.active = active;
            this.passive = passive;
            texture = passive;
            this.rectangle = rectangle;
        }

        public void CheckCursor()
        {
           mouseState = Mouse.GetState();

            if (rectangle.Contains(mouseState.Position))
            {
                texture = active; isAct = true;
            }
            else { texture = passive; isAct = false; }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
            if (isAct) spriteBatch.Draw(tick, new Rectangle(rectangle.X - 85, rectangle.Y, 80, rectangle.Height), Color.White);
        }

       
    }
}
