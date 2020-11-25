using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace new_Game
{
    public abstract class GameObject
    {
        public PointF WorldPosition = new PointF();
        public Image Sprite;
        public float Angle = 0;

        public abstract void Update();

        public void Draw(PaintEventArgs e)
        {
            Point screenPosition = Camera.WorldToScreen(WorldPosition);
            
            GraphicsState transState = e.Graphics.Save();
            
            e.Graphics.TranslateTransform(screenPosition.X, screenPosition.Y);
            e.Graphics.RotateTransform(Angle);
            e.Graphics.TranslateTransform(-Sprite.Width / 2f, -Sprite.Height / 2f);
            e.Graphics.DrawImage(Sprite, new Point(0,0));
            
            e.Graphics.Restore(transState);
        }
    }
}