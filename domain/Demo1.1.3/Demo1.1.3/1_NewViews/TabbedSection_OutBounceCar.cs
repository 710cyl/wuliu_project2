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

namespace Demo1._1._3._1_NewViews
{
    public partial class TabbedSection_OutBounceCar : Form
    {
        FunctionClass fc = new FunctionClass();
        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码
        private static string name;
        domain.Outbound_Car cf = new domain.Outbound_Car();

        #region

        /// <summary>
        /// 派车单号
        /// </summary>
        public string sendcar_num { get; set; }
        /// <summary>
        /// 货主单位
        /// </summary>
        public string owner_unit { get; set; }

        /// <summary>
        /// 发货仓库
        /// </summary>
        public string warehouse_send { get; set; }

        /// <summary>
        /// 付费单位
        /// </summary>
        public string pay_unit { get; set; }

        /// <summary>
        /// 车队
        /// </summary>
        public string cars { get; set; }
        /// <summary>
        /// 车号
        /// </summary>
        public string carnum { get; set; }

        /// <summary>
        /// 司机
        /// </summary>
        public string driver { get; set; }

        /// <summary>
        /// 卸货城市
        /// </summary>
        public string unload_city { get; set; }
        /// <summary>
        /// 卸货区域
        /// </summary>
        public string unload_area { get; set; }
        /// <summary>
        /// 实际卸点
        /// </summary>
        public string unload_point { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public  string explain { get; set; }

        //定义委托处理
        public delegate void ClickOutBounceCar(string sendcar_num, string owner_unit, string warehouse_send, string pay_unit
                                                , string cars, string carnum, string driver, string unload_city
                                                , string unload_area, string unload_point, string explain);
        //定义返回委托事件
        public ClickOutBounceCar ReturnEvent;
        #endregion

        public TabbedSection_OutBounceCar()
        {
            InitializeComponent();
            gridControl1.DataSource = fc.showData(cf, now_Page.ToString());

            total_Page = fc.getTotal<domain.Outbound_Car>(cf, total_Page);
            fc.InitPage(dataNavigator_Basic_Set, total_Page, now_Page);

            this.gridView1.Columns[0].Caption = "订单号";
            this.gridView1.Columns[1].Caption = "派车单号";
            this.gridView1.Columns[2].Caption = "货主单位";
            this.gridView1.Columns[3].Caption = "发货仓库";
            this.gridView1.Columns[4].Caption = "发货量";
            this.gridView1.Columns[5].Caption = "出库方式";
            this.gridView1.Columns[6].Caption = "业务部门";
            this.gridView1.Columns[7].Caption = "业务人员";
            this.gridView1.Columns[8].Caption = "付费单位";
            this.gridView1.Columns[9].Caption = "车队";
            this.gridView1.Columns[10].Caption = "车号";
            this.gridView1.Columns[11].Caption = "司机";
            this.gridView1.Columns[12].Caption = "派车人";
            this.gridView1.Columns[13].Caption = "派车时间";
            this.gridView1.Columns[14].Caption = "卸货城市";
            this.gridView1.Columns[15].Caption = "卸货区域";
            this.gridView1.Columns[16].Caption = "实际卸点";
            this.gridView1.Columns[17].Caption = "打包";
            this.gridView1.Columns[18].Caption = "关闭";
            this.gridView1.Columns[19].Caption = "关闭人";
            this.gridView1.Columns[20].Caption = "关闭时间";
            this.gridView1.Columns[21].Caption = "说明";
            this.gridView1.BestFitColumns();
        }

        private void simpleButton2_Click(object sender, EventArgs e) //
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e) //确定
        {
            sendcar_num = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[0]);
            owner_unit = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[2]);
            warehouse_send = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[3]);
            pay_unit = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[8]);
            cars = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[9]);
            carnum = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[10]);
            driver = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[11]);
            unload_city = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[14]);
            unload_area = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[15]);
            unload_point = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[16]);
            explain = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[21]);

            Close();

            ReturnEvent?.Invoke(sendcar_num, owner_unit, warehouse_send, pay_unit, cars, carnum, driver
                , unload_city, unload_area, unload_point, explain);
        }

        private void simpleButton3_Click(object sender, EventArgs e) //查询
        {
            string input_val = textBox1.Text;
            if (input_val.Equals(""))
            {
                MessageBox.Show("请输入查询关键字！");
            }
            else
            {
                gridControl1.DataSource = fc.showDataLike<domain.Outbound_Car>(cf, now_Page.ToString(), input_val);
            }
        }

        private void dataNavigator_Basic_Set_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page < total_Page)
                {
                    now_Page++;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Outbound_Car bs = new domain.Outbound_Car();
                    gridControl1.DataSource = fc.showData<domain.Outbound_Car>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page > 1)
                {
                    now_Page--;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Outbound_Car bs = new domain.Outbound_Car();
                    gridControl1.DataSource = fc.showData<domain.Outbound_Car>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page = 1;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Outbound_Car bs = new domain.Outbound_Car();
                    gridControl1.DataSource = fc.showData<domain.Outbound_Car>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page = total_Page;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Outbound_Car bs = new domain.Outbound_Car();
                    gridControl1.DataSource = fc.showData<domain.Outbound_Car>(bs, now_Page.ToString());
                }
            }
        }
    }
}
