using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab6
{
    public class CLine : Shape
    {
        private Point p1, p2;
        private Pen pen;

        //constructor
        public CLine(Point p1, Point p2, Pen pen)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.pen = pen;
        }

        //draw line
        public override void Draw(Graphics g)
        {
            g.DrawLine(this.pen, this.p1, this.p2);
        }

    }
}
