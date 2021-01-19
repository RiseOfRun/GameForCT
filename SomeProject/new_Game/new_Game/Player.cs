using System.Drawing;
using System.Linq;

namespace new_Game
{
    public class Player
    {
        public int money = 1000;
        public int Lives = 10;
        public int score = 0;

        public Towers ChosenTower = Towers.SmallTower;

        public bool CanBuilt(PointF pos)
        {
            foreach (var item in Form1.gameObjects.OfType<Enemy>())
            {
                if (pos.Equals(PointExtensions.RoundPointF(item.WorldPosition))||pos.Equals(GameField.MyGameField.Start)||pos.Equals(GameField.MyGameField.Finish))
                {
                    return false;
                }
            }

            return true;
        }
        public void BuildTower(PointF tower)
        {
            if (!CanBuilt(tower))
            {
                return;
            }
            int cost = GameController.Controller.TowerList[ChosenTower];
            if (!GameController.Controller.field.isFree(tower))
            {
                return;
            }
            
            if (money>=GameController.Controller.TowerList[ChosenTower])
            {
                money -= cost;
                Form1.gameObjects.Add(new Tower(tower));
            }
        }
    }
}