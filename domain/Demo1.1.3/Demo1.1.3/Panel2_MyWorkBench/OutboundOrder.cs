﻿using System;
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
    public partial class OutboundOrder : UserControl
    {
        StringReader streamToPrint = null;
        Font printFont;
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据
        public static string str = null;

        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码
        public List<domain.StorageDetailsOut> sd = new List<StorageDetailsOut>(); //得到明细表的list

        domain.StorageFormMainOut bs = new domain.StorageFormMainOut();
        FunctionClass fc = new FunctionClass();

        public OutboundOrder()
        {
            InitializeComponent();
            total_Page = fc.getTotal<domain.StorageFormMainOut>(bs, total_Page);
            fc.InitPage(dataNavigator_Basic_Set, total_Page, now_Page);
            fc.InitPage(dataNavigator1, 1, 1);

            isEdit();
        }

        /// <summary>
        /// 判断是否可编辑
        /// </summary>
        private void isEdit()
        {
            if (Sign_in.storage.Substring(2, 2) == "01")
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton7.Visible = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e) //新建
        {
            isExist = false;
            Views.MyWorkBench_SkipForm.New_OutboundOrder gde = new Views.MyWorkBench_SkipForm.New_OutboundOrder();
            gde.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e) //修改
        {
            colCount = gridView3.Columns.Count() - 1;
            array = new string[colCount];
            for (int i = 0; i < colCount; i++)
            {
                array[i] = gridView3.GetFocusedRowCellDisplayText(gridView3.Columns[i]);
            }
            if (array[0].Length > 0)
            {
                try
                {
                    isExist = true;
                    Views.MyWorkBench_SkipForm.New_OutboundOrder gde = new Views.MyWorkBench_SkipForm.New_OutboundOrder();
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

        private void toolStripButton7_Click(object sender, EventArgs e) //删除
        {
            fc.DeleteMain(this.gridView3, "StorageFormMainOut", "outStorageNumber");
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

        private void toolStripButton8_Click(object sender, EventArgs e) //导出数据
        {
            string localFilePath = fc.ShowSaveFileDialog();

            if (localFilePath != null)
            {
                gridView2.Export(DevExpress.XtraPrinting.ExportTarget.Xls, localFilePath);
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
                gridControl3.DataSource = fc.showDataLike<domain.StorageFormMainOut>(bs, now_Page.ToString(), input_val);
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
                    domain.StorageFormMainOut bs = new domain.StorageFormMainOut();
                    gridControl3.DataSource = fc.showData<domain.StorageFormMainOut>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page > 1)
                {
                    now_Page--;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.StorageFormMainOut bs = new domain.StorageFormMainOut();
                    gridControl3.DataSource = fc.showData<domain.StorageFormMainOut>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page = 1;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.StorageFormMainOut bs = new domain.StorageFormMainOut();
                    gridControl3.DataSource = fc.showData<domain.StorageFormMainOut>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page = total_Page;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.StorageFormMainOut bs = new domain.StorageFormMainOut();
                    gridControl3.DataSource = fc.showData<domain.StorageFormMainOut>(bs, now_Page.ToString());
                }
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            
        }

        private void gridView3_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            str = gridView3.GetFocusedRowCellDisplayText(gridView3.Columns["outStorageNumber"]); //获取主键内容
            MessageBox.Show(str);
            sd = JsonConvert.DeserializeObject<List<domain.StorageDetailsOut>>(fc.FindDeteils(str, "StorageDetailsOut"));
            gridControl2.DataSource = sd;

            this.gridView2.Columns[0].Caption = "出库单识别码";
            this.gridView2.Columns[0].Visible = false;
            this.gridView2.Columns[1].Caption = "出库单号";
            this.gridView2.Columns[1].Visible = false;
            this.gridView2.Columns[2].Caption = "入库性质";
            this.gridView2.Columns[3].Caption = "入库时间";
            this.gridView2.Columns[4].Caption = "订单号";
            this.gridView2.Columns[5].Caption = "货主";
            this.gridView2.Columns[5].Visible = false;
            this.gridView2.Columns[6].Caption = "卸货点";
            this.gridView2.Columns[6].Visible = false;
            this.gridView2.Columns[7].Caption = "卸货城市";
            this.gridView2.Columns[7].Visible = false;
            this.gridView2.Columns[8].Caption = "卸货区域";
            this.gridView2.Columns[8].Visible = false;
            this.gridView2.Columns[9].Caption = "卷号";
            this.gridView2.Columns[10].Caption = "品种";
            this.gridView2.Columns[11].Caption = "材质";
            this.gridView2.Columns[12].Caption = "规格";
            this.gridView2.Columns[13].Caption = "库存件数";
            this.gridView2.Columns[14].Caption = "库存数量";
            this.gridView2.Columns[15].Caption = "实发件数";
            this.gridView2.Columns[16].Caption = "实发数量";
            this.gridView2.Columns[17].Caption = "入库单识别码";
            this.gridView2.Columns[17].Visible = false;
            this.gridView2.Columns[18].Caption = "车队";
            this.gridView2.Columns[18].Visible = false;
            this.gridView2.Columns[19].Caption = "车号";
            this.gridView2.Columns[19].Visible = false;
            this.gridView2.Columns[20].Caption = "司机";
            this.gridView2.Columns[20].Visible = false;
            this.gridView2.Columns[21].Caption = "发货员";
            this.gridView2.Columns[21].Visible = false;
            this.gridView2.Columns[22].Caption = "发货时间";
            this.gridView2.Columns[22].Visible = false;
            this.gridView2.Columns[23].Caption = "库管";
            this.gridView2.Columns[23].Visible = false;
            this.gridView2.Columns[24].Caption = "吊车工";
            this.gridView2.Columns[24].Visible = false;
            this.gridView2.Columns[25].Caption = "装卸工";
            this.gridView2.Columns[25].Visible = false;
            this.gridView2.Columns[26].Caption = "装卸工1";
            this.gridView2.Columns[26].Visible = false;
            this.gridView2.Columns[27].Caption = "备注";
            this.gridView2.Columns[28].Caption = "实际卸货点";
            this.gridView2.Columns[28].Visible = false;
            this.gridView2.Columns[29].Caption = "实际卸货城市";
            this.gridView2.Columns[29].Visible = false;
            this.gridView2.Columns[30].Caption = "实际卸货区域";
            this.gridView2.Columns[30].Visible = false;
            this.gridView2.Columns[31].Caption = "发装城市";
            this.gridView2.Columns[31].Visible = false;
            this.gridView2.Columns[32].Caption = "发装区域";
            this.gridView2.Columns[32].Visible = false;
            this.gridView2.Columns[33].Caption = "发装点";
            this.gridView2.Columns[33].Visible = false;
            this.gridView2.Columns[34].Caption = "车队标识";
            this.gridView2.Columns[34].Visible = false;
            this.gridView2.Columns[35].Caption = "出库时间";
            this.gridView2.Columns[35].Visible = false;
            this.gridView2.Columns[36].Caption = "垛位号";
            this.gridView2.Columns[36].Visible = false;
            this.gridView2.Columns[37].Caption = "修改人";
            this.gridView2.Columns[37].Visible = false;
            this.gridView2.Columns[38].Caption = "修改时间";
            this.gridView2.Columns[38].Visible = false;
            this.gridView2.Columns[39].Caption = "仓库名称";
            this.gridView2.Columns[39].Visible = false;
            this.gridView2.Columns[40].Caption = "项目号";
            this.gridView2.Columns[41].Caption = "仓费单价";
            this.gridView2.Columns[42].Caption = "仓储费";
            this.gridView2.Columns[43].Caption = "付费单位";
            this.gridView2.Columns[43].Visible = false;
            this.gridView2.Columns[44].Caption = "基础存储期";
            this.gridView2.Columns[44].Visible = false;
            this.gridView2.Columns[45].Caption = "实际存储期";
            this.gridView2.Columns[45].Visible = false;
            this.gridView2.Columns[46].Caption = "超期";
            this.gridView2.Columns[46].Visible = false;
            this.gridView2.Columns[47].Caption = "基本仓储单价";
            this.gridView2.Columns[47].Visible = false;
            this.gridView2.Columns[48].Caption = "超期单价";
            this.gridView2.Columns[48].Visible = false;

            this.gridView2.BestFitColumns();
        }
    }
}
