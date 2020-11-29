using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace new_Game
{
    public class Tower : GameObject
    {
        public GameObject Target;

        private float firerate = 0.0001f;
        private Timer shootT = new Timer();

        private void ShootTimer_tick(object sender, EventArgs e)
        {
            Shoot();
        }

        public void Shoot()
        {
            if (Target == null)
            {
                return;
            }
            Form1.gameObjects.Add(new Bullet(Target,1,@"new_Game\Guns\SmallBullet.png",WorldPosition,this));
        }
        
        public Tower(PointF pos)
        {
            shootT.Interval = (int) 1;
            shootT.Enabled = true;
            shootT.Tick += ShootTimer_tick;
            shootT.Start();
            Sprite = Image.FromFile(@"new_Game\Guns\lazer_gun1.png");
            Spawn(pos);
        }

        public GameObject FindTarget()
        {
            GameObject target = null;
            try
            {
                target = Form1.gameObjects.OfType<Boy>().First();
            }
            catch (Exception e)
            {
                target = null;
            }

            return target;
        }
        
        public override void Update()
        {
            if (Target==null)
            {
                Target = FindTarget();
                return;
            }

            SetLookTo(Target.WorldPosition);

        }

        public override void Spawn(PointF pos)
        {
            GameField field = GameField.MyGameField;
            if (GameField.MyGameField.openCells[field.cells.IndexOf(WorldPosition)]==false)
            {
                return;
            }
            WorldPosition = PointExtensions.RoundPointF(pos);
            GameField.MyGameField.openCells[field.cells.IndexOf(WorldPosition)]=false;
        }
    }
}