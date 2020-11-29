using System.Drawing;
using System.Windows.Forms;

namespace new_Game
{
    public class Bullet : GameObject
    {
        private float speed = 0.5f;
        private float damage;
        private GameObject target;
        private Tower parent;

        public Bullet(GameObject target, float damage, string sprite, PointF position, Tower parent)
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
            diraction = PointExtensions.Scale(diraction, 1 / length);
            WorldPosition=PointExtensions.Sum(WorldPosition,PointExtensions.Scale(diraction,speed));
            if (PointExtensions.Sub(WorldPosition, target.WorldPosition).GetLength()<speed)
            {
                target.Alive = false;
                this.Alive = false;
                parent.Target = null;

            }

            SetLookTo(target.WorldPosition);
        }
        

        public override void Spawn(PointF pos)
        {
            throw new System.NotImplementedException();
        }
    }
}