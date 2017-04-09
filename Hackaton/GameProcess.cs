using System;
using System.Collections;
using System.Collections.Generic;

namespace Hackaton{

    class GameProcess {
        public int[,] GameFild;
        public Tower[,] Towers;
        int[] MainCell = {3 * 35 + 2, 17 * 35 + 2, 17 * 35 + 32, 3 * 35 + 32, 3 * 35 + 17, 31 * 35 + 17, 31 * 35 + 32 };
        ArrayList Way;
        public GameProcess() {
            Way = new ArrayList();
            GameFild = new int[35, 35];
            Towers =  new Tower[35, 35];
            GetWay();
        }

        void Zero() {
            for (int i = 0; i < 35; i++)
                for (int j = 0; j < 35; j++)
                    GameFild[i, j] = -1;
        }

        bool GetWay() {
            ArrayList stack = new ArrayList();
            Way.Clear();
            Way.Add(MainCell[0]);
            for (int i = 1; i < MainCell.Length; i++) {
                stack.Clear();
                Zero();
                stack.Add((int)Way[Way.Count - 1]);
                int ind = 0;
                GameFild[(int)stack[ind] / 35, (int)stack[ind] % 35] = -2;
                while (ind < stack.Count && (int)stack[ind] != MainCell[i]) {
                    int v = (int)stack[ind++];
                    if (v > 34 && Towers[v / 35 - 1, v % 35] == null && GameFild[v / 35 - 1, v % 35] == -1) {
                        stack.Add(v - 35);
                        GameFild[v / 35 - 1, v % 35] = v;
                    }
                    if (v < 35 * 34 && Towers[v / 35 + 1, v % 35] == null && GameFild[v / 35 + 1, v % 35] == -1) {
                        stack.Add(v + 35);
                        GameFild[v / 35 + 1, v % 35] = v;
                    }
                    if (v % 35 > 0 && Towers[v / 35, v % 35 - 1] == null && GameFild[v / 35, v % 35 - 1] == -1) {
                        stack.Add(v - 1);
                        GameFild[v / 35, v % 35 - 1] = v;
                    }
                    if (v % 35 < 34 && Towers[v / 35, v % 35 + 1] == null && GameFild[v / 35, v % 35 + 1] == -1) {
                        stack.Add(v + 1);
                        GameFild[v / 35, v % 35 + 1] = v;
                    }
                }
                if ((int)stack[ind] != MainCell[i]) return false;
                ArrayList locWay = new ArrayList();
                locWay.Add(MainCell[i]);
                while (GameFild[(int)locWay[locWay.Count - 1] / 35, (int)locWay[locWay.Count - 1] % 35] != MainCell[i - 1]) {
                    locWay.Add(GameFild[(int)locWay[locWay.Count - 1] / 35, (int)locWay[locWay.Count - 1] % 35]);
                }
                locWay.Reverse();
                Way.AddRange(locWay);
            }
            return true;

        }
    }
}