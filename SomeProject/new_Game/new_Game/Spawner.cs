using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace new_Game
{
    public class Spawner
    {
        public int Count = 0;
        public List<Enemy> Enemies = new List<Enemy>();
        private Timer spawnT = new Timer();
        public bool BossWave = false;

        public Spawner()
        {
            spawnT.Interval = (int) 800;
            spawnT.Tick += SpawnTimer_Tick;
        }

        private void SpawnTimer_Tick(object sender, EventArgs e)
        {
            Spawn();
        }

        private void Spawn()
        {
            double health = 0;
            
            if (Count%6 == 0 && Count!=0)
            {
                health = Configs.AirPlaneHealh;
                health = health + (1/Configs.StartDificultyMultiplier*Math.Pow(Count,Configs.AirScaleSpeedMultiplier))*Configs.LevelMultiplier*health;
                Form1.gameObjects.Add(new AirUnit(GameField.MyGameField,health));
                BossWave = true;
                Count += 1;
            }
            
            if (Count%10 == 0 && Count!=0)
            {
                health = Configs.BaseMegaBoyHealh;
                health = health + (1/Configs.StartDificultyMultiplier*Math.Pow(Count,Configs.ScaleSpeedMultiplier))*Configs.LevelMultiplier*health;
                Form1.gameObjects.Add(new MegaBoy(GameField.MyGameField,health));
                BossWave = true;
                Count += 1;
                return;
            }
            if (Count%3 == 0 && Count!=0)
            {
                health = Configs.BaseBoyHealh;
                health = health + (1/Configs.StartDificultyMultiplier*Math.Pow(Count,Configs.ScaleSpeedMultiplier))*Configs.LevelMultiplier*health;
                Form1.gameObjects.Add(new FastBoy(GameField.MyGameField,health));
                BossWave = true;
                Count += 1;
                return;
            }
            health = Configs.BaseBoyHealh;
            health = health + (1/Configs.StartDificultyMultiplier*Count*Count)*Configs.LevelMultiplier*health;
            Form1.gameObjects.Add(new Boy(GameField.MyGameField,health));
            Count += 1;
        }
        
        public void StartSpawn()
        {
            spawnT.Enabled = true;
        }

        public void StopSpawn()
        {
            spawnT.Enabled = false;
        }
    }
}