using System.Drawing;
using System.Linq;

namespace new_Game
{
    class AntiAirTower : Tower
    {
        public override Enemy FindTarget()
        {
            Enemy target = null;
            target = Form1.gameObjects.OfType<AirUnit>().FirstOrDefault(x=>x.Alive && x is Enemy && PointExtensions.Distance(x.WorldPosition,WorldPosition)<range);
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
            Form1.gameObjects.Add(new Bullet(Target,damage,"Rocket.png",WorldPosition,this,0.3f));
        }
        
        public AntiAirTower(PointF pos, int cost = 100) : base(pos, cost)
        {
            shootT.Stop();
            firerate = 0.7f;
            range = 10;
            damage = 800;
            shootT.Interval = (int) (1000 / firerate);
            shootT.Start();
            Sprite = Form1.MyImageList.Images["AntiAir_tower.png"];
            this.cost = Configs.AntiAirTowerCost;
            Spawn(pos);
        }
    }
}