using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sellauto{

    public partial class Form1 : Form{//ルール2は正しく動くことを確認。後はチェックリストだけ。

        Cells cell = new Cells();
        Rule1 rule1 = new Rule1();
        Rule2 rule2 = new Rule2();
        int windowX = 0;
        int windowY = 0;
        int rule = 1;
        List<int> born = new List<int>();
        List<int> survive = new List<int>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            cell.DrawField(sender,e);
            cell.DrawCell(sender, e);
            Size size = ((PictureBox)sender).Size;
            windowX = size.Width - size.Width % Cells.CELL_SIZE;
            windowY = size.Height - size.Height % Cells.CELL_SIZE;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NextMapTimer.Stop();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            x = x - x % Cells.CELL_SIZE;
            y = y - y % Cells.CELL_SIZE;
            cell.AddCell(comboBox1.SelectedIndex,x, y);
            pictureBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cell.ClearCell();
            pictureBox1.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;
            x = x - x % Cells.CELL_SIZE;
            y = y - y % Cells.CELL_SIZE;
            label1.Text = $"{e.X / Cells.CELL_SIZE + 1},{e.Y / Cells.CELL_SIZE + 1}";
        }

        private void NextMapTimer_Tick(object sender, EventArgs e)
        {
            switch (rule)
            {
                case 1:
                    rule1.next();
                    pictureBox1.Refresh();
                    break;
                case 2:
                    rule2.next(windowX,windowY,born,survive);
                    pictureBox1.Refresh();
                   //label2.Text = $"{born[0]},{born[1]}";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            survive.Clear();
            born.Clear();
            foreach (var s in checkedListBox1.CheckedItems)
            {
                born.Add(int.Parse(s.ToString()));
            }
            foreach (var s in checkedListBox2.CheckedItems)
            {
                survive.Add(int.Parse(s.ToString()));
            }
            
            NextMapTimer.Start();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null) {
                NextMapTimer.Interval = int.Parse(comboBox3.SelectedItem.ToString());
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    rule = 1;
                    groupBox4.Visible = false;
                    groupBox5.Visible = false;
                    break;

                case 1:
                    rule = 2;
                    groupBox4.Visible = true;
                    groupBox5.Visible = true;
                    break;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {      
            
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void checkedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
