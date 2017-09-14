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

namespace Demo1._1._3.Views.MyWorkBench_SkipForm.Transport
{
    public partial class New_FleetPrice_1 : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        private BindingList<domain.FleetPrice_Detail> FleetPrice_Detail;
        domain.FleetPrice fp = new FleetPrice();
        domain.FleetPrice_Detail fpd = new domain.FleetPrice_Detail();
        List<domain.FleetPrice_Detail> sd = new List<FleetPrice_Detail>();
        public List<domain.TransportationRegister> tr = new List<TransportationRegister>();
        public List<domain.TransportationRegister_Detail> trd = new List<TransportationRegister_Detail>();
        FunctionClass fc = new FunctionClass();
        public static string Transport_ID = null;
        public Demo1._1._3.Panel2_MyWorkBench.FleetPrice fleetp;
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
        public New_FleetPrice_1()
        {
            InitializeComponent();
            comboBox1.DisplayMember = "运输方式";
            comboBox1.ValueMember = "value";
            comboBox1.DataSource = fc.getTransportation();
            if (Panel2_MyWorkBench.FleetPrice.isExist)
            {
                //主表显示
                textBox14.Text = Panel2_MyWorkBench.FleetPrice.array[0];
                textBox5.Text = Panel2_MyWorkBench.FleetPrice.array[1];
                //dateTimePicker2.Value = Convert.ToDateTime(Panel2_MyWorkBench.FleetPrice.array[2]);
                //textBox4.Text = Panel2_MyWorkBench.FleetPrice.array[3];
                //textBox5.Text = Panel2_MyWorkBench.FleetPrice.array[4];
                textBox3.Text = Panel2_MyWorkBench.FleetPrice.array[4];
                textBox1.Text = Panel2_MyWorkBench.FleetPrice.array[5];
                textBox2.Text = Panel2_MyWorkBench.FleetPrice.array[6];
                textBox13.Text = Panel2_MyWorkBench.FleetPrice.array[7];
                comboBox1.Text = Panel2_MyWorkBench.FleetPrice.array[8];
                textBox9.Text = Panel2_MyWorkBench.FleetPrice.array[9];
                textBox18.Text = Panel2_MyWorkBench.FleetPrice.array[10];
                textBox10.Text = Panel2_MyWorkBench.FleetPrice.array[11];//卸货地点
                dateTimePicker3.Value = Convert.ToDateTime(Panel2_MyWorkBench.FleetPrice.array[12]);
                //dateTimePicker3.Value = Convert.ToDateTime(Panel2_MyWorkBench.FleetPrice.array[14]);
                dateTimePicker4.Value = Convert.ToDateTime(Panel2_MyWorkBench.FleetPrice.array[13]);
                textBox7.Text = Demo1._1._3.Sign_in.name;
                textBox12.Text = Demo1._1._3.Sign_in.name;
                dateTimePicker1.Value = Convert.ToDateTime(Panel2_MyWorkBench.FleetPrice.array[16]);
                dateTimePicker2.Value = Convert.ToDateTime(Panel2_MyWorkBench.FleetPrice.array[17]);
                //明细表显示


                sd = JsonConvert.DeserializeObject<List<domain.FleetPrice_Detail>>(fc.FindDeteils(Panel2_MyWorkBench.FleetPrice.str, "FleetPrice_Detail"));
                FleetPrice_Detail = new BindingList<domain.FleetPrice_Detail>(sd);


                gridControl1.DataSource = FleetPrice_Detail;
                //gridView1.Columns[2].DisplayFormat.FormatType =DevExpress.Utils.FormatType.DateTime;
                //gridView1.Columns[23].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                //gridView1.Columns[25].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                //gridView1.Columns[26].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            }
            else
            {
                DataGridViewInit();
                textBox5.Text = fc.DateTimeToUnix("SJ");
                textBox7.Text = Demo1._1._3.Sign_in.name;
                textBox12.Text = Demo1._1._3.Sign_in.name;

            }

            this.gridView1.Columns[0].Caption = "订单号";
            this.gridView1.Columns[1].Caption = "货主";
            this.gridView1.Columns[2].Caption = "卷号";
            this.gridView1.Columns[3].Caption = "品种";
            this.gridView1.Columns[4].Caption = "材质";
            this.gridView1.Columns[5].Caption = "规格";
            this.gridView1.Columns[6].Caption = "件数";
            this.gridView1.Columns[7].Caption = "数量";
            this.gridView1.Columns[8].Caption = "车队运价";
            this.gridView1.Columns[9].Caption = "车队运费";
            this.gridView1.Columns[10].Caption = "运输单标识";
            this.gridView1.Columns[10].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[11].Caption = "业务部门";
            this.gridView1.Columns[12].Caption = "业务员";
            this.gridView1.Columns[13].Caption = "备注";
            this.gridView1.Columns[14].Caption = "运输单号";
            this.gridView1.Columns[14].OptionsColumn.AllowEdit = false;
            this.gridView1.BestFitColumns();
        }
        public void DataGridViewInit()
        {
            List<domain.FleetPrice_Detail> sd = null;
            sd = JsonConvert.DeserializeObject<List<domain.FleetPrice_Detail>>(fc.GridViewInit("FleetPrice_Detail"));
            FleetPrice_Detail = new BindingList<domain.FleetPrice_Detail>(sd);
            gridControl1.DataSource = FleetPrice_Detail;
        }

        private void simpleButton4_Click(object sender, EventArgs e)//添加
        {
            domain.FleetPrice_Detail sd = new domain.FleetPrice_Detail()
            { transport_identifying = string.Format("{0}-{1}", textBox5.Text, FleetPrice_Detail.Count + 1), transport_ID = textBox5.Text,
            };
            FleetPrice_Detail.Add(sd);
        }

        private void simpleButton3_Click(object sender, EventArgs e)//删除
        {
            try
            {
                int index = gridView1.SelectedRowsCount + 1;//dataGridView1.CurrentRow.Index;
                FleetPrice_Detail.RemoveAt(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)//保存
        {
            if (Panel2_MyWorkBench.FleetPrice.isExist) //保存修改
            {
                fp.transport_ID = textBox5.Text;
                fp.price_ID = textBox14.Text;
                fp.payment = textBox3.Text;
                fp.fleet = textBox1.Text;
                //fp.TotalStorage = Convert.ToDecimal(textBox6.Text);
                fp.car_number = textBox2.Text;
                fp.driver = textBox13.Text;
                fp.transport_way = comboBox1.Text;
                fp.depart_point = textBox9.Text;
                fp.ship_point = textBox18.Text;
                fp.unload_point = textBox10.Text;
                fp.depart_date = dateTimePicker3.Value;
                fp.back_date = dateTimePicker4.Value;
                fp.enter_staff = textBox7.Text;
                fp.change_staff = textBox12.Text;
                fp.enter_time = dateTimePicker1.Value;
                fp.change_time = dateTimePicker2.Value;

                //List<domain.FleetPrice_Detail> sd = FleetPrice_Detail.ToList<domain.FleetPrice_Detail>();
                string Json = JsonConvert.SerializeObject(this.gridControl1.DataSource);
                string jsonMain = JsonConvert.SerializeObject(fp);

                fc.ChangeData(jsonMain, Json, fp.GetType().Name.ToString(), "FleetPrice_Detail");

            }
            else
            {
                fp.transport_ID = textBox5.Text;
                fp.price_ID = textBox14.Text;
                fp.payment = textBox3.Text;
                fp.fleet = textBox1.Text;
                //fp.TotalStorage = Convert.ToDecimal(textBox6.Text);
                fp.car_number = textBox2.Text;
                fp.driver = textBox13.Text;
                fp.transport_way = comboBox1.Text;
                fp.depart_point = textBox9.Text;
                fp.ship_point = textBox18.Text;
                fp.unload_point = textBox10.Text;
                fp.depart_date = dateTimePicker3.Value;
                fp.back_date = dateTimePicker4.Value;
                fp.enter_staff = textBox7.Text;
                fp.change_staff = textBox12.Text;
                fp.enter_time = dateTimePicker1.Value;
                fp.change_time = dateTimePicker2.Value;

                //如果新建的车队定价里的司机定价的主表的运输单号与运输登记的主表的运输单号一致，则填充运输登记里的明细表的数据
                Transport_ID = textBox5.Text;
                tr = JsonConvert.DeserializeObject<List<domain.TransportationRegister>>(fc.FindDate(Transport_ID));
                if (tr != null)
                {
                    trd = JsonConvert.DeserializeObject<List<domain.TransportationRegister_Detail>>(fc.FindDeteils(textBox5.Text, "TransportationRegister_Detail"));
                    for (int i = 0; i < trd.Count; i++)
                    {
                        fpd.order_ID = trd[i].order_number;
                        fpd.owner = trd[i].owner;
                        fpd.reel_number = trd[i].reel_number;
                        fpd.variety = trd[i].variety;
                        fpd.texture = trd[i].texture;
                        fpd.standard = trd[i].standard;
                        fpd.number = trd[i].number;
                        fpd.quantity = trd[i].quantity;
                        sd.Add(fpd);
                    }
                    string json = JsonConvert.SerializeObject(sd);
                    string jsonMain = JsonConvert.SerializeObject(fp);
                    fc.SaveData(jsonMain, json, fp.GetType().Name.ToString(), "FleetPrice_Detail");
                }
                else
                {
                    string Json = JsonConvert.SerializeObject(this.gridControl1.DataSource);
                    string jsonMain = JsonConvert.SerializeObject(fp);
                    fc.SaveData(jsonMain, Json, fp.GetType().Name.ToString(), "FleetPrice_Detail");
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)//取消
        {
            Close();
        }

        private void textBox1_Click(object sender, EventArgs e)//车队
        {
            child_form.ReturnEvent += new TabbedSections.ClickCar(getCarValue);
            child_form.ShowDialog();
        }
        void getCarValue(string a, string b, string c)
        {
            textBox1.Text = a;
            textBox2.Text = b;
            textBox13.Text = c;
        }

        private void textBox9_Click(object sender, EventArgs e)//出发地点
        {

        }

        private void textBox18_Click(object sender, EventArgs e)//装货地点
        {
            load_form.ReturnEvent += new Demo1._1._3._1_NewViews.TebbedSection_LoadSpot.ClickCity(getLoadValue);
            load_form.ShowDialog();
        }
        void getLoadValue(string a, string b, string c)
        {
            textBox18.Text = a;

        }

        private void textBox10_Click(object sender, EventArgs e)//卸货地点
        {
            discharge_form.ReturnEvent += new Demo1._1._3._1_NewViews.TabbedSection_Discharge.ClickCity(getDischargeValue);
            discharge_form.ShowDialog();
        }
        void getDischargeValue(string a, string b, string c)
        {
            textBox10.Text = a;
        }
    }
}
