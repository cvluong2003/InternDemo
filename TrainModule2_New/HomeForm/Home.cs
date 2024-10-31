using TrainModule2_New.DTOs;
using System.Text.Json;
using System.Collections.Generic;
using System.Data.SqlTypes;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Http;
using Azure;
using System.Windows.Forms;
using System.Text;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
namespace HomeForm
{
    public partial class Home : Form
    {
        private readonly HttpClient client = new HttpClient();
        int numberofPage;
        int recordPerPage = 4;
        public Home()
        {

            InitializeComponent();
            comboBox1.Items.Add("Tất cả");
            comboBox1.Items.Add("001");
            comboBox1.Items.Add("002");
            comboBox1.SelectedItem = comboBox1.Items[0];
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            this.Load += Home_Load;
            btnincrease.Click += Btnincrease_Click;
            btndecrease.Click += Btndecrease_Click;
            //panel1.AutoSize = true; // Bật tính năng tự động điều chỉnh kích thước
            //panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //this.AutoSize = true;
            //this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            textBox1.Enabled = false;
            textBox1.Text = "1";
            
          
        }

        private async void UserControl2_buttonOkClick(object? sender, EventArgs e)
        {
            var control = sender as UserControl2;
            if (control != null)
            {
                var sv = control.sendData();
                if (sv != null) { 
                   string endpoint="https://localhost:7220/api/SinhVien/";
                   string svID = control.sendData().masv;
                    string fullEndpoint = endpoint + svID;
                    if(!client.DefaultRequestHeaders.Contains("Serect-key"))
                    {
                        client.DefaultRequestHeaders.Add("Serect-key","123");
                    }
                    bool rs =await callAPIupdateStudentByPutMethod(sv, fullEndpoint);
                    if (rs)
                    {
                        MessageBox.Show("Update Successfully");
                        int currentPage = int.Parse(textBox1.Text);
                        await loadDataRow(await callAPIgetAllStudent(conCatUrlwithParamGetAllAPI(int.Parse(textBox1.Text)), recordPerPage.ToString()), recordPerPage);
                    }
                }
            }
        }

        async  private void Btndecrease_Click(object? sender, EventArgs e)
        {
            btnincrease.Enabled = true;
            if (int.Parse(textBox1.Text) ==1)
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text = (int.Parse(textBox1.Text) - 1).ToString();
            }
            var lstAll = await callAPIgetAllStudent(conCatUrlwithParamGetAllAPI(int.Parse(textBox1.Text)), recordPerPage.ToString());

            if (comboBox1.SelectedIndex == 0)
            {
                resetDataRow();
                await loadDataRow(await callAPIgetAllStudent(conCatUrlwithParamGetAllAPI(int.Parse(textBox1.Text)), recordPerPage.ToString()), recordPerPage);
            }
            else
            {
                //var lst = await callAPIgetAllStudent("https://localhost:7220/api/SinhVien", recordPerPage.ToString());
                //var lstClasscode = lst.Where(sv => sv.malop == "L" + comboBox1.SelectedItem.ToString()).ToList();
                loadDataRowsWithClasscode(comboBox1.SelectedItem.ToString());
            }
        }

