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
    public partial class TransportationRegister : UserControl
    {
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据
        public long total_Page1 = 0; //主表页码总条目
        public long now_Page1 = 1; //主表当前页码
        public long total_Page2 = 0; //明细表页码总条目
        public long now_Page2 = 1; //明细表当前页码
        public static string str = null;
        public List<domain.TransportationRegister_Detail> sd = new List<TransportationRegister_Detail>(); //得到明细表的list
        domain.TransportationRegister tr = new domain.TransportationRegister();
        domain.TransportationRegister_Detail trd = new domain.TransportationRegister_Detail();
        FunctionClass fc = new FunctionClass();
        public TransportationRegister()
        {
            InitializeComponent();
            total_Page1 = fc.getTotal<domain.TransportationRegister>(tr, total_Page1);
            fc.InitPage(dataNavigator_TransportationRegister, total_Page1, now_Page1);
            total_Page2 = fc.getTotal<domain.TransportationRegister_Detail>(trd, total_Page2);
            fc.InitPage(dataNavigator_TransportationRegister_Detail, total_Page2, now_Page2);
        }

        /// <summary>
        /// 点击主表对应的明细表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            str = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns["transport_ID"]); //获取主键内容
            //MessageBox.Show(str);
            sd = JsonConvert.DeserializeObject<List<domain.TransportationRegister_Detail>>(fc.FindDeteils(str, "TransportationRegister_Detail"));
            gridControl2.DataSource = sd;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)//新建
        {
            isExist = false;
            Demo1._1._3.Views.MyWorkBench_SkipForm.Transport.New_TransportationRegister tr = new Demo1._1._3.Views.MyWorkBench_SkipForm.Transport.New_TransportationRegister();
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
                    Demo1._1._3.Views.MyWorkBench_SkipForm.Transport.New_TransportationRegister tr = new Demo1._1._3.Views.MyWorkBench_SkipForm.Transport.New_TransportationRegister();
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
            fc.DeleteMain(this.gridView1, "TransportaitonRegister", "transport_ID");
        }

        private void 导出表单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string localFilePath = fc.ShowSaveFileDialog();

            if (localFilePath != null)
            {
                gridView1.Export(DevExpress.XtraPrinting.ExportTarget.Xls, localFilePath);
            }
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



        private void dataNavigator_TransportationRegister_Click(object sender, EventArgs e)
        {

        }

        private void dataNavigator_TransportationRegister_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page1 < total_Page1)
                {
                    now_Page1++;
                    dataNavigator_TransportationRegister.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page1, total_Page1);
                    domain.TransportationRegister bs = new domain.TransportationRegister();
                    gridControl1.DataSource = fc.showData<domain.TransportationRegister>(bs, now_Page1.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page1 > 1)
                {
                    now_Page1--;
                    dataNavigator_TransportationRegister.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page1, total_Page1);
                    domain.TransportationRegister bs = new domain.TransportationRegister();
                    gridControl1.DataSource = fc.showData<domain.TransportationRegister>(bs, now_Page1.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page1 = 1;
                    dataNavigator_TransportationRegister.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page1, total_Page1);
                    domain.TransportationRegister bs = new domain.TransportationRegister();
                    gridControl1.DataSource = fc.showData<domain.TransportationRegister>(bs, now_Page1.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page1 = total_Page1;
                    dataNavigator_TransportationRegister.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page1, total_Page1);
                    domain.TransportationRegister bs = new domain.TransportationRegister();
                    gridControl1.DataSource = fc.showData<domain.TransportationRegister>(bs, now_Page1.ToString());
                }
            }
        }

        private void dataNavigator_TransportationRegister_Detail_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page2 < total_Page2)
                {
                    now_Page2++;
                    dataNavigator_TransportationRegister_Detail.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page2, total_Page2);
                    domain.TransportationRegister_Detail bs = new domain.TransportationRegister_Detail();
                    gridControl2.DataSource = fc.showData<domain.TransportationRegister_Detail>(bs, now_Page2.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page2 > 1)
                {
                    now_Page2--;
                    dataNavigator_TransportationRegister_Detail.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page2, total_Page2);
                    domain.TransportationRegister_Detail bs = new domain.TransportationRegister_Detail();
                    gridControl2.DataSource = fc.showData<domain.TransportationRegister_Detail>(bs, now_Page2.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page1 = 2;
                    dataNavigator_TransportationRegister_Detail.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page2, total_Page2);
                    domain.TransportationRegister_Detail bs = new domain.TransportationRegister_Detail();
                    gridControl2.DataSource = fc.showData<domain.TransportationRegister_Detail>(bs, now_Page2.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page2 = total_Page2;
                    dataNavigator_TransportationRegister_Detail.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page2, total_Page2);
                    domain.TransportationRegister_Detail bs = new domain.TransportationRegister_Detail();
                    gridControl2.DataSource = fc.showData<domain.TransportationRegister_Detail>(bs, now_Page2.ToString());
                }
            }
        }
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            String input_val = textBox1.Text;
            if (input_val.Equals(""))
            {
                MessageBox.Show("请输入查询关键字！");
            }
            else
            {
                gridControl1.DataSource = fc.showDataLike<domain.TransportationRegister>(tr, now_Page1.ToString(), input_val);
            }
        }

        //private void 打印表单ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    fc.print(printDialog1, printDocument1, gridControl2);
        //}
    }
}
