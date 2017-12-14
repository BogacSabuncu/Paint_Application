using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab6
{
    public class CRectangle : Shape
    {
        private Point p1;
        private Point p2;
        private Pen pen;
        private Brush brush;
        private bool fill, outline;

        private int x, y, w, h;

        private Rectangle rec;

        //constructer
        public CRectangle(Point p1, Point p2, Pen pen, Brush brush, bool fill, bool outline)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.pen = pen;
            this.brush = brush;
            this.fill = fill;
            this.outline = outline;
            
        }

        //form a rectangle
        private void form_rec()
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

            rec = new Rectangle(x, y, w, h);

        }

        //draw the rectangle accordingly
        public override void Draw(Graphics g)
        {
            form_rec();

            if(this.fill)
                g.FillRectangle(this.brush, rec);
            if(this.outline)
                g.DrawRectangle(this.pen, rec);
        }
    }
}
