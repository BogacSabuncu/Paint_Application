using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab6
{
    class CEllipse : Shape
    {
        private Point p1;
        private Point p2;
        private Pen pen;
        private Brush brush;
        private bool fill, outline;

        private int x, y, w, h;

        //constructer
        public CEllipse(Point p1, Point p2, Pen pen, Brush brush, bool fill, bool outline)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.pen = pen;
            this.brush = brush;
            this.fill = fill;
            this.outline = outline;
        }

        //set the values for ellipse
        private void form_elps()
        {
            if (p1.X < p2.X)
                x = this.p1.X;
            else
                x = this.p2.X;

            if (p1.Y < p2.Y)
                y = this.p1.Y;
            else
                y = this.p2.Y;

            w = Math.Abs(this.p1.X - this.p2.X);
            h = Math.Abs(this.p1.Y - this.p2.Y);

        }

        //draw the ellipse accordingly
        public override void Draw(Graphics g)
        {
            form_elps();

            if (this.fill)
                g.FillEllipse(this.brush, x, y, w, h);
            if (this.outline)
                g.DrawEllipse(this.pen, x, y, w, h);
        }
    }
}