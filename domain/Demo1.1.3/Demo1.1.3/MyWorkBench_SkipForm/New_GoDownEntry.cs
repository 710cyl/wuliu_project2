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

namespace Demo1._1._3.MyWorkBench_SkipForm
{
    public partial class New_GoDownEntry : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        private BindingList<domain.StorageDetails> StorageDetails;
        domain.StorageFormMain sfm = new StorageFormMain();
        List<domain.StorageDetails> sd = new List<StorageDetails>();
        FunctionClass fc = new FunctionClass();

        public New_GoDownEntry()
        {
            InitializeComponent();
            
            if (Panel2_MyWorkBench.GodownEntry.isExist)
            {
                //主表显示
                textBox2.Text = Panel2_MyWorkBench.GodownEntry.array[0];
                textBox1.Text = Panel2_MyWorkBench.GodownEntry.array[1];
                dateTimePicker2.Value = Convert.ToDateTime(Panel2_MyWorkBench.GodownEntry.array[2]);
                textBox4.Text = Panel2_MyWorkBench.GodownEntry.array[3];
                textBox5.Text = Panel2_MyWorkBench.GodownEntry.array[4];
                textBox8.Text = Panel2_MyWorkBench.GodownEntry.array[5];
                textBox9.Text = Panel2_MyWorkBench.GodownEntry.array[6];
                textBox6.Text = Panel2_MyWorkBench.GodownEntry.array[7];
                textBox10.Text = Panel2_MyWorkBench.GodownEntry.array[8];
                textBox12.Text = Panel2_MyWorkBench.GodownEntry.array[9];
                textBox11.Text = Panel2_MyWorkBench.GodownEntry.array[10];
                textBox13.Text = Panel2_MyWorkBench.GodownEntry.array[11];
                dateTimePicker1.Value = Convert.ToDateTime(Panel2_MyWorkBench.GodownEntry.array[12]);
                textBox14.Text = Panel2_MyWorkBench.GodownEntry.array[13];
                dateTimePicker3.Value = Convert.ToDateTime(Panel2_MyWorkBench.GodownEntry.array[14]);
                textBox16.Text = Panel2_MyWorkBench.GodownEntry.array[15];
                textBox17.Text = Panel2_MyWorkBench.GodownEntry.array[16];
                textBox7.Text = Panel2_MyWorkBench.GodownEntry.array[17];
                textBox18.Text = Panel2_MyWorkBench.GodownEntry.array[18];
                textBox19.Text = Panel2_MyWorkBench.GodownEntry.array[19];
                textBox15.Text = Panel2_MyWorkBench.GodownEntry.array[20];
                textBox20.Text = Panel2_MyWorkBench.GodownEntry.array[21];
                textBox21.Text = Panel2_MyWorkBench.GodownEntry.array[22];

                //明细表显示


                sd = JsonConvert.DeserializeObject<List<domain.StorageDetails>>(fc.FindDeteils(Panel2_MyWorkBench.GodownEntry.str, "StorageDetails"));
                StorageDetails = new BindingList<domain.StorageDetails>(sd);


                gridControl1.DataSource = StorageDetails;

            }
            else
            {
                DataGridViewInit();
                textBox2.Text = fc.DateTimeToUnix("CK");
            }

            this.gridView1.Columns[0].Caption = "入库单识别码";
            this.gridView1.Columns[0].OptionsColumn.AllowEdit = false; //设置不可编辑的列
            this.gridView1.Columns[1].Caption = "入库单号";
            this.gridView1.Columns[1].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[2].Caption = "仓库名称";
            this.gridView1.Columns[3].Caption = "出厂日期";
            this.gridView1.Columns[4].Caption = "订单号";
            this.gridView1.Columns[5].Caption = "货主";
            this.gridView1.Columns[6].Caption = "卸货点";
            this.gridView1.Columns[7].Caption = "卸货城市";
            this.gridView1.Columns[8].Caption = "卸货区域";
            this.gridView1.Columns[9].Caption = "卷号";
            this.gridView1.Columns[10].Caption = "品种";
            this.gridView1.Columns[11].Caption = "材质";
            this.gridView1.Columns[12].Caption = "规格";
            this.gridView1.Columns[13].Caption = "件数";
            this.gridView1.Columns[14].Caption = "数量";
            this.gridView1.Columns[15].Caption = "垛位号";
            this.gridView1.Columns[16].Caption = "入库方式";
            this.gridView1.Columns[17].Caption = "车队";
            this.gridView1.Columns[18].Caption = "车号";
            this.gridView1.Columns[19].Caption = "司机";
            this.gridView1.Columns[20].Caption = "装货城市";
            this.gridView1.Columns[21].Caption = "装货地点";
            this.gridView1.Columns[22].Caption = "装货区域";
            this.gridView1.Columns[23].Caption = "录入员";
            this.gridView1.Columns[24].Caption = "录入时间";
            this.gridView1.Columns[25].Caption = "修改人";
            this.gridView1.Columns[26].Caption = "修改时间";
            this.gridView1.Columns[27].Caption = "入库时间";
            this.gridView1.Columns[28].Caption = "库管";
            this.gridView1.Columns[29].Caption = "吊车工";
            this.gridView1.Columns[30].Caption = "装卸工";
            this.gridView1.Columns[31].Caption = "其他人";
            this.gridView1.Columns[32].Caption = "备注";
            this.gridView1.Columns[33].Caption = "库存件数";
            this.gridView1.Columns[34].Caption = "库存数量";
            this.gridView1.Columns[35].Caption = "票数";
            this.gridView1.Columns[36].Caption = "车队标识";
            this.gridView1.Columns[37].Caption = "项目号";
            this.gridView1.Columns[38].Caption = "可派件数";
            this.gridView1.Columns[39].Caption = "可派数量";
            
            /*
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.GroupSummary.Clear();
            this.gridView1.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, gridView1.Columns[33].Caption, gridView1.Columns[33], "合计:{0}");
            */

            this.gridView1.BestFitColumns();
        }

