using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.ByteCode.Castle;
using domain;
using WebSocketSharp;
using Basic_SetTest;
using System.Threading;
using Newtonsoft.Json;
using System.Reflection;
using System.Data.OleDb;
using Newtonsoft.Json.Converters;
using Demo1._1._3.MyWorkBench_SkipForm;
using System.IO;
using DevExpress.XtraEditors;
using System.Drawing.Printing;

namespace Demo1._1._3.Panel2_Basic_UserControl
{
    public partial class CapitalAccount : UserControl
    {
        New_CapitalAccount nc;
        StringReader streamToPrint = null;
        Font printFont;
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据


        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码
        domain.Fund_Accounts fa = new Fund_Accounts();
        FunctionClass fc = new FunctionClass();

        public CapitalAccount()
        {
            InitializeComponent();

            total_Page = fc.getTotal<domain.Fund_Accounts>(fa, total_Page);
            fc.InitPage(dataNavigator_FundAccount, total_Page, now_Page);

            isEdit();
        }

        /// <summary>
        /// 判断是否可以编辑
        /// </summary>
        private void isEdit()
        {
            if (Sign_in.basic.Substring(18, 2) == "01")
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton7.Visible = false;
            }
        }

        private void dataNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page < total_Page)
                {
                    now_Page++;
                    dataNavigator_FundAccount.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Fund_Accounts bs = new domain.Fund_Accounts();
                    gridControl2.DataSource = fc.showData<domain.Fund_Accounts>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page > 1)
                {
                    now_Page--;
                    dataNavigator_FundAccount.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Fund_Accounts bs = new domain.Fund_Accounts();
                    gridControl2.DataSource = fc.showData<domain.Fund_Accounts>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page = 1;
                    dataNavigator_FundAccount.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Fund_Accounts bs = new domain.Fund_Accounts();
                    gridControl2.DataSource = fc.showData<domain.Fund_Accounts>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page = total_Page;
                    dataNavigator_FundAccount.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Fund_Accounts bs = new domain.Fund_Accounts();
                    gridControl2.DataSource = fc.showData<domain.Fund_Accounts>(bs, now_Page.ToString());
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)  //导入数据
        {
            string dataString = fc.getDataTable();

            if (dataString != null)
            {
                using (var ws = new WebSocket("ws://localhost:9000/BatchSave"))
                {
                    ws.Connect();
                    ws.Send(dataString);
                    ws.Close();
                }
                MessageBox.Show("导入成功！！");
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)  // 导出数据
        {
           
        }

        private void toolStripButton7_Click(object sender, EventArgs e) //删除
        {
            fc.DeleteData(this.gridView2, "Basic_Set");
        }

        private void toolStripButton2_Click(object sender, EventArgs e) //修改
        {
            colCount = gridView2.Columns.Count();
            array = new string[colCount];
            for (int i = 0; i < colCount; i++)
            {
                array[i] = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[i]);
            }
            if (array[0].Length > 0)
            {
                isExist = true;
                nc = new New_CapitalAccount();
                nc.ShowDialog();
            }
            else
            {
                MessageBox.Show("该条数据不含主键，无法修改");
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e) //新建
        {
            isExist = false;
            nc = new New_CapitalAccount();
            nc.ShowDialog();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e) //新 新建
        {
            panel3.Visible = true;
            isExist = false;
            textBox26.Text = Sign_in.name;
            textBox28.Text = Sign_in.name;
        }

        private void toolStripButton5_Click(object sender, EventArgs e) //查看
        {
            simpleButton6.Visible = false;
            colCount = gridView2.Columns.Count();
            array = new string[colCount];
            for (int i = 0; i < colCount; i++)
            {
                array[i] = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[i]);
            }
            if (array[0].Length > 0)
            {
                panel3.Visible = true;
                comboBox1.Text = array[1];
                textBox29.Text = array[2];
                textBox35.Text = array[3];
                textBox34.Text = array[4];
                textBox32.Text = array[5];
                textBox9.Text = array[6];
                textBox11.Text = array[7];
                textBox10.Text = array[8];
                textBox12.Text = array[9];
            }
            else
            {
                MessageBox.Show("该条数据不含主键，无法修改");
            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e) //修改
        {
            panel3.Visible = true;
            isExist = true;

            colCount = gridView2.Columns.Count();
            array = new string[colCount];
            for (int i = 0; i < colCount; i++)
            {
                array[i] = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[i]);
            }
            if (array[0].Length > 0)
            {
                panel3.Visible = true;
                comboBox1.Text = array[1];
                textBox29.Text = array[2];
                textBox35.Text = array[3];
                textBox34.Text = array[4];
                textBox32.Text = array[5];
                textBox9.Text = array[6];
                textBox11.Text = array[7];
                textBox10.Text = array[8];
                textBox12.Text = array[9];
            }
            else
            {
                MessageBox.Show("该条数据不含主键，无法修改");
            }
        }

        private void toolStripButton7_Click_1(object sender, EventArgs e) //删除
        {
            fc.DeleteData(this.gridView2, "Fund_Accounts");
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e) //导出
        {
            string localFilePath = fc.ShowSaveFileDialog();

            if (localFilePath != null)
            {
                gridView2.Export(DevExpress.XtraPrinting.ExportTarget.Xls, localFilePath);
            }
        }

        private void toolStripButton6_Click_1(object sender, EventArgs e) //导入
        {
            string dataString = fc.getDataTable();

            if (dataString != null)
            {
                using (var ws = new WebSocket("ws://localhost:9000/BatchSave"))
                {
                    ws.Connect();
                    ws.Send(dataString);
                    ws.Close();
                }
                MessageBox.Show("导入成功！！");
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e) //保存
        {
            if (isExist == false)
            {
                Fund_Accounts fa = new Fund_Accounts();

                fa.account_property = comboBox1.Text;
                fa.account_name = textBox29.Text;
                fa.bank_deposit = textBox35.Text;
                fa.account_number = Convert.ToInt32(textBox34.Text);
                fa.initial_balance = Convert.ToDecimal(textBox32.Text);
                fa.collection_sum = Convert.ToDecimal(textBox9.Text);
                fa.payment_sum = Convert.ToDecimal(textBox11.Text);
                fa.remaining_sum = Convert.ToDecimal(textBox10.Text);
                fa.statement = textBox12.Text;
                fc.saveData(fa, "Fund_Accounts");
            }
            else if (isExist == true)
            {
                Fund_Accounts fa = new Fund_Accounts();

                fa.ID = Convert.ToInt32(array[0]);
                fa.account_property = comboBox1.Text;
                fa.account_name = textBox29.Text;
                fa.bank_deposit = textBox35.Text;
                fa.account_number = Convert.ToInt32(textBox34.Text);
                fa.initial_balance = Convert.ToDecimal(textBox32.Text);
                fa.collection_sum = Convert.ToDecimal(textBox9.Text);
                fa.payment_sum = Convert.ToDecimal(textBox11.Text);
                fa.remaining_sum = Convert.ToDecimal(textBox10.Text);
                fa.statement = textBox12.Text;
                fc.updateData(fa, "Fund_Accounts");
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e) //关闭
        {
            panel3.Visible = false;
            simpleButton6.Visible = true;
        }
    }
}
