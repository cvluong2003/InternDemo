namespace HomeForm
{
    partial class UserControl2
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnsua = new Button();
            button2 = new Button();
            txtma = new TextBox();
            txtname = new TextBox();
            txtnamsinh = new TextBox();
            txtdiachi = new TextBox();
            txtmalop = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // btnsua
            // 
            btnsua.Location = new Point(1227, 3);
            btnsua.Name = "btnsua";
            btnsua.Size = new Size(94, 29);
            btnsua.TabIndex = 5;
            btnsua.Text = "button1";
            btnsua.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(1230, 54);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 6;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // txtma
            // 
            txtma.Font = new Font("Times New Roman", 17F);
            txtma.Location = new Point(25, 20);
            txtma.Name = "txtma";
            txtma.Size = new Size(125, 40);
            txtma.TabIndex = 7;
            // 
            // txtname
            // 
            txtname.Font = new Font("Times New Roman", 17F);
            txtname.Location = new Point(219, 20);
            txtname.Name = "txtname";
            txtname.Size = new Size(313, 40);
            txtname.TabIndex = 8;
            // 
            // txtnamsinh
            // 
            txtnamsinh.Font = new Font("Times New Roman", 17F);
            txtnamsinh.Location = new Point(538, 20);
            txtnamsinh.Name = "txtnamsinh";
            txtnamsinh.Size = new Size(135, 40);
            txtnamsinh.TabIndex = 9;
            // 
            // txtdiachi
            // 
            txtdiachi.Font = new Font("Times New Roman", 17F);
            txtdiachi.Location = new Point(700, 20);
            txtdiachi.Name = "txtdiachi";
            txtdiachi.Size = new Size(238, 40);
            txtdiachi.TabIndex = 10;
            txtdiachi.TextChanged += textBox4_TextChanged;
            // 
            // txtmalop
            // 
            txtmalop.Font = new Font("Times New Roman", 17F);
            txtmalop.Location = new Point(970, 20);
            txtmalop.Name = "txtmalop";
            txtmalop.Size = new Size(125, 40);
            txtmalop.TabIndex = 11;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(1127, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(94, 29);
            btnOK.TabIndex = 12;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(1130, 54);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(94, 29);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // UserControl2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtmalop);
            Controls.Add(txtdiachi);
            Controls.Add(txtnamsinh);
            Controls.Add(txtname);
            Controls.Add(txtma);
            Controls.Add(button2);
            Controls.Add(btnsua);
            Name = "UserControl2";
            Size = new Size(1324, 86);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnsua;
        private Button button2;
        private TextBox txtma;
        private TextBox txtname;
        private TextBox txtnamsinh;
        private TextBox txtdiachi;
        private TextBox txtmalop;
        private Button btnOK;
        private Button btnCancel;
    }
}
