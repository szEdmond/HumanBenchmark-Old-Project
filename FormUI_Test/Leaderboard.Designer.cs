
namespace FormUI_Test
{
    partial class Leaderboard
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Leaderboard));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Nev = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Speed = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Flick = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Precision = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ReactionSpeed = new System.Windows.Forms.DataGridViewButtonColumn();
            this.NumberMemory = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Simon = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Chimp = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(145)))), ((int)(((byte)(171)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(145)))), ((int)(((byte)(171)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gold;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Plum;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nev,
            this.Speed,
            this.Flick,
            this.Precision,
            this.ReactionSpeed,
            this.NumberMemory,
            this.Simon,
            this.Chimp});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.Black;
            this.dataGridView1.Location = new System.Drawing.Point(12, 108);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(660, 441);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(12, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 40);
            this.btnExit.TabIndex = 4;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(660, 74);
            this.label1.TabIndex = 5;
            this.label1.Text = "Leaderboard";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Nev
            // 
            this.Nev.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Nev.HeaderText = "Name";
            this.Nev.Name = "Nev";
            this.Nev.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Nev.Text = "";
            this.Nev.Width = 63;
            // 
            // Speed
            // 
            this.Speed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Speed.HeaderText = "Speed";
            this.Speed.Name = "Speed";
            this.Speed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Speed.Width = 67;
            // 
            // Flick
            // 
            this.Flick.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Flick.HeaderText = "Flick";
            this.Flick.Name = "Flick";
            this.Flick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Flick.Width = 58;
            // 
            // Precision
            // 
            this.Precision.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Precision.HeaderText = "Precision";
            this.Precision.Name = "Precision";
            this.Precision.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Precision.Width = 83;
            // 
            // ReactionSpeed
            // 
            this.ReactionSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReactionSpeed.HeaderText = "ReactionSpeed";
            this.ReactionSpeed.Name = "ReactionSpeed";
            this.ReactionSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ReactionSpeed.Width = 118;
            // 
            // NumberMemory
            // 
            this.NumberMemory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NumberMemory.HeaderText = "NumberMemory";
            this.NumberMemory.Name = "NumberMemory";
            this.NumberMemory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.NumberMemory.Width = 117;
            // 
            // Simon
            // 
            this.Simon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Simon.HeaderText = "Sequence";
            this.Simon.Name = "Simon";
            this.Simon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Simon.Width = 88;
            // 
            // Chimp
            // 
            this.Chimp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Chimp.HeaderText = "ChimpTest";
            this.Chimp.Name = "Chimp";
            this.Chimp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Chimp.Width = 90;
            // 
            // Leaderboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(84)))), ((int)(((byte)(113)))));
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Leaderboard";
            this.Text = "Leaderboard";
            this.Load += new System.EventHandler(this.Leaderboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewButtonColumn Nev;
        private System.Windows.Forms.DataGridViewButtonColumn Speed;
        private System.Windows.Forms.DataGridViewButtonColumn Flick;
        private System.Windows.Forms.DataGridViewButtonColumn Precision;
        private System.Windows.Forms.DataGridViewButtonColumn ReactionSpeed;
        private System.Windows.Forms.DataGridViewButtonColumn NumberMemory;
        private System.Windows.Forms.DataGridViewButtonColumn Simon;
        private System.Windows.Forms.DataGridViewButtonColumn Chimp;
    }
}