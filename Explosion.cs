using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ParticlesTest
{
    public class Explosion
    {
        public List<Particle> particles = new List<Particle>();
        public int X; // X центра эмиттера
        public int Y; // Y центра эмиттера
        public int Spreading = 360; // Разброс частиц относительно Direction
        public int SpeedMin = 8; // Начальная минимальная скорость
        public int SpeedMax = 10; // Начальная максимальная скорость
        public int RadiusMin = 5; // Минимальный радиус частицы
        public int RadiusMax = 10; // Максимальный радиус частицы
        public int LifeMin = 20; // Минимальное время жизни частицы
        public int LifeMax = 100; // Максимальное время жизни частицы
        public int ParticlesPerTick = 40; // Количество частиц за такт

        public Color ColorFrom = Color.Red; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Black); // конечный цвет частиц

        public int ParticlesCount = 120;
        
        public Explosion(int x, int y, Color color) { X = x; Y = y; ColorFrom = color; }
        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();

            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = (double)Particle.rand.Next(Spreading) - Spreading / 2;
            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }
        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick;

            foreach (var particle in particles.ToList())
            {
                particle.Life--;
                if (particle.Life < 0)
                {
                    particles.Remove(particle);
                }
                else
                {
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }
            while (particlesToCreate >= 1 && ParticlesCount > 0)
            {
                particlesToCreate -= 1;
                ParticlesCount--;
                var particle = CreateParticle();
                particles.Add(particle);
            }
        }
        public void Render(Graphics graphics)
        {
            foreach (var particle in particles)
            {
                particle.Draw(graphics);
            }
        }
    }

    public class SmallExplosion : Explosion
    {
        public SmallExplosion(int x, int y, Color color) : base(x, y, color)
        {
            SpeedMin = 5;
            SpeedMax = 7;
            ParticlesCount = 20;
        }
    }
}
