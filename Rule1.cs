using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Sellauto
{
    class Rule1
    {
        List<Rectangle> removeList = new List<Rectangle>();
        List<Rectangle> addList = new List<Rectangle>();
        List<int> directionList = new List<int>();
        int count = 0;
        Rectangle rectangle = new Rectangle(0, 0, 0, 0);
        Cells cell = new Cells();

        public Rule1() {
            
        }

        public void next() {

            foreach (var i in Cells.YellowCells){
                rectangle = i;
                if(Cells.YellowCells.Count!=directionList.Count)directionList.Add(3);
                switch (directionList[count])
                {
                    case 0://上向き
                        if (Cells.RedCells.Contains(i)==false) {
                            directionList[count] = 1;
                            removeList.Add(rectangle);
                            Cells.RedCells.Add(rectangle);
                            rectangle.X += Cells.CELL_SIZE;
                            rectangle.Y += 0;
                            addList.Add(rectangle);
                            
                        }
                        else{
                            directionList[count]=3;
                            removeList.Add(rectangle);
                            Cells.RedCells.Remove(rectangle);
                            rectangle.X -= Cells.CELL_SIZE;
                            rectangle.Y += 0;
                            addList.Add(rectangle);
                        }
                        break;

                    case 1://右向き
                        if (Cells.RedCells.Contains(i) == false)
                        {
                            directionList[count] = 2;
                            removeList.Add(rectangle);
                            Cells.RedCells.Add(rectangle);
                            rectangle.X += 0;
                            rectangle.Y += Cells.CELL_SIZE;
                            addList.Add(rectangle);
                        }
                        else
                        {
                            directionList[count] = 0;
                            removeList.Add(rectangle);
                            Cells.RedCells.Remove(rectangle);
                            rectangle.X += 0;
                            rectangle.Y -= Cells.CELL_SIZE;
                            addList.Add(rectangle);
                        }
                        break;

                    case 2://下向き
                        if (Cells.RedCells.Contains(i) == false)
                        {
                            directionList[count] = 3;
                            removeList.Add(rectangle);
                            Cells.RedCells.Add(rectangle);
                            rectangle.X -= Cells.CELL_SIZE;
                            rectangle.Y += 0;
                            addList.Add(rectangle);
                        }
                        else
                        {
                            directionList[count] = 1;
                            removeList.Add(rectangle);
                            Cells.RedCells.Remove(rectangle);
                            rectangle.X += Cells.CELL_SIZE;
                            rectangle.Y += 0;
                            addList.Add(rectangle);
                        }
                        break;

                    case 3://左向き
                        if (Cells.RedCells.Contains(i) == false)
                        {
                            directionList[count] = 0;
                            removeList.Add(rectangle);
                            Cells.RedCells.Add(rectangle);
                            rectangle.X += 0;
                            rectangle.Y -= Cells.CELL_SIZE;
                            addList.Add(rectangle);
                        }
                        else
                        {
                            directionList[count] = 2;
                            removeList.Add(rectangle);
                            Cells.RedCells.Remove(rectangle);
                            rectangle.X += 0;
                            rectangle.Y += Cells.CELL_SIZE;
                            addList.Add(rectangle);
                        }
                        break;
                }
                count++;
            }
            count = 0;
            foreach (var i in removeList) {
                Cells.YellowCells.Remove(i);
            }
            removeList.Clear();
            foreach (var i in addList)
            {
                Cells.YellowCells.Add(i);
            }
            addList.Clear();
        }
    }
}
