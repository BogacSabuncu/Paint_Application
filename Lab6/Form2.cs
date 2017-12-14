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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
            //set the first list box
            listBox1.Items.Add("Black");
            listBox1.Items.Add("Red");
            listBox1.Items.Add("Blue");
            listBox1.Items.Add("Green");
            listBox1.SelectionMode = SelectionMode.One;
            listBox1.SetSelected(listBox1.FindString(Form1.pen_s), true);

            //set the secomd list box
            listBox2.Items.Add("White");
            listBox2.Items.Add("Black");
            listBox2.Items.Add("Red");
            listBox2.Items.Add("Blue");
            listBox2.Items.Add("Green");
            listBox2.SelectionMode = SelectionMode.One;
            listBox2.SetSelected(listBox2.FindString(Form1.fill_s), true);

            //set the third list box
            listBox3.Items.Add("1");
            listBox3.Items.Add("2");
            listBox3.Items.Add("3");
            listBox3.Items.Add("4");
            listBox3.Items.Add("5");
            listBox3.Items.Add("6");
            listBox3.Items.Add("7");
            listBox3.Items.Add("8");
            listBox3.Items.Add("9");
            listBox3.Items.Add("10");
            listBox3.SelectionMode = SelectionMode.One;
            listBox3.SetSelected(Convert.ToInt32(Form1.thickness)-1, true);

            //previous selections
            checkBox1.Checked = Form1.fill;
            checkBox2.Checked = Form1.outline;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();//closes the form
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.thickness = Convert.ToSingle(listBox3.SelectedItem);//sets the thickness of the line

            Form1.fill = checkBox1.Checked;//sets the check boxes
            Form1.outline = checkBox2.Checked;

            //determine the pen
            Form1.pen_s = listBox1.SelectedItem.ToString();

            if (Form1.pen_s == "Black")
                Form1.pen_c = new Pen(Color.Black, Form1.thickness);
            else if (Form1.pen_s == "Red")
                Form1.pen_c = new Pen(Color.Red, Form1.thickness);
            else if (Form1.pen_s == "Blue")
                Form1.pen_c = new Pen(Color.Blue, Form1.thickness);
            else
                Form1.pen_c = new Pen(Color.Green, Form1.thickness);

            //determine the brush
            Form1.fill_s = listBox2.SelectedItem.ToString();

            if (Form1.fill_s == "White")
                Form1.fill_c = Brushes.White;
            else if (Form1.fill_s == "Black")
                Form1.fill_c = Brushes.Black;
            else if (Form1.fill_s == "Red")
                Form1.fill_c = Brushes.Red;
            else if (Form1.fill_s == "Blue")
                Form1.fill_c = Brushes.Blue;
            else
                Form1.fill_c = Brushes.Green;

            this.Close();
        }
    }
}
