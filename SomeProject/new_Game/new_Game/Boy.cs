﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace new_Game
{
    public abstract class Enemy : GameObject
    {
        public double MaxHealth = 100;
        public double CurrentHealth = 100;
        public int Reward = 10;
        public int Punishment = 1;
        public override void Draw(PaintEventArgs e)
        {
            base.Draw(e);
            Point healthBarPosition = Camera.WorldToScreen(WorldPosition);
           
            Brush b = new SolidBrush(Color.Red);
            e.Graphics.FillRectangle(b,healthBarPosition.X-50,healthBarPosition.Y-30, (int)100, 10);
            Brush greenB = new SolidBrush(Color.LawnGreen);          
            e.Graphics.FillRectangle(greenB,healthBarPosition.X-50,healthBarPosition.Y-30, (int)(CurrentHealth/MaxHealth*100), 10);
            Pen p = new Pen(Color.Red);
            e.Graphics.DrawRectangle(p, healthBarPosition.X-50,healthBarPosition.Y-30, 100,10);
        }
    }
    class Boy : Enemy
    {
        private float speed = 0.05f;
        public List<PointF> path = new List<PointF>();

        public List<PointF> FindPath(GameField field, PointF b)
        {
            PointF roundedPosition = new PointF(
                (float) Math.Round(WorldPosition.X),
                (float) Math.Round(WorldPosition.Y));
            PointF roundedTarget = new PointF(
                (float) Math.Round(b.X),
                (float) Math.Round(b.Y));
            
            int startCellNum = field.cells.IndexOf(roundedPosition);
            int targetCellNum = field.cells.IndexOf(roundedTarget);

            if (startCellNum == -1 || targetCellNum == -1)
            {
                return new List<PointF>();
            }
            
            // Queue<List<int>> open = new Queue<List<int>>();
            List<int> p = new List<int>{startCellNum};
            
            List<PathA> open = new List<PathA>();
            open.Add(new PathA(p,0));
            
            bool[] visited = new bool[field.cells.Count];
            bool pathFound = false;
            while (open.Count!=0)
            {
                PathA current = open.Min();
                open.Remove(current);
                p = current.P;
                int v = current.P[p.Count - 1];
                
                if (visited[v])
                {
                    continue;
                }

                visited[v] = true;
                

                if (v == targetCellNum)
                {
                    pathFound = true;
                    break;
                }
                

                List<int> acident = field.GetAllAccidentCells(v);
                
                foreach (var nextV in acident)
                {
                    var gCost = field.GCost(v,nextV);
                    var hCost = field.HCost(nextV,targetCellNum);
                    int f = gCost + current.Cost+ hCost;
                    List<int> nextPath = new List<int>(p);
                    nextPath.Add(nextV);
                    open.Add(new PathA(nextPath,f));
                }
            }

            if (!pathFound)
            {
                return new List<PointF> {field.cells[field.cells.Count - 1]};

            }
            foreach (var node in p)
            {
                path.Add(field.cells[node]);
            }
            path.RemoveRange(0,1);
            return path;
        }

        void WannaMove(GameField field)
        {
            Random r = new Random();
            path = FindPath(field, field.Finish);
        }
        public Boy(GameField field)
        {
            Sprite = Image.FromFile(@"new_Game\Guns\Boy.png");
            // path.Add(new PointF(
            //     9.5f,
            //     9.5f
            // ));
            // path.Add(new PointF(
            //     10,
            //     1
            // ));
            // return;
            // Random r = new Random();
            // for (int i = 0; i < 100; i++)
            // {
            //     path.Add(new PointF(
            //         (float) (r.NextDouble()*10-0.5),
            //         (float) (r.NextDouble()*10-0.5))
            //     );
            // }
            WannaMove(GameField.MyGameField);
        }

        public override void Update()
        {
            if (WorldPosition.Equals(GameField.MyGameField.Finish))
            {
                GameController.Controller.CurrentPlayer.Lives -= this.Punishment;
                this.Alive = false;
            }
            if (path.Count==0)
            {
                WannaMove(GameField.MyGameField);
                return;
            }
            if (PointExtensions.Sub(WorldPosition, path[0]).GetLength()<speed)
            {
                WorldPosition = path[0];
                path.RemoveAt(0);
                return;
            }

            PointF target = path[0];
            PointF diraction = new PointF(target.X-WorldPosition.X,
                target.Y-WorldPosition.Y);
            float length = diraction.GetLength();
            diraction = PointExtensions.Scale(diraction, 1 / length);
            WorldPosition=PointExtensions.Sum(WorldPosition,PointExtensions.Scale(diraction,speed));
            
            Angle = PointExtensions.GetAngle(new PointF(1, 0), diraction);
        }

        public override void Spawn(PointF pos)
        {
            throw new NotImplementedException();
        }
    }
}