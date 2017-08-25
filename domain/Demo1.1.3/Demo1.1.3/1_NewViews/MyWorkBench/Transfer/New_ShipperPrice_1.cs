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
using System.Data.SqlTypes;
using WebSocketSharp;
using Basic_SetTest;
using System.Threading;
using Newtonsoft.Json;
using System.Reflection;
using System.Data.OleDb;
using Newtonsoft.Json.Converters;
using Demo1._1._3.MyWorkBench_SkipForm;
using Demo1._1._3.Panel2_MyWorkBench;
using System.IO;
using DevExpress.XtraEditors;
using System.Data.SqlTypes;
using System.Drawing.Printing;

namespace Demo1._1._3.Views.MyWorkBench_SkipForm.Transport
{
    public partial class New_ShipperPrice_1 : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        private BindingList<domain.ShipperPrice_Detail> ShipperPrice_Detail;
        domain.ShipperPrice sfm = new domain.ShipperPrice();
        List<domain.ShipperPrice_Detail> sd = new List<ShipperPrice_Detail>();
        FunctionClass fc = new FunctionClass();
        public Demo1._1._3.Panel2_MyWorkBench.ShipperPrice shipperp;
        /// <summary>
        /// 车队、司机、车号
        /// </summary>
        private TabbedSections child_form = new TabbedSections();

        /// <summary>
        /// 装点、装货城市、装货地区
        /// </summary>
        private Demo1._1._3._1_NewViews.TebbedSection_LoadSpot load_form = new Demo1._1._3._1_NewViews.TebbedSection_LoadSpot();

