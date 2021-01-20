using System.Drawing;
using System.Linq;

namespace new_Game
{
    class FocusTower : Tower
    {
        public override Enemy FindTarget()
        {
            Enemy target = null;
            target = Form1.gameObjects.OfType<FastBoy>().FirstOrDefault(x=>x.Alive && x is Enemy && PointExtensions.Distance(x.WorldPosition,WorldPosition)<range);
            if (target==null)
            {
                target = Form1.gameObjects.OfType<Boy>().FirstOrDefault(x=>x.Alive && x is Enemy && PointExtensions.Distance(x.WorldPosition,WorldPosition)<range);
            }
            return target;
        }

        public override void Shoot()
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
            Form1.gameObjects.Add(new Bullet(Target,damage,"bitBullet.png",WorldPosition,this,0.3f));
        }
        
        public FocusTower(PointF pos, int cost = 100) : base(pos, cost)
        {
            shootT.Stop();
            firerate = firerate*6;
            damage = damage / 5;
            range = 5;
            shootT.Interval = (int) (1000 / firerate);
            shootT.Start();
            Sprite = Form1.MyImageList.Images["focus_tower.png"];
            this.cost = Configs.FocusTowerCost;
            Spawn(pos);
        }
    }
}