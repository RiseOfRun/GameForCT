using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace new_Game
{
    class Cell
    {
        private Point[] points;

        public void Draw(PaintEventArgs e)
        {
            Pen p = new Pen(Color.GreenYellow);
            e.Graphics.DrawPolygon(p, points);
        }

        public void Fill(PaintEventArgs e)
        {
            Brush b = new SolidBrush(Color.Red);
            e.Graphics.FillPolygon(b, points);
        }
        
        public Cell(Point[] p)
        {
            points = p;
        }
    }
}