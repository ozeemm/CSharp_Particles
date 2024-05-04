using System;
using System.Collections.Generic;
using System.Drawing;

namespace ParticlesTest
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;

        // абстрактный метод с помощью которого будем изменять состояние частиц (например, притягивать)
        public abstract void ImpactParticle(Particle particle);

        public void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
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
}
