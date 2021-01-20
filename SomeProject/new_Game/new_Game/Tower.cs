using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace new_Game
{
    public class Tower : GameObject
    {
        

        public Enemy Target;
        protected float firerate = 2f;
        protected Timer shootT = new Timer();
        public double damage = 200;
        public int cost = 100;
        public float range = 3f;

        private void ShootTimer_tick(object sender, EventArgs e)
        {
            Shoot();
        }
        public override void Remove()
        {
            shootT.Stop();
            GameField.MyGameField.openCells[GameField.MyGameField.cells.IndexOf(PointExtensions.RoundPointF(WorldPosition))] = true;
            base.Remove();
        }
        public virtual void Shoot()
        {
            if (!GameController.Controller.UnPaused)
            {
                return;
            }
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
            Form1.gameObjects.Add(new Bullet(Target,damage,@"new_Game\Guns\SmallBullet.png",WorldPosition,this,0.25f));
        }
        
        public Tower(PointF pos, int cost=100)
        {
            shootT.Interval = (int) (1000/firerate);
            shootT.Enabled = true;
            shootT.Tick += ShootTimer_tick;
            shootT.Start();
            Sprite = Image.FromFile(@"new_Game\Guns\lazer_gun1.png");
            this.cost = cost;
            Spawn(pos);
        }

        public virtual Enemy FindTarget()
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
}