using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;


namespace new_Game
{
    public partial class Form1 : Form
    {
        Label PlayerScore = new Label();
        Label PlayerLives= new Label();
        Timer timer = new Timer();
        Timer cps = new Timer();
        GameField gf = GameField.MyGameField;
        public static List<GameObject> gameObjects = new List<GameObject>();

        void RestartGame()
        {
            List<GameObject> least = gameObjects.AsEnumerable().ToList();
            foreach (var item in gameObjects.AsEnumerable().ToList())
            {
                if (item is Tower)
                {
                    int k = 4;
                }
                item.Remove();
            }

            GameController.Controller.TickCount = 0;
            GameController.Controller.spawner.Count = 0;
            gameObjects = new List<GameObject>();
            MenuPanel.Visible = true;
        }
        public Form1()
        {
            this.DoubleBuffered = true;
            timer.Enabled = true;
            timer.Interval = (int) 16;
            timer.Tick += Timer1_Tick;
            timer.Start();
            InitializeComponent();
            button1.Text = Configs.BaseTowerCost.ToString();
            button2.Text = Configs.FocusTowerCost.ToString();
            button3.Text = Configs.AntiAirTowerCost.ToString();
        }

        public void Update()
        {
            if (GameController.Controller.UnPaused)
            {
                GameController.Controller.TickCount += 1;
            }
            
            if (GameController.Controller.UnPaused)
            {
                foreach (var obj in gameObjects)
                {
                    obj.Update();
                }
            
                foreach (var item in gameObjects.Where(go => !go.Alive).ToList())
                {
            
                    if (item is Enemy)
                    {
                        GameController.Controller.EnemyCount--;
                    }
            
                    item.Remove();
                }
            }
            
            PlayerScore.Text = "Player's Money:\n" + GameController.Controller.CurrentPlayer.money;
            PlayerLives.Text = "Player's Lives:\n" + GameController.Controller.CurrentPlayer.Lives;
            if (GameController.Controller.CurrentPlayer.Lives<=0)
            {
                timer.Stop();
                GameController.Controller.UnPaused = false;
                MessageBox.Show($"GameOver. Your scrore: {GameController.Controller.CurrentPlayer.score}");
                GameController.Controller.Finish();
                GameController.Controller.UnPaused = true;
                OnReadyButtonClick();
                RestartGame();
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Update();
            Invalidate();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            PlayerScore.BackColor = Color.Azure;
            PlayerScore.Height = 100;
            PlayerScore.Location = new Point(600,100);
            
            PlayerLives.BackColor = Color.Azure;
            PlayerLives.Height = 100;
            PlayerLives.Location = new Point(600,200);
            this.Controls.Add(PlayerScore);
            this.Controls.Add(PlayerLives);
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Chartreuse);
            Point p = new Point(this.ClientSize.Width, this.ClientSize.Height);
            
            gf.Draw(e);
            
             foreach (var obj in gameObjects)
             {
                 obj.Draw(e);
             }
            
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!GameController.Controller.GameStarted)
            {
                return;
            }
            Point screenP = e.Location;
            PointF worldP = Camera.ScreenToWorld(screenP);
            PointF nearestP = PointExtensions.RoundPointF(worldP);
            switch (GameController.Controller.CurrentPlayer.Mode)
            {
                case ControlMode.Build:
                    GameController.Controller.players[0].BuildTower(nearestP);
                    break;
                case ControlMode.Delete:
                    GameController.Controller.players[0].RemoveTower(nearestP);
                    break;
            }
        }

        void OnReadyButtonClick()
        {
            if (GameController.Controller.UnPaused == false)
            {
                GameController.Controller.spawner.StartSpawn();
                GameController.Controller.UnPaused = true;
                StartWaveButton.Text = "Pause";
            }
            else
            {
                GameController.Controller.spawner.StopSpawn();
                GameController.Controller.UnPaused = false;
                StartWaveButton.Text = "Start";

            }
        }
        private void StartWaveButton_Click(object sender, EventArgs e)
        {
            
            OnReadyButtonClick();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    GameController.Controller.CurrentPlayer.Mode = ControlMode.Delete;
                    ControlMode_label.Text = "Delete Mod";
                    BuildOptions_Panel.Visible = false;
                    break;
                case Keys.B:
                    GameController.Controller.CurrentPlayer.Mode = ControlMode.Build;
                    ControlMode_label.Text = "Build Mod";
                    BuildOptions_Panel.Visible = true;
        
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GameController.Controller.CurrentPlayer.ChosenTower = Towers.FocusTower;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameController.Controller.CurrentPlayer.ChosenTower = Towers.SmallTower;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GameController.Controller.CurrentPlayer.ChosenTower = Towers.AntiAirTower;

        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            GameController.Controller.GameStarted = true;
            timer.Start();
            MenuPanel.Visible = false;
        }

        private void ShowRecordsButton_Click(object sender, EventArgs e)
        {
            Records_panel.Visible = true;
            Records_ListBox.Items.Clear();
            Records_ListBox.Items.Add("Records");
            Records_ListBox.Items.Add("Name:Score");
            int i = 1;
            foreach (var record in GameController.Controller.TopTen)
            {
                Records_ListBox.Items.Add($"{i}: "+record);
                i++;
            }
        
        }
        
        private void CloseRecords_button_Click(object sender, EventArgs e)
        {
            Records_panel.Visible = false;
        }
        
        private void RemoveRecords_button_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"new_game/records.txt","");
            GameController.Controller.TopTen=new List<string>(File.ReadAllLines(@"new_game/records.txt"));
            foreach (var record in GameController.Controller.TopTen)
            {
                Records_ListBox.Items.Add(record);
            }
        }
        
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                Configs.PlayerName = textBox1.Text;
                GameController.Controller.CurrentPlayer.Name = Configs.PlayerName;
                e.Handled=true;
                e.SuppressKeyPress=true;

            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            GameController.Controller.GameStarted = false;
            GameController.Controller.CurrentPlayer.Lives = 0;
        }
        
    }
}