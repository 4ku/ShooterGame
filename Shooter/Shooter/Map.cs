using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Shooter.Game1;

namespace Shooter
{

    public class Map
    {
        //public int width;
        //public int height;
        public int[,] walls;
        //public Vector2 startPosition;


        public Map(int[,] walls)
        {
            this.walls = walls;           
            //this.height = ;
            //this.width = width;
           // this.startPosition = new Vector2(height / 2, width / 2);            
        }
        public Map()
        {

        }


      /*  public int width;
        public int height;
        public static Vector2 StartPos;
        List<Entity> objects;

        public Map()
        {

        }
        public Map(int[,] arr, int height, int width)
        {
            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    objects.Add(Wall(i, j));
            this.height = height; this.width = width;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Entity o in objects)
                o.Draw();
        }*/
        public void LoadMap(World world)
        {
            for (int i = 0; i < walls.GetLength(0); i++)
                for (int j = 0; j < walls.GetLength(1); j++)
                    if (walls[i, j] == 1)
                        world.entities.Add(new Wall(j, i));
        }
        public void RemoveMap(World world)
        {
            for (int i = 0; i < walls.GetLength(0); i++)
                for (int j = 0; j < walls.GetLength(1); j++)
                    if (walls[i, j] == 1)
                        world.entities.Remove(new Wall(j, i));
        }
        public void MapGener(int height, int width)
        {
            int[,] ar = new int[height, width];
            for (int i = 0; i < height; i++) { ar[i, 0] = 1; ar[i, width - 1] = 1; }
            for (int i = 0; i < width; i++) { ar[0, i] = 1; ar[height-1,i] = 1; }
            int CX = 1;  int CY = 0;
            Random R = new Random();
            while (CY < height)
            {
                int r = R.Next(-1, 2);
                if (CX + r >= 0 && CX + r < width/3) CX += r;
                ar[CY, CX] = 1;
                CY++;
            }
            CY--;
            while (CX < width)
            {
                int r = R.Next(-1, 2);
                if (CY + r >= height*2/3 && CY + r < height) CY += r;
                ar[CY, CX] = 1;
                CX++;
            } CX--;
            while (CY >=0)
            {
                int r = R.Next(-1, 2);
                if (CX + r <width && CX + r > width*2 / 3) CX += r;
                ar[CY, CX] = 1;
                CY--;
            }CY++;
            while (CX >=0)
            {
                int r = R.Next(-1, 2);
                if (CY + r >= 0 && CY + r < height/3) CY += r;
                ar[CY, CX] = 1;
                CX--;
            }CX++;

            for (int i = 0; i < height; i++) { ar[i, width / 2] = 0; ar[i, width / 2 +1] = 0; }
            
            this.walls = ar;
        }

    }
}
