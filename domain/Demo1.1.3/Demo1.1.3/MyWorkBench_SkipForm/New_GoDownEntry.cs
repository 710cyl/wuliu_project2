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
using Demo1._1._3._1_NewViews;
using System.IO;
using DevExpress.XtraEditors;
using System.Data.SqlTypes;
using System.Drawing.Printing;

namespace Demo1._1._3.MyWorkBench_SkipForm
{
    public partial class New_GoDownEntry : Form
    {
        private BindingList<domain.StorageDetails> StorageDetails;
        domain.StorageFormMain sfm = new StorageFormMain();
        List<domain.StorageDetails> sd = new List<StorageDetails>();
        FunctionClass fc = new FunctionClass();
        /// <summary>
        /// 车队、司机、车号
        /// </summary>
        private TabbedSections child_form = new TabbedSections();
        
        /// <summary>
        /// 装点、装货城市、装货地区
        /// </summary>
        private TebbedSection_LoadSpot load_form = new TebbedSection_LoadSpot();

        /// <summary>
        /// 卸点、发卸城市、发卸地区
        /// </summary>
        private TabbedSection_Discharge discharge_form = new TabbedSection_Discharge();

        private TabbedSection_Transportation tr = new TabbedSection_Transportation();
        domain.Decorate de = new Decorate();

        void getCarValue(string a, string b, string c)
        {
            textBox5.Text = a;
            textBox8.Text = b;
            textBox9.Text = c;
        }

        void getLoadValue(string a, string b, string c)
        {
            textBox10.Text = a;
            textBox12.Text = b;
            textBox11.Text = c;
        }