       async private void Btnincrease_Click(object? sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) == 0)
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text = (int.Parse(textBox1.Text) + 1).ToString();
            }
            var lstAll = await callAPIgetAllStudent(conCatUrlwithParamGetAllAPI(int.Parse(textBox1.Text)), recordPerPage.ToString());
         
            if (comboBox1.SelectedIndex == 0)
            {
                resetDataRow();
                await loadDataRow(await callAPIgetAllStudent(conCatUrlwithParamGetAllAPI(int.Parse(textBox1.Text)), recordPerPage.ToString()), recordPerPage);
            }
            else
            {
                //var lst = await callAPIgetAllStudent("https://localhost:7220/api/SinhVien", recordPerPage.ToString());
                //var lstClasscode = lst.Where(sv => sv.malop == "L" + comboBox1.SelectedItem.ToString()).ToList();
                loadDataRowsWithClasscode(comboBox1.SelectedItem.ToString());
            }
            btndecrease.Enabled = true;
        }
        private async void loadDataRowsWithClasscode(string classcode)
        {
            var lstClassCode = await callAPIgetStudentByClasscode(classcode, textBox1.Text, recordPerPage.ToString());
            if (lstClassCode.Count < recordPerPage)
            {
                btnincrease.Enabled = false;
            }
            if (textBox1.Text == "1")
            {
                btndecrease.Enabled = false;
            }
            resetDataRow();
            await loadDataRow(lstClassCode, recordPerPage);
        }
        private async void loadDataRowAllClassCode(int page)
        {
            string fullEndpointGetAll = conCatUrlwithParamGetAllAPI(page);

            var lst = await callAPIgetAllStudent(fullEndpointGetAll, recordPerPage.ToString());
            if (lst.Count<recordPerPage)
            {
                btnincrease.Enabled = false;
            }
            if(textBox1.Text=="1")
            {
                btndecrease.Enabled = false;
            }
            resetDataRow();
            
            await loadDataRow(lst, recordPerPage);
        }
        private async void ComboBox1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            textBox1.Text = 1.ToString();
            if (comboBox1.SelectedIndex != 0) { 
                loadDataRowsWithClasscode(comboBox1.SelectedItem.ToString());
              
            }
            else
            {
                loadDataRowAllClassCode(int.Parse(textBox1.Text));
            }

        }
        async public Task<bool> callAPIupdateStudentByPutMethod(SinhVienDTO sv ,string endpoint)
        {

            var json=JsonSerializer.Serialize(sv);
            var content=new StringContent(json,Encoding.UTF8,"application/json");
            HttpResponseMessage response =await client.PutAsync(endpoint, content);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        async private Task<List<SinhVienDTO>> callAPIgetStudentByClasscode(string studentClasscode,string page,string rowperpage)
        {
            if(!client.DefaultRequestHeaders.Contains("rowperpage"))
            {
                client.DefaultRequestHeaders.Add("rowperpage", rowperpage);
            }
            if(!client.DefaultRequestHeaders.Contains("Serect-code"))
            {
                client.DefaultRequestHeaders.Add("Serect-code", "123");
            }
            try
            {
                //client.DefaultRequestHeaders.Add("Serect-code", "123");
                //client.DefaultRequestHeaders.Add("rowperpage", "4");
                string url = "https://localhost:7220/api/sinhvien/class?classcode=L";
             
                string paging=string.Empty;
                if(page!=string.Empty)
                {
                    paging = "&page=" + page;
                }
                string param = studentClasscode+paging;
                string fullurl = url + param;
                HttpResponseMessage response = await client.GetAsync(fullurl);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var listsv = JsonSerializer.Deserialize<List<SinhVienDTO>>(responseBody);
                    return listsv.OrderBy(col => int.Parse(col.masv)).ToList();
                }
                else
                {
                    return new List<SinhVienDTO>();
                }
            }
            catch (Exception ex)
            {
                return new List<SinhVienDTO>();
            }
        }
        async public Task loadDataRow(List<SinhVienDTO> lst,int rowperpage)
        {
       

            
            if (lst.Count() != 0)
            {
                int top = panel1.Top;

                int left = panel1.Left;
                foreach (var item in lst)
                {
                    UserControl2 us2 = new UserControl2();
                    us2.LoadData(item);
                    us2.Location = new Point(left, top);
                    panel1.Controls.Add(us2);
                    top += us2.Height + 10;
                    us2.buttonOkClick += UserControl2_buttonOkClick;
                }
               
            }
            else
            {
                Blank uc2=new Blank();
                panel1.Controls.Add(uc2);
            }
            numberofPage = lst.Count();
           
        }
        public void resetDataRow()
        {
            panel1.Controls.Clear();
        }
        async public Task<bool> callAPIUpdateSinhVien(string url)
        {
            UserControl2 userControl2 = new UserControl2();
            try
            {
                var json = JsonSerializer.Serialize(userControl2.sendData());
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response =await client.PutAsync(url, content);
                if(response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        async public Task<List<SinhVienDTO>> callAPIgetAllStudent(string url,string rowperpage)
        {
            try
            {
                if (!client.DefaultRequestHeaders.Contains("Serect-code"))
                {
                    client.DefaultRequestHeaders.Add("Serect-code", "123");
                }
                if (!client.DefaultRequestHeaders.Contains("rowperpage"))
                {

                    client.DefaultRequestHeaders.Add("rowperpage", rowperpage);
                }
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var listsv = JsonSerializer.Deserialize<List<SinhVienDTO>>(responseBody);
                    return listsv.OrderBy(col => int.Parse(col.masv)).ToList();
                }
                else
                {
                    return new List<SinhVienDTO>();
                }
            }
            catch (Exception ex)
            {
                return new List<SinhVienDTO>();
            }

        }
        private string conCatUrlwithParamGetAllAPI(int page)
        {
            string urlGetAll = "https://localhost:7220/api/SinhVien";
            string paramGetAll = "?page=" + page.ToString();
            string fullEndpointGetAll = string.Concat(urlGetAll, paramGetAll);
            return fullEndpointGetAll;
        }
        async private void Home_Load(object? sender, EventArgs e)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
    (sender, certificate, chain, sslPolicyErrors) => true;
            //var lst=await  callAPIgetAllStudent("https://localhost:7220/api/SinhVien");
            int page = 1;
            string fullEndpointGetAll = conCatUrlwithParamGetAllAPI(page);
            
            var lst = await callAPIgetAllStudent(fullEndpointGetAll,recordPerPage.ToString());
            await loadDataRow(lst,4 );
            //dataGridView1.DataSource = lst;

            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //int totalHeight = 0;
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    totalHeight += row.Height;
            //}


            //totalHeight += dataGridView1.ColumnHeadersHeight;

            //dataGridView1.Height = totalHeight;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
