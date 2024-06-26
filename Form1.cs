﻿using System;
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

        private Point MousePos;
        private bool IsMousePressed = false;
        public static int Score = 0;
        private bool IsBorders = true;

        public Form1()
        {
            InitializeComponent();
            
            pbMain.Image = new Bitmap(pbMain.Width, pbMain.Height);

            player = new Player 
            {
                X = pbMain.Width / 2,
                Y = pbMain.Height / 2,
            };

            emitters.Add(new TopEmitter { Width = pbMain.Width });
            emitters.Add(new BottomEmitter { Width = pbMain.Width, Height = pbMain.Height });
            emitters.Add(new LeftEmitter { Height = pbMain.Height });
            emitters.Add(new RightEmitter { Width = pbMain.Width, Height = pbMain.Height });

            PistolButton_Click(null, null);
            BulletsColorButton.BackColor = Gun.ColorFrom;
            BorderColorButton.BackColor = Emitter.ColorFrom;

            Gun.player = player;
            ChangePointsCount(5);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            player.UpdateState(IsMousePressed, MousePos);
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
                DrawScore(graphics);

                if (IsBorders)
                {
                    foreach (Emitter emitter in emitters)
                    {
                        emitter.Render(graphics);
                    }
                }
            }

            pbMain.Invalidate(); // Отрисовка
        }

        private void ChangePointsCount(int count)
        {
            while (count != Gun.points.Count)
            {
                if (count > Gun.points.Count)
                {
                    Gun.points.Add(new Enemy(pbMain));
                }
                else
                {
                    Gun.points.RemoveAt(Gun.points.Count - 1);
                }
            }
        }

        private void DrawScore(Graphics g)
        {
            g.DrawString(
                $"Счёт: {Score}", 
                new Font("Verdana", 10),
                new SolidBrush(Color.White),
                600, 30
            );
        }

        private void pbMain_MouseDown(object sender, MouseEventArgs e)
        {
            IsMousePressed = true;
        }

        private void pbMain_MouseUp(object sender, MouseEventArgs e)
        {
            IsMousePressed = false;
        }

        private Color HighlightedColor = Color.GhostWhite;
        private Color DefaultColor = Color.White;
        private Button LastPressedButton;
        private void PistolButton_Click(object sender, EventArgs e)
        {
            CurrentGun = new Pistol();
            if(LastPressedButton != null)
                LastPressedButton.BackColor = DefaultColor;
            PistolButton.BackColor = HighlightedColor;
            LastPressedButton = PistolButton;
        }

        private void ShotgunButton_Click(object sender, EventArgs e)
        {
            CurrentGun = new Shotgun();
            if (LastPressedButton != null)
                LastPressedButton.BackColor = DefaultColor;
            ShotgunButton.BackColor = HighlightedColor;
            LastPressedButton = ShotgunButton;
        }

        private void MachineGunButton_Click(object sender, EventArgs e)
        {
            CurrentGun = new MachineGun();
            if (LastPressedButton != null)
                LastPressedButton.BackColor = DefaultColor;
            MachineGunButton.BackColor = HighlightedColor;
            LastPressedButton = MachineGunButton;
        }

        private void BulletsColorButton_Click(object sender, EventArgs e)
        {
            if(colorDialog.ShowDialog() == DialogResult.OK)
            {
                BulletsColorButton.BackColor = colorDialog.Color;
                Gun.ColorFrom = colorDialog.Color;
            }
        }

        private void SpeedTrackbar_Scroll(object sender, EventArgs e)
        {
            float speed = SpeedTrackbar.Value / 10f;
            SpeedLabel.Text = $"Скорость: {speed}";
            player.Speed = speed;
        }

        private void TargetsTrackbar_Scroll(object sender, EventArgs e)
        {
            TargetsLabel.Text = $"Количество целей: {TargetsTrackbar.Value}";
            ChangePointsCount(TargetsTrackbar.Value);
        }

        private void BorderColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                BorderColorButton.BackColor = colorDialog.Color;
                Emitter.ColorFrom = colorDialog.Color;
            }
        }

        private void BordersCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            IsBorders = BordersCheckbox.Checked;
        }

        private void pbMain_MouseMove(object sender, MouseEventArgs e)
        {
            MousePos = e.Location;
        }
    }
}
