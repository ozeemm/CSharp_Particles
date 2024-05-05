using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticlesTest.Guns
{
    public class Pistol : Gun
    {
        public Pistol()
        {
            Spreading = 2;
            SpeedMin = 6;
            SpeedMax = 7;
            RadiusMin = 4;
            RadiusMax = 6;
            LifeMin = 100;
            LifeMax = 125;
            Cooldown = 15;
        }
        public override void CreateParticles()
        {
            base.CreateParticles();

            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            particle.Life = Particle.rand.Next(LifeMin, LifeMax);
            particle.X = X;
            particle.Y = Y;

            var direction = Direction + (double)Particle.rand.Next(Spreading) - Spreading / 2;
            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);

            particles.Add(particle);
        }
    }
}
