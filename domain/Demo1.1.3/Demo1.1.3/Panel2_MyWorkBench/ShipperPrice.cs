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

namespace Demo1._1._3.Panel2_MyWorkBench
{
    public partial class ShipperPrice : UserControl
    {
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据
        public long total_Page1 = 0; //主表页码总条目
        public long now_Page1 = 1; //主表当前页码
        public long total_Page2 = 0; //明细表页码总条目
        public long now_Page2 = 1; //明细表当前页码
        public static string str = null;
        public List<domain.ShipperPrice_Detail> sd = new List<ShipperPrice_Detail>(); //得到明细表的list
        domain.ShipperPrice tr = new domain.ShipperPrice();
        domain.ShipperPrice_Detail trd = new domain.ShipperPrice_Detail();
        FunctionClass fc = new FunctionClass();
        public static BindingList<domain.ShipperPrice_Detail> shipperprice_detail;
        
        public ShipperPrice()
        {
            InitializeComponent();
            total_Page1 = fc.getTotal<domain.ShipperPrice>(tr, total_Page1);
            fc.InitPage(dataNavigator_ShipperPrice, total_Page1, now_Page1);
            total_Page2 = fc.getTotal<domain.ShipperPrice_Detail>(trd, total_Page2);
            fc.InitPage(dataNavigator_ShipperPrice_Detail, total_Page2, now_Page2);


            isEdit();
        }

        /// <summary>
        /// 判断可否编辑
        /// </summary>
        private void isEdit()
        {
            if (Sign_in.transpotation.Substring(6, 2) == "01")
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton4.Visible = false;
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            str = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns["price_ID"]); //获取主键内容
            //MessageBox.Show(str);
            sd = JsonConvert.DeserializeObject<List<domain.ShipperPrice_Detail>>(fc.FindDeteils(str, "ShipperPrice_Detail"));
            gridControl2.DataSource = sd;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)//新建
        {
            isExist = false;
            Demo1._1._3.Views.MyWorkBench_SkipForm.Transport.New_ShipperPrice_1 tr = new Demo1._1._3.Views.MyWorkBench_SkipForm.Transport.New_ShipperPrice_1();
            tr.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)//修改
        {
            colCount = gridView1.Columns.Count() - 1;
            array = new string[colCount];
            for (int i = 0; i < colCount; i++)
            {
                array[i] = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[i]);
            }
            if (array[0].Length > 0)
            {
                try
                {
                    isExist = true;
                    Demo1._1._3.Views.MyWorkBench_SkipForm.Transport.New_ShipperPrice_1 tr = new Demo1._1._3.Views.MyWorkBench_SkipForm.Transport.New_ShipperPrice_1();
                    tr.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("该条数据不含主键，无法修改");
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)//删除
        {
            fc.DeleteMain(this.gridView1, "ShipperPrice", "price_ID");
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//导入数据
        {
            string dataString = fc.getDataTable();

            if (dataString != null)
            {
                using (var ws = new WebSocket("ws://localhost:9000/BatchSave"))
                {
                    ws.Connect();
                    ws.Send(dataString);
                    using (var wss = new WebSocket("ws://localhost:9000/GetClassName/Main"))
                    {
                        wss.Connect();
                        wss.Send(tr.GetType().Name);
                        wss.Close();
                    }
                    ws.Close();
                }
                MessageBox.Show("导入成功！！");
            }
        }

        private void 导出表单ToolStripMenuItem_Click(object sender, EventArgs e)//导出
        {
            string localFilePath = fc.ShowSaveFileDialog();

            if (localFilePath != null)
            {
                gridView1.Export(DevExpress.XtraPrinting.ExportTarget.Xls, localFilePath);
            }
        }

        private void button1_Click(object sender, EventArgs e)//模糊查询
        {
            String input_val = textBox1.Text;
            if (input_val.Equals(""))
            {
                MessageBox.Show("请输入查询关键字！");
            }
            else
            {
                gridControl1.DataSource = fc.showDataLike<domain.ShipperPrice>(tr, now_Page1.ToString(), input_val);
            }
        }

        private void dataNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page1 < total_Page1)
                {
                    now_Page1++;
                    dataNavigator_ShipperPrice.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page1, total_Page1);
                    domain.ShipperPrice bs = new domain.ShipperPrice();
                    gridControl1.DataSource = fc.showData<domain.ShipperPrice>(bs, now_Page1.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page1 > 1)
                {
                    now_Page1--;
                    dataNavigator_ShipperPrice.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page1, total_Page1);
                    domain.ShipperPrice bs = new domain.ShipperPrice();
                    gridControl1.DataSource = fc.showData<domain.ShipperPrice>(bs, now_Page1.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page1 = 1;
                    dataNavigator_ShipperPrice.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page1, total_Page1);
                    domain.ShipperPrice bs = new domain.ShipperPrice();
                    gridControl1.DataSource = fc.showData<domain.ShipperPrice>(bs, now_Page1.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page1 = total_Page1;
                    dataNavigator_ShipperPrice.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page1, total_Page1);
                    domain.ShipperPrice bs = new domain.ShipperPrice();
                    gridControl1.DataSource = fc.showData<domain.ShipperPrice>(bs, now_Page1.ToString());
                }
            }
        }

        private void dataNavigator_Basic_Set_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page2 < total_Page2)
                {
                    now_Page2++;
                    dataNavigator_ShipperPrice_Detail.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page2, total_Page2);
                    domain.ShipperPrice_Detail bs = new domain.ShipperPrice_Detail();
                    gridControl2.DataSource = fc.showData<domain.ShipperPrice_Detail>(bs, now_Page2.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page2 > 1)
                {
                    now_Page2--;
                    dataNavigator_ShipperPrice_Detail.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page2, total_Page2);
                    domain.ShipperPrice_Detail bs = new domain.ShipperPrice_Detail();
                    gridControl2.DataSource = fc.showData<domain.ShipperPrice_Detail>(bs, now_Page2.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page1 = 2;
                    dataNavigator_ShipperPrice_Detail.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page2, total_Page2);
                    domain.ShipperPrice_Detail bs = new domain.ShipperPrice_Detail();
                    gridControl2.DataSource = fc.showData<domain.ShipperPrice_Detail>(bs, now_Page2.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page2 = total_Page2;
                    dataNavigator_ShipperPrice_Detail.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page2, total_Page2);
                    domain.ShipperPrice_Detail bs = new domain.ShipperPrice_Detail();
                    gridControl2.DataSource = fc.showData<domain.ShipperPrice_Detail>(bs, now_Page2.ToString());
                }
            }
        }
    }
}
