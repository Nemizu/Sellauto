using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sellauto{

    class Cells{
        public static readonly int CELL_SIZE = 7;
        //listのsetgetって後からnewするしstaticの変数だとできなくない？
        public static List<Rectangle> RedCells = new List<Rectangle>();
        public static List<Rectangle> YellowCells = new List<Rectangle>();

        public Cells() {
        }


        public void AddCell(int Index,int x,int y) {



            switch (Index) {
                case 0:
                    if (!YellowCells.Contains(new Rectangle(x, y, CELL_SIZE, CELL_SIZE))){
                        ClearCell(new Rectangle(x, y, CELL_SIZE, CELL_SIZE));
                        YellowCells.Add(new Rectangle(x, y, CELL_SIZE, CELL_SIZE));
                    }
                    break;
                case 1:
                    if (!RedCells.Contains(new Rectangle(x, y, CELL_SIZE, CELL_SIZE)))
                    {
                        ClearCell(new Rectangle(x, y, CELL_SIZE, CELL_SIZE));
                        RedCells.Add(new Rectangle(x, y, CELL_SIZE, CELL_SIZE));
                    }
                    break;
                case 2:
                    ClearCell(new Rectangle(x, y, CELL_SIZE, CELL_SIZE));
                    break;
            }  
            

        }

        public void ClearCell(object cell = null) {
            if (cell == null)
            {
                RedCells.Clear();
                YellowCells.Clear();
            }
            else {
                RedCells.Remove((Rectangle)cell);
                YellowCells.Remove((Rectangle)cell);
            }
            
        }

        public void DrawField(object sender, PaintEventArgs e) {

            //マスを描画
            Pen pen = new Pen(Color.FromArgb(100,100,100), 1);
            Size size = ((PictureBox)sender).Size;
            int width = size.Width;
            int height = size.Height;

            for (var i = CELL_SIZE; i <= width; i += CELL_SIZE)
            {
                e.Graphics.DrawLine(pen, i, 0, i, height);
            }
            for (var i = CELL_SIZE; i <= height; i += CELL_SIZE)
            {
                e.Graphics.DrawLine(pen, 0, i, width, i);
            }
        }

        public void DrawCell(object sender,PaintEventArgs e) {

            SolidBrush Yellow = new SolidBrush(Color.Yellow);
            SolidBrush Red = new SolidBrush(Color.Red);           
            foreach (var i in RedCells)
            {
                e.Graphics.FillRectangle(Red, i);
            }
            foreach (var i in YellowCells)
            {
                e.Graphics.FillRectangle(Yellow, i);
            }


        }

    }
}
