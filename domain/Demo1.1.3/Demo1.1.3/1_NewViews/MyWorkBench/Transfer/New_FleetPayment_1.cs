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
    public partial class New_FleetPayment_1 : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        private BindingList<domain.FleetPayment_Detail> FleetPayment_Detail;
        domain.FleetPayment sfm = new FleetPayment();
        List<domain.FleetPayment_Detail> sd = new List<FleetPayment_Detail>();
        FunctionClass fc = new FunctionClass();
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

            }
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
            domain.FleetPayment_Detail sd = new domain.FleetPayment_Detail() {/* FleetPayment = sfm*/ };
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

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
