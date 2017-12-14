using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        //initial varaibles
        bool first_click = true;
        Point p1, p2;
        int shape_type;

        int count = 0;

        public static Pen pen_c = Pens.Black;
        public static Brush fill_c = Brushes.White;
        public static float thickness = 1;
        public static bool fill = false, outline = true;
        public static string pen_s = "Black", fill_s = "White";

        public List<Shape> shapes_list = new List<Shape>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 settingsForm = new Form2();// create new form

            settingsForm.ShowDialog();//open form2
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); //clesses app when you press exit
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            shape_type = 0; //change the shape to a line
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            shape_type = 1;//change the shape to a rectangle
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            shape_type = 2; //change the shape to ellipse
        }
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapes_list.Clear(); //clears the panel
            panel2.Invalidate();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (count > 0)
            {
                shapes_list.Remove(shapes_list.Last());//removes the last item from the list
                panel2.Invalidate();
                count--;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //Draw every object in the shapes list
            foreach (Shape obj in shapes_list)
                obj.Draw(g);
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (first_click)//checks if its the first click
                {
                    p1 = new Point(e.X, e.Y);//sets the point
                    first_click = false;
                }
                else//if second click
                {
                    p2 = new Point(e.X, e.Y);//set the second point
                    first_click = true;

                    if (!fill && !outline && shape_type != 0)//if outline or fill not selected
                    {
                        MessageBox.Show("Fill and or outline must be checked.");//warning
                        return;
                    }

                    if(shape_type ==0)//line
                    {
                        
                        CLine newLine = new CLine(p1, p2, pen_c);//creates a new line object
                        shapes_list.Add(newLine);//adds to list
                        count++;

                        panel2.Invalidate();
                    }
                    else if(shape_type == 1)//rectangle
                    {
                        CRectangle newRect = new CRectangle(p1, p2, pen_c, fill_c, fill, outline);//creates new rectangle
                        shapes_list.Add(newRect);//adds to list
                        count++;

                        panel2.Invalidate();
                    }
                    else if(shape_type == 2)//ellipse
                    {
                        CEllipse newElps = new CEllipse (p1, p2, pen_c, fill_c, fill, outline);//creates new elipse
                        shapes_list.Add(newElps);//adds to list
                        count++;

                        panel2.Invalidate();
                    }
                }
            }
        }
    }
}
