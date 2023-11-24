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
    public partial class thongke : Form
    {
        db conn = new db();
        public thongke()
        {
            InitializeComponent();
        }

        private void thongke_Load(object sender, EventArgs e)
        {
            r2.Checked = true;
        }


        // chọn 
        private void r1_CheckedChanged(object sender, EventArgs e)
        {   
            // chọn tất cả
            if (r1.Checked)
            {
                string cmnd = "select * from v_doanhthu  ";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns[0].Width = 100;
                    dataGridView2.Columns[1].Width = 300;
                    dataGridView2.Columns[2].Width = 120;
                    dataGridView2.Columns[3].Width = 120;
                    dataGridView2.Columns[4].Width = 100;
                    dataGridView2.Columns[5].Width = 170;


                }
                else MessageBox.Show("err");
                dataGridView2.ClearSelection();
                tinhtien();

            }
            // chọn hôm nay 
            if (r2.Checked)
            {

                string cmnd = "select * from v_doanhthu where  Ngày >= CAST(GETDATE() AS DATE) ";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns[1].Width = 300;
                    dataGridView2.Columns[2].Width = 120;
                    dataGridView2.Columns[3].Width = 120;
                    dataGridView2.Columns[4].Width = 100;
                    dataGridView2.Columns[5].Width = 170;

                }
                else MessageBox.Show("err");
                dataGridView2.ClearSelection();
                tinhtien();

            }
            // chọn tháng này 
            if (r3.Checked)
            {

                string cmnd = "select * from v_doanhthu  where YEAR([Ngày]) = YEAR(GETDATE()) AND MONTH([Ngày]) = MONTH(GETDATE()) ";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns[1].Width = 300;
                    dataGridView2.Columns[2].Width = 120;
                    dataGridView2.Columns[3].Width = 120;
                    dataGridView2.Columns[4].Width = 100;
                    dataGridView2.Columns[5].Width = 170;

                }
                else MessageBox.Show("err");
                dataGridView2.ClearSelection();
                tinhtien();

            }
            // chọn 3 tháng 
            if (r4.Checked)
            {

                string cmnd = "select * from v_doanhthu  where YEAR([Ngày]) = YEAR(GETDATE()) AND MONTH([Ngày]) BETWEEN MONTH(GETDATE()) - 2 AND MONTH(GETDATE()) ";

                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns[1].Width = 300;
                    dataGridView2.Columns[2].Width = 120;
                    dataGridView2.Columns[3].Width = 120;
                    dataGridView2.Columns[4].Width = 100;
                    dataGridView2.Columns[5].Width = 170;

                }
                else MessageBox.Show("err");
                dataGridView2.ClearSelection();
                tinhtien();
            }
            // chọn chọn ngày 
            if (r5.Checked)
            {

                string dt1 = dateTimePicker1.Value.ToString("yyyy'/'MM'/'dd");
                string cmnd = "select * from v_doanhthu where Ngày =  '" + dt1 + "'";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView2.DataSource = dt;
                    dataGridView2.Columns[1].Width = 300;
                    dataGridView2.Columns[2].Width = 120;
                    dataGridView2.Columns[3].Width = 120;
                    dataGridView2.Columns[4].Width = 100;
                    dataGridView2.Columns[5].Width = 170;

                }
                else MessageBox.Show("err");
                dataGridView2.ClearSelection();
                tinhtien();
            }
        }


        void tinhtien()
        {

            int tong = 0;
            int tsl = 0;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridView2.Rows[i];
                int tt = Convert.ToInt32(row.Cells[5].Value);
                int sl = Convert.ToInt32(row.Cells[4].Value);
                tsl += sl;
                tong += tt;
            }

            // Hiển thị tổng số lượng
            label18.Text = tsl.ToString();
            label17.Text = tong.ToString();
        }
    }
}
