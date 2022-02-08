using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Sellauto
{
    class Rule2
    {
        Rectangle rectangle = new Rectangle(0, 0, Cells.CELL_SIZE, Cells.CELL_SIZE);
        List<Rectangle> addList = new List<Rectangle>();
        List<Rectangle> remList = new List<Rectangle>();
        int count = 0;
        public Rule2()
        {

        }
        public void next(int x, int y, List<int> b, List<int> s)
        {
            for (var i = 0; i <= x ; i += Cells.CELL_SIZE) {//探索するとき、真ん中のセルを除かないといけないのをわすれてた
                for (var j = 0 ; j <= y ; j+= Cells.CELL_SIZE) {
                    if (Cells.YellowCells.Contains(new Rectangle(i,j,Cells.CELL_SIZE,Cells.CELL_SIZE)))
                    {
                        for (var k = i-Cells.CELL_SIZE; k <= i+Cells.CELL_SIZE; k += Cells.CELL_SIZE) {
                            for (var m = j - Cells.CELL_SIZE; m <= j + Cells.CELL_SIZE; m += Cells.CELL_SIZE) {
                                if (Cells.YellowCells.Contains(new Rectangle(k, m, Cells.CELL_SIZE, Cells.CELL_SIZE))&&(k!=i||m!=j)) count++;
                            }
                        }
                        if (s.Contains(count) == false) remList.Add(new Rectangle(i, j, Cells.CELL_SIZE, Cells.CELL_SIZE));
                        count = 0;
                    }
                    else {
                        for (var k = i - Cells.CELL_SIZE; k <= i + Cells.CELL_SIZE; k += Cells.CELL_SIZE)
                        {
                            for (var m = j - Cells.CELL_SIZE; m <= j + Cells.CELL_SIZE; m += Cells.CELL_SIZE)
                            {
                                if (Cells.YellowCells.Contains(new Rectangle(k,m, Cells.CELL_SIZE, Cells.CELL_SIZE))) count++;
                            }
                        }
                        if (b.Contains(count) == true) addList.Add(new Rectangle(i, j, Cells.CELL_SIZE, Cells.CELL_SIZE));
                        count = 0;
                    }
                }
            }
            foreach (var i in remList)
            {
                Cells.YellowCells.Remove(i);
            }
            remList.Clear();
            foreach (var i in addList)
            {
                Cells.YellowCells.Add(i);
            }
            addList.Clear();
        }
        }
}
