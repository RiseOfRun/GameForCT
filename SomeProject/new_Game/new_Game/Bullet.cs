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
        private float damage;
        private Enemy target;
        private Tower parent;

        public Bullet(Enemy target, float damage, string sprite, PointF position, Tower parent)
        {
            Sprite = Image.FromFile(sprite);
            this.WorldPosition = position;
            this.target = target;
            this.damage = damage;
            this.parent = parent;
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
            if (PointExtensions.Sub(WorldPosition, target.WorldPosition).GetLength()<speed)
            {
                target.CurrentHealth -= parent.damage;
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