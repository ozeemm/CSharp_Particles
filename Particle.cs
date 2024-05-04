using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticlesTest
{
    public class Particle
    {
        public float X;
        public float Y;
        public float Radius;

        public float Direction; // Направление в градусах
        public float Speed;

        public float SpeedX;
        public float SpeedY;

        public float Life; // Запас здоровья частицы

        public static Random rand = new Random();

        public Particle()
        {
            // Генерируем произвольное направление и скорость
            Direction = rand.Next(360);
            Speed = 1 + rand.Next(10);

            // Рассчитываем вектор скорости
            SpeedX = (float)(Math.Cos(Direction / 180 * Math.PI) * Speed);
            SpeedY = -(float)(Math.Sin(Direction / 180 * Math.PI) * Speed);

            Radius = 2 + rand.Next(10);
            Life = 20 + rand.Next(100);
        }

        public virtual void Draw(Graphics g)
        {
            // Рассчитываем коэффициент прозрачности по шкале от 0 до 1.0
            float k = Math.Min(1f, Life / 100);
            int alpha = (int)(k * 255);
            var color = Color.FromArgb(alpha, Color.Black);
            var brush = new SolidBrush(color);

            g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2); // Центр - (X, Y)

            // удалили кисть из памяти, вообще сборщик мусора рано или поздно это сам сделает
            // но документация рекомендует делать это самому
            brush.Dispose();
        }
    }

    public class ParticleColorful : Particle
    {
        public Color FromColor; // Начальный цвет
        public Color ToColor; // Конечный цвет

        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                    (int)(color2.A * k + color1.A * (1-k)),
                    (int)(color2.R * k + color1.R * (1-k)),
                    (int)(color2.G * k + color1.G * (1-k)),
                    (int)(color2.B * k + color1.B * (1-k))
                );
        }

        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);

            // так как k уменьшается от 1 до 0, то порядок цветов обратный
            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            b.Dispose();
        }
    }
}
