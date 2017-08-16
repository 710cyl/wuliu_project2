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
    public partial class New_ShipperPrice_1 : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        private BindingList<domain.ShipperPrice_Detail> ShipperPrice_Detail;
        domain.ShipperPrice sfm = new ShipperPrice();
        List<domain.ShipperPrice_Detail> sd = new List<ShipperPrice_Detail>();
        FunctionClass fc = new FunctionClass();
        public New_ShipperPrice_1()
        {
            InitializeComponent();
            if (Panel2_MyWorkBench.ShipperPrice.isExist)
            {
                //主表显示
                textBox5.Text = Panel2_MyWorkBench.ShipperPrice.array[0];
                textBox7.Text = Panel2_MyWorkBench.ShipperPrice.array[1];
                textBox3.Text = Panel2_MyWorkBench.ShipperPrice.array[2];
                dateTimePicker1.Value = Convert.ToDateTime(Panel2_MyWorkBench.ShipperPrice.array[3]);
                textBox12.Text = Panel2_MyWorkBench.ShipperPrice.array[4];
                dateTimePicker2.Value = Convert.ToDateTime(Panel2_MyWorkBench.ShipperPrice.array[5]);
                //textBox1.Text = Panel2_MyWorkBench.ShipperPrice.array[7];
                //textBox2.Text = Panel2_MyWorkBench.ShipperPrice.array[8];
                //textBox6.Text = Panel2_MyWorkBench.ShipperPrice.array[9];

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

            }
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
            domain.ShipperPrice_Detail sd = new domain.ShipperPrice_Detail() {/* ShipperPrice = sfm*/ };
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
                sfm.total_money = Convert.ToDecimal(textBox7.Text);
                sfm.enter_staff = textBox3.Text;
                sfm.enter_time = dateTimePicker1.Value;
                sfm.change_staff = textBox12.Text;
                sfm.change_time = dateTimePicker2.Value;
                //sfm.CarNumber = textBox1.Text;
                //sfm.Driver = textBox2.Text;
                //sfm.LoadingCity = textBox6.Text;


                List<domain.ShipperPrice_Detail> sd = ShipperPrice_Detail.ToList<domain.ShipperPrice_Detail>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(sfm);

                fc.ChangeData(jsonMain, Json, sfm.GetType().Name.ToString(), "ShipperPrice_Detail");
            }

            else   //保存
            {
                sfm.price_ID = textBox5.Text;
                sfm.total_money = Convert.ToDecimal(textBox7.Text);
                sfm.enter_staff = textBox3.Text;
                sfm.enter_time = dateTimePicker1.Value;
                sfm.change_staff = textBox12.Text;
                sfm.change_time = dateTimePicker2.Value;
                //sfm.CarNumber = textBox1.Text;
                //sfm.Driver = textBox2.Text;
                //sfm.LoadingCity = textBox6.Text;

                List<domain.ShipperPrice_Detail> sd = ShipperPrice_Detail.ToList<domain.ShipperPrice_Detail>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(sfm);

                fc.SaveData(jsonMain, Json, sfm.GetType().Name.ToString(), "ShipperPrice_Detail");
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
    }
}
