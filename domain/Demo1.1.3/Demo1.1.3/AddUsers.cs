using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Demo1._1._3
{
    public partial class AddUsers : Form
    {
        FunctionForSign fcs = new FunctionForSign();
        FunctionClass fc = new FunctionClass();
        public AddUsers()
        {
            InitializeComponent();

            comboBox1.DisplayMember = "角色名";
            comboBox1.ValueMember = "value";
            comboBox1.DataSource = fc.getRoleName();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            domain.权限.User user = new domain.权限.User();
            user.name = textEdit1.Text;
            user.password = textEdit2.Text;

            user.Role = fcs.getAuthority(comboBox1.Text);

            fcs.saveUser(user);

            Thread.Sleep(200);
            Close();
        }
    }
}
