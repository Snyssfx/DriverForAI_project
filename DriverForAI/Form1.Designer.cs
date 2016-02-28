namespace DriverForAI
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
            if ( disposing && (components != null) ) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.replayButton44 = new System.Windows.Forms.Button();
            this.historyBar24 = new System.Windows.Forms.TrackBar();
            this.fieldBox1 = new System.Windows.Forms.PictureBox();
            this.winLabel = new System.Windows.Forms.Label();
            this.statLabel = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblStart2 = new System.Windows.Forms.Label();
            this.labBegin = new System.Windows.Forms.Label();
            this.mainButton = new System.Windows.Forms.Button();
            this.mainTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historyBar24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTab
            // 
            this.mainTab.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.mainTab.Controls.Add(this.tabPage1);
            this.mainTab.Controls.Add(this.tabPage2);
            this.mainTab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainTab.Location = new System.Drawing.Point(0, 59);
            this.mainTab.Multiline = true;
            this.mainTab.Name = "mainTab";
            this.mainTab.Padding = new System.Drawing.Point(3, 3);
            this.mainTab.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(649, 329);
            this.mainTab.TabIndex = 0;
            this.mainTab.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.replayButton44);
            this.tabPage1.Controls.Add(this.historyBar24);
            this.tabPage1.Controls.Add(this.fieldBox1);
            this.tabPage1.Controls.Add(this.winLabel);
            this.tabPage1.Controls.Add(this.statLabel);
            this.tabPage1.Controls.Add(this.headerLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(641, 300);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Игра 1";
            // 
            // replayButton44
            // 
            this.replayButton44.BackColor = System.Drawing.SystemColors.Control;
            this.replayButton44.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("replayButton44.BackgroundImage")));
            this.replayButton44.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.replayButton44.ForeColor = System.Drawing.Color.White;
            this.replayButton44.Location = new System.Drawing.Point(113, 295);
            this.replayButton44.Name = "replayButton44";
            this.replayButton44.Size = new System.Drawing.Size(42, 39);
            this.replayButton44.TabIndex = 6;
            this.replayButton44.UseVisualStyleBackColor = false;
            // 
            // historyBar24
            // 
            this.historyBar24.Location = new System.Drawing.Point(29, 267);
            this.historyBar24.Maximum = 100;
            this.historyBar24.Name = "historyBar24";
            this.historyBar24.Size = new System.Drawing.Size(220, 45);
            this.historyBar24.TabIndex = 5;
            // 
            // fieldBox1
            // 
            this.fieldBox1.Location = new System.Drawing.Point(29, 44);
            this.fieldBox1.Name = "fieldBox1";
            this.fieldBox1.Size = new System.Drawing.Size(220, 220);
            this.fieldBox1.TabIndex = 4;
            this.fieldBox1.TabStop = false;
            // 
            // winLabel
            // 
            this.winLabel.AutoSize = true;
            this.winLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.winLabel.Location = new System.Drawing.Point(341, 275);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(239, 24);
            this.winLabel.TabIndex = 3;
            this.winLabel.Text = "Победитель: крестики!";
            this.winLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statLabel
            // 
            this.statLabel.AutoSize = true;
            this.statLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statLabel.Location = new System.Drawing.Point(341, 44);
            this.statLabel.Name = "statLabel";
            this.statLabel.Size = new System.Drawing.Size(103, 60);
            this.statLabel.TabIndex = 2;
            this.statLabel.Text = "Статистика:\r\n3214\r\n545\r\n";
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.headerLabel.Location = new System.Drawing.Point(25, 13);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(193, 20);
            this.headerLabel.TabIndex = 1;
            this.headerLabel.Text = "Depture VS VHSAUTO";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.trackBar1);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(641, 300);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(286, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(36, 270);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(220, 45);
            this.trackBar1.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(36, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 220);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(348, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Победитель: крестики!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(348, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 60);
            this.label2.TabIndex = 8;
            this.label2.Text = "Статистика:\r\n3214\r\n545\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(50, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Depture VS VHSAUTO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblStart2
            // 
            this.LblStart2.AutoSize = true;
            this.LblStart2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LblStart2.Location = new System.Drawing.Point(221, 24);
            this.LblStart2.Name = "LblStart2";
            this.LblStart2.Size = new System.Drawing.Size(57, 20);
            this.LblStart2.TabIndex = 3;
            this.LblStart2.Text = "label4";
            // 
            // labBegin
            // 
            this.labBegin.AutoSize = true;
            this.labBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labBegin.Location = new System.Drawing.Point(250, 108);
            this.labBegin.Name = "labBegin";
            this.labBegin.Size = new System.Drawing.Size(94, 55);
            this.labBegin.TabIndex = 1;
            this.labBegin.Text = "3...";
            this.labBegin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labBegin.Visible = false;
            // 
            // mainButton
            // 
            this.mainButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainButton.Location = new System.Drawing.Point(211, 236);
            this.mainButton.Name = "mainButton";
            this.mainButton.Size = new System.Drawing.Size(173, 92);
            this.mainButton.TabIndex = 2;
            this.mainButton.Text = "Are you ready?\r\n";
            this.mainButton.UseVisualStyleBackColor = true;
            this.mainButton.Click += new System.EventHandler(this.mainButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(649, 388);
            this.Controls.Add(this.mainButton);
            this.Controls.Add(this.labBegin);
            this.Controls.Add(this.mainTab);
            this.Controls.Add(this.LblStart2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Game";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.mainTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historyBar24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button replayButton44;
        private System.Windows.Forms.TrackBar historyBar24;
        private System.Windows.Forms.PictureBox fieldBox1;
        private System.Windows.Forms.Label winLabel;
        private System.Windows.Forms.Label statLabel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labBegin;
        private System.Windows.Forms.Button mainButton;
        private System.Windows.Forms.Label LblStart2;
    }
}

