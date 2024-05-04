using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticlesTest.Guns
{
    public class MachineGun : Gun
    {
        public MachineGun()
        {
            Spreading = 15;
            SpeedMin = 8;
            SpeedMax = 15;
            RadiusMin = 4;
            RadiusMax = 6;
            LifeMin = 50;
            LifeMax = 75;
            Cooldown = 2;
            ColorFrom = Color.Orange;
            ColorTo = Color.FromArgb(0, Color.White);
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
