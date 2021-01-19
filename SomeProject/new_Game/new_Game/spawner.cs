using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace new_Game
{
    public class Spawner
    {
        private List<Enemy> enemies = new List<Enemy>();
        private Timer spawnT = new Timer();

        public Spawner()
        {
            spawnT.Interval = (int) 16;
            spawnT.Tick += SpawnTimer_Tick;
        }

        private void SpawnTimer_Tick(object sender, EventArgs e)
        {
            Spawn();
        }

        private void Spawn()
        {
            if (enemies.Count==0)
            {
                spawnT.Enabled = false;
                return;
            }
            Form1.gameObjects.Add(enemies[0]);
            enemies.RemoveAt(0);
        }

        public Enemy Target { get; set; }

        public void StartSpawn()
        {
            spawnT.Enabled = true;
        }
    }
}