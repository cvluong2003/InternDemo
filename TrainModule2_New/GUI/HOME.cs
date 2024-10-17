using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
namespace GUI
{
    public partial class HOME : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public HOME()
        {
            InitializeComponent();
            this.Load += HOME_Load;
        }

        private void HOME_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource
        }
        //private async Task<bool> getAllSinhVien()
        //{
        //    var kq = await client.GetAsync("https://localhost:7220/api/SinhVien");
        //    var lst = kq.Content;
        //    return lst;
        //}
    }
}