        /// <summary>
        /// 卸点、发卸城市、发卸地区
        /// </summary>
        private Demo1._1._3._1_NewViews.TabbedSection_Discharge discharge_form = new Demo1._1._3._1_NewViews.TabbedSection_Discharge();
        public New_ShipperPrice_1()
        {
            InitializeComponent();
            int number = 0;
            double total_money = 0;
            double fare = 0;
            shipperp = new Demo1._1._3.Panel2_MyWorkBench.ShipperPrice();
            int rowCount = shipperp.gridView2.RowCount;
            //MessageBox.Show(Convert.ToString(rowCount));
            for (int i = 0; i < rowCount; i++)
            {
                number += Convert.ToInt32(shipperp.gridView2.Columns["数量"].SummaryText);
                total_money += Convert.ToInt32(shipperp.gridView2.Columns["货主金额"].SummaryText);
                fare += Convert.ToInt32(shipperp.gridView2.Columns["货主运价"].SummaryText);
            }
            if (Panel2_MyWorkBench.ShipperPrice.isExist)
            {
                //主表显示
                textBox5.Text = Panel2_MyWorkBench.ShipperPrice.array[0];
                textBox7.Text = Convert.ToString(total_money);
                textBox3.Text = Panel2_MyWorkBench.ShipperPrice.array[2];
                dateTimePicker1.Value = Convert.ToDateTime(Panel2_MyWorkBench.ShipperPrice.array[3]);
                textBox12.Text = Panel2_MyWorkBench.ShipperPrice.array[4];
                dateTimePicker2.Value = Convert.ToDateTime(Panel2_MyWorkBench.ShipperPrice.array[5]);
                textBox1.Text = Convert.ToString(rowCount);
                textBox2.Text = Convert.ToString(number);
                textBox6.Text = Convert.ToString(fare);

                //明细表显示


                sd = JsonConvert.DeserializeObject<List<domain.ShipperPrice_Detail>>(fc.FindDeteils(Panel2_MyWorkBench.ShipperPrice.str, "ShipperPrice_Detail"));
                ShipperPrice_Detail = new BindingList<domain.ShipperPrice_Detail>(sd);


                gridControl1.DataSource = ShipperPrice_Detail;
                //gridView1.Columns[2].DisplayFormat.FormatType =DevExpress.Utils.FormatType.DateTime;
                //gridView1.Columns[23].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                //gridView1.Columns[25].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                //gridView1.Columns[26].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            }
            else
            {
                DataGridViewInit();
                textBox5.Text = fc.DateTimeToUnix("HJ");
                textBox1.Text = Convert.ToString(rowCount);
                textBox2.Text = Convert.ToString(number);
                textBox6.Text = Convert.ToString(fare);
                textBox7.Text = Convert.ToString(total_money);
            }

            this.gridView1.Columns[0].Caption = "货主";
            this.gridView1.Columns[1].Caption = "运输单标识";
            this.gridView1.Columns[1].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[2].Caption = "订单号";
            this.gridView1.Columns[3].Caption = "运输方式";
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox combobox_transportation = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            combobox_transportation.Items.AddRange(fc.getTransportation());
            this.gridView1.Columns[3].ColumnEdit = combobox_transportation;
            this.gridView1.Columns[4].Caption = "出发地点";
            this.gridView1.Columns[4].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[5].Caption = "装货地点";
            this.gridView1.Columns[5].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[6].Caption = "卸货地点";
            this.gridView1.Columns[6].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[7].Caption = "出发日期";
            this.gridView1.Columns[8].Caption = "返回日期";
            this.gridView1.Columns[9].Caption = "卷号";
            this.gridView1.Columns[10].Caption = "品种";
            this.gridView1.Columns[11].Caption = "材质";
            this.gridView1.Columns[12].Caption = "规格";
            this.gridView1.Columns[13].Caption = "件数";
            this.gridView1.Columns[14].Caption = "数量";
            this.gridView1.Columns[15].Caption = "货主运价";
            this.gridView1.Columns[16].Caption = "货主金额";
            this.gridView1.Columns[17].Caption = "备注";
            this.gridView1.Columns[18].Caption = "车队";
            this.gridView1.Columns[18].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[19].Caption = "车号";
            this.gridView1.Columns[19].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[20].Caption = "司机";
            this.gridView1.Columns[20].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[21].Caption = "出发城市";
            this.gridView1.Columns[21].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[22].Caption = "出发区域";
            this.gridView1.Columns[22].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[23].Caption = "装货城市";
            this.gridView1.Columns[23].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[24].Caption = "装货区域";
            this.gridView1.Columns[24].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[25].Caption = "卸货城市";
            this.gridView1.Columns[25].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[26].Caption = "卸货区域";
            this.gridView1.Columns[26].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[27].Caption = "定价单号";
            this.gridView1.Columns[27].OptionsColumn.AllowEdit = false;
            this.gridView1.BestFitColumns();
        }
        public void DataGridViewInit()
        {
            List<domain.ShipperPrice_Detail> sd = null;
            sd = JsonConvert.DeserializeObject<List<domain.ShipperPrice_Detail>>(fc.GridViewInit("ShipperPrice_Detail"));
            ShipperPrice_Detail = new BindingList<domain.ShipperPrice_Detail>(sd);
            gridControl1.DataSource = ShipperPrice_Detail;
        }

        private void simpleButton4_Click(object sender, EventArgs e)//添加
        {
            domain.ShipperPrice_Detail sd = new domain.ShipperPrice_Detail()
            { transport_identifying = string.Format("{0}-{1}", textBox5.Text, ShipperPrice_Detail.Count + 1), price_ID = textBox5.Text };
            ShipperPrice_Detail.Add(sd);
        }

        private void simpleButton3_Click(object sender, EventArgs e)//删除
        {
            try
            {
                int index = gridView1.SelectedRowsCount + 1;//dataGridView1.CurrentRow.Index;
                ShipperPrice_Detail.RemoveAt(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)//保存
        {
            if (Panel2_MyWorkBench.ShipperPrice.isExist) //保存修改
            {
                sfm.price_ID = textBox5.Text;
                //sfm.total_money = Convert.ToDecimal(textBox7.Text);
                sfm.enter_staff = textBox3.Text;
                sfm.enter_time = dateTimePicker1.Value;
                sfm.change_staff = textBox12.Text;
                sfm.change_time = dateTimePicker2.Value;
               


                List<domain.ShipperPrice_Detail> sd = ShipperPrice_Detail.ToList<domain.ShipperPrice_Detail>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(sfm);

                fc.ChangeData(jsonMain, Json, sfm.GetType().Name.ToString(), "ShipperPrice_Detail");
            }

            else   //保存
            {
                sfm.price_ID = textBox5.Text;
                //sfm.total_money = Convert.ToDecimal(textBox7.Text);
                sfm.enter_staff = textBox3.Text;
                sfm.enter_time = dateTimePicker1.Value;
                sfm.change_staff = textBox12.Text;
                sfm.change_time = dateTimePicker2.Value;
                

                List<domain.ShipperPrice_Detail> sd = ShipperPrice_Detail.ToList<domain.ShipperPrice_Detail>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(sfm);

                fc.SaveData(jsonMain, Json, sfm.GetType().Name.ToString(), "ShipperPrice_Detail");
            }
            shipperp = new Demo1._1._3.Panel2_MyWorkBench.ShipperPrice();
            domain.ShipperPrice fleetprice = new domain.ShipperPrice();
            Demo1._1._3.Panel2_MyWorkBench.ShipperPrice dbs = new Panel2_MyWorkBench.ShipperPrice();
            domain.ShipperPrice_Detail fleetprice_detail = new domain.ShipperPrice_Detail();
            shipperp.gridControl1.DataSource = fc.showData<domain.ShipperPrice>(fleetprice, dbs.now_Page1.ToString());
            shipperp.gridControl2.DataSource = fc.showData<domain.ShipperPrice_Detail>(fleetprice_detail, dbs.now_Page2.ToString());
        }

        private void simpleButton2_Click(object sender, EventArgs e)//取消
        {
            Close();
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DateTime date;
            DateTime min = new DateTime(1753, 1, 1);
            if (e.Column.FieldName == "depart_date" || e.Column.FieldName == "back_date")
            {
                try
                {
                    date = Convert.ToDateTime(e.Value);
                    if (date < min)
                    {
                        MessageBox.Show("时间值允许大于1753/1/1的时间段");
                    }
                }
                catch (Exception)
                {
                    // MessageBox.Show("时间值允许大于1753/1/1的时间段");
                    throw;
                }

            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Caption == "卸货城市" || e.Column.Caption == "卸货地点" || e.Column.Caption == "卸货区域")
            {
                discharge_form.ReturnEvent += new Demo1._1._3._1_NewViews.TabbedSection_Discharge.ClickCity(getDischargeValue);
                discharge_form.ShowDialog();
            }
            if (e.Column.Caption == "装货城市" || e.Column.Caption == "装货地点" || e.Column.Caption == "装货区域")
            {
                load_form.ReturnEvent += new Demo1._1._3._1_NewViews.TebbedSection_LoadSpot.ClickCity(getLoadValue);
                load_form.ShowDialog();
            }
            if (e.Column.Caption == "车队" || e.Column.Caption == "车号" || e.Column.Caption == "司机")
            {
                child_form.ReturnEvent += new TabbedSections.ClickCar(getCarValue);
                child_form.ShowDialog();
            }
        }
        public void getDischargeValue(string a, string b, string c)
        {
            this.gridView1.SetRowCellValue((ShipperPrice_Detail.Count - 1), gridView1.Columns[25], a);
            this.gridView1.SetRowCellValue((ShipperPrice_Detail.Count - 1), gridView1.Columns[6], b);
            this.gridView1.SetRowCellValue((ShipperPrice_Detail.Count - 1), gridView1.Columns[26], c);
        }
        public void getLoadValue(string a, string b, string c)
        {
            this.gridView1.SetRowCellValue((ShipperPrice_Detail.Count - 1), gridView1.Columns[23], a);
            this.gridView1.SetRowCellValue((ShipperPrice_Detail.Count - 1), gridView1.Columns[5], b);
            this.gridView1.SetRowCellValue((ShipperPrice_Detail.Count - 1), gridView1.Columns[24], c);
        }
        void getCarValue(string a, string b, string c)
        {
            this.gridView1.SetRowCellValue((ShipperPrice_Detail.Count - 1), gridView1.Columns[18], a);
            this.gridView1.SetRowCellValue((ShipperPrice_Detail.Count - 1), gridView1.Columns[19], b);
            this.gridView1.SetRowCellValue((ShipperPrice_Detail.Count - 1), gridView1.Columns[20], c);
        }
    }
}
