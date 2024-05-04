using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ParticlesTest.Guns;

namespace ParticlesTest
{
    public partial class Form1 : Form
    {
        private List<Emitter> emitters = new List<Emitter>();
        
        private Player player;
        private Gun CurrentGun;
        private bool isSpacePressed = false;

        //Emitter emitter;   
        public Form1()
        {
            InitializeComponent();
            pbMain.Image = new Bitmap(pbMain.Width, pbMain.Height);

            player = new Player 
            {
                X = pbMain.Width / 2,
                Y = pbMain.Height / 2,
            };

            CurrentGun = new Shotgun
            {
                player = this.player
            };

            Gun.points.Add(new TargetPoint
            {
                X = pbMain.Width * 0.25f,
                Y = pbMain.Height / 2,
            });

            /*var emitter = new Emitter 
            {
                Direction = 0,
                Spreading = 30,
                SpeedMin = 5,
                SpeedMax = 5,
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 3,
                X = pbMain.Width / 2,
                Y = pbMain.Height / 2,
                LifeMin = 50,
                LifeMax = 50,
                RadiusMin = 5,
                RadiusMax = 5
            };

            emitters.Add(emitter);*/


            /*
            emitter.gravityPoints.Add(new GravityPoint
            {
                X = pbMain.Width * 0.25f,
                Y = pbMain.Height / 2
            });
            emitter.gravityPoints.Add(new AntiGravityPoint
            {
                X = pbMain.Width * 0.5f,
                Y = pbMain.Height / 2
            });
            emitter.gravityPoints.Add(new GravityPoint
            {
                X = pbMain.Width * 0.75f,
                Y = pbMain.Height / 2
            });
            */
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            player.UpdateState(isSpacePressed);
            CurrentGun.UpdateState();
            foreach (Emitter emitter in emitters)
            {
                emitter.UpdateState();
            }
            using (var graphics = Graphics.FromImage(pbMain.Image))
            {
                graphics.Clear(Color.Black);
                
                player.Render(graphics);
                CurrentGun.Render(graphics);

                foreach (Emitter emitter in emitters)
                {
                    emitter.Render(graphics);
                }
            }

            pbMain.Invalidate(); // Отрисовка
        }

        private void pbMain_MouseMove(object sender, MouseEventArgs e)
        {
            //emitter.MousePositionX = e.X;
            //emitter.MousePositionY = e.Y;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space) { isSpacePressed = true; }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) { isSpacePressed = false; player.RotationSpeed *= -1; }
        }
    }
}
