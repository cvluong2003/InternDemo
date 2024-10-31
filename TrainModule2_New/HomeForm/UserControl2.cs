using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainModule2_New.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HomeForm
{
    
    public partial class UserControl2 : UserControl
    {
        public event EventHandler buttonOkClick;
        public UserControl2()
        {
            InitializeComponent();
            this.Load += UserControl2_Load;
            btnsua.Click += Btnsua_Click;
            btnCancel.Click += BtnCancel_Click;
            btnOK.Click += BtnOK_Click;
        }
        
        public SinhVienDTO selectData()
        {
            SinhVienDTO sv=new SinhVienDTO();
            sv.masv=txtma.Text;
            sv.namsinh=txtnamsinh.Text;
            sv.diachi=txtdiachi.Text;
            sv.tensv=txtname.Text;
            sv.malop=txtmalop.Text;
            sv.namsinh = txtnamsinh.Text;
            return sv;
        }
       
        private void BtnOK_Click(object? sender, EventArgs e)
        {
            buttonOkClick?.Invoke(this, EventArgs.Empty);  
            
        }
        public SinhVienDTO sendData()
        {
            SinhVienDTO sv = new SinhVienDTO();
            sv.masv = txtma.Text;
            sv.tensv = txtname.Text;
            sv.namsinh = txtnamsinh.Text.ToString().Substring(6,4);
            sv.ngaysinh = txtnamsinh.Text;
            sv.diachi = txtdiachi.Text;
            sv.malop = txtmalop.Text;
           
            return sv;
        }
        //private async Task<bool> callAPIUpdateSinhVien(SinhVienDTO sv,string endpoint)
        //{
        //    HttpResponseMessage response= 

        //}
        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            btnOK.Visible = false;
            btnsua.Visible = true;
            button2.Visible = true;
            btnCancel.Visible = false;
        }

        private void Btnsua_Click(object? sender, EventArgs e)
        {
            txtname.Enabled = true;
            txtnamsinh.Enabled = true;
            txtdiachi.Enabled = true;
            txtmalop.Enabled = true;
            btnOK.Visible = true;
            btnCancel.Visible = true;
            btnsua.Visible = false;
            button2.Visible = false;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Vẽ đường thẳng
            using (Pen pen = new Pen(Color.Black, 2)) // Đặt màu và độ dày cho đường thẳng
            {
                // Vẽ đường thẳng từ điểm (0, Height) đến (Width, Height)
                e.Graphics.DrawLine(pen, 0, this.Height, this.Width, this.Height);
            }
        }
        private void UserControl2_Load(object? sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                if (c is System.Windows.Forms.TextBox textbox)
                {
                    Size textSize = TextRenderer.MeasureText(textbox.Text, textbox.Font);
                    textbox.Width = textSize.Width + 10; // Thêm một chút khoảng cách
                    textbox.BorderStyle = BorderStyle.None;
                    textbox.BackColor = this.BackColor;
                }
            }
            btnOK.Visible = false;
            btnCancel.Visible=false;
            btnsua.Text = "Sửa";
            button2.Text = "Xóa";
            txtma.Enabled= false;
            txtname.Enabled = false;
            txtnamsinh.Enabled = false;
            txtdiachi.Enabled = false;
            txtmalop.Enabled = false;
        }
        public void LoadData(SinhVienDTO sinhVienDTO)
        {
            //string baseurl = "https://localhost:7220/";
            //string resourceurl = "api/SinhVien";
            //string paramurl = "?page=2";
            //string fullurl=baseurl+ resourceurl+paramurl;
            txtma.Text = sinhVienDTO.masv;
            txtname.Text = sinhVienDTO.tensv;
            txtnamsinh.Text = sinhVienDTO.ngaysinh.ToString();
            txtdiachi.Text = sinhVienDTO.diachi;
            txtmalop.Text = sinhVienDTO.malop;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

   }

        
    }
