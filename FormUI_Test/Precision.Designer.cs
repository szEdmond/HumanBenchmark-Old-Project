
namespace FormUI_Test
{
    partial class Precision
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Precision));
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.labelToolTip = new System.Windows.Forms.Label();
            this.labelHelp = new System.Windows.Forms.Label();
            this.labelLives = new System.Windows.Forms.Label();
            this.labelHits = new System.Windows.Forms.Label();
            this.rBtn4 = new FormUI_Test.RoundButton();
            this.rBtn5 = new FormUI_Test.RoundButton();
            this.rBtn3 = new FormUI_Test.RoundButton();
            this.rBtn2 = new FormUI_Test.RoundButton();
            this.rBtn1 = new FormUI_Test.RoundButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(644, 116);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hit the targets on the screen\r\nbefore they disappear!\r\nYou have 3 \"lives\"";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(34)))), ((int)(((byte)(51)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(294, 232);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(82, 45);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(12, 18);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 40);
            this.btnExit.TabIndex = 7;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // labelToolTip
            // 
            this.labelToolTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelToolTip.AutoSize = true;
            this.labelToolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelToolTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelToolTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelToolTip.Location = new System.Drawing.Point(298, 359);
            this.labelToolTip.Name = "labelToolTip";
            this.labelToolTip.Size = new System.Drawing.Size(344, 136);
            this.labelToolTip.TabIndex = 9;
            this.labelToolTip.Text = resources.GetString("labelToolTip.Text");
            this.labelToolTip.Visible = false;
            // 
            // labelHelp
            // 
            this.labelHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHelp.AutoSize = true;
            this.labelHelp.Cursor = System.Windows.Forms.Cursors.Help;
            this.labelHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHelp.ForeColor = System.Drawing.Color.Gray;
            this.labelHelp.Location = new System.Drawing.Point(639, 495);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(17, 18);
            this.labelHelp.TabIndex = 8;
            this.labelHelp.Text = "?";
            this.labelHelp.MouseLeave += new System.EventHandler(this.labelHelp_MouseLeave);
            this.labelHelp.MouseHover += new System.EventHandler(this.labelHelp_MouseHover);
            // 
            // labelLives
            // 
            this.labelLives.AutoSize = true;
            this.labelLives.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLives.ForeColor = System.Drawing.Color.White;
            this.labelLives.Location = new System.Drawing.Point(53, 9);
            this.labelLives.Name = "labelLives";
            this.labelLives.Size = new System.Drawing.Size(86, 18);
            this.labelLives.TabIndex = 10;
            this.labelLives.Text = "Missed : 0";
            this.labelLives.Visible = false;
            // 
            // labelHits
            // 
            this.labelHits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHits.AutoSize = true;
            this.labelHits.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHits.ForeColor = System.Drawing.Color.White;
            this.labelHits.Location = new System.Drawing.Point(561, 9);
            this.labelHits.Name = "labelHits";
            this.labelHits.Size = new System.Drawing.Size(57, 18);
            this.labelHits.TabIndex = 11;
            this.labelHits.Text = "Hits: 0";
            this.labelHits.Visible = false;
            // 
            // rBtn4
            // 
            this.rBtn4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(69)))));
            this.rBtn4.FlatAppearance.BorderSize = 0;
            this.rBtn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rBtn4.Location = new System.Drawing.Point(487, 232);
            this.rBtn4.Name = "rBtn4";
            this.rBtn4.Size = new System.Drawing.Size(100, 100);
            this.rBtn4.TabIndex = 6;
            this.rBtn4.Text = "roundButton1";
            this.rBtn4.UseVisualStyleBackColor = false;
            this.rBtn4.Visible = false;
            this.rBtn4.Click += new System.EventHandler(this.rBtn4_Click);
            // 
            // rBtn5
            // 
            this.rBtn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(69)))));
            this.rBtn5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rBtn5.FlatAppearance.BorderSize = 0;
            this.rBtn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rBtn5.Location = new System.Drawing.Point(412, 74);
            this.rBtn5.Name = "rBtn5";
            this.rBtn5.Size = new System.Drawing.Size(100, 100);
            this.rBtn5.TabIndex = 5;
            this.rBtn5.Text = "roundButton1";
            this.rBtn5.UseVisualStyleBackColor = false;
            this.rBtn5.Visible = false;
            this.rBtn5.Click += new System.EventHandler(this.rBtn5_Click);
            // 
            // rBtn3
            // 
            this.rBtn3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(69)))));
            this.rBtn3.FlatAppearance.BorderSize = 0;
            this.rBtn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rBtn3.Location = new System.Drawing.Point(276, 385);
            this.rBtn3.Name = "rBtn3";
            this.rBtn3.Size = new System.Drawing.Size(100, 100);
            this.rBtn3.TabIndex = 4;
            this.rBtn3.Text = "roundButton1";
            this.rBtn3.UseVisualStyleBackColor = false;
            this.rBtn3.Visible = false;
            this.rBtn3.Click += new System.EventHandler(this.rBtn3_Click);
            // 
            // rBtn2
            // 
            this.rBtn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(69)))));
            this.rBtn2.FlatAppearance.BorderSize = 0;
            this.rBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rBtn2.Location = new System.Drawing.Point(56, 232);
            this.rBtn2.Name = "rBtn2";
            this.rBtn2.Size = new System.Drawing.Size(100, 100);
            this.rBtn2.TabIndex = 3;
            this.rBtn2.Text = "roundButton1";
            this.rBtn2.UseVisualStyleBackColor = false;
            this.rBtn2.Visible = false;
            this.rBtn2.Click += new System.EventHandler(this.rBtn2_Click);
            // 
            // rBtn1
            // 
            this.rBtn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(69)))));
            this.rBtn1.FlatAppearance.BorderSize = 0;
            this.rBtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rBtn1.Location = new System.Drawing.Point(161, 74);
            this.rBtn1.Name = "rBtn1";
            this.rBtn1.Size = new System.Drawing.Size(100, 100);
            this.rBtn1.TabIndex = 2;
            this.rBtn1.Text = "roundButton1";
            this.rBtn1.UseVisualStyleBackColor = false;
            this.rBtn1.Visible = false;
            this.rBtn1.Click += new System.EventHandler(this.rBtn1_Click);
            // 
            // Precision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(113)))));
            this.ClientSize = new System.Drawing.Size(668, 522);
            this.Controls.Add(this.labelHits);
            this.Controls.Add(this.labelLives);
            this.Controls.Add(this.labelToolTip);
            this.Controls.Add(this.labelHelp);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.rBtn4);
            this.Controls.Add(this.rBtn5);
            this.Controls.Add(this.rBtn3);
            this.Controls.Add(this.rBtn2);
            this.Controls.Add(this.rBtn1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Name = "Precision";
            this.Text = "Precision";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private RoundButton rBtn1;
        private RoundButton rBtn2;
        private RoundButton rBtn3;
        private RoundButton rBtn5;
        private RoundButton rBtn4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label labelToolTip;
        private System.Windows.Forms.Label labelHelp;
        private System.Windows.Forms.Label labelLives;
        private System.Windows.Forms.Label labelHits;
    }
}