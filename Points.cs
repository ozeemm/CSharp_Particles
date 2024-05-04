using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ParticlesTest
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;
        public float Radius = 5;

        // абстрактный метод с помощью которого будем изменять состояние частиц (например, притягивать)
        public abstract void ImpactParticle(Particle particle);

        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - Radius,
                    Y - Radius,
                    Radius * 2,
                    Radius * 2
                );
        }
    }

    public class GravityPoint : IImpactPoint
    {
        public int Power = 100;
        public override void ImpactParticle(Particle particle)
        {
            // Считаем вектор притяжения к точке
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            // Считаем квадрат расстояния между частицей и точкой r^2
            float r2 = Math.Max(100, gX * gX + gY * gY);

            // Пересчитываем вектор скорости с учетом притяжения к точке
            particle.SpeedX += (gX) * Power / r2;
            particle.SpeedY += (gY) * Power / r2;
        }
    }

    public class AntiGravityPoint : IImpactPoint
    {
        public int Power = 100;
        public override void ImpactParticle(Particle particle)
        {
            // Считаем вектор притяжения к точке
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            // Считаем квадрат расстояния между частицей и точкой r^2
            float r2 = Math.Max(100, gX * gX + gY * gY);

            // Пересчитываем вектор скорости с учетом притяжения к точке
            particle.SpeedX -= (gX) * Power / r2;
            particle.SpeedY -= (gY) * Power / r2;
        }
    }

    public class TargetPoint : IImpactPoint
    {
        public TargetPoint() { Radius = 40; }
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            if(Math.Sqrt(gX * gX + gY * gY) <= Radius)
            {
                particle.Destroyed = true;
                Radius -= 10;
            }
        }
        public override void Render(Graphics g)
        {
            for(int i = 0; i < (Radius / 10); i++)
            {
                float r = Radius - i * 10;
                g.DrawEllipse(new Pen(Color.Red, 2), X - r, Y - r, r * 2, r * 2);
            }
        }
    }
}
