using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Hackaton {

    class GameProcess {
        static public List<Type> EnemyType = new List<Type>();
        static public List<Vector2> Way;

        public Vector2[,] GameFild;
        public Tower[,] Towers;

        Enemy enemy;
        List<Vector2> MainCell = new List<Vector2>{new Vector2(2, 2), new Vector2(2, 17), new Vector2(32, 17),
            new Vector2(32, 2), new Vector2(17, 2), new Vector2(17, 32), new Vector2(32, 32)};

        public GameProcess() {
            Way = new List<Vector2>();
            GameFild = new Vector2[35, 35];
            Towers =  new Tower[35, 35];
            GetWay();
            //enemy = new Enemy1();
        }

        public void Update() {
            //enemy.Update();
        }

        public void Draw() {
            //enemy.Draw();
        }

        bool GetWay() {
            List<Vector2> stack = new List<Vector2>();
            Way.Clear();
            Way.Add(MainCell[0]);
            for (int i = 1; i < MainCell.Count; i++) {
                stack.Clear();
                GameFild = new Vector2[35, 35];
                stack.Add(Way[Way.Count - 1]);
                int ind = 0;
                while (ind < stack.Count && stack[ind] != MainCell[i]) {
                    Vector2 v = stack[ind++];
                    if (v.Y > 0 && Towers[(int)v.X, (int)v.Y - 1] == null && GameFild[(int)v.X, (int)v.Y - 1].X + GameFild[(int)v.X, (int)v.Y - 1].Y == 0) {
                        stack.Add(new Vector2(v.X, v.Y - 1));
                        GameFild[(int)v.X, (int)v.Y- 1] = v;
                    }
                    if (v.Y < 34 && Towers[(int)v.X, (int)v.Y + 1] == null && GameFild[(int)v.X, (int)v.Y + 1].X + GameFild[(int)v.X, (int)v.Y + 1].Y == 0) {
                        stack.Add(new Vector2(v.X, v.Y + 1));
                        GameFild[(int)v.X, (int)v.Y + 1] = v;
                    }
                    if (v.X > 0 && Towers[(int)v.X - 1, (int)v.Y] == null && GameFild[(int)v.X - 1, (int)v.Y].X + GameFild[(int)v.X - 1, (int)v.Y].Y == 0) {
                        stack.Add(new Vector2(v.X - 1, v.Y));
                        GameFild[(int)v.X - 1, (int)v.Y] = v;
                    }
                    if (v.X < 34 && Towers[(int)v.X + 1, (int)v.Y] == null && GameFild[(int)v.X + 1, (int)v.Y].X + GameFild[(int)v.X + 1, (int)v.Y].Y == 0) {
                        stack.Add(new Vector2(v.X + 1, v.Y));
                        GameFild[(int)v.X + 1, (int)v.Y] = v;
                    }
                }
                if (stack[ind] != MainCell[i]) return false;
                List<Vector2> locWay = new List<Vector2>();
                locWay.Add(MainCell[i]);
                while (GameFild[(int)locWay[locWay.Count - 1].X, (int)locWay[locWay.Count - 1].Y] != MainCell[i - 1]) {
                    locWay.Add(GameFild[(int)locWay[locWay.Count - 1].X, (int)locWay[locWay.Count - 1].Y]);
                }
                locWay.Reverse();
                Way.AddRange(locWay);
            }
            return true;

        }
    }
}