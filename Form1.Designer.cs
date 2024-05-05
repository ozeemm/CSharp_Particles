namespace ParticlesTest
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PistolButton = new System.Windows.Forms.Button();
            this.ShotgunButton = new System.Windows.Forms.Button();
            this.MachineGunButton = new System.Windows.Forms.Button();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.BulletsColorLabel = new System.Windows.Forms.Label();
            this.BulletsColorButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.Location = new System.Drawing.Point(12, 12);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(955, 669);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            this.pbMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseDown);
            this.pbMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PistolButton
            // 
            this.PistolButton.BackColor = System.Drawing.Color.White;
            this.PistolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PistolButton.Location = new System.Drawing.Point(973, 12);
            this.PistolButton.Name = "PistolButton";
            this.PistolButton.Size = new System.Drawing.Size(122, 46);
            this.PistolButton.TabIndex = 1;
            this.PistolButton.TabStop = false;
            this.PistolButton.Text = "Пистолет";
            this.PistolButton.UseVisualStyleBackColor = false;
            this.PistolButton.Click += new System.EventHandler(this.PistolButton_Click);
            // 
            // ShotgunButton
            // 
            this.ShotgunButton.BackColor = System.Drawing.Color.White;
            this.ShotgunButton.Location = new System.Drawing.Point(973, 64);
            this.ShotgunButton.Name = "ShotgunButton";
            this.ShotgunButton.Size = new System.Drawing.Size(122, 46);
            this.ShotgunButton.TabIndex = 2;
            this.ShotgunButton.TabStop = false;
            this.ShotgunButton.Text = "Дробовик";
            this.ShotgunButton.UseVisualStyleBackColor = false;
            this.ShotgunButton.Click += new System.EventHandler(this.ShotgunButton_Click);
            // 
            // MachineGunButton
            // 
            this.MachineGunButton.BackColor = System.Drawing.Color.White;
            this.MachineGunButton.Location = new System.Drawing.Point(973, 116);
            this.MachineGunButton.Name = "MachineGunButton";
            this.MachineGunButton.Size = new System.Drawing.Size(122, 46);
            this.MachineGunButton.TabIndex = 3;
            this.MachineGunButton.TabStop = false;
            this.MachineGunButton.Text = "Автомат";
            this.MachineGunButton.UseVisualStyleBackColor = false;
            this.MachineGunButton.Click += new System.EventHandler(this.MachineGunButton_Click);
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(887, 27);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(52, 16);
            this.ScoreLabel.TabIndex = 4;
            this.ScoreLabel.Text = "Счёт: 0";
            // 
            // BulletsColorLabel
            // 
            this.BulletsColorLabel.AutoSize = true;
            this.BulletsColorLabel.Location = new System.Drawing.Point(973, 175);
            this.BulletsColorLabel.Name = "BulletsColorLabel";
            this.BulletsColorLabel.Size = new System.Drawing.Size(84, 16);
            this.BulletsColorLabel.TabIndex = 5;
            this.BulletsColorLabel.Text = "Цвет пулек:";
            // 
            // BulletsColorButton
            // 
            this.BulletsColorButton.Location = new System.Drawing.Point(1060, 172);
            this.BulletsColorButton.Name = "BulletsColorButton";
            this.BulletsColorButton.Size = new System.Drawing.Size(35, 23);
            this.BulletsColorButton.TabIndex = 6;
            this.BulletsColorButton.UseVisualStyleBackColor = true;
            this.BulletsColorButton.Click += new System.EventHandler(this.BulletsColorButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 685);
            this.Controls.Add(this.BulletsColorButton);
            this.Controls.Add(this.BulletsColorLabel);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.MachineGunButton);
            this.Controls.Add(this.ShotgunButton);
            this.Controls.Add(this.PistolButton);
            this.Controls.Add(this.pbMain);
            this.Name = "Form1";
            this.Text = "My Awesome Shooter";
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button PistolButton;
        private System.Windows.Forms.Button ShotgunButton;
        private System.Windows.Forms.Button MachineGunButton;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label BulletsColorLabel;
        private System.Windows.Forms.Button BulletsColorButton;
    }
}

