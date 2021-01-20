using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        public bool GameStarted = false;
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
        public List<string> TopTen;
        
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

        void ReadTopTen()
        {
            if (!File.Exists(@"new_game/records.txt"))
            {
                Directory.CreateDirectory("new_game/");
                using (FileStream fs = File.Create(@"new_game/records.txt"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("");
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            string[] topPlayers = File.ReadAllLines(@"new_game/records.txt");
            TopTen = new List<string>(topPlayers);
        }

        public void Finish()
        {
            List<int> scores = new List<int>();
            bool inList = false;
            for (int i = 0; i < TopTen.Count; i++)
            {
                int item = int.Parse(TopTen[i].Split(' ')[1]);
                if (item<CurrentPlayer.score)
                {
                    TopTen[i] = $"{CurrentPlayer.Name} {CurrentPlayer.score}";
                    inList = true;
                    break;
                }
            }

            if (TopTen.Count<10&&!inList)
            {
                TopTen.Add($"{CurrentPlayer.Name} {CurrentPlayer.score}");
            }
            
            File.WriteAllLines(@"new_game/records.txt",TopTen);
            players = new List<Player>();
            players.Add(new Player());
            CurrentPlayer = players[0];
        }
        public GameController()
        {
            TowerList.Add(Towers.SmallTower,Configs.BaseTowerCost);
            TowerList.Add(Towers.FocusTower,Configs.FocusTowerCost);
            TowerList.Add(Towers.AntiAirTower,Configs.AntiAirTowerCost);
            players.Add(new Player());
            GameField Field = GameField.MyGameField;
            CurrentPlayer = players[0];
            ReadTopTen();

        }
    }
}