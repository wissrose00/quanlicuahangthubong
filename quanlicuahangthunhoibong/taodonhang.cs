using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace quanlicuahangthunhoibong
{
    public partial class taodonhang : Form
    {
        db conn = new db();
        public taodonhang()
        {
            InitializeComponent();
        }

        private void taodonhang_Load(object sender, EventArgs e)
        {
            loaddata();
            comboBox1.SelectedIndex = 0;
            label15.Text = login.Name_USER;
        }
        // hiện sản phẩm 
        public void loaddata()
        {
            string cmnd = "select * from v_2 ";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 70;
                dataGridView1.Columns[1].Width = 355;
                dataGridView1.Columns[2].Width = 110;
            }
            dataGridView1.ClearSelection();
        }

        // thêm
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.Enabled = true;
            cochon = true;
            var selectedRow = dataGridView1.SelectedRows[0];

            // Lưu lại để sử dụng ở nút Thêm
            selectedDataGridView1Row = selectedRow; 

        }
        // xóa
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Enabled = true;
            cochon1 = true;
        }
        private bool cochon = false;
        private bool cochon1 = false;

        public DataGridViewRow selectedDataGridView1Row { get; set; }
        // thêm sản phẩm 
        private void button2_Click(object sender, EventArgs e)
        {
            if (cochon)
            {   
                
                dataGridView2.Rows.Add(selectedDataGridView1Row.Cells[0].Value,
                            selectedDataGridView1Row.Cells[1].Value, selectedDataGridView1Row.Cells[2].Value, "1", selectedDataGridView1Row.Cells[2].Value
                            );
                dataGridView2.ClearSelection();
                dataGridView1.ClearSelection();
                cochon = false;
                total();
            }
        }
        // xóa sanr phẩm 
        private void button3_Click(object sender, EventArgs e)
        {
            if (cochon1)
            {
                int selectedRowIndex = dataGridView2.CurrentCell.RowIndex;

                dataGridView2.Rows.RemoveAt(selectedRowIndex);


                dataGridView2.ClearSelection();
                cochon1 = false;
                total();
            }
        }

        // tính tiền 
        void total() {

            int sl = 0;
            double tong = 0.00;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView2.Rows[i];
                int tt = Convert.ToInt32(row.Cells[4].Value);
                tong += tt;
                sl++;
            }

            // Hiển thị tổng số lượng
            label11.Text = sl.ToString();
            label12.Text = tong.ToString();

            if (comboBox1.SelectedIndex != -1)
            {
                double a = tong * double.Parse(comboBox1.SelectedItem.ToString()) / 100;

                tong = tong - a;
            }
            
            label10.Text = tong.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            total();
        }

        // nút thanh tóan
        private void button1_Click(object sender, EventArgs e)
        {
            thanhtoan(label15.Text, textBox1.Text, textBox2.Text, label10.Text);
            textBox2.Text = label12.Text = label11.Text = label10.Text = "";
            comboBox1.SelectedIndex = -1;
            loaddata();
        }

        // thanh toán 
        private void thanhtoan(string nhanvien, string khach, string sdt, string tongtien)
        {
            string cmnd = "sp_ThemHoaDon '" + nhanvien + "',N'" + khach + "','" + sdt + "','" + tongtien + "'";
            DataTable dt = conn.readdata(cmnd);
            string a = "";
            if (dt != null)
            {
                a = dt.Rows[0][0].ToString();
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    string cm = "sp_ThemHoaDonCT '" + a + "','" + dataGridView2.Rows[i].Cells[0].Value.ToString() + "','1','" + dataGridView2.Rows[i].Cells[2].Value.ToString() + "'";
                    bool y = conn.exedata(cm);
                }
                dataGridView2.Rows.Clear();
                MessageBox.Show("Thanh toán thành công số tiền " + label10.Text);
            }
        }

        // tìm gấu 
        private void button4_Click(object sender, EventArgs e)
        {
            string cmnd = "select * from v_2 where [Tên sản phẩm] like  N'%" + textBox4.Text + "%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 70;
                dataGridView1.Columns[1].Width = 355;
                dataGridView1.Columns[2].Width = 110;
            }
            dataGridView1.ClearSelection();
           
        }
    }
}
