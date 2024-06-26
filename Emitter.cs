﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticlesTest
{
    public class Emitter
    {
        public List<IImpactPoint> gravityPoints = new List<IImpactPoint>();

        public float GravitationX = 0;
        public float GravitationY = 0;

        List<Particle> particles = new List<Particle>();
        public int MousePositionX;
        public int MousePositionY;

        public int X; // X центра эмиттера
        public int Y; // Y центра эмиттера
        public int Direction = 0; // Вектор направления в градусах, куда направляет эмиттер
        public int Spreading = 360; // Разброс частиц относительно Direction
        public int SpeedMin = 1; // Начальная минимальная скорость
        public int SpeedMax = 2; // Начальная максимальная скорость
        public int RadiusMin = 2; // Минимальный радиус частицы
        public int RadiusMax = 10; // Максимальный радиус частицы
        public int LifeMin = 50; // Минимальное время жизни частицы
        public int LifeMax = 100; // Максимальное время жизни частицы
        public int ParticlesPerTick = 1; // Количество частиц за такт
        public int ParticlesLimit = 200; // Лимит партиклов

        private int ParticlesCreated = 0;

        public static Color ColorFrom = Color.White; // начальный цвет частицы
        public static Color ColorTo = Color.FromArgb(0, Color.Black); // конечный цвет частиц

        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
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
                    ResetParticle(particle);
                }
                else
                {
                    foreach (var point in gravityPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }
            if (ParticlesCreated < ParticlesLimit)
            {
                while (particlesToCreate >= 1)
                {
                    particlesToCreate -= 1;
                    var particle = CreateParticle();
                    ResetParticle(particle);
                    particles.Add(particle);
                    ParticlesCreated++;
                }
            }
        }

        public virtual void ResetParticle(Particle particle)
        {
            (particle as ParticleColorful).FromColor = ColorFrom;

            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            particle.X = X;
            particle.Y = Y;

            var direction = Direction + (double)Particle.rand.Next(Spreading) - Spreading / 2;
            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
        }

        public void Render(Graphics graphics)
        {
            foreach (var particle in particles)
            {
                particle.Draw(graphics);
            }

            // рисую точки притяжения красными кружочками
            foreach (var point in gravityPoints)
            {
                point.Render(graphics);
            }
        }
    }

    public class TopEmitter : Emitter
    {
        public int Width;

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle);

            particle.X = Particle.rand.Next(Width);
            particle.Y = 0; // Верх экрана

            particle.SpeedY = 1; // Вниз
            particle.SpeedX = Particle.rand.Next(-2, 2); // Разброс вправо/влево
        }
    }

    public class BottomEmitter : Emitter
    {
        public int Width;
        public int Height;

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle);

            particle.X = Particle.rand.Next(Width);
            particle.Y = Height; // Низ экрана

            particle.SpeedY = -1; // Вниз
            particle.SpeedX = Particle.rand.Next(-2, 2); // Разброс вправо/влево
        }
    }

    public class LeftEmitter : Emitter
    {
        public int Height;

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle);

            particle.X = 0;
            particle.Y = Particle.rand.Next(Height);

            particle.SpeedY = Particle.rand.Next(-2, 2);
            particle.SpeedX = 1;
        }
    }

    public class RightEmitter : Emitter
    {
        public int Width;
        public int Height;

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle);

            particle.X = Width;
            particle.Y = Particle.rand.Next(Height);

            particle.SpeedY = Particle.rand.Next(-2, 2);
            particle.SpeedX = -1;
        }
    }
}
