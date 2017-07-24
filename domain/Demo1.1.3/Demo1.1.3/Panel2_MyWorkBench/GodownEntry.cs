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
    public partial class GodownEntry : UserControl
    {
        StringReader streamToPrint = null;
        Font printFont;
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据
        public static string str = null;

        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码
        public  List<domain.StorageDetails> sd = new List<StorageDetails>(); //得到明细表的list

        domain.StorageFormMain bs = new domain.StorageFormMain();
        FunctionClass fc = new FunctionClass();

        public GodownEntry()
        {
            InitializeComponent();
            total_Page = fc.getTotal<domain.StorageFormMain>(bs, total_Page);
            fc.InitPage(dataNavigator_Basic_Set, total_Page, now_Page);
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) //点击行 得到主表中明细的内容
        {
            str = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns["StorageNumber"]); //获取主键内容
            MessageBox.Show(str);
            sd = JsonConvert.DeserializeObject<List<domain.StorageDetails>>(fc.FindDeteils(str, "StorageDetails"));
            gridControl2.DataSource = sd;
        }

      


        private void DeleteButtom_Click(object sender, EventArgs e) //删除按钮
        {
            fc.DeleteMain(this.gridView1, "StorageFormMain");
        }

        private void toolStripButton1_Click(object sender, EventArgs e) //保存
        {
            isExist = false;
            New_GoDownEntry gde = new New_GoDownEntry();
            gde.ShowDialog();
        }

        private void toolStripButton8_Click(object sender, EventArgs e) //导出数据
        {
            string localFilePath = fc.ShowSaveFileDialog();

            if (localFilePath != null)
            {
                gridView2.Export(DevExpress.XtraPrinting.ExportTarget.Xls, localFilePath);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e) //修改
        {
            colCount = gridView1.Columns.Count()-1;
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
                    New_GoDownEntry gde = new New_GoDownEntry();
                    gde.ShowDialog();
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

        private void toolStripButton6_Click(object sender, EventArgs e) //导入数据
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
                        wss.Send(bs.GetType().Name);
                        wss.Close();
                    }
                    ws.Close();
                }
                MessageBox.Show("导入成功！！");
            }
        }

        private void toolStripButton9_Click(object sender, EventArgs e) //模糊查询
        {
            String input_val = toolStripTextBox1.Text;
            if (input_val.Equals(""))
            {
                MessageBox.Show("请输入查询关键字！");
            }
            else
            {
                gridControl1.DataSource = fc.showDataLike<domain.StorageFormMain>(bs, now_Page.ToString(), input_val);
            }
        }

        private void dataNavigator_Basic_Set_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page < total_Page)
                {
                    now_Page++;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.StorageFormMain bs = new domain.StorageFormMain();
                    gridControl1.DataSource = fc.showData<domain.StorageFormMain>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page > 1)
                {
                    now_Page--;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.StorageFormMain bs = new domain.StorageFormMain();
                    gridControl1.DataSource = fc.showData<domain.StorageFormMain>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page = 1;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.StorageFormMain bs = new domain.StorageFormMain();
                    gridControl1.DataSource = fc.showData<domain.StorageFormMain>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page = total_Page;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.StorageFormMain bs = new domain.StorageFormMain();
                    gridControl1.DataSource = fc.showData<domain.StorageFormMain>(bs, now_Page.ToString());
                }
            }
        }
    }
}
