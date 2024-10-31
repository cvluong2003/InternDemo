using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 
using System.Net.Http;

namespace GUI
{
    public partial class DN : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public DN()
        {
            InitializeComponent();
            btnexit.Click += Btnexit_Click;
            btnlogin.Click += Btnlogin_Click;
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
    (sender, certificate, chain, sslPolicyErrors) => true;
        }

        private async void Btnlogin_Click(object sender, EventArgs e)
        {
            string name=txtusername.Text.Trim();
            string password=txtpassword.Text.Trim();
            string statuscode = await login(name, password);
            if(statuscode=="OK")
            {
                MessageBox.Show("Đăng nhập thành công " +statuscode);
            }
            else 
            {
                MessageBox.Show("Đăng nhập không thành công "+statuscode);
            }
        }

        private void Btnexit_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát ", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(rs==DialogResult.OK)
            {
                this.Close();
            }

        }
        private async Task<string> login(string username, string password)
        {
            var json = $"{{\"magv\":\"{username}\",\"pass\":\"{password}\"}}";
            var content =new StringContent(json,UTF8Encoding.UTF8,"application/json");
            var response = await client.PostAsync("https://localhost:7220/api/GiaoVien/login", content);
            //response.EnsureSuccessStatusCode();
            var statuscode = response.StatusCode.ToString();
            //if (!response.IsSuccessStatusCode)
            //{
            //    var errorContent = await response.Content.ReadAsStringAsync();
            //    return errorContent;
            //}

            return statuscode;
        }
        
    }
}
