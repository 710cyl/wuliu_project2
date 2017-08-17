using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using domain;
using Demo1._1._3.Views.MyWorkBench_SkipForm.Transport;
using Newtonsoft.Json;
using WebSocketSharp;

namespace Demo1._1._3.Panel2_MyWorkBench
{
    public partial class OilGasRegister : UserControl
    {
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据
        public static string str = null;

        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码
        public List<domain.OilGasRegister_Detail> ogr_list = new List<OilGasRegister_Detail>(); //得到明细表的list

        domain.OilGasRegister_Main tcm = new domain.OilGasRegister_Main();
        FunctionClass fc = new FunctionClass();

        public OilGasRegister()
        {
            InitializeComponent();

        }
        //查看
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            str = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns["register_id"]); //获取主键内容
            MessageBox.Show(str);
            ogr_list = JsonConvert.DeserializeObject<List<domain.OilGasRegister_Detail>>(fc.FindDeteils(str, "OilGasRegister_Detail"));
            gridControl2.DataSource = ogr_list;
        }
        //新建
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            isExist = false;
            New_OilGasRegister_1 ntc = new New_OilGasRegister_1();
            ntc.ShowDialog();
        }
        //修改
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            colCount = gridView1.Columns.Count() - 1;
            array = new string[colCount + 1];
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
            fc.DeleteMain(this.gridView1, "OilGasRegister_Main","register_id");
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
        private void dataNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page < total_Page)
                {
                    now_Page++;
                    dataNavigator1.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.OilGasRegister_Main tcm = new domain.OilGasRegister_Main();
                    gridControl1.DataSource = fc.showData<domain.OilGasRegister_Main>(tcm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page > 1)
                {
                    now_Page--;
                    dataNavigator1.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.OilGasRegister_Main tcm = new domain.OilGasRegister_Main();
                    gridControl1.DataSource = fc.showData<domain.OilGasRegister_Main>(tcm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page = 1;
                    dataNavigator1.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.OilGasRegister_Main tcm = new domain.OilGasRegister_Main();
                    gridControl1.DataSource = fc.showData<domain.OilGasRegister_Main>(tcm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page = total_Page;
                    dataNavigator1.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.OilGasRegister_Main tcm = new domain.OilGasRegister_Main();
                    gridControl1.DataSource = fc.showData<domain.OilGasRegister_Main>(tcm, now_Page.ToString());
                }
            }
        }
        //明细表分页
        private void dataNavigator2_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page < total_Page)
                {
                    now_Page++;
                    dataNavigator2.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.OilGasRegister_Detail tcm = new domain.OilGasRegister_Detail();
                    gridControl1.DataSource = fc.showData<domain.OilGasRegister_Detail>(tcm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page > 1)
                {
                    now_Page--;
                    dataNavigator2.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.OilGasRegister_Detail tcm = new domain.OilGasRegister_Detail();
                    gridControl1.DataSource = fc.showData<domain.OilGasRegister_Detail>(tcm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page = 1;
                    dataNavigator2.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.OilGasRegister_Detail tcm = new domain.OilGasRegister_Detail();
                    gridControl1.DataSource = fc.showData<domain.OilGasRegister_Detail>(tcm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page = total_Page;
                    dataNavigator2.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.OilGasRegister_Detail tcm = new domain.OilGasRegister_Detail();
                    gridControl1.DataSource = fc.showData<domain.OilGasRegister_Detail>(tcm, now_Page.ToString());
                }
            }
        }
        //主表单击事件
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            str = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns["register_id"]); //获取主键内容
            MessageBox.Show(str);
            ogr_list = JsonConvert.DeserializeObject<List<domain.OilGasRegister_Detail>>(fc.FindDeteils(str, "OilGasRegister_Detail"));
            gridControl2.DataSource = ogr_list;

        }
    }
}
