using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace ParticlesTest
{
    public abstract class IImpactPoint
    {
        public int X;
        public int Y;
        public int Radius = 5;

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
        private static Random rand = new Random();
        private List<Explosion> explosions = new List<Explosion>();

        public PictureBox pbMain;

        public Color color;
        public TargetPoint(PictureBox pb) 
        {
            pbMain = pb;
            Respawn();
        }
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            if(Math.Sqrt(gX * gX + gY * gY) <= Radius)
            {
                particle.Destroyed = true;
                Radius -= 10;
                if (Radius == 0)
                {
                    explosions.Add(new Explosion(X, Y, color));
                    Form1.Score += 5;
                    Respawn();
                }
                else
                {
                    Form1.Score += 1;
                    explosions.Add(new SmallExplosion(X, Y, color));
                }
            }
        }
        public override void Render(Graphics g)
        {
            foreach(var explosion in explosions.ToList()) 
            {
                if (explosion.ParticlesCount == 0 && explosion.particles.Count == 0)
                    explosions.Remove(explosion);

                explosion.UpdateState();
                explosion.Render(g);
            }
            for(int i = 0; i < (Radius / 10); i++)
            {
                float r = Radius - i * 10;
                g.DrawEllipse(new Pen(color, 2), X - r, Y - r, r * 2, r * 2);
            }
        }
        private void Respawn()
        {
            Radius = 30;
            color = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
            X = rand.Next(pbMain.Width - (int)Radius*2) + Radius;
            Y = rand.Next(pbMain.Height - (int)Radius*2) + Radius;
        }
    }
}
