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
        List<domain.FleetPrice_Detail> sd = new List<FleetPrice_Detail>();
        FunctionClass fc = new FunctionClass();
        public New_FleetPrice_1()
        {
            InitializeComponent();
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
                textBox8.Text = Panel2_MyWorkBench.FleetPrice.array[8];
                textBox9.Text = Panel2_MyWorkBench.FleetPrice.array[9];
                textBox18.Text = Panel2_MyWorkBench.FleetPrice.array[10];
                textBox10.Text = Panel2_MyWorkBench.FleetPrice.array[11];//卸货地点
                dateTimePicker3.Value = Convert.ToDateTime(Panel2_MyWorkBench.FleetPrice.array[12]);
                //dateTimePicker3.Value = Convert.ToDateTime(Panel2_MyWorkBench.FleetPrice.array[14]);
                dateTimePicker4.Value = Convert.ToDateTime(Panel2_MyWorkBench.FleetPrice.array[13]);
                textBox7.Text = Panel2_MyWorkBench.FleetPrice.array[14];
                textBox12.Text = Panel2_MyWorkBench.FleetPrice.array[15];
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

            }
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
            domain.FleetPrice_Detail sd = new domain.FleetPrice_Detail() {/* StorageFormMain = fp*/ };
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
                fp.transport_way = textBox8.Text;
                fp.depart_point = textBox9.Text;
                fp.ship_point = textBox18.Text;
                fp.unload_point = textBox10.Text;
                fp.depart_date = dateTimePicker3.Value;
                fp.back_date = dateTimePicker4.Value;
                fp.enter_staff = textBox7.Text;
                fp.change_staff = textBox12.Text;
                fp.enter_time = dateTimePicker1.Value;
                fp.change_time = dateTimePicker2.Value;

                List<domain.FleetPrice_Detail> sd = FleetPrice_Detail.ToList<domain.FleetPrice_Detail>();
                string Json = JsonConvert.SerializeObject(sd);
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
                fp.transport_way = textBox8.Text;
                fp.depart_point = textBox9.Text;
                fp.ship_point = textBox18.Text;
                fp.unload_point = textBox10.Text;
                fp.depart_date = dateTimePicker3.Value;
                fp.back_date = dateTimePicker4.Value;
                fp.enter_staff = textBox7.Text;
                fp.change_staff = textBox12.Text;
                fp.enter_time = dateTimePicker1.Value;
                fp.change_time = dateTimePicker2.Value;

                List<domain.FleetPrice_Detail> sd = FleetPrice_Detail.ToList<domain.FleetPrice_Detail>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(fp);

                fc.SaveData(jsonMain, Json, fp.GetType().Name.ToString(), "FleetPrice_Detail");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)//取消
        {
            Close();
        }
    }
}
