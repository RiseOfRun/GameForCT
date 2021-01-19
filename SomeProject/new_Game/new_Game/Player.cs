using System.Drawing;
using System.Linq;

namespace new_Game
{
    public enum ControlMode
    {
        Build,
        Delete,
        Select
    }
    
    public class Player
    {
        public int money = 150;
        public int Lives = 10;
        public int score = 0;
        public ControlMode Mode = ControlMode.Build;
        public Towers ChosenTower = Towers.SmallTower;

        public bool CanBuilt(PointF pos)
        {
            if (Mode != ControlMode.Build)
            {
                return false;
            }
            
            foreach (var item in Form1.gameObjects.OfType<Enemy>())
            {
                if (pos.Equals(PointExtensions.RoundPointF(item.WorldPosition))||pos.Equals(GameField.MyGameField.Start)||pos.Equals(GameField.MyGameField.Finish))
                {
                    return false;
                }
            }
            return true;
        }

        public bool SelectTower(PointF pos, out Tower t)
        {
            t = null;
            if (Form1.gameObjects.OfType<Tower>().Any(X => X.WorldPosition == pos))
            {
                t = Form1.gameObjects.OfType<Tower>().First(X => X.WorldPosition == pos);
                return true;
            }
            return false;
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

        public void RemoveTower(PointF tower)
        {
            bool contains = false;
            Tower t;
            contains = SelectTower(tower, out t);
            if (contains)
            {
                GameController.Controller.CurrentPlayer.money += t.cost / 2;
                Form1.gameObjects.Remove(t);
                GameField.MyGameField.openCells[GameField.MyGameField.cells.IndexOf(tower)] = true;
            }
        }
    }
}