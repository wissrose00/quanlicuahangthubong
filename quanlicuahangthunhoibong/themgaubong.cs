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
    public partial class themgaubong : Form
    {
        db conn = new db();
        public string id;

        public themgaubong(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // hiện danh sách loại gấu bông 
        private void loaddanhmuc()
        {
            string cmnd = "select * from loaigau where maso not like 6";
            DataTable dt = conn.readdata(cmnd);
            if (dt != null)
            {
                cb1.DataSource = dt;
                cb1.DisplayMember = "ten";
                cb1.ValueMember = "maso";
            }
            cb1.SelectedValue = -1;

        }

        // nút lưu
        private void button1_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                add();
            }
            else
            {
                sua();
            }
        }

       
        // thêm sản phẩm 
        private void add()
        {
            DateTime t1 = dt1.Value;
            string cmd = "SP_them_sanpham N'" + t2.Text + "','" + t3.Text + "','" + t4.Text + "','" + t1.ToString("yyyy'/'MM'/'dd") + "','" + cb1.SelectedValue + "'";

            if (conn.exedata(cmd) == true)
            {
                MessageBox.Show("Đã thêm");
            }
            else
            {
                MessageBox.Show("Không thể thêm");
            }
            this.Close();
        }

        // sửa sản phẩm 
        private void sua()
        {
            DateTime dt = dt1.Value;
            string cmd = "SP_sua_sanpham '" + t1.Text + "',N'" + t2.Text + "','" + t3.Text + "','" + t4.Text + "','" + dt.ToString("yyyy'/'MM'/'dd") + "','" + cb1.SelectedValue + "'";

            if (conn.exedata(cmd) == true)
            {
                MessageBox.Show("Đã sửa");
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể sửa");
            }
        }

        private void themgaubong_Load(object sender, EventArgs e)
        {
            loaddanhmuc();
            if (id != "") { dodulieu(id); }
        }


        private void dodulieu(string id)
        {

            string cmnd = "select * from gaubong  where maso = " + id;
            DataTable dt = conn.readdata(cmnd);
            if (dt != null)
            {
                t1.Text = dt.Rows[0]["maso"].ToString();
                t2.Text = dt.Rows[0]["ten"].ToString();
                cb1.SelectedValue = dt.Rows[0]["loai"];
                t3.Text = dt.Rows[0]["gia"].ToString();
                dt1.Value = DateTime.Parse(dt.Rows[0]["ngaynhap"].ToString());
                t4.Text = dt.Rows[0]["soluong"].ToString();
            }
        }
    }
}
