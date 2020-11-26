using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace new_Game
{
    class GameField
    {
        private static GameField instance;
        public static GameField MyGameField
        {
            get
            {
                if (instance==null)
                {
                    instance = new GameField(10,10);
                }

                return instance;
            }
        }
        
        public bool[] openCells;
        public List<PointF> cells;
        private int[] weights;
        private int width;
        private int height;

        public PointF GetNearestCell(PointF b)
        {
            PointF roundedPoint = new PointF(
                (float) Math.Round(b.X, 0),
                (float) Math.Round(b.Y, 0));
            return roundedPoint;
        }
        public GameField(int width, int height)
        {
            this.width = width;
            this.height = height;
            cells = new List<PointF>(width*height);
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cells.Add(new PointF(j,i));
                }
            }

            openCells = Enumerable.Repeat(true, cells.Count).ToArray();
            weights = Enumerable.Repeat(1, cells.Count).ToArray();
            Random r = new Random();
            int count = r.Next(4, width * height - width * height / 4);
            for (int i = 0; i<count; i++)
            {
                openCells[r.Next(2,width*height-2)] = false;
            }
            
        }

        public int GCost(int start, int target)
        {
            if (Math.Abs(start - target) != 1 && Math.Abs(start - target) != width)
            {
                return 14*weights[target];
            }
            return 10*weights[target];
        }

        public int HCost(int start, int target)
        {
            int[] sCord =
            {
                start / width,
                start % width
            };

            int[] tCord =
            {
                target / width,
                target % width
            };
            return (Math.Abs(tCord[0]-sCord[0])+Math.Abs(tCord[1]-sCord[1]))*10;
        }
    

        public List<int> GetAllAccidentCells(int n)
        {
            List<int> aCells = new List<int>();
            if (n==13)
            {
                int k = 5;
            }
            int i = n / width;
            int j = n % width;
            if (j!=width-1) aCells.Add(width*i+j+1);
            if (j!=0) aCells.Add(width*i+j-1);
            if (i!=0) aCells.Add(width*(i-1)+j);
            if (i!=height-1) aCells.Add(width*(i+1)+j);
            if (j!=width-1&&i!=height-1) aCells.Add((i+1)*width+j+1);//
            if (j!=width-1&& i!=0) aCells.Add((i-1)*width+j+1);
            if (j!=0&&i!=0) aCells.Add(j-1+(i-1)*width);
            if (j!=0&&i!=height-1) aCells.Add(j-1+(i+1)*width);
               
            
            return aCells.Where(x => openCells[x]).ToList();
        }
        

        public void Draw(PaintEventArgs e)
        {
            foreach (var cell in cells)
            {
                Pen p = new Pen(Color.Cornsilk);
                Point screenPos = Camera.WorldToScreen(cell);
                if (!openCells[cells.IndexOf(cell)])
                {
                    Brush b = new SolidBrush(Color.Black);
                    e.Graphics.FillRectangle(b,screenPos.X-Camera.Shift, screenPos.Y-Camera.Shift,Camera.Scale,Camera.Scale);
                }
                e.Graphics.DrawRectangle(p,screenPos.X-Camera.Shift, screenPos.Y-Camera.Shift,Camera.Scale,Camera.Scale);
            }
        }
        
        

    }
}