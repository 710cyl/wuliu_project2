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
    public partial class New_CapitalAccount : Form
    {

        domain.Fund_Accounts bs = new domain.Fund_Accounts();
        FunctionClass fc = new FunctionClass();
        public New_CapitalAccount()
        {
            InitializeComponent();

            if (Panel2_Basic_UserControl.CapitalAccount.isExist)
            {
                comboBox_account_property.Text = Panel2_Basic_UserControl.CapitalAccount.array[1];
                account_name.Text = Panel2_Basic_UserControl.CapitalAccount.array[2];
                bank_deposit.Text = Panel2_Basic_UserControl.CapitalAccount.array[3];
                account_number.Text = Panel2_Basic_UserControl.CapitalAccount.array[4];
                initial_balance.Text = Panel2_Basic_UserControl.CapitalAccount.array[5];
                collection_sum.Text = Panel2_Basic_UserControl.CapitalAccount.array[6];
                payment_sum.Text = Panel2_Basic_UserControl.CapitalAccount.array[7];
                remaining_sum.Text = Panel2_Basic_UserControl.CapitalAccount.array[8];
                statement.Text = Panel2_Basic_UserControl.CapitalAccount.array[9];
            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e) //增加
        {
            if (Panel2_Basic_UserControl.CapitalAccount.isExist)
            {
                var guid = new Guid(Panel2_Basic_UserControl.CapitalAccount.array[0]);
                bs.ID = guid;
                bs.account_property = comboBox_account_property.Text;
                bs.account_name = account_name.Text;
                bs.bank_deposit = bank_deposit.Text;
                bs.account_number = Convert.ToInt32(account_number.Text);
                bs.initial_balance = Convert.ToDecimal(initial_balance.Text);
                bs.payment_sum = Convert.ToDecimal(payment_sum.Text);
                bs.remaining_sum = Convert.ToDecimal(remaining_sum.Text);
                bs.statement = statement.Text;

                fc.updateData(bs);
            }

            else
            {
                bs.ID = Guid.NewGuid();
                bs.account_property = comboBox_account_property.Text;
                bs.account_name = account_name.Text;
                bs.bank_deposit = bank_deposit.Text;
                bs.account_number = Convert.ToInt32(account_number.Text);
                bs.initial_balance = Convert.ToDecimal(initial_balance.Text);
                bs.payment_sum = Convert.ToDecimal(payment_sum.Text);
                bs.remaining_sum = Convert.ToDecimal(remaining_sum.Text);
                bs.statement = statement.Text;

                fc.saveData(bs);
            }

            Close();
        }

        private void simpleButton5_Click(object sender, EventArgs e)  //关闭
        {
            Close();
        }
    }
}
