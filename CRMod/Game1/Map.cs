using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CRMod.Game1;
namespace CRMod
{

    public class Map
    {
        public int[,] ar;
        public int width; public int height;
        public Map()
        {

        }
        public Map(int[,] ar, int height, int width)
        {
            this.ar = ar; this.height = height; this.width = width;
        }
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (ar[i, j] == 0) spriteBatch.Draw(metal, new Rectangle(j * CellWIDTH, i * CellHEIGHT, CellWIDTH, CellHEIGHT), new Rectangle(0, 0, metal.Width, metal.Height), Color.White);
                    else if (ar[i, j] == 1) spriteBatch.Draw(iron, new Rectangle(j * CellWIDTH, i * CellHEIGHT, CellWIDTH, CellHEIGHT), new Rectangle(0, 0, iron.Width, iron.Height), Color.White);
                }
            }

        }

        public void MapGener(int height, int width)
        {
            int[,] ar = new int[height, width];
            this.width = width; this.height = height;
            for (int i = 0; i < height; i++) { ar[i, 0] = 1; ar[i, width - 1] = 1; }
            for (int i = 0; i < width; i++) { ar[0, i] = 1; ar[height - 1, i] = 1; }
            int CX = 1; int CY = 0;
            Random R = new Random();
            while (CY < height)
            {
                int r = R.Next(-1, 2);
                if (CX + r >= 0 && CX + r < width / 3) CX += r;
                ar[CY, CX] = 1;
                CY++;
            }
            CY--;
            while (CX < width)
            {
                int r = R.Next(-1, 2);
                if (CY + r >= height * 2 / 3 && CY + r < height) CY += r;
                ar[CY, CX] = 1;
                CX++;
            }
            CX--;
            while (CY >= 0)
            {
                int r = R.Next(-1, 2);
                if (CX + r < width && CX + r > width * 2 / 3) CX += r;
                ar[CY, CX] = 1;
                CY--;
            }
            CY++;
            while (CX >= 0)
            {
                int r = R.Next(-1, 2);
                if (CY + r >= 0 && CY + r < height / 3) CY += r;
                ar[CY, CX] = 1;
                CX--;
            }
            CX++;
            this.ar = ar;
        }

    }
}