        public void DataGridViewInit()
        {
            List<domain.StorageDetails> sd = null;
            sd =  JsonConvert.DeserializeObject<List<domain.StorageDetails>>(fc.GridViewInit("StorageDetails"));
            StorageDetails = new BindingList<domain.StorageDetails>(sd);
            gridControl1.DataSource = StorageDetails;
        }

       

        private void button1_Click(object sender, EventArgs e) //添加数据
        {
            domain.StorageDetails sd = new domain.StorageDetails() { StorageCode = string.Format("{0}-{1}", textBox2.Text, StorageDetails.Count + 1), StorageNumber = textBox2.Text };
            StorageDetails.Add(sd);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int index = gridView1.SelectedRowsCount;//dataGridView1.CurrentRow.Index;
                StorageDetails.RemoveAt(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);        
            }        
        }

        private void button3_Click(object sender, EventArgs e) //保存按钮 
        {
            if (Panel2_MyWorkBench.GodownEntry.isExist) //保存修改
            {
                sfm.StorageNumber = textBox2.Text;
                sfm.Storage = textBox1.Text;
                sfm.Modifier = textBox14.Text;
                sfm.StorageWay = textBox4.Text;
                sfm.TotalStorage = Convert.ToDecimal(textBox6.Text);
                sfm.StorageFleet = textBox5.Text;
                sfm.CarNumber = textBox7.Text;
                sfm.Driver = textBox9.Text;
                sfm.LoadingCity = textBox10.Text;
                sfm.LoadingArea = textBox11.Text;
                sfm.LoadingSpot = textBox12.Text;
                sfm.KeyBoarder = textBox13.Text;
                sfm.Loader = textBox7.Text;
                sfm.KeyTime = dateTimePicker1.Value;
                sfm.StorageTime = dateTimePicker2.Value;
                sfm.ModifyTime = dateTimePicker3.Value;

                sfm.StorageKeeper = textBox16.Text;
                sfm.Craneman = textBox17.Text;
                sfm.Others = textBox18.Text;
                sfm.Statement = textBox19.Text;
                sfm.UnLoadingSpot = textBox15.Text;
                sfm.UnLoadingCity = textBox20.Text;
                sfm.UnLoadingArea = textBox21.Text;

                List<domain.StorageDetails> sd = StorageDetails.ToList<domain.StorageDetails>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(sfm);

                fc.ChangeData(jsonMain,Json,sfm.GetType().Name.ToString(), "StorageDetails");
            }

            else   //保存
            {
                sfm.StorageNumber = textBox2.Text;
                sfm.Storage = textBox1.Text;
                sfm.Modifier = textBox14.Text;
                sfm.StorageWay = textBox4.Text;
                sfm.TotalStorage = Convert.ToDecimal(textBox6.Text);
                sfm.StorageFleet = textBox5.Text;
                sfm.CarNumber = textBox7.Text;
                sfm.Driver = textBox9.Text;
                sfm.LoadingCity = textBox10.Text;
                sfm.LoadingArea = textBox11.Text;
                sfm.LoadingSpot = textBox12.Text;
                sfm.KeyBoarder = textBox13.Text;
                sfm.Loader = textBox7.Text;
                sfm.KeyTime = dateTimePicker1.Value;
                sfm.StorageTime = dateTimePicker2.Value;
                sfm.ModifyTime = dateTimePicker3.Value;

                sfm.StorageKeeper = textBox16.Text;
                sfm.Craneman = textBox17.Text;
                sfm.Others = textBox18.Text;
                sfm.Statement = textBox19.Text;
                sfm.UnLoadingSpot = textBox15.Text;
                sfm.UnLoadingCity = textBox20.Text;
                sfm.UnLoadingArea = textBox21.Text;

                List<domain.StorageDetails> sd = StorageDetails.ToList<domain.StorageDetails>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(sfm);

                fc.SaveData(jsonMain,Json,sfm.GetType().Name.ToString(), "StorageDetails");
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DateTime date;
            DateTime min = new DateTime(1753,1,1);
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
