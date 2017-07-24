using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebSocketSharp;
using Newtonsoft.Json;

namespace Demo1._1._3.MyWorkBench_SkipForm
{
    public partial class NewBasic : Form
    {
        domain.Basic_Set bs = new domain.Basic_Set();
        FunctionClass fc = new FunctionClass();
        public NewBasic()
        {
            InitializeComponent();

            if (Basic_Set.isExist)
            {
                textBox_position_Set.Text = Basic_Set.array[1];
                textBox_account_Receive.Text = Basic_Set.array[2];
                textBox_account_Pay.Text = Basic_Set.array[3];
                textBox_storage_Mode.Text = Basic_Set.array[4];
                textBox_outStorage_Mode.Text = Basic_Set.array[5];
                textBox_transportation_Mode.Text = Basic_Set.array[6];
                textBox_post_Property.Text = Basic_Set.array[7];
                textBox_borrow_Property.Text = Basic_Set.array[8];
                textBox_customer_Type.Text = Basic_Set.array[9];
                textBox_expense_Category.Text = Basic_Set.array[10];
                textBox_nationality.Text = Basic_Set.array[11];
                TextBox_storage.Text = Basic_Set.array[12];
                textBox_refund_Mode.Text = Basic_Set.array[13];
                textBox_oil_Varirety.Text = Basic_Set.array[14];

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //********************
        //按钮“关闭”单击事件
        //********************
        private void simpleButton2_Close_Click(object sender, EventArgs e)
        {
            Close();
            
        }
        //********************
        //按钮“保存”单击事件
        //********************
        private void simpleButton1_Save_Click(object sender, EventArgs e)
        {

            if (Basic_Set.isExist)
            {
                var guid = new Guid(Basic_Set.array[0]);
                bs.ID = guid;
                bs.position_Set = textBox_position_Set.Text;
                bs.account_Receive = Convert.ToDecimal(textBox_account_Receive.Text);
                bs.account_Pay = Convert.ToDecimal(textBox_account_Pay.Text);
                bs.storage_Mode = textBox_storage_Mode.Text;
                bs.outStorage_Mode = textBox_outStorage_Mode.Text;
                bs.transportation_Mode = textBox_transportation_Mode.Text;
                bs.post_Property = textBox_post_Property.Text;
                bs.borrow_Property = textBox_borrow_Property.Text;
                bs.customer_Type = textBox_customer_Type.Text;
                bs.expense_Category = textBox_expense_Category.Text;
                bs.nationality = textBox_nationality.Text;
                bs.storage = TextBox_storage.Text;
                bs.refund_Mode = textBox_refund_Mode.Text;
                bs.oil_Varirety = textBox_oil_Varirety.Text;

                fc.updateData(bs);
            }
            else
            {
                bs.ID = Guid.NewGuid();
                bs.position_Set = textBox_position_Set.Text;
                bs.account_Receive = Convert.ToDecimal(textBox_account_Receive.Text);
                bs.account_Pay = Convert.ToDecimal(textBox_account_Pay.Text);
                bs.storage_Mode = textBox_storage_Mode.Text;
                bs.outStorage_Mode = textBox_outStorage_Mode.Text;
                bs.transportation_Mode = textBox_transportation_Mode.Text;
                bs.post_Property = textBox_post_Property.Text;
                bs.borrow_Property = textBox_borrow_Property.Text;
                bs.customer_Type = textBox_customer_Type.Text;
                bs.expense_Category = textBox_expense_Category.Text;
                bs.nationality = textBox_nationality.Text;
                bs.storage = TextBox_storage.Text;
                bs.refund_Mode = textBox_refund_Mode.Text;
                bs.oil_Varirety = textBox_oil_Varirety.Text;

                fc.saveData(bs);
            }
            Close();
        }
    }
}
