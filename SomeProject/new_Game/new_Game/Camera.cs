using System.Drawing;

namespace new_Game
{
    class Camera
    {
        public static float Scale = 50f;
        public static float Shift = Scale/2;
        
        public static Point WorldToScreen(PointF point)
        {
            return new Point((int) (point.X*Scale+Shift),(int) (point.Y*Scale+Shift));
        }

        public static PointF ScreenToWorld(Point point)
        {
            return new PointF((point.X-Shift)/Scale,(point.Y-Shift)/Scale);
        }
        
    }
}