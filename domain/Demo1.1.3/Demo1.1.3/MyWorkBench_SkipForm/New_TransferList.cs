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

namespace Demo1._1._3.Views.MyWorkBench_SkipForm
{
    public partial class New_TransferList : Form
    {
        private BindingList<domain.StorageDetailsTrans> StorageDetails;
        domain.StorageFormMainTrans sfm = new StorageFormMainTrans();
        List<domain.StorageDetailsTrans> sd = new List<StorageDetailsTrans>();
        FunctionClass fc = new FunctionClass();
        public New_TransferList()
        {
            InitializeComponent();

            if (Panel2_MyWorkBench.TransferList.isExist)
            {
                comboBox3.Text = Panel2_MyWorkBench.TransferList.array[0];
                comboBox4.Text = Panel2_MyWorkBench.TransferList.array[2];
                textBox20.Text = Panel2_MyWorkBench.TransferList.array[3];
                textBox8.Text = Panel2_MyWorkBench.TransferList.array[4];
                textBox5.Text = Panel2_MyWorkBench.TransferList.array[18];
                textBox3.Text = Panel2_MyWorkBench.TransferList.array[16];
                textBox9.Text = Panel2_MyWorkBench.TransferList.array[17];
                textBox18.Text = Panel2_MyWorkBench.TransferList.array[15];
                textBox10.Text = Panel2_MyWorkBench.TransferList.array[1];
                dateTimePicker1.Value =Convert.ToDateTime( Panel2_MyWorkBench.TransferList.array[5]);
                comboBox1.Text = Panel2_MyWorkBench.TransferList.array[10];
                comboBox5.Text = Panel2_MyWorkBench.TransferList.array[11];
                comboBox2.Text = Panel2_MyWorkBench.TransferList.array[12];
                comboBox6.Text = Panel2_MyWorkBench.TransferList.array[19];
                textBox14.Text = Panel2_MyWorkBench.TransferList.array[15];
                textBox13.Text = Panel2_MyWorkBench.TransferList.array[6];
                dateTimePicker2.Value =Convert.ToDateTime( Panel2_MyWorkBench.TransferList.array[7]);
                textBox12.Text = Panel2_MyWorkBench.TransferList.array[8];
                dateTimePicker3.Value = Convert.ToDateTime(Panel2_MyWorkBench.TransferList.array[9]);


                sd = JsonConvert.DeserializeObject<List<domain.StorageDetailsTrans>>(fc.FindDeteils(Panel2_MyWorkBench.TransferList.str, "StorageDetailsTrans"));
                StorageDetails = new BindingList<domain.StorageDetailsTrans>(sd);


                gridControl1.DataSource = StorageDetails;
            }

            else
            {
                DataGridViewInit();
            }
        }

        public void DataGridViewInit()
        {
            List<domain.StorageDetailsTrans> sd = null;
            sd = JsonConvert.DeserializeObject<List<domain.StorageDetailsTrans>>(fc.GridViewInit());
            StorageDetails = new BindingList<domain.StorageDetailsTrans>(sd);
            gridControl1.DataSource = StorageDetails;
        }

        private void simpleButton4_Click(object sender, EventArgs e) //添加
        {
            domain.StorageDetailsTrans sd = new domain.StorageDetailsTrans() {/* StorageFormMain = sfm*/ };
            StorageDetails.Add(sd);
        }

        private void simpleButton3_Click(object sender, EventArgs e) //删除
        {
            try
            {
                int index = gridView1.SelectedRowsCount + 1;//dataGridView1.CurrentRow.Index;
                StorageDetails.RemoveAt(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e) //保存
        {
            if (Panel2_MyWorkBench.TransferList.isExist)
            {
                sfm.StorageName = comboBox3.Text;
                sfm.StorageWay = comboBox4.Text;
                sfm.RemoveCustomer = textBox20.Text;
                sfm.InCustomer = textBox8.Text;
                sfm.StoragePriceUnit = textBox5.Text;
                sfm.StoragePriceSingle =Convert.ToDecimal( textBox3.Text);
                sfm.StoragePrice = Convert.ToDecimal(textBox9.Text);
                sfm.StorageUnitPrice = textBox18.Text;
                sfm.StorageNumber = textBox10.Text;
                sfm.AccountDate = dateTimePicker1.Value;
                sfm.StorageKeeper = comboBox1.Text;
                sfm.Craneman = comboBox5.Text;
                sfm.Loader = comboBox2.Text;
                sfm.Loader_1 = comboBox6.Text;
                sfm.TotalStorage =Convert.ToDecimal( textBox14.Text);
                sfm.KeyBoarder = textBox13.Text;
                sfm.KeyTime = dateTimePicker2.Value;
                sfm.Modifier = textBox12.Text;
                sfm.ModifyTime = dateTimePicker3.Value;

                List<domain.StorageDetailsTrans> sd = StorageDetails.ToList<domain.StorageDetailsTrans>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(sfm);

                fc.ChangeData(jsonMain, Json, sfm.GetType().Name.ToString(), "StorageDetailsTrans");
            }

            else
            {
                sfm.StorageName = comboBox3.Text;
                sfm.StorageWay = comboBox4.Text;
                sfm.RemoveCustomer = textBox20.Text;
                sfm.InCustomer = textBox8.Text;
                sfm.StoragePriceUnit = textBox5.Text;
                sfm.StoragePriceSingle = Convert.ToDecimal(textBox3.Text);
                sfm.StoragePrice = Convert.ToDecimal(textBox9.Text);
                sfm.StorageUnitPrice = textBox18.Text;
                sfm.StorageNumber = textBox10.Text;
                sfm.AccountDate = dateTimePicker1.Value;
                sfm.StorageKeeper = comboBox1.Text;
                sfm.Craneman = comboBox5.Text;
                sfm.Loader = comboBox2.Text;
                sfm.Loader_1 = comboBox6.Text;
                sfm.TotalStorage = Convert.ToDecimal(textBox14.Text);
                sfm.KeyBoarder = textBox13.Text;
                sfm.KeyTime = dateTimePicker2.Value;
                sfm.Modifier = textBox12.Text;
                sfm.ModifyTime = dateTimePicker3.Value;

                List<domain.StorageDetailsTrans> sd = StorageDetails.ToList<domain.StorageDetailsTrans>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(sfm);

                fc.SaveData(jsonMain, Json, sfm.GetType().Name.ToString(), "StorageDetailsTrans");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e) //取消
        {
            Close();
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DateTime date;
            DateTime min = new DateTime(1753, 1, 1);
            if (e.Column.FieldName == "StorageTime" || e.Column.FieldName == "ProductionDate" || e.Column.FieldName == "KeyTime" || e.Column.FieldName == "ModifyTime")
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
                    throw;
                }
            }
        }
    }
}
