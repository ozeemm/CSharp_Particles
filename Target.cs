using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticlesTest
{
    public class Target
    {
        public float X;
        public float Y;
        public float Radius = 30;
        public Color BorderColor = Color.GreenYellow;

        public void Render(Graphics graphics)
        {
            graphics.DrawEllipse(new Pen(BorderColor, 2), X - Radius, Y - Radius, Radius * 2, Radius * 2);
        }
    }
}
