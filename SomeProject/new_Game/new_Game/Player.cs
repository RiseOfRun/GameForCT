using System.Drawing;

namespace new_Game
{
    public class Player
    {
        public int money = 1000;
        public int Lives = 10;
        public int score = 0;

        public Towers ChosenTower = Towers.SmallTower;
        public void BuildTower(PointF tower)
        {
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