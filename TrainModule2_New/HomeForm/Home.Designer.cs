namespace HomeForm
{
    partial class Home
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
            comboBox1 = new ComboBox();
            panel1 = new Panel();
            textBox1 = new TextBox();
            btndecrease = new Button();
            btnincrease = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(59, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Location = new Point(59, 65);
            panel1.Name = "panel1";
            panel1.Size = new Size(1400, 425);
            panel1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(960, 13);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(80, 27);
            textBox1.TabIndex = 3;
            // 
            // btndecrease
            // 
            btndecrease.Location = new Point(930, 11);
            btndecrease.Name = "btndecrease";
            btndecrease.Size = new Size(33, 29);
            btndecrease.TabIndex = 4;
            btndecrease.Text = "<";
            btndecrease.UseVisualStyleBackColor = true;
            // 
            // btnincrease
            // 
            btnincrease.Location = new Point(1037, 11);
            btnincrease.Name = "btnincrease";
            btnincrease.Size = new Size(36, 29);
            btnincrease.TabIndex = 5;
            btnincrease.Text = ">";
            btnincrease.UseVisualStyleBackColor = true;
            btnincrease.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1280, 663);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1502, 694);
            Controls.Add(button1);
            Controls.Add(btnincrease);
            Controls.Add(btndecrease);
            Controls.Add(textBox1);
            Controls.Add(panel1);
            Controls.Add(comboBox1);
            Name = "Home";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBox1;
        private Panel panel1;
        private TextBox textBox1;
        private Button btndecrease;
        private Button btnincrease;
        private Button button1;
    }
}
