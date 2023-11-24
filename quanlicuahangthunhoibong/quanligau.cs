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
    public partial class quanligau : Form
    {
        db conn = new db();
        public quanligau()
        {
            InitializeComponent();
            loaddanhmuc();
            loaddata();
        }

        // xóa gấu 
        private void button1_Click(object sender, EventArgs e)
        {
            del();
        }
        private void del()
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            string a = dataGridView1.Rows[row].Cells[0].Value.ToString();
            string cmd = "delete gaubong where maso = " + a;
            DialogResult dlg = MessageBox.Show("Bạn có chắc chắn muốn xóa không ? ", " Thông Báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == DialogResult.Yes)
            {
                if (conn.exedata(cmd) == true)
                {
                    MessageBox.Show("Đã xóa dữ liệu");
                }
                else
                {
                    MessageBox.Show("Không thể xóa dữ liệu");
                }
                loaddata();
            }

        }

        // k phải admin thì k nhấn dc 2 nút sửa xóa 
        private void quanligau_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 5;
            if (login.ID_USER != "1") {
                button2.Enabled = button3.Enabled = false;
            
            }
        }


        // hiện gấu 
        public void loaddata()
        {
            string cmnd = "select * from v_1 ";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100; 
            }
            dataGridView1.ClearSelection();
            label2.Text = string.Format("Tổng cộng: {0} sản phầm.", dataGridView1.Rows.Count);

        }

        // hiện danh mục gấu
        private void loaddanhmuc()
        {
            string cmnd = "select * from loaigau";
            DataTable dt = conn.readdata(cmnd);
            if (dt != null)
            {
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "ten";
                comboBox1.ValueMember = "ten";
            }
            comboBox1.SelectedValue = -1;

        }


        // sửa gấu 
        private void button3_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            string a = dataGridView1.Rows[row].Cells[0].Value.ToString();
            themgaubong tgb = new themgaubong(a);
            tgb.ShowDialog();
        }

        // danh mục gấu
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex != 5)
            {
                string cmnd = "select * from v_1 where [Loại gấu] like  N'%"+comboBox1.SelectedValue+"%'";
                DataTable dt = conn.readdata(cmnd);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Width = 50;
                    dataGridView1.Columns[1].Width = 285;
                    dataGridView1.Columns[2].Width = 100;
                    dataGridView1.Columns[3].Width = 100;
                    dataGridView1.Columns[4].Width = 100;
                    dataGridView1.Columns[5].Width = 100;
                }
                dataGridView1.ClearSelection();
                label2.Text = string.Format("Tổng cộng: {0} sản phầm.", dataGridView1.Rows.Count);
            }
            else loaddata();
        }
       
        // nust tim kiem
        private void button1_Click_1(object sender, EventArgs e)
        {
            string cmnd = "select * from v_1 where [Tên sản phẩm] like  N'%" + textBox1.Text + "%'";
            DataTable dt = conn.readdata(cmnd);

            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 285;
                dataGridView1.Columns[2].Width = 100;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 100;
            }
            dataGridView1.ClearSelection();
            label2.Text = string.Format("Tổng cộng: {0} sản phầm.", dataGridView1.Rows.Count);
        }


        }
    }

