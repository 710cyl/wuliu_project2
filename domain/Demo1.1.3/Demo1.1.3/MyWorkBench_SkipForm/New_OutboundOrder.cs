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
    public partial class New_OutboundOrder : Form
    {

        private BindingList<domain.StorageDetailsOut> StorageDetailsOut;
        domain.StorageFormMainOut sfm = new StorageFormMainOut();
        List<domain.StorageDetailsOut> sd = new List<StorageDetailsOut>();
        FunctionClass fc = new FunctionClass();

        public static string ordernum;
        #region

        /// <summary>
        /// 派车单号
        /// </summary>
        public string sendcar_num { get; set; }
        /// <summary>
        /// 货主单位
        /// </summary>
        public string owner_unit { get; set; }

        /// <summary>
        /// 发货仓库
        /// </summary>
        public string warehouse_send { get; set; }

        /// <summary>
        /// 付费单位
        /// </summary>
        public string pay_unit { get; set; }

        /// <summary>
        /// 车队
        /// </summary>
        public string cars { get; set; }
        /// <summary>
        /// 车号
        /// </summary>
        public string carnum { get; set; }

        /// <summary>
        /// 司机
        /// </summary>
        public string driver { get; set; }

        /// <summary>
        /// 卸货城市
        /// </summary>
        public string unload_city { get; set; }
        /// <summary>
        /// 卸货区域
        /// </summary>
        public string unload_area { get; set; }
        /// <summary>
        /// 实际卸点
        /// </summary>
        public string unload_point { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string explain { get; set; }
        #endregion

         void ClickOutBounceCar(string sendcar_num, string owner_unit, string warehouse_send, string pay_unit
                                               , string cars, string carnum, string driver, string unload_city
                                               , string unload_area, string unload_point, string explain)
        {
            textBox11.Text = sendcar_num;
            textBox1.Text = owner_unit;
            textBox2.Text = warehouse_send;
            textBox3.Text = pay_unit;
            textBox20.Text = cars;
            textBox8.Text = carnum;
            textBox5.Text = driver;
            textBox9.Text = unload_city;
            textBox18.Text = unload_area;
            textBox10.Text = unload_point;

        }


        #region
        /// <summary>
        /// 入库标识码
        /// </summary>
        public string store_code { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string order_num { get; set; }

        /// <summary>
        /// 入库性质
        /// </summary>
        public string store_kind { get; set; }
        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime store_date { get; set; }

        /// <summary>
        /// 项目号
        /// </summary>
        public decimal pro_num { get; set; }
        /// <summary>
        /// 卷号
        /// </summary>
        public string roll_num { get; set; }
        /// <summary>
        /// 品种
        /// </summary>
        public string kind { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        public string textures { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string norms { get; set; }

        /// <summary>
        /// 可派件数
        /// </summary>
        public int piece { get; set; }
        /// <summary>
        /// 可派数量
        /// </summary>
        public string out_num { get; set; }

        /// <summary>
        /// 订单卸城
        /// </summary>
        public string order_city { get; set; }
        /// <summary>
        /// 订单卸区
        /// </summary>
        public string order_area { get; set; }
        /// <summary> 
        /// 订单卸点
        /// </summary>
        public string order_point { get; set; }

        /// <summary>
        /// 垛位号
        /// </summary>
        public string crib_num { get; set; }
        #endregion
         void ClickOutBounceCarDetails(string store_code, string order_num, string store_kind, DateTime store_date, decimal pro_num, string roll_num
                                                     , string kind, string textures, string norms, int piece, string out_num,
                                                     string order_city, string order_area, string order_point, string crib_num)
        {
            this.gridView1.SetRowCellValue(StorageDetailsOut.Count-1, gridView1.Columns[17], store_code);
            this.gridView1.SetRowCellValue(StorageDetailsOut.Count - 1, gridView1.Columns[4], order_num);
            this.gridView1.SetRowCellValue(StorageDetailsOut.Count - 1, gridView1.Columns[2], store_kind);

            this.gridView1.SetRowCellValue(StorageDetailsOut.Count - 1, gridView1.Columns[3], store_date);
            this.gridView1.SetRowCellValue(StorageDetailsOut.Count-1, gridView1.Columns[40], pro_num);
            this.gridView1.SetRowCellValue(StorageDetailsOut.Count-1, gridView1.Columns[9], roll_num);

            this.gridView1.SetRowCellValue(StorageDetailsOut.Count-1, gridView1.Columns[10], kind);
            this.gridView1.SetRowCellValue(StorageDetailsOut.Count-1, gridView1.Columns[11], textures);
            this.gridView1.SetRowCellValue(StorageDetailsOut.Count-1, gridView1.Columns[12], norms);

            this.gridView1.SetRowCellValue(StorageDetailsOut.Count-1, gridView1.Columns[13], piece);
            this.gridView1.SetRowCellValue(StorageDetailsOut.Count-1, gridView1.Columns[14], out_num);
            this.gridView1.SetRowCellValue(StorageDetailsOut.Count-1, gridView1.Columns[29], order_city);

            this.gridView1.SetRowCellValue(StorageDetailsOut.Count-1, gridView1.Columns[30], order_area);
            this.gridView1.SetRowCellValue(StorageDetailsOut.Count-1, gridView1.Columns[28], order_point);
            this.gridView1.SetRowCellValue(StorageDetailsOut.Count-1, gridView1.Columns[36], crib_num);

            
        }
        public New_OutboundOrder()
        {
            InitializeComponent();

            if (Panel2_MyWorkBench.OutboundOrder.isExist)
            {
                textBox1.Text = Panel2_MyWorkBench.OutboundOrder.array[22];
                textBox2.Text = Panel2_MyWorkBench.OutboundOrder.array[21];
                textBox20.Text = Panel2_MyWorkBench.OutboundOrder.array[3];
                textBox8.Text = Panel2_MyWorkBench.OutboundOrder.array[4];
                textBox5.Text = Panel2_MyWorkBench.OutboundOrder.array[5];
                textBox3.Text = Panel2_MyWorkBench.OutboundOrder.array[23];
                textBox9.Text = Panel2_MyWorkBench.OutboundOrder.array[18];
                textBox18.Text = Panel2_MyWorkBench.OutboundOrder.array[19];
                textBox10.Text = Panel2_MyWorkBench.OutboundOrder.array[17];
                dateTimePicker1.Value =Convert.ToDateTime( Panel2_MyWorkBench.OutboundOrder.array[20]);
                textBox11.Text = Panel2_MyWorkBench.OutboundOrder.array[0];
                comboBox5.Text = Panel2_MyWorkBench.OutboundOrder.array[7];

                comboBox2.Text = Panel2_MyWorkBench.OutboundOrder.array[8];

                comboBox1.Text = Panel2_MyWorkBench.OutboundOrder.array[9];

                textBox14.Text = Panel2_MyWorkBench.OutboundOrder.array[27];
                textBox28.Text = Panel2_MyWorkBench.OutboundOrder.array[29];
                textBox15.Text = Panel2_MyWorkBench.OutboundOrder.array[30];
                textBox7.Text = Panel2_MyWorkBench.OutboundOrder.array[25];
                textBox17.Text = Panel2_MyWorkBench.OutboundOrder.array[26];
                textBox16.Text = Panel2_MyWorkBench.OutboundOrder.array[24];
                dateTimePicker2.Value = Convert.ToDateTime(Panel2_MyWorkBench.OutboundOrder.array[28]);
                textBox4.Text = Panel2_MyWorkBench.OutboundOrder.array[10];
                dateTimePicker3.Value = Convert.ToDateTime(Panel2_MyWorkBench.OutboundOrder.array[1]);
                textBox12.Text = Sign_in.name;
                dateTimePicker4.Value = Convert.ToDateTime(Panel2_MyWorkBench.OutboundOrder.array[12]);

                sd = JsonConvert.DeserializeObject<List<domain.StorageDetailsOut>>(fc.FindDeteils(Panel2_MyWorkBench.OutboundOrder.str, "StorageDetailsOut"));
                StorageDetailsOut = new BindingList<domain.StorageDetailsOut>(sd);


                gridControl1.DataSource = StorageDetailsOut;
            }
            else
            {
                DataGridViewInit();

                // textBox11.Text = fc.DateTimeToUnix("PC");

                textBox12.Text = Sign_in.name;
                textBox13.Text = Sign_in.name;
                this.gridView1.Columns[0].Caption = "出库单识别码";
                
                this.gridView1.Columns[1].Caption = "出库单号";
                
                this.gridView1.Columns[2].Caption = "入库性质";
                this.gridView1.Columns[3].Caption = "入库时间";
                this.gridView1.Columns[4].Caption = "订单号";
                this.gridView1.Columns[5].Caption = "货主";
                this.gridView1.Columns[5].Visible = false;
                this.gridView1.Columns[6].Caption = "卸货点";
                this.gridView1.Columns[6].Visible = false;
                this.gridView1.Columns[7].Caption = "卸货城市";
                this.gridView1.Columns[7].Visible = false;
                this.gridView1.Columns[8].Caption = "卸货区域";
                this.gridView1.Columns[8].Visible = false;
                this.gridView1.Columns[9].Caption = "卷号";
                this.gridView1.Columns[10].Caption = "品种";
                this.gridView1.Columns[11].Caption = "材质";
                this.gridView1.Columns[12].Caption = "规格";
                this.gridView1.Columns[13].Caption = "库存件数";
                this.gridView1.Columns[14].Caption = "库存数量";
                this.gridView1.Columns[15].Caption = "实发件数";
                this.gridView1.Columns[16].Caption = "实发数量";
                this.gridView1.Columns[17].Caption = "入库单识别码";
                this.gridView1.Columns[17].Visible = false;
                this.gridView1.Columns[18].Caption = "车队";
                this.gridView1.Columns[18].Visible = false;
                this.gridView1.Columns[19].Caption = "车号";
                this.gridView1.Columns[19].Visible = false;
                this.gridView1.Columns[20].Caption = "司机";
                this.gridView1.Columns[20].Visible = false;
                this.gridView1.Columns[21].Caption = "发货员";
                this.gridView1.Columns[21].Visible = false;
                this.gridView1.Columns[22].Caption = "发货时间";
                this.gridView1.Columns[22].Visible = false;
                this.gridView1.Columns[23].Caption = "库管";
                this.gridView1.Columns[23].Visible = false;
                this.gridView1.Columns[24].Caption = "吊车工";
                this.gridView1.Columns[24].Visible = false;
                this.gridView1.Columns[25].Caption = "装卸工";
                this.gridView1.Columns[25].Visible = false;
                this.gridView1.Columns[26].Caption = "装卸工1";
                this.gridView1.Columns[26].Visible = false;
                this.gridView1.Columns[27].Caption = "备注";
                this.gridView1.Columns[28].Caption = "实际卸货点";
                this.gridView1.Columns[28].Visible = false;
                this.gridView1.Columns[29].Caption = "实际卸货城市";
                this.gridView1.Columns[29].Visible = false;
                this.gridView1.Columns[30].Caption = "实际卸货区域";
                this.gridView1.Columns[30].Visible = false;
                this.gridView1.Columns[31].Caption = "发装城市";
                this.gridView1.Columns[31].Visible = false;
                this.gridView1.Columns[32].Caption = "发装区域";
                this.gridView1.Columns[32].Visible = false;
                this.gridView1.Columns[33].Caption = "发装点";
                this.gridView1.Columns[33].Visible = false;
                this.gridView1.Columns[34].Caption = "车队标识";
                this.gridView1.Columns[34].Visible = false;
                this.gridView1.Columns[35].Caption = "出库时间";
                this.gridView1.Columns[35].Visible = false;
                this.gridView1.Columns[36].Caption = "垛位号";
                this.gridView1.Columns[36].Visible = false;
                this.gridView1.Columns[37].Caption = "修改人";
                this.gridView1.Columns[37].Visible = false;
                this.gridView1.Columns[38].Caption = "修改时间";
                this.gridView1.Columns[38].Visible = false;
                this.gridView1.Columns[39].Caption = "仓库名称";
                this.gridView1.Columns[39].Visible = false;
                this.gridView1.Columns[40].Caption = "项目号";
                this.gridView1.Columns[41].Caption = "仓费单价";
                this.gridView1.Columns[42].Caption = "仓储费";
                this.gridView1.Columns[43].Caption = "付费单位";
                this.gridView1.Columns[43].Visible = false;
                this.gridView1.Columns[44].Caption = "基础存储期";
                this.gridView1.Columns[44].Visible = false;
                this.gridView1.Columns[45].Caption = "实际存储期";
                this.gridView1.Columns[45].Visible = false;
                this.gridView1.Columns[46].Caption = "超期";
                this.gridView1.Columns[46].Visible = false;
                this.gridView1.Columns[47].Caption = "基本仓储单价";
                this.gridView1.Columns[47].Visible = false;
                this.gridView1.Columns[48].Caption = "超期单价";
                this.gridView1.Columns[48].Visible = false;

                this.gridView1.BestFitColumns();
            }
            comboBox5.DisplayMember = "库管";
            comboBox5.ValueMember = "value";
            comboBox5.DataSource = fc.getKeeper();

            comboBox2.DisplayMember = "吊工";
            comboBox2.ValueMember = "value";
            comboBox2.DataSource = fc.getCrane();

            comboBox1.DisplayMember = "装卸工";
            comboBox1.ValueMember = "value";
            comboBox1.DataSource = fc.getLoader();
        }

        public void DataGridViewInit()
        {
            List<domain.StorageDetailsOut> sd = null;
            sd = JsonConvert.DeserializeObject<List<domain.StorageDetailsOut>>(fc.GridViewInit("StorageDetailsOut"));
            StorageDetailsOut = new BindingList<domain.StorageDetailsOut>(sd);
            gridControl1.DataSource = StorageDetailsOut;
        }

        private void simpleButton4_Click(object sender, EventArgs e) //添加
        {
            domain.StorageDetailsOut sd = new domain.StorageDetailsOut() {outStorageNumber = textBox11.Text, outStorageCode = string.Format("{0}-{1}", textBox11.Text, StorageDetailsOut.Count + 1)
                                                                            , ModifyTime = DateTime.Now,StorageTime = DateTime.Now,outStorageTime = DateTime.Now,shipperTime = DateTime.Now};
            StorageDetailsOut.Add(sd);
        }

        private void simpleButton3_Click(object sender, EventArgs e) //删除
        {
            try
            {
                int index = gridView1.SelectedRowsCount + 1;//dataGridView1.CurrentRow.Index;
                StorageDetailsOut.RemoveAt(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e) //保存
        {
            if (Panel2_MyWorkBench.OutboundOrder.isExist)
            {
                sfm.CargoOwner = textBox1.Text;
                sfm.Storage = textBox2.Text;
                sfm.StorageFleet = textBox20.Text;
                sfm.CarNumber = textBox8.Text;
                sfm.Driver = textBox5.Text;
                sfm.PayUnits = textBox3.Text;
                sfm.UnLoadingCity = textBox9.Text;
                sfm.UnLoadingArea = textBox18.Text;
                sfm.UnLoadingSpotActual = textBox10.Text;
                sfm.StorageTime = dateTimePicker1.Value;
                sfm.outStorageNumber = textBox11.Text;
                sfm.StorageKeeper = comboBox5.Text;
                sfm.Craneman = comboBox2.Text;
                sfm.Loader = comboBox1.Text;
                sfm.StorageFee = Convert.ToDecimal(textBox14.Text);
                sfm.FeeReceive = Convert.ToDecimal(textBox28.Text);
                sfm.ReceiveComplete = textBox15.Text;
                sfm.Accountants = textBox7.Text;
                sfm.AccountName = textBox17.Text;
                sfm.Payee = textBox16.Text;
                sfm.CollectionTime = dateTimePicker2.Value;
                sfm.Shipper = textBox4.Text;
                sfm.LogTime = dateTimePicker3.Value;
                sfm.Modifier = textBox12.Text;
                sfm.ModifyTime = dateTimePicker4.Value;

                List<domain.StorageDetailsOut> sd = StorageDetailsOut.ToList<domain.StorageDetailsOut>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(sfm);

                fc.ChangeData(jsonMain, Json, sfm.GetType().Name.ToString(), "StorageDetailsOut");
            }

            else
            {
                
                sfm.CargoOwner = textBox1.Text;
                sfm.Storage = textBox2.Text;
                sfm.StorageFleet = textBox20.Text;
                sfm.CarNumber = textBox8.Text;
                sfm.Driver = textBox5.Text;
                sfm.PayUnits = textBox3.Text;
                sfm.UnLoadingCity = textBox9.Text;
                sfm.UnLoadingArea = textBox18.Text;
                sfm.UnLoadingSpotActual = textBox10.Text;
                sfm.StorageTime = dateTimePicker1.Value;
                sfm.outStorageNumber = textBox11.Text;
                sfm.StorageKeeper = comboBox5.Text;
                sfm.Craneman = comboBox2.Text;
                sfm.Loader = comboBox1.Text;
                sfm.StorageFee = Convert.ToDecimal(textBox14.Text);
                sfm.FeeReceive = Convert.ToDecimal(textBox28.Text);
                sfm.ReceiveComplete = textBox15.Text;
                sfm.Accountants = textBox7.Text;
                sfm.AccountName = textBox17.Text;
                sfm.Payee = textBox16.Text;
                sfm.CollectionTime = dateTimePicker2.Value;
                sfm.Shipper = textBox4.Text;
                sfm.LogTime = dateTimePicker3.Value;
                sfm.Modifier = textBox12.Text;
                sfm.ModifyTime = dateTimePicker4.Value;

                List<domain.StorageDetailsOut> sd = StorageDetailsOut.ToList<domain.StorageDetailsOut>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(sfm);

                fc.SaveData(jsonMain, Json, sfm.GetType().Name.ToString(), "StorageDetailsOut");
                MessageBox.Show("保存完毕");
                Close();
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
            if (e.Column.FieldName == "outStorageTime" || e.Column.FieldName == "StorageTime" || e.Column.FieldName == "shipperTime" || e.Column.FieldName == "ModifyTime")
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

        private void textBox1_Click(object sender, EventArgs e) //主表点击事件
        {
            Demo1._1._3._1_NewViews.TabbedSection_OutBounceCar oc = new _1_NewViews.TabbedSection_OutBounceCar();
            oc.ReturnEvent += new _1_NewViews.TabbedSection_OutBounceCar.ClickOutBounceCar(ClickOutBounceCar);
            oc.ShowDialog();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e) //明细表点击事件
        {
            ordernum = textBox11.Text;
            Demo1._1._3._1_NewViews.TabbedSection_OutBounceCarDetails obd = new _1_NewViews.TabbedSection_OutBounceCarDetails();
            obd.ReturnEvent += new _1_NewViews.TabbedSection_OutBounceCarDetails.ClickOutBounceCarDetails(ClickOutBounceCarDetails);
            obd.ShowDialog();
        }
    }
}
