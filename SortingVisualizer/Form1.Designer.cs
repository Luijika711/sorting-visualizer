namespace SortingVisualizer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            trackBar1 = new TrackBar();
            comboBox1 = new ComboBox();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            button2 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(12, 665);
            trackBar1.Maximum = 100;
            trackBar1.Minimum = 2;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(1277, 45);
            trackBar1.TabIndex = 0;
            trackBar1.Value = 2;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(143, 633);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(223, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 636);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 2;
            label1.Text = "sorting algorithm:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Silver;
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1277, 615);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // button1
            // 
            button1.Location = new Point(393, 633);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(474, 633);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "reset";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1306, 722);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(trackBar1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trackBar1;
        private ComboBox comboBox1;
        private Label label1;
        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private System.Windows.Forms.Timer timer1;
    }
}