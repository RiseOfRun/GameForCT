using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace new_Game
{
    class Tower : GameObject
    {
        public Tower()
        {
            Sprite = Image.FromFile(@"new_Game\Guns\lazer_gun1.png");
            Random r = new Random();
            //WorldPosition = new PointF(r.Next(10),r.Next(10));
            WorldPosition = new PointF(1,3);
        }
        
        
        public override void Update()
        {
            
        }
    }
}