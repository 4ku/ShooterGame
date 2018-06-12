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

    public class World
    {
        public readonly Game1 game;
        public List<Entity> entities;
        public List<Entity> ToKill;
        public List<Entity> ToAdd;
        Camera camera;
        KeyboardState kspast;
        public MainHero Hero;
        public Map map;
        public World(Game1 game)
        {
            this.game = game;
            kspast = Keyboard.GetState();
            entities = new List<Entity>();
            ToKill = new List<Entity>();
            ToAdd = new List<Entity>();
            camera = new Camera(game.GraphicsDevice.Viewport);
            new TexturePack(game); //проинициализировали все текстуры
            Hero = new Robot(robot, new Vector2(WinWIDTH/2, WinHEIGHT/2));
            entities.Add(Hero);
        }

      /*  public virtual void Initialize(Map map)
        {
            for (int i = 0; i < map.walls.GetLength(0); i++)
                for (int j = 0; j < map.walls.GetLength(1); j++)
                    if (map.walls[i, j] == 1)
                        entities.Add(new Wall(j, i));
            entities.Add(Hero);

        }*/

           


        public void Update(GameTime gameTime)
        {
           
            foreach (var e in entities)
              e.Update(this, gameTime);

            foreach (var e in ToKill)
                entities.Remove(e);
            ToKill.Clear();

            foreach (var e in ToAdd)
                entities.Add(e);
            ToAdd.Clear();

           RandomSpawn(this, gameTime);

            camera.Update(gameTime, Hero.position);

            KeyboardState ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Escape) && kspast.IsKeyUp(Keys.Escape))
            {
                isGame = false;
                menu = new Pause(Hero.position-new Vector2(WinWIDTH/2,WinHEIGHT/2));
            }
            kspast = ks;
        }


        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, null, camera.transform);
            foreach (var e in entities)
                e.Draw(spriteBatch);

            spriteBatch.Draw(blasterTex, new Rectangle(-5, -5, 10, 10), Color.Red);
            
            spriteBatch.End();

        }

    }
}
