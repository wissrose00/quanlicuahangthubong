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
    public partial class ahome : Form
    {
        db conn = new db();
        public bool isExit = true;
        public event EventHandler logout;
        public ahome()
        {
            InitializeComponent();
           
        }

        private void ahome_Load(object sender, EventArgs e)
        {
            if (login.ID_USER == "1")
            {
                comboBox1.SelectedIndex = 0;
            }
            else comboBox1.SelectedIndex = 1;
        }

        // nút đăng xuất
        private void button2_Click(object sender, EventArgs e)
        {
            logout(this, new EventArgs());
        }

        private void ahome_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
                Application.Exit();
        }


        private void ahome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            {
                if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình ?", "Thông báo ", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                {
                    e.Cancel = true;
                }

            }
        }


        // thêm gấu bông 
        private void button10_Click(object sender, EventArgs e)
        {
            themgaubong tgb = new themgaubong("");
            tgb.ShowDialog();
        }

        // mở các form quản lí 
        private Form activeForm = null;
        private void openChildFormInPanel(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel5.Controls.Add(childForm);
            panel5.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // nút qli gấu 
        private void button3_Click(object sender, EventArgs e)
        {
            
            openChildFormInPanel(new quanligau());
        }

        // nút quay lại 
        private void button12_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
           
        }

        // nút đơn hàng 
        private void button4_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new quanlidonhang());
        }

        // nút tạo đơn hàng 
        private void button5_Click(object sender, EventArgs e)
        {
            taodonhang tdh = new taodonhang();
            tdh.ShowDialog();
        }

        // nút thống kê 
        private void button9_Click(object sender, EventArgs e)
        {
            openChildFormInPanel(new thongke());
        }
        // nút trang chủ 
        private void button1_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

        }
    }
}
