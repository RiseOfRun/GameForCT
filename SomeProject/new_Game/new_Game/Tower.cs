using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace new_Game
{
    public class Tower : GameObject
    {
        public Enemy Target;
        private float firerate = 3f;
        private Timer shootT = new Timer();
        public double damage = 150;
        public int cost = 100;
        public float range = 3f;

        private void ShootTimer_tick(object sender, EventArgs e)
        {
            Shoot();
        }

        public void Shoot()
        {
            if (Target == null || !Target.Alive)
            {
                Target = FindTarget();
                return;
            }

            double distance = PointExtensions.Sub(WorldPosition,Target.WorldPosition).GetLength();
            if (distance>range)
            {
                Target = FindTarget();
                return;
            }
            Form1.gameObjects.Add(new Bullet(Target,1,@"new_Game\Guns\SmallBullet.png",WorldPosition,this));
        }
        
        public Tower(PointF pos, int cost = 100)
        {
            shootT.Interval = (int) (1000/firerate);
            shootT.Enabled = true;
            shootT.Tick += ShootTimer_tick;
            shootT.Start();
            Sprite = Image.FromFile(@"new_Game\Guns\lazer_gun1.png");
            this.cost = cost;
            Spawn(pos);
        }

        public Enemy FindTarget()
        {
            Enemy target = null;
            target = Form1.gameObjects.OfType<Boy>().FirstOrDefault(x=>x.Alive && x is Enemy && PointExtensions.Distance(x.WorldPosition,WorldPosition)<range);
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

        public bool CanBeBuilded()
        {
            foreach (var VARIABLE in Form1.gameObjects.OfType<Boy>())
            {
                
            }

            return true;
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
            foreach (var item in Form1.gameObjects.OfType<Boy>())
            {
                item.path = new List<PointF>();
            }
        }
    }

    class FocusTower : Tower
    {
        public FocusTower(PointF pos, int cost = 100) : base(pos, cost)
        {
        }
    }
}