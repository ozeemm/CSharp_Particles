using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParticlesTest
{
    public class Enemy : TargetPoint
    {
        private float Speed;

        public Enemy(PictureBox pb) : base(pb) { }

        public void UpdateState(Player player)
        {
            var length = Math.Sqrt((X - player.X) * (X - player.X) + (Y - player.Y) * (Y - player.Y));
            if (length < Radius + player.Radius)
                return;

            var Direction = (int)(90 + Math.Atan2(X - player.X, Y - player.Y) * 180 / Math.PI);

            int SpeedX = (int)(Math.Cos(Direction / 180f * Math.PI) * Speed);
            int SpeedY = -(int)(Math.Sin(Direction / 180f * Math.PI) * Speed);

            X += SpeedX;
            Y += SpeedY;
        }

        protected override void Respawn()
        {
            base.Respawn();
            Speed = rand.Next(10, 25) / 10.0f;
        }
    }
}
