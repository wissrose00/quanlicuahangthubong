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
    public partial class login : Form
    {
        db conn = new db();
        public login()
        {
            InitializeComponent();
        }

        public static string ID_USER = "";
        public static string Name_USER = "";

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập tài khoản!");
                return;
            }
            if (String.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }
            log();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
                textBox2.PasswordChar = '*';
            if (checkBox1.Checked)
                textBox2.PasswordChar = '\0';
        }



        void tc_logout(object sender, EventArgs e)
        {
            (sender as ahome).isExit = false;
            (sender as ahome).Close();
            this.Show();
        }


        // ham dang nhap
        private void log()
        {
            ID_USER = getID(textBox1.Text, textBox2.Text);
            Name_USER = getName(textBox1.Text, textBox2.Text);
            string a = Name_USER;
            if (a != "")
            {
                ahome tc = new ahome();
                tc.Show();
                this.Hide();
                tc.logout += new EventHandler(tc_logout);
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin tài khoản !");
                System.Media.SystemSounds.Exclamation.Play();

            }
        }


        // lấy id 
        private string getID(string username, string password)
        {
            string id = "";
            String cmd = ("SELECT * FROM taikhoan WHERE tendangnhap ='" + username + "' and matkhau='" + password + "'");
            DataTable dt = conn.readdata(cmd);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    id = dr["maso"].ToString();
                }
            }
            return id;
        }
        // lay ten
        private string getName(string username, string password)
        {
            string id = "";
            String cmd = ("SELECT * FROM taikhoan WHERE tendangnhap ='" + username + "' and matkhau='" + password + "'");
            DataTable dt = conn.readdata(cmd);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    id = dr["tennguoidung"].ToString();
                }
            }
            return id;
        }

    }
}
