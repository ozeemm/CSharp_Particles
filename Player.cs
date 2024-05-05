using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticlesTest
{
    public class Player
    {
        public float X;
        public float Y;
        public float Radius = 15f;
        public float GunLength = 25;

        public int Direction = 0;
        public float Speed = 3;
        public int RotationSpeed = 4;

        public float SpeedX;
        public float SpeedY;

        public Color color = Color.DeepSkyBlue;

        public void UpdateState(bool isGoing)
        {
            if (isGoing) 
            {
                SpeedX = (float)Math.Cos(Direction / 180f * Math.PI) * Speed;
                SpeedY = -(float)Math.Sin(Direction / 180f * Math.PI) * Speed;

                X += SpeedX;
                Y += SpeedY;
            }
            else
            {
                SpeedX = 0;
                SpeedY = 0;
                Direction = (Direction + RotationSpeed) % 360;
            }
        }
        public void Render(Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(color), X - Radius, Y - Radius, Radius * 2, Radius * 2);
            graphics.DrawEllipse(new Pen(Color.White, 2), X - Radius, Y - Radius, Radius * 2, Radius * 2);
            
            graphics.DrawLine(new Pen(Color.LightGray, 2), X, Y, GetGunEndX(), GetGunEndY());
        }

        public int GetGunEndX() { return (int)(X + GunLength * (float)Math.Cos(Direction / 180f * Math.PI)); }
        public int GetGunEndY() { return (int)(Y - GunLength * (float)Math.Sin(Direction / 180f * Math.PI)); }
    }
}