        void getDischargeValue(string a, string b, string c) //明细表
        {
            this.gridView1.SetRowCellValue((StorageDetails.Count-1), gridView1.Columns[6],a);
            this.gridView1.SetRowCellValue((StorageDetails.Count - 1), gridView1.Columns[7], b);
            this.gridView1.SetRowCellValue((StorageDetails.Count - 1), gridView1.Columns[8], c);

        }

        

        

        
        public New_GoDownEntry()
        {
            InitializeComponent();

           /* child_form.ReturnEvent += new TabbedSections.ClickCar(getCarValue);

            load_form.ReturnEvent += new TebbedSection_LoadSpot.ClickCity(getLoadValue);

            discharge_form.ReturnEvent += new TabbedSection_Discharge.ClickCity(getDischargeValue);*/
        #region 设置下拉控件
            comboBox1.DisplayMember = "入库方式";
            comboBox1.ValueMember = "value";
            comboBox1.DataSource = fc.getStorageway();

            comboBox2.DisplayMember = "仓库";
            comboBox2.ValueMember = "value";
            comboBox2.DataSource = fc.getStoragename();

            comboBox3.DisplayMember = "库管";
            comboBox3.ValueMember = "value";
            comboBox3.DataSource = fc.getKeeper();

            comboBox4.DisplayMember = "吊工";
            comboBox4.ValueMember = "value";
            comboBox4.DataSource = fc.getCrane();

            comboBox5.DisplayMember = "装卸工";
            comboBox5.ValueMember = "value";
            comboBox5.DataSource = fc.getLoader();
        #endregion
            if (Panel2_MyWorkBench.GodownEntry.isExist)
            {
                //主表显示
                textBox2.Text = Panel2_MyWorkBench.GodownEntry.array[0];
                comboBox2.Text = Panel2_MyWorkBench.GodownEntry.array[1];
                dateTimePicker2.Value = Convert.ToDateTime(Panel2_MyWorkBench.GodownEntry.array[2]);
                comboBox1.Text = Panel2_MyWorkBench.GodownEntry.array[3];
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
                comboBox3.Text = Panel2_MyWorkBench.GodownEntry.array[15];
                comboBox4.Text = Panel2_MyWorkBench.GodownEntry.array[16];
                comboBox5.Text = Panel2_MyWorkBench.GodownEntry.array[17];
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
                textBox2.Text = fc.DateTimeToUnix("RK");
            }

            this.gridView1.Columns[0].Caption = "入库单识别码";
            this.gridView1.Columns[0].OptionsColumn.AllowEdit = false; //设置不可编辑的列
            this.gridView1.Columns[1].Caption = "入库单号";
            this.gridView1.Columns[1].OptionsColumn.AllowEdit = false;

            #region gridview获取下拉菜单的方法
            this.gridView1.Columns[2].Caption = "仓库名称";
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox combobox_storage = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            //combobox_storage.Items.AddRange(fc.getStoragename());
            this.gridView1.Columns[2].ColumnEdit =combobox_storage;
            #endregion

            this.gridView1.Columns[3].Caption = "出厂日期";
            this.gridView1.Columns[4].Caption = "订单号";
            this.gridView1.Columns[5].Caption = "货主";

            this.gridView1.Columns[6].Caption = "卸货点";
            this.gridView1.Columns[6].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[7].Caption = "卸货城市";
            this.gridView1.Columns[7].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[8].Caption = "卸货区域";
            this.gridView1.Columns[8].OptionsColumn.AllowEdit = false;

            this.gridView1.Columns[9].Caption = "卷号";

            this.gridView1.Columns[10].Caption = "品种";
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox combobox_variety = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
           // combobox_variety.Items.AddRange(fc.getVariety());
            this.gridView1.Columns[10].ColumnEdit = combobox_variety;

            this.gridView1.Columns[11].Caption = "材质";
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox combobox_texture = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
          //  combobox_texture.Items.AddRange(fc.getTexture());
            this.gridView1.Columns[11].ColumnEdit = combobox_texture;


            this.gridView1.Columns[12].Caption = "规格";
            this.gridView1.Columns[13].Caption = "件数";
            this.gridView1.Columns[14].Caption = "数量";


            this.gridView1.Columns[15].Caption = "垛位号";
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox combobox_cranenumber = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
          //  combobox_cranenumber.Items.AddRange(fc.getCraneNumber());
            this.gridView1.Columns[15].ColumnEdit = combobox_cranenumber;

            this.gridView1.Columns[16].Caption = "入库方式";

            this.gridView1.Columns[17].Caption = "车队";
            this.gridView1.Columns[17].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[18].Caption = "车号";
            this.gridView1.Columns[18].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[19].Caption = "司机";
            this.gridView1.Columns[19].OptionsColumn.AllowEdit = false;

            this.gridView1.Columns[20].Caption = "装货城市";
            this.gridView1.Columns[20].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[21].Caption = "装货地点";
            this.gridView1.Columns[21].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[22].Caption = "装货区域";
            this.gridView1.Columns[22].OptionsColumn.AllowEdit = false;

            this.gridView1.Columns[23].Caption = "录入员";
            this.gridView1.Columns[24].Caption = "录入时间";
            this.gridView1.Columns[25].Caption = "修改人";
            this.gridView1.Columns[26].Caption = "修改时间";
            this.gridView1.Columns[27].Caption = "入库时间";

            this.gridView1.Columns[28].Caption = "库管";
            this.gridView1.Columns[28].Visible = false;
            this.gridView1.Columns[29].Caption = "吊车工";
            this.gridView1.Columns[29].Visible = false;
            this.gridView1.Columns[30].Caption = "装卸工";
            this.gridView1.Columns[30].Visible = false;
            this.gridView1.Columns[31].Caption = "其他人";
            this.gridView1.Columns[31].Visible = false;

            this.gridView1.Columns[32].Caption = "备注";
            this.gridView1.Columns[33].Caption = "库存件数";
            this.gridView1.Columns[33].Visible = false;
            this.gridView1.Columns[34].Caption = "库存数量";
            this.gridView1.Columns[34].Visible = false;
            this.gridView1.Columns[35].Caption = "票数";
            this.gridView1.Columns[36].Caption = "车队标识";
            this.gridView1.Columns[36].Visible = false;
            this.gridView1.Columns[37].Caption = "项目号";
            this.gridView1.Columns[38].Caption = "可派件数";
            this.gridView1.Columns[38].Visible = false;
            this.gridView1.Columns[39].Caption = "可派数量";
            this.gridView1.Columns[39].Visible = false;

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
            domain.StorageDetails sd = new domain.StorageDetails() { StorageCode = string.Format("{0}-{1}", textBox2.Text, StorageDetails.Count + 1)
                , StorageNumber = textBox2.Text
                , CarNumber = textBox8.Text
                , Drive = textBox9.Text
                , StorageFleet = textBox5.Text
                , LoadingCity = textBox10.Text
                , LoadingSpot = textBox12.Text
                , LoadingArea = textBox11.Text
                , KeyTime = DateTime.Now
                ,StorageTime = DateTime.Now
                ,ModifyTime  = DateTime.Now
                , ProductionDate=DateTime.Now};
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
                sfm.Storage = comboBox2.Text;
                sfm.Modifier = textBox14.Text;
                sfm.StorageWay = comboBox1.Text;
                sfm.TotalStorage = Convert.ToDecimal(textBox6.Text);
                sfm.StorageFleet = textBox5.Text;
                sfm.CarNumber = textBox8.Text;
                sfm.Driver = textBox9.Text;
                sfm.LoadingCity = textBox10.Text;
                sfm.LoadingArea = textBox11.Text;
                sfm.LoadingSpot = textBox12.Text;
                sfm.KeyBoarder = textBox13.Text;
                sfm.Loader = comboBox5.Text;
                sfm.KeyTime = dateTimePicker1.Value;
                sfm.StorageTime = dateTimePicker2.Value;
                sfm.ModifyTime = dateTimePicker3.Value;

                sfm.StorageKeeper = comboBox3.Text;
                sfm.Craneman = comboBox4.Text;
                sfm.Others = textBox18.Text;
                sfm.Statement = textBox19.Text;
                sfm.UnLoadingSpot = textBox15.Text;
                sfm.UnLoadingCity = textBox20.Text;
                sfm.UnLoadingArea = textBox21.Text;

                List<domain.StorageDetails> sd = StorageDetails.ToList<domain.StorageDetails>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(sfm);

                fc.ChangeData(jsonMain,Json,sfm.GetType().Name.ToString(), "StorageDetails");

                Thread.Sleep(500);
                MessageBox.Show("修改完毕");
                Close();
            }

