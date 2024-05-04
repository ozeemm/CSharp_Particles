using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticlesTest.Guns
{
    public class Shotgun : Gun
    {
        public Shotgun()
        {
            Spreading = 0;
            SpeedMin = 7;
            SpeedMax = 7;
            RadiusMin = 8;
            RadiusMax = 10;
            LifeMin = 80;
            LifeMax = 100;
            Cooldown = 20;
        }
        public override void CreateParticles()
        {
            base.CreateParticles();

            float[] directions = new float[] { -30, -15, 0, 15, 30 };
            foreach (var dir in directions)
            {
                var particle = new ParticleColorful();
                particle.FromColor = ColorFrom;
                particle.ToColor = ColorTo;

                particle.Life = Particle.rand.Next(LifeMin, LifeMax);
                particle.X = X;
                particle.Y = Y;

                var direction = Direction + dir + (double)Particle.rand.Next(Spreading) - Spreading / 2;
                var speed = Particle.rand.Next(SpeedMin, SpeedMax);

                particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

                particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);

                particles.Add(particle);
            }
        }
    }
}
