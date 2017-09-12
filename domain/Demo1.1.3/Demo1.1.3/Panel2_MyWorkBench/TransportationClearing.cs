using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Demo1._1._3.Views.MyWorkBench_SkipForm.Transport;
using DevExpress.XtraEditors;
using WebSocketSharp;
using Newtonsoft.Json;
using domain;


namespace Demo1._1._3.Panel2_MyWorkBench
{
    public partial class TransportationClearing : UserControl
    {
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据
        public static string str = null;

        public long total_Page1 = 0; //主表页码总条目
        public long now_Page1 = 1; //主表当前页码
        public long total_Page2 = 0; //明细表页码总条目
        public long now_Page2 = 1; //明细表当前页码
        public List<domain.TransportationClearing_Detail> tcd_list = new List<TransportationClearing_Detail>(); //得到明细表的list

        domain.TransportationClearing_Main tcm = new domain.TransportationClearing_Main();
        domain.TransportationClearing_Detail tcd = new domain.TransportationClearing_Detail();
        FunctionClass fc = new FunctionClass();

        public TransportationClearing()
        {
            InitializeComponent();
            total_Page1 = fc.getTotal<domain.TransportationClearing_Main>(tcm, total_Page1);
            fc.InitPage(dataNavigator_TransportationClearing_Main, total_Page1, now_Page1);
        }
        //查看
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            colCount = gridView1.Columns.Count();
            array = new string[colCount];
            str = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns["clearing_id"]);
            for (int i = 0; i < colCount; i++)
            {
                array[i] = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[i]);
            }
            if (array[0].Length > 0)
            {
                try
                {
                    isExist = true;
                    New_TransportationClearing gde = new New_TransportationClearing();
                    gde.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        //新建
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            isExist = false;
            New_TransportationClearing ntc = new New_TransportationClearing();
            ntc.ShowDialog();
        }
        //修改
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            str = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns["clearing_id"]);
            colCount = gridView1.Columns.Count();
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
                    New_TransportationClearing gde = new New_TransportationClearing();
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
        //删除
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            fc.DeleteMain(this.gridView1, "TransportationClearing_Main", "clearing_id");
        }
        //导入数据
        private void toolStripButton6_Click(object sender, EventArgs e)
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
                        wss.Send(tcm.GetType().Name);
                        wss.Close();
                    }
                    ws.Close();
                }
                MessageBox.Show("导入成功！！");
            }
        }
        //主表分页
        private void dataNavigator_TransportationClearing_Main_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page1 < total_Page1)
                {
                    now_Page1++;
                    dataNavigator_TransportationClearing_Main.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page1, total_Page1);
                    domain.TransportationClearing_Main tcm = new domain.TransportationClearing_Main();
                    gridControl1.DataSource = fc.showData<domain.TransportationClearing_Main>(tcm, now_Page1.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page1 > 1)
                {
                    now_Page1--;
                    dataNavigator_TransportationClearing_Main.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page1, total_Page1);
                    domain.TransportationClearing_Main tcm = new domain.TransportationClearing_Main();
                    gridControl1.DataSource = fc.showData<domain.TransportationClearing_Main>(tcm, now_Page1.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page1 = 1;
                    dataNavigator_TransportationClearing_Main.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page1, total_Page1);
                    domain.TransportationClearing_Main tcm = new domain.TransportationClearing_Main();
                    gridControl1.DataSource = fc.showData<domain.TransportationClearing_Main>(tcm, now_Page1.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page1 = total_Page1;
                    dataNavigator_TransportationClearing_Main.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page1, total_Page1);
                    domain.TransportationClearing_Main tcm = new domain.TransportationClearing_Main();
                    gridControl1.DataSource = fc.showData<domain.TransportationClearing_Main>(tcm, now_Page1.ToString());
                }
            }
        }
        //明细表分页
        private void dataNavigator_TransportationClearing_Detail_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page2 < total_Page2)
                {
                    now_Page2++;
                    dataNavigator_TransportationClearing_Detail.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page2, total_Page2);
                    domain.TransportationClearing_Detail tcm = new domain.TransportationClearing_Detail();
                    gridControl1.DataSource = fc.showData<domain.TransportationClearing_Detail>(tcm, now_Page2.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page2 > 1)
                {
                    now_Page2--;
                    dataNavigator_TransportationClearing_Detail.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page2, total_Page2);
                    domain.TransportationClearing_Detail tcm = new domain.TransportationClearing_Detail();
                    gridControl1.DataSource = fc.showData<domain.TransportationClearing_Detail>(tcm, now_Page2.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page2 = 1;
                    dataNavigator_TransportationClearing_Detail.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page2, total_Page2);
                    domain.TransportationClearing_Detail tcm = new domain.TransportationClearing_Detail();
                    gridControl1.DataSource = fc.showData<domain.TransportationClearing_Detail>(tcm, now_Page2.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page2 = total_Page2;
                    dataNavigator_TransportationClearing_Detail.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page2, total_Page2);
                    domain.TransportationClearing_Detail tcm = new domain.TransportationClearing_Detail();
                    gridControl1.DataSource = fc.showData<domain.TransportationClearing_Detail>(tcm, now_Page2.ToString());
                }
            }
        }
        //单击某行
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            str = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns["clearing_id"]); //获取主键内容
            MessageBox.Show(str);
            tcd_list = JsonConvert.DeserializeObject<List<domain.TransportationClearing_Detail>>(fc.FindDeteils(str, "TransportationClearing_Detail"));
            gridControl2.DataSource = tcd_list;
            //明细表分页 不知道怎么做？
            //total_Page2 = fc.getTotal<domain.TransportationClearing_Detail>(tcd, total_Page2);
            //fc.InitPage(dataNavigator_TransportationClearing_Detail, total_Page2, now_Page2);
        }

    }
}
