using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParticlesTest.Guns
{
    public abstract class Gun
    {
        protected static List<Particle> particles = new List<Particle>();
        public static List<IImpactPoint> points = new List<IImpactPoint>();

        public int X; // X центра эмиттера
        public int Y; // Y центра эмиттера
        public int Direction = 0; // Вектор направления в градусах, куда направляет эмиттер
        public int Spreading = 360; // Разброс частиц относительно Direction
        public int SpeedMin = 1; // Начальная минимальная скорость
        public int SpeedMax = 1; // Начальная максимальная скорость
        public int RadiusMin = 2; // Минимальный радиус частицы
        public int RadiusMax = 10; // Максимальный радиус частицы
        public int LifeMin = 20; // Минимальное время жизни частицы
        public int LifeMax = 100; // Максимальное время жизни частицы
        public int Cooldown = 10;

        public static Color ColorFrom = Color.Orange;
        public static Color ColorTo = Color.FromArgb(0, Color.White);

        public static Player player;

        public virtual void CreateParticles() 
        {
            X = player.GetGunEndX();
            Y = player.GetGunEndY();
            Direction = player.Direction;
        }

        private int k = 0;
        public void UpdateState() 
        {
            if (k == 0)
            {
                CreateParticles();
            }
            k = (k + 1) % Cooldown;

            foreach (var particle in particles.ToList())
            {
                particle.Life--;
                if (particle.Life < 0 || particle.Destroyed)
                {
                    particles.Remove(particle);
                }
                else
                {
                    foreach (var point in points)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }
        }
     
        public void Render(Graphics graphics)
        {
            foreach (var particle in particles)
            {
                particle.Draw(graphics);
            }

            foreach(var point in points)
            {
                point.Render(graphics);
            }
        }
    }
}
