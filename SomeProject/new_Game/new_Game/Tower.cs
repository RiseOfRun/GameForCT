using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace new_Game
{
    class Tower : GameObject
    {
        public Tower(PointF pos)
        {
            Sprite = Image.FromFile(@"new_Game\Guns\lazer_gun1.png");
            Spawn(pos);
        }
        
        
        public override void Update()
        {
            
        }

        public override void Spawn(PointF pos)
        {
            GameField field = GameField.MyGameField;
            WorldPosition = field.GetNearestCell(pos);
            GameField.MyGameField.openCells[field.cells.IndexOf(WorldPosition)]=false;
        }
    }
}