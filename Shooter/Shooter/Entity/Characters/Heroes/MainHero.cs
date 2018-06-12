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
    public class MainHero : Character
    {
        public int width;
        public int height;
        public Vector2 position;
        public Texture2D texture;
        //public int health;
        public float speed;

        public int numCurrentGun = 0;
        public Weapon[] guns;

        public Vector2 move;
        KeyboardState keyboardState;
        KeyboardState keyboardStatePast;
        public List<Ability> abilities;
       
        public MainHero(Texture2D Texture, Vector2 StartPos)
        {
          
            keyboardState = keyboardStatePast = new KeyboardState();
            width = 57;
            height =57;
            position = StartPos;
            texture = Texture;
            speed = 10f;
            health = 5000;
            //rectangle = new Rectangle((int)StartPos.X, (int)StartPos.Y, Width, Height);
            rectangle = new RectangleV3(StartPos, width, height);
            guns = new Weapon[4];
            guns[0] = new Pistol();
            //guns[0].isEnemy = false;
            guns[1] = new Blaster();
           // guns[1].isEnemy = false;
            guns[2] = new Lightsaber();
           // guns[2].isEnemy = false;
            guns[3] = new Rocket();
            //  guns[3].isEnemy = false;
            //guns[1] = new Blaster();
            //guns[2] = new Lightsaber();
            abilities = new List<Ability>() ;
            //abilities.Add(new Standart(this));
            
        }

        public void MoveVector()
        {
            move = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.W))
                move += new Vector2(0, -1);
            if (keyboardState.IsKeyDown(Keys.A))
                move += new Vector2(-1, 0);
            if (keyboardState.IsKeyDown(Keys.D))
                move += new Vector2(1, 0);
            if (keyboardState.IsKeyDown(Keys.S))
                move += new Vector2(0, 1);
            if (!move.Equals(Vector2.Zero))
            {
                move.Normalize();
                move *= speed;
            }

        }
       

        public override void Update(World world, GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
           
            MoveVector();
          


            if (mouseState.LeftButton == ButtonState.Pressed)// && mouseStatePast.LeftButton == ButtonState.Released)
            {
               // int x = world.game.graphics.GraphicsDevice.Viewport.X; int y = world.game.graphics.GraphicsDevice.Viewport.Y;
                Vector2 direction = new Vector2(mouseState.Position.X, mouseState.Position.Y) - new Vector2(WinWIDTH / 2, WinHEIGHT / 2);
                //direction.Normalize();
                guns[numCurrentGun].Shoot(world, position, direction);
            }
            guns[numCurrentGun].Update(gameTime);

            if (keyboardState.IsKeyDown(Keys.Space) && keyboardStatePast.IsKeyUp(Keys.Space))
            {
                numCurrentGun = (numCurrentGun + 1) % guns.Length;
                guns[numCurrentGun].Taken();
            }

            if (health <= 0)
            {
                world.ToKill.Add(this);
                
            }

            //сохранение предыдущего состояния
            keyboardStatePast = keyboardState;
            mouseStatePast = mouseState;
        }



        public override void Draw(SpriteBatch spriteBatch)
        {
          // spriteBatch.Draw(texture, rectangle.r, new Rectangle(0, 0, texture.Width, texture.Height), Color.CornflowerBlue);
          
           
            spriteBatch.DrawString(font, Convert.ToString(health), position - new Vector2(width * rectangle.kx, height * rectangle.ky), Color.Red,0,Vector2.Zero,1f,SpriteEffects.None,2f);
         
        }

    }
}
