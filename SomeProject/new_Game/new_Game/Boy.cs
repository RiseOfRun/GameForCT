using System;
using System.Collections.Generic;
using System.Drawing;

namespace new_Game
{
    class Boy : GameObject
    {
        private float speed = 0.02f;
        List<PointF> path = new List<PointF>();
        public Boy()
        {
            Sprite = Image.FromFile(@"new_Game\Guns\Boy.png");
            // path.Add(new PointF(
            //     2,
            //     2
            // ));
            // path.Add(new PointF(
            //     10,
            //     1
            // ));
            // return;
            Random r = new Random();
            for (int i = 0; i < 3; i++)
            {
                path.Add(new PointF(
                    (float) (r.NextDouble()*10-0.5),
                    (float) (r.NextDouble()*10-0.5))
                );
            }
        }

        public override void Update()
        {
            if (path.Count==0)
            {
                return;
            }
            if (PointExtensions.Sub(WorldPosition, path[0]).GetLength()<speed)
            {
                WorldPosition = path[0];
                path.RemoveAt(0);
                return;
            }

            PointF target = path[0];
            PointF diraction = new PointF(target.X-WorldPosition.X,
                target.Y-WorldPosition.Y);
            float length = diraction.GetLength();
            diraction = PointExtensions.Scale(diraction, 1 / length);
            WorldPosition=PointExtensions.Sum(WorldPosition,PointExtensions.Scale(diraction,speed));
            
            Angle = PointExtensions.GetAngle(new PointF(1, 0), diraction);
        }
    }
}