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

        public static string storagename;

        #region 明细表传参
        public string storagenames;//仓库
        public string cargoowner;//货主
        public string variety;//品种
        public string storagecode;//入库单识别码
        public string ordernumber;//订单号
        public string itemnumber;//项目号
        public int InventoryNumber;//库存件数
        public decimal StockQuantity;// 库存数量
        public string ReelNumber;//卷号
        public string Material;// 材质
        public string Specification;// 规格
        public string CribNumber;// 垛位号

        public string Statement;// 备注
        #endregion

        #region
        private void getCustomerOut(string customer) //移出客户
        {
            textBox20.Text = customer;
        }

        private void getCustomerIn(string customer) //移入客户
        {
            textBox8.Text = customer;
        }
        private void getStorageUint(string customer) //仓库付费单位
        {
            textBox5.Text = customer;
        }
        private void getTransUnit(string customer) //移库付费单位
        {
            textBox18.Text = customer;
        }

        void ClickStorageDetails(/*string storagename, string cargoowner,*/ string variety, string storagecode
                                                , string ordernumber, string itemnumber, int InventoryNumber, decimal StockQuantity
                                                , string ReelNumber, string Material, string Specification, string CribNumber, string Statement)
        {
            //this.gridView1.SetRowCellValue((StorageDetails.Count - 1), gridView1.Columns[12], storagename);
            //this.gridView1.SetRowCellValue((StorageDetails.Count - 1), gridView1.Columns[5], cargoowner);
            this.gridView1.SetRowCellValue((StorageDetails.Count - 1), gridView1.Columns[6], variety);

            this.gridView1.SetRowCellValue((StorageDetails.Count - 1), gridView1.Columns[1], storagecode);
            this.gridView1.SetRowCellValue((StorageDetails.Count - 1), gridView1.Columns[3], ordernumber);
            this.gridView1.SetRowCellValue((StorageDetails.Count - 1), gridView1.Columns[4], itemnumber);

            this.gridView1.SetRowCellValue((StorageDetails.Count - 1), gridView1.Columns[9], InventoryNumber);
            this.gridView1.SetRowCellValue((StorageDetails.Count - 1), gridView1.Columns[10], StockQuantity);
            this.gridView1.SetRowCellValue((StorageDetails.Count - 1), gridView1.Columns[5], ReelNumber);

            this.gridView1.SetRowCellValue((StorageDetails.Count - 1), gridView1.Columns[7], Material);
            this.gridView1.SetRowCellValue((StorageDetails.Count - 1), gridView1.Columns[8], Specification);
            this.gridView1.SetRowCellValue((StorageDetails.Count - 1), gridView1.Columns[11], CribNumber);

            this.gridView1.SetRowCellValue((StorageDetails.Count - 1), gridView1.Columns[18], Statement);
        }
        #endregion

        public New_TransferList()
        {
            InitializeComponent();

            comboBox3.DisplayMember = "仓库名称";
            comboBox3.ValueMember = "value";
            comboBox3.DataSource = fc.getStoragename();

            comboBox2.DisplayMember = "装卸工";
            comboBox2.ValueMember = "value";
            comboBox2.DataSource = fc.getLoader();

            comboBox6.DisplayMember = "装卸工";
            comboBox6.ValueMember = "value";
            comboBox6.DataSource = fc.getLoader();

            comboBox1.DisplayMember = "库管";
            comboBox1.ValueMember = "value";
            comboBox1.DataSource = fc.getKeeper();

            comboBox5.DisplayMember = "吊车工";
            comboBox5.ValueMember = "value";
            comboBox5.DataSource = fc.getCrane();

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
                textBox14.Text = Panel2_MyWorkBench.TransferList.array[14];
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
                textBox10.Text = fc.DateTimeToUnix("YK");
            }

            this.gridView1.Columns[0].Caption = "移库识别码";
            this.gridView1.Columns[0].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[1].Caption = "入库单识别码";
            this.gridView1.Columns[1].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[2].Caption = "移库单号";
            this.gridView1.Columns[2].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[3].Caption = "订单号";
            this.gridView1.Columns[3].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[4].Caption = "项目号";
            this.gridView1.Columns[4].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[5].Caption = "卷号";
            this.gridView1.Columns[5].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[6].Caption = "品种";
            this.gridView1.Columns[6].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[7].Caption = "材质";
            this.gridView1.Columns[7].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[8].Caption = "规格";
            this.gridView1.Columns[8].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[9].Caption = "库存件数";
            this.gridView1.Columns[9].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[10].Caption = "库存数量";
            this.gridView1.Columns[10].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[11].Caption = "原垛位号";
            this.gridView1.Columns[11].OptionsColumn.AllowEdit = false;

            this.gridView1.Columns[12].Caption = "新垛位号";
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox combobox_cranenumbernew = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            combobox_cranenumbernew.Items.AddRange(fc.getCraneNumber());
            this.gridView1.Columns[12].ColumnEdit = combobox_cranenumbernew;

            this.gridView1.Columns[13].Caption = "移库件数";
            this.gridView1.Columns[13].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[14].Caption = "移库数量";
            this.gridView1.Columns[14].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[15].Caption = "票数";
            this.gridView1.Columns[15].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[16].Caption = "入库日期";
            this.gridView1.Columns[17].Caption = "出厂日期";
            this.gridView1.Columns[18].Caption = "备注";
            this.gridView1.Columns[18].OptionsColumn.AllowEdit = false;

            this.gridView1.BestFitColumns();
        }

        public void DataGridViewInit()
        {
            List<domain.StorageDetailsTrans> sd = null;
            sd = JsonConvert.DeserializeObject<List<domain.StorageDetailsTrans>>(fc.GridViewInit("StorageDetailsTrans"));
            StorageDetails = new BindingList<domain.StorageDetailsTrans>(sd);
            gridControl1.DataSource = StorageDetails;
        }

        private void simpleButton4_Click(object sender, EventArgs e) //添加
        {
            domain.StorageDetailsTrans sd = new domain.StorageDetailsTrans()
            {
                transStorageCode = string.Format("{0}-{1}", textBox10.Text, StorageDetails.Count + 1)
                ,
                StorageNumber = textBox10.Text
                ,
                StorageTime = DateTime.Now
                ,
                ProductionDate = DateTime.Now
            };
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
        #region
        private void textBox20_Click(object sender, EventArgs e) //移出客户
        {
            
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox18_Click(object sender, EventArgs e)
        {
            
        }
        #endregion
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
           
        }

        private void textBox20_Click_1(object sender, EventArgs e)
        {
            Demo1._1._3._1_NewViews.TabbedSection_Customers tc = new _1_NewViews.TabbedSection_Customers();
            tc.ReturnEvent += new Demo1._1._3._1_NewViews.TabbedSection_Customers.Customers(getCustomerOut);
            tc.ShowDialog();
        }

        private void textBox8_Click_1(object sender, EventArgs e)
        {
            Demo1._1._3._1_NewViews.TabbedSection_Customers tc = new _1_NewViews.TabbedSection_Customers();
            tc.ReturnEvent += new Demo1._1._3._1_NewViews.TabbedSection_Customers.Customers(getCustomerIn);
            tc.ShowDialog();
        }

        private void textBox5_Click_1(object sender, EventArgs e)
        {
            Demo1._1._3._1_NewViews.TabbedSection_Customers tc = new _1_NewViews.TabbedSection_Customers();
            tc.ReturnEvent += new Demo1._1._3._1_NewViews.TabbedSection_Customers.Customers(getStorageUint);
            tc.ShowDialog();
        }

        private void textBox18_Click_1(object sender, EventArgs e)
        {
            Demo1._1._3._1_NewViews.TabbedSection_Customers tc = new _1_NewViews.TabbedSection_Customers();
            tc.ReturnEvent += new Demo1._1._3._1_NewViews.TabbedSection_Customers.Customers(getTransUnit);
            tc.ShowDialog();
        }

        private void gridView1_RowCellClick_1(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            storagename = comboBox3.Text;
            Demo1._1._3._1_NewViews.MyWorkBench.TabbedSection_StorageDetails sd = new _1_NewViews.MyWorkBench.TabbedSection_StorageDetails();
            sd.ReturnEvent += new _1_NewViews.MyWorkBench.TabbedSection_StorageDetails.ClickStorageDetails(ClickStorageDetails);
            sd.ShowDialog();
        }
    }
}
