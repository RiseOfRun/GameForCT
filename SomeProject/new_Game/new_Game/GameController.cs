using System.Collections.Generic;

namespace new_Game
{

    public enum Towers
    {
        SmallTower,
        FocusTower,
        AntiAirTower
    }
    class GameController
    {
        public bool UnPaused = false;
        public int EnemyCount = 0;
        public float multiplier = 100;
        public int TickCount = 0;
        public GameField Field;
        public Dictionary<Towers, int> TowerList = new Dictionary<Towers, int>();
        public List<Player> players = new List<Player>();
        public Player CurrentPlayer;
        public GameField field = GameField.MyGameField;
        private static GameController instance;
        public Spawner spawner = new Spawner();

        public static GameController Controller
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameController();
                }

                return instance;
            }
        }

        public GameController()
        {
            TowerList.Add(Towers.SmallTower,100);
            TowerList.Add(Towers.FocusTower,120);
            TowerList.Add(Towers.AntiAirTower,110);
            players.Add(new Player());
            GameField Field = GameField.MyGameField;
            CurrentPlayer = players[0];

        }
    }
}