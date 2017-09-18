using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo1._1._3
{
    public partial class Sign_in : Form
    {
        FunctionForSign fcs = new FunctionForSign();

        public static string storage;//仓库权限码
        public static string sendcar;//派车权限码
        public static string transpotation;//运输权限码
        public static string basic;//基础权限码

        public static string name; //登录人姓名

        public Sign_in()
        {
            InitializeComponent();
        }

        private void Sign_in_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Paint(object sender, PaintEventArgs e)
        {

        }
         
        private void simpleButton2_Click(object sender, EventArgs e) //重置
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e) //登录
        {
            domain.权限.User user = new domain.权限.User();
           domain.权限.Role role = new domain.权限.Role();
            user = fcs.getPassword(textBox1.Text);
           
            if (user.password == textBox2.Text)
            {
                role = user.Role[0];
                storage = role.storage.ToString();
                sendcar = role.sendcar.ToString();
                transpotation = role.transpotation.ToString();
                basic = role.basic.ToString();
                name = user.name.ToString();
                Form1 form = new Form1();
                form.ShowDialog();

                this.Close();
                
            }
            else
            {
                MessageBox.Show("用户名或密码错误，请重新输入！");
            }
            
        }
    }
}
