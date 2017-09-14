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

namespace Demo1._1._3
{
    public partial class Basic_Set : UserControl
    {
       
        StringReader streamToPrint = null;
        Font printFont;
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据


        public  long total_Page = 0; //页码总条目
        public  long now_Page = 1; //当前页码
        domain.Basic_Set bs = new domain.Basic_Set();
        FunctionClass fc = new FunctionClass();

        public Basic_Set()
        {
            InitializeComponent();
            
            total_Page = fc.getTotal<domain.Basic_Set>(bs,total_Page);
            fc.InitPage(dataNavigator_Basic_Set,total_Page,now_Page);

            isEdit();
        }


        /// <summary>
        /// 判断是否可以编辑
        /// </summary>
        private void isEdit()
        {
            if (Sign_in.basic.Substring(0, 2) == "01")
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton4.Visible = false;
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            
        }
       
        private void toolStripButtonDelete_Click(object sender, EventArgs e) //Delete
        {
            fc.DeleteData(gridView2, "Basic_Set");
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            string localFilePath  = fc.ShowSaveFileDialog();
            
            if (localFilePath !=null)
            {
                gridView2.Export(DevExpress.XtraPrinting.ExportTarget.Xls, localFilePath);
            }   
        }

        private void toolStripButton8_Click(object sender, EventArgs e) //复选功能
        {
            if (this.gridView2.OptionsSelection.MultiSelect == true)
            {
                if (MessageBox.Show("是否关闭复选框", "复选框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    this.gridView2.OptionsSelection.MultiSelect = false;
                   // this.gridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                }
            }
            else if(MessageBox.Show("是否打开复选框", "复选框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                this.gridView2.OptionsSelection.MultiSelect = true;
                this.gridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            }  
        }

        private void toolStripButton3_Click(object sender, EventArgs e) //导入数据
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


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            fc.PrintDocument(sender,e);
        }

        private void 页面设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fc.PageSet(pageSetupDialog1, printDocument1);
        }

        private void 页面预览ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            fc.PageView(pageSetupDialog1, printDocument1);
        }

        private void 打印ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
                printDocument1.Print();
        }

        private void toolStripButton2_Click(object sender, EventArgs e) //修改数据
        {
            colCount = gridView2.Columns.Count();
            array = new string[colCount];
            for (int i = 0; i < colCount; i++)
            {
                array[i] = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[i]);
            }
            if (array[0].Length > 0)
            {
  
            }
            else
            {
                MessageBox.Show("该条数据不含主键，无法修改");
            }
        }


       

        private void dataNavigator_Basic_Set_ButtonClick(object sender, NavigatorButtonClickEventArgs e) //分页
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page<total_Page)
                {
                    now_Page++;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Basic_Set bs = new domain.Basic_Set();
                    gridControl2.DataSource = fc.showData<domain.Basic_Set>(bs,now_Page.ToString());
                }
                else if (btn.Tag.ToString() =="上一页" && now_Page>1)
                {
                    now_Page--;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Basic_Set bs = new domain.Basic_Set();
                    gridControl2.DataSource = fc.showData<domain.Basic_Set>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page = 1;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Basic_Set bs = new domain.Basic_Set();
                    gridControl2.DataSource = fc.showData<domain.Basic_Set>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page = total_Page;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Basic_Set bs = new domain.Basic_Set();
                    gridControl2.DataSource = fc.showData<domain.Basic_Set>(bs, now_Page.ToString());
                }
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e) //新建
        {
            panel3.Visible = true;
            isExist = false;
            textBox9.Text = Sign_in.name;
            textBox11.Text = Sign_in.name;
        }

        private void simpleButton3_Click(object sender, EventArgs e) //关闭
        {
            panel3.Visible = false;
            simpleButton4.Visible = true;
        }

        private void simpleButton4_Click(object sender, EventArgs e) //保存
        {
            if (isExist == false)
            {
                domain.Basic_Set bs = new domain.Basic_Set();
                bs.position_Set = textBox1.Text;
                bs.account_Receive =Convert.ToDecimal(textBox3.Text);
                bs.account_Pay = Convert.ToDecimal(textBox22.Text);
                bs.storage_Mode = textBox21.Text;
                bs.outStorage_Mode = textBox6.Text;
                bs.transportation_Mode = textBox20.Text;
                bs.post_Property = textBox19.Text;
                bs.borrow_Property = textBox18.Text;
                bs.customer_Type = textBox17.Text;
                bs.expense_Category = textBox16.Text;
                bs.nationality = textBox2.Text;
                bs.storage = textBox4.Text;
                bs.refund_Mode = textBox5.Text;
                bs.oil_Varirety = textBox7.Text;
                fc.saveData(bs, "Basic_Set");
            }
            else if (isExist == true)
            {
                domain.Basic_Set bs = new domain.Basic_Set();
                bs.ID = Convert.ToInt32(array[0]);
                bs.position_Set = textBox1.Text;
                bs.account_Receive = Convert.ToDecimal(textBox3.Text);
                bs.account_Pay = Convert.ToDecimal(textBox22.Text);
                bs.storage_Mode = textBox21.Text;
                bs.outStorage_Mode = textBox6.Text;
                bs.transportation_Mode = textBox20.Text;
                bs.post_Property = textBox19.Text;
                bs.borrow_Property = textBox18.Text;
                bs.customer_Type = textBox17.Text;
                bs.expense_Category = textBox16.Text;
                bs.nationality = textBox2.Text;
                bs.storage = textBox4.Text;
                bs.refund_Mode = textBox5.Text;
                bs.oil_Varirety = textBox7.Text;
                fc.updateData(bs, "Basic_Set");
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e) //查看
        {
            simpleButton4.Visible = false;

            colCount = gridView2.Columns.Count();
            array = new string[colCount];
            for (int i = 0; i < colCount; i++)
            {
                array[i] = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[i]);
            }
            if (array[0].Length > 0)
            {
                panel3.Visible = true;

                textBox1.Text = array[1];
                textBox3.Text = array[2];
                textBox22.Text = array[3];
                textBox21.Text = array[4];
                textBox6.Text = array[5];
                textBox20.Text = array[6];
                textBox19.Text = array[7];
                textBox18.Text = array[8];
                textBox17.Text = array[9];
                textBox16.Text = array[10];
                textBox2.Text = array[11];
                textBox4.Text = array[12];
                textBox5.Text = array[13];
                textBox7.Text = array[14];

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
                textBox1.Text = array[1];
                textBox3.Text = array[2];
                textBox22.Text = array[3];
                textBox21.Text = array[4];
                textBox6.Text = array[5];
                textBox20.Text = array[6];
                textBox19.Text = array[7];
                textBox18.Text = array[8];
                textBox17.Text = array[9];
                textBox16.Text = array[10];
                textBox2.Text = array[11];
                textBox4.Text = array[12];
                textBox5.Text = array[13];
                textBox7.Text = array[14];
            }
            else
            {
                MessageBox.Show("该条数据不含主键，无法修改");
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e) //删除
        {
            fc.DeleteData(this.gridView2, "Basic_Set");
        }
         
        private void toolStripButton3_Click_1(object sender, EventArgs e) //导出数据
        {
            string localFilePath = fc.ShowSaveFileDialog();

            if (localFilePath != null)
            {
                gridView2.Export(DevExpress.XtraPrinting.ExportTarget.Xls, localFilePath);
            }
        }
    }
}
