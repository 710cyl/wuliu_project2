using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo1._1._3.MyWorkBench_SkipForm
{
    public partial class New_InternalFleet : Form
    {
        domain.Internal_Vehicle iv = new domain.Internal_Vehicle();
        FunctionClass fc = new FunctionClass();
        public New_InternalFleet()
        {
            InitializeComponent();
            if (Internal_Fleet.isExist)
            {
                comboBox_motorcade.Text = Internal_Fleet.array[1];
                comboBox_carnumber.Text = Internal_Fleet.array[2];
                comboBox_driver.Text = Internal_Fleet.array[3];
                textBox_statement.Text = Internal_Fleet.array[4];
            }
        }

        private void NewInternalFleet_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)// 保存
        {
            if (Internal_Fleet.isExist)
            {
                var guid = new Guid(Internal_Fleet.array[0]);
                iv.ID = guid;
                iv.car_driver = comboBox_driver.Text;
                iv.car_number = comboBox_carnumber.Text;
                iv.motorcade = comboBox_motorcade.Text;
                iv.statement = textBox_statement.Text;

                fc.updateData(iv);
            }
            else
            {
                iv.ID = Guid.NewGuid();
                iv.car_driver = comboBox_driver.Text;
                iv.car_number = comboBox_carnumber.Text;
                iv.motorcade = comboBox_motorcade.Text;
                iv.statement = textBox_statement.Text;

                fc.saveData(iv);
            }

            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e) //关闭
        {
            Close();
        }
    }
}
