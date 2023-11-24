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
    public partial class quanlidonhang : Form
    {
        db conn = new db();
        public quanlidonhang()
        {
            InitializeComponent();
            rd2.Checked = true;
        }

     
        // lọc danh sách hóa đơn theo từng lựa chọn 
        private void rd1_CheckedChanged(object sender, EventArgs e)
        {   // tất cả 
            if (rd1.Checked)
            {
                string cmnd = "select * from v_hoadon";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;

                }
                dataGridView1.ClearSelection();
                label14.Text =" SL: "+ dataGridView1.Rows.Count ;
            }
            if (rd2.Checked)
                // hôm nay 
            {
                string cmnd = "select * from v_hoadon where  Ngày >= CAST(GETDATE() AS DATE)";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;
                }
                dataGridView1.ClearSelection();
                label14.Text = " SL: " + dataGridView1.Rows.Count;
            }
            // tháng này
            if (rd3.Checked)
            {
                string cmnd = "select * from v_hoadon where YEAR([Ngày]) = YEAR(GETDATE()) AND MONTH([Ngày]) = MONTH(GETDATE()) ";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;

                }
                dataGridView1.ClearSelection();
                label14.Text = " SL: " + dataGridView1.Rows.Count;
            }
            // chọn ngày 
            if (rd4.Checked)
            {
                string dt1 = dateTimePicker1.Value.ToString("yyyy'/'MM'/'dd");
                string cmnd = "select * from v_hoadon where [Ngày] =  '" + dt1 + "'";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;

                }
                dataGridView1.ClearSelection();
                label14.Text = " SL: " + dataGridView1.Rows.Count;
            }
        }


        // Bấm 1 dòng trong danh sấch hóa đơn sau đó đổ thông tin hóa đơn ra 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            string a = dataGridView1.Rows[row].Cells[0].Value.ToString();
            label12.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            label13.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
            label7.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
            label8.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();
            label9.Text = dataGridView1.Rows[row].Cells[5].Value.ToString();


            string cmnd = "select * from v_hoadonCT where HD =  "+ a;
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView3.DataSource = dt;
            }
            dataGridView3.ClearSelection();

            label1.Text = "SL: " +dataGridView3.Rows.Count + "món";

        }


    }
}
