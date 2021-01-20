using System;
using System.Drawing;
using System.Windows.Forms;


static class Config
{
    
}
namespace new_Game
{
    public class Bullet : GameObject
    {
        private float speed = 0.5f;
        private double damage;
        private Enemy target;
        private Tower parent;

        public Bullet(Enemy target,double damage, string sprite, PointF position, Tower parent,float speed = 0.5f)
        {
            Sprite = Image.FromFile(sprite);
            this.WorldPosition = position;
            this.target = target;
            this.damage = damage;
            this.parent = parent;
            this.speed = speed;
        }
        
        public override void Update()
        {
            
            PointF diraction = new PointF(target.WorldPosition.X-WorldPosition.X,
                target.WorldPosition.Y-WorldPosition.Y);
            float length = diraction.GetLength();
            if (Math.Abs(length) < 0.01)
            {
                this.Alive = false;
            }
            diraction = PointExtensions.Scale(diraction, 1 / length);
            WorldPosition=PointExtensions.Sum(WorldPosition,PointExtensions.Scale(diraction,speed));
            if (float.IsNaN(WorldPosition.X)|| float.IsNaN(WorldPosition.Y))
            {
                WorldPosition = target.WorldPosition;
                this.Alive = false;
                return;
            }
            if (PointExtensions.Sub(WorldPosition, target.WorldPosition).GetLength()<speed)
            {
                target.CurrentHealth -= damage;
                if (target.CurrentHealth < 0 && target.Alive)
                {
                    target.Alive = false;
                    parent.Target = null;
                    GameController.Controller.CurrentPlayer.money += target.Reward;
                    GameController.Controller.CurrentPlayer.score += target.Reward;
                }
                this.Alive = false;

            }

            SetLookTo(target.WorldPosition);
        }
        

        public override void Spawn(PointF pos)
        {
            throw new System.NotImplementedException();
        }
    }
}