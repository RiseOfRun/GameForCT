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
        public bool Alive = true;

        public abstract void Update();

        public abstract void Spawn(PointF pos);

        public void SetLookTo(PointF target)
        {
            PointF diraction = PointExtensions.Sub(WorldPosition, target);
            Angle = PointExtensions.GetAngle(new PointF(-1,0), diraction);
        }
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