            else   //保存
            {
                try
                {
                    sfm.StorageNumber = textBox2.Text;
                    sfm.Storage = comboBox2.Text;
                    sfm.Modifier = textBox14.Text;
                    sfm.StorageWay = comboBox1.Text;
                    sfm.TotalStorage = Convert.ToDecimal(textBox6.Text);
                    sfm.StorageFleet = textBox5.Text;
                    sfm.CarNumber = textBox8.Text;
                    sfm.Driver = textBox9.Text;
                    sfm.LoadingCity = textBox10.Text;
                    sfm.LoadingArea = textBox11.Text;
                    sfm.LoadingSpot = textBox12.Text;
                    sfm.KeyBoarder = textBox13.Text;
                    sfm.Loader = comboBox5.Text;
                    sfm.KeyTime = dateTimePicker1.Value;
                    sfm.StorageTime = dateTimePicker2.Value;
                    sfm.ModifyTime = dateTimePicker3.Value;

                    sfm.StorageKeeper = comboBox3.Text;
                    sfm.Craneman = comboBox4.Text;
                    sfm.Others = textBox18.Text;
                    sfm.Statement = textBox19.Text;
                    sfm.UnLoadingSpot = textBox15.Text;
                    sfm.UnLoadingCity = textBox20.Text;
                    sfm.UnLoadingArea = textBox21.Text;


                    if (textBox6.Text == null)
                    {
                        MessageBox.Show("请填写入库总量后保存");
                    }
                    else
                    {
                        List<domain.StorageDetails> sd = StorageDetails.ToList<domain.StorageDetails>();
                        string Json = JsonConvert.SerializeObject(sd);
                        string jsonMain = JsonConvert.SerializeObject(sfm);

                        fc.SaveData(jsonMain, Json, sfm.GetType().Name.ToString(), "StorageDetails");

                        Thread.Sleep(500);
                        MessageBox.Show("保存完毕");
                        Close();
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show("请填写入库总量后保存");
                }
               
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

        private void textBox9_Click(object sender, EventArgs e) //点击出现窗体 车队
        {
            child_form.ReturnEvent += new TabbedSections.ClickCar(getCarValue);
            child_form.ShowDialog();
        }

        private void textBox10_Click(object sender, EventArgs e)//点击出现窗体 装货
        {
            load_form.ReturnEvent += new TebbedSection_LoadSpot.ClickCity(getLoadValue);
            load_form.ShowDialog(); 
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e) //点击单元格处罚事件
        {
            if (e.Column.Caption == "卸货点" || e.Column.Caption == "卸货地点" || e.Column.Caption == "卸货区域")
            {
                discharge_form.ReturnEvent += new TabbedSection_Discharge.ClickCity(getDischargeValue);
                discharge_form.ShowDialog();
            }
        }

        private void textBox15_Click(object sender, EventArgs e) //发货地点
        {

        }
    }
}
