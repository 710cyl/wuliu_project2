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
using System.Data.SqlTypes;
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
using System.Data.SqlTypes;
using System.Drawing.Printing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Demo1._1._3.Views.MyWorkBench_SkipForm.Transport
{
    public partial class New_FleetPayment_1 : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        private BindingList<domain.FleetPayment_Detail> FleetPayment_Detail;
        domain.FleetPayment sfm = new FleetPayment();
        List<domain.FleetPayment_Detail> sd = new List<FleetPayment_Detail>();
        FunctionClass fc = new FunctionClass();
        public Demo1._1._3.Panel2_MyWorkBench.FleetPayment fleetpay;
        /// <summary>
        /// 车队、司机
        /// </summary>
        private TabbedSections child_form = new TabbedSections();
        private Demo1._1._3._1_NewViews.TebbedSection_LoadSpot load_form = new Demo1._1._3._1_NewViews.TebbedSection_LoadSpot();
        private Demo1._1._3._1_NewViews.TabbedSection_Discharge discharge_form = new Demo1._1._3._1_NewViews.TabbedSection_Discharge();
        public New_FleetPayment_1()
        {
            InitializeComponent();
            if (Panel2_MyWorkBench.FleetPayment.isExist)
            {
                //主表显示
                textBox18.Text = Panel2_MyWorkBench.FleetPayment.array[0];
                textBox20.Text = Panel2_MyWorkBench.FleetPayment.array[1];
                //dateTimePicker2.Value = Convert.ToDateTime(Panel2_MyWorkBench.FleetPayment.array[2]);
                textBox19.Text = Panel2_MyWorkBench.FleetPayment.array[2];
                textBox17.Text = Panel2_MyWorkBench.FleetPayment.array[5];
                dateTimePicker1.Value = Convert.ToDateTime(Panel2_MyWorkBench.FleetPayment.array[6]);
                //明细表显示


                sd = JsonConvert.DeserializeObject<List<domain.FleetPayment_Detail>>(fc.FindDeteils(Panel2_MyWorkBench.FleetPayment.str, "FleetPayment_Detail"));
                FleetPayment_Detail = new BindingList<domain.FleetPayment_Detail>(sd);


                gridControl1.DataSource = FleetPayment_Detail;
                //gridView1.Columns[2].DisplayFormat.FormatType =DevExpress.Utils.FormatType.DateTime;
                //gridView1.Columns[23].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                //gridView1.Columns[25].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                //gridView1.Columns[26].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            }
            else
            {
                DataGridViewInit();
                textBox18.Text = fc.DateTimeToUnix("CK");
            }

            this.gridView1.Columns[0].Caption = "定价单号";
            this.gridView1.Columns[0].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[1].Caption = "运输方式";
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox combobox_transportation = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            combobox_transportation.Items.AddRange(fc.getTransportation());
            this.gridView1.Columns[1].ColumnEdit = combobox_transportation;
            this.gridView1.Columns[2].Caption = "出发地点";
            this.gridView1.Columns[2].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[3].Caption = "装货地点";
            this.gridView1.Columns[3].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[4].Caption = "卸货地点";
            this.gridView1.Columns[4].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[5].Caption = "出发日期";
            this.gridView1.Columns[6].Caption = "返回日期";
            this.gridView1.Columns[7].Caption = "运量";
            this.gridView1.Columns[8].Caption = "单价";
            this.gridView1.Columns[9].Caption = "运费";
            this.gridView1.Columns[10].Caption = "备注";
            this.gridView1.Columns[11].Caption = "运输单号";
            this.gridView1.Columns[12].Caption = "清单号";
            this.gridView1.Columns[12].OptionsColumn.AllowEdit = false;
            this.gridView1.BestFitColumns();
        }
        public void DataGridViewInit()
        {
            List<domain.FleetPayment_Detail> sd = null;
            sd = JsonConvert.DeserializeObject<List<domain.FleetPayment_Detail>>(fc.GridViewInit("FleetPayment_Detail"));
            FleetPayment_Detail = new BindingList<domain.FleetPayment_Detail>(sd);
            gridControl1.DataSource = FleetPayment_Detail;
        }

        private void simpleButton4_Click(object sender, EventArgs e)//添加
        {
            domain.FleetPayment_Detail sd = new domain.FleetPayment_Detail()
            { price_ID = string.Format("{0}-{1}", textBox18.Text, FleetPayment_Detail.Count + 1), list_ID = textBox18.Text };
            FleetPayment_Detail.Add(sd);
        }

        private void simpleButton3_Click(object sender, EventArgs e)//删除
        {
            try
            {
                int index = gridView1.SelectedRowsCount + 1;//dataGridView1.CurrentRow.Index;
                FleetPayment_Detail.RemoveAt(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)//保存
        {
            if (Panel2_MyWorkBench.FleetPayment.isExist) //保存修改
            {
                sfm.list_ID = textBox18.Text;
                sfm.fleet = textBox20.Text;
                sfm.car_number = textBox19.Text;
                sfm.make_staff = textBox17.Text;
                sfm.make_time = dateTimePicker1.Value;

                List<domain.FleetPayment_Detail> sd = FleetPayment_Detail.ToList<domain.FleetPayment_Detail>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(sfm);

                fc.ChangeData(jsonMain, Json, sfm.GetType().Name.ToString(), "FleetPayment_Detail");
            }

            else   //保存
            {
                sfm.list_ID = textBox18.Text;
                sfm.fleet = textBox20.Text;
                sfm.car_number = textBox19.Text;
                sfm.make_staff = textBox17.Text;
                sfm.make_time = dateTimePicker1.Value;

                List<domain.FleetPayment_Detail> sd = FleetPayment_Detail.ToList<domain.FleetPayment_Detail>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(sfm);

                fc.SaveData(jsonMain, Json, sfm.GetType().Name.ToString(), "FleetPayment_Detail");
            }
            fleetpay = new Demo1._1._3.Panel2_MyWorkBench.FleetPayment();
            domain.FleetPayment fleetprice = new domain.FleetPayment();
            Demo1._1._3.Panel2_MyWorkBench.FleetPayment dbs = new Panel2_MyWorkBench.FleetPayment();
            domain.FleetPayment_Detail fleetprice_detail = new domain.FleetPayment_Detail();
            fleetpay.gridControl1.DataSource = fc.showData<domain.FleetPayment>(fleetprice, dbs.now_Page1.ToString());
            fleetpay.gridControl2.DataSource = fc.showData<domain.FleetPayment_Detail>(fleetprice_detail, dbs.now_Page2.ToString());
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

        private void textBox20_Click(object sender, EventArgs e)//车队
        {
            child_form.ReturnEvent += new TabbedSections.ClickCar(getCarValue);
            child_form.ShowDialog();
        }
        void getCarValue(string a, string b, string c)
        {
            textBox20.Text = a;
            textBox19.Text = b;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Caption == "卸货地点")
            {
                discharge_form.ReturnEvent += new Demo1._1._3._1_NewViews.TabbedSection_Discharge.ClickCity(getDischargeValue);
                discharge_form.ShowDialog();
            }
            if (e.Column.Caption == "出发地点")
            {
                //discharge_form.ReturnEvent += new Demo1._1._3._1_NewViews.TabbedSection_Discharge.ClickCity(getDischargeValue);
                //discharge_form.ShowDialog();
            }
            if (e.Column.Caption == "装货地点")
            {
                load_form.ReturnEvent += new Demo1._1._3._1_NewViews.TebbedSection_LoadSpot.ClickCity(getLoadValue);
                load_form.ShowDialog();
            }
        }
        public void getDischargeValue(string a, string b, string c)
        {
            this.gridView1.SetRowCellValue((FleetPayment_Detail.Count - 1), gridView1.Columns[4], a);
        }
        public void getLoadValue(string a, string b, string c)
        {
            this.gridView1.SetRowCellValue((FleetPayment_Detail.Count - 1), gridView1.Columns[3], a);
        }
    }
}
