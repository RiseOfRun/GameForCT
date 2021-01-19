using System;
using System.Drawing;

namespace new_Game
{
    public static class PointExtensions
    {
        public static PointF RoundPointF(PointF b)
        {
            PointF roundedPoint = new PointF(
                (float) Math.Round(b.X, 0),
                (float) Math.Round(b.Y, 0));
            return roundedPoint;
        }
        
        public static float GetLength(this PointF point)
        {
            string BD = "";
            return (float) Math.Sqrt(point.X * point.X + point.Y * point.Y);
        }

        public static PointF Sum(PointF a, PointF b)
        {
            return new PointF(a.X+b.X,a.Y+b.Y);
        }
        
        public static PointF Sub(PointF a, PointF b)
        {
            return new PointF(a.X-b.X,a.Y-b.Y);
        }
        
        public static PointF Scale(PointF point, float s)
        {
            return new PointF(x: point.X*s,y: point.Y*s);
        }

        public static float Dot(PointF a, PointF b)
        {
            return (float) b.X*a.X+a.Y*b.Y;
        }

        public static float GetAngle(PointF a, PointF b)
        {
            float unsigned_angle = (float) (Math.Acos(Dot(a, b)/a.GetLength()/b.GetLength())*180/Math.PI);
            if (float.IsNaN(unsigned_angle))
            {
                return 0f;
            }
            float sign = Math.Sign(a.X * b.Y - a.Y * b.X);
            return unsigned_angle * sign;
        }
    }
}