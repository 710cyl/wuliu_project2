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
using System.Drawing.Printing;

namespace Demo1._1._3.MyWorkBench_SkipForm
{
    public partial class New_OutBound_Car : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        FunctionClass fc = new FunctionClass();
        domain.Outbound_Car bs = new domain.Outbound_Car();
        private BindingList<Outbound_Car_Detail> carDetailList;
        List<domain.Outbound_Car_Detail> sd = new List<Outbound_Car_Detail>();
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int i = 0;//计算增加gridview行数
        // 车队、司机、车号
        private TabbedSections child_form = new TabbedSections();
        //装点、装货城市、装货地区
        private Demo1._1._3._1_NewViews.TebbedSection_LoadSpot load_form = new Demo1._1._3._1_NewViews.TebbedSection_LoadSpot();
        //卸点、发卸城市、发卸地区
        private Demo1._1._3._1_NewViews.TabbedSection_Discharge discharge_form = new Demo1._1._3._1_NewViews.TabbedSection_Discharge();

        public New_OutBound_Car()
        {
            InitializeComponent();

            DataGridViewInit();
            this.gridView1.Columns[15].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[16].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[17].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[0].Caption = "入库标识码";
            this.gridView1.Columns[1].Visible = false;
            this.gridView1.Columns[2].Caption = "入库性质";
            this.gridView1.Columns[3].Caption = "入库日期";
            this.gridView1.Columns[4].Caption = "派车单号";
            this.gridView1.Columns[5].Caption = "项目号";
            this.gridView1.Columns[6].Caption = "卷号";
            this.gridView1.Columns[7].Caption = "品种";
            this.gridView1.Columns[8].Caption = "材质";
            this.gridView1.Columns[9].Caption = "规格";
            this.gridView1.Columns[10].Caption = "可派件数";
            this.gridView1.Columns[11].Caption = "可派数量";
            this.gridView1.Columns[12].Caption = "拟发件数";
            this.gridView1.Columns[13].Caption = "拟发数量";
            this.gridView1.Columns[14].Caption = "派车时间";
            this.gridView1.Columns[15].Caption = "订单卸城";
            this.gridView1.Columns[16].Caption = "订单卸区";
            this.gridView1.Columns[17].Caption = "订单卸点";
            this.gridView1.Columns[18].Caption = "垛位号";
            this.gridView1.Columns[19].Caption = "备注";
            this.gridView1.BestFitColumns();

        }

        private void dtp_TextChange(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dtp.Text; //时间控件选择时间时，就把时间赋给所在的单元格  
        }


        public void DataGridViewInit()
        {
            List<domain.Outbound_Car_Detail> sd = null;
            String str ="Outbound_Car_Detail";
            sd = JsonConvert.DeserializeObject<List<domain.Outbound_Car_Detail>>(fc.GridViewInit(str));
            carDetailList = new BindingList<domain.Outbound_Car_Detail>(sd);
            gridControl1.DataSource = carDetailList;
        }
        /***删除出库派车明细 fairy 2017-07-27**/
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int index = gridView1.SelectedRowsCount + 1;
                carDetailList.RemoveAt(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e) //保存按钮 
        {
            
            bs.sendcar_num = textEdit2.Text;
            textEdit2.AllowDrop = false;
            bs.owner_unit = text_owner_unit.Text;
            bs.warehouse_send = text_warehouse_send.Text;
            bs.deliver_quantity = Convert.ToDecimal(text_deliver_quantity.Text);
            bs.out_way = checkedComboBoxout_way.Text;
            bs.oper_apart = text_oper_apart.Text;
            bs.oper_staff = text_oper_staff.Text;
            bs.pay_unit = text_pay_unit.Text;
            bs.cars = checkedComboBoxcars.Text;
            bs.carnum = text_carnum.Text;
            bs.driver = text_driver.Text;
            bs.sendcar_staff = text_sendcar_staff.Text;
            bs.sendcar_time = Convert.ToDateTime(dateEdit1.DateTime);
            //bs.packge = checkedComboBoxpackge.SelectedText.ToString();
            bs.unload_city = textEditCity.Text;
            bs.unload_area = text_unload_area.Text;
            bs.unload_point = text_unload_point.Text;
            bs.is_close = checkedComboBoxclose.SelectedText.ToString();
            bs.close_staff = text_close_staff.Text;
            bs.close_time = Convert.ToDateTime(date_close_time.DateTime);
            bs.explain = text_explain.Text;
            
            
            if (Demo1._1._3.Outbound_Car.isExist) //保存修改数据
            {
                string Json = JsonConvert.SerializeObject(this.gridControl1.DataSource);
                string jsonMain = JsonConvert.SerializeObject(bs);
                fc.ChangeData(jsonMain, Json, bs.GetType().Name.ToString(), "Outbound_Car_Detail");
            }
            else
            {  //保存新增数据
                string Json = JsonConvert.SerializeObject(this.gridControl1.DataSource);
                string jsonMain = JsonConvert.SerializeObject(bs);
                fc.SaveData(jsonMain, Json, bs.GetType().Name.ToString(), "Outbound_Car_Detail");
            }

        }

        public List<T> DatagridviewToList<T>(DataGridView gv)
        {
            List<T> lis = null;
            int rowNum = gv.Rows.Count; //获取总行数
            int cells = gv.Rows[1].Cells.Count;//获取总列数

            for (int i = 0; i < rowNum; i++)
            {
                for (int j = 0; j < cells; j++)
                {

                }
            }
            return lis;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {   
            
            if (Demo1._1._3.Outbound_Car.isExist)
            {//修改
                domain.Outbound_Car_Detail sd = new domain.Outbound_Car_Detail() { store_code = string.Format("{0}-{1}", textEdit2.Text, Outbound_Car.carDetails.Count + 1), order_num = textEdit2.Text };
                Outbound_Car.carDetails.Add(sd);
                int i = gridView1.RowCount - 1;
                this.gridView1.SetRowCellValue(i, gridView1.Columns[1], textEdit2.Text);
                this.gridView1.Columns[1].OptionsColumn.AllowEdit = false; //设置不可编辑的列
            }
            else {//新增
                domain.Outbound_Car_Detail sd = new domain.Outbound_Car_Detail() { store_code = string.Format("{0}-{1}", textEdit2.Text, carDetailList.Count + 1), order_num = textEdit2.Text };
                carDetailList.Add(sd);
                int i = gridView1.RowCount-1;
                this.gridView1.SetRowCellValue(i, gridView1.Columns[1], textEdit2.Text);
                this.gridView1.Columns[1].OptionsColumn.AllowEdit = false; //设置不可编辑的列
            }
                

        }
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            Demo1._1._3.Outbound_Car.isExist = false;
        }
    
       
        private void textEditCity_Click(object sender, EventArgs e)
        {
            //卸货城市 卸货区域 实际卸点
            discharge_form.ReturnEvent += new Demo1._1._3._1_NewViews.TabbedSection_Discharge.ClickCity(getDischargeValue);
            discharge_form.ShowDialog();
           
        }
        void getDischargeValue(string a, string b, string c)
        {
            textEditCity.Text = a;
            text_unload_area.Text = b;
            text_unload_point.Text = c;
        }

        private void textEditCar_Click(object sender, EventArgs e)
        {
            //车队 车号 司机
            child_form.ReturnEvent += new TabbedSections.ClickCar(getCarValue);
            child_form.ShowDialog();
        }
        void getCarValue(string a, string b, string c)
        {
            textEditCar.Text = a;
            text_carnum.Text = b;
            text_driver.Text = c;
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //卸货城市 卸货区域 实际卸点
            discharge_form.ReturnEvent += new Demo1._1._3._1_NewViews.TabbedSection_Discharge.ClickCity(getColumnsValue);
            discharge_form.ShowDialog();
        }
        void getColumnsValue(string a, string b, string c) {
            this.gridView1.SetRowCellValue(gridView1.SelectedRowsCount - 1, this.gridView1.Columns[15], a);
            this.gridView1.SetRowCellValue(gridView1.SelectedRowsCount - 1, this.gridView1.Columns[16], b);
            this.gridView1.SetRowCellValue(gridView1.SelectedRowsCount - 1, this.gridView1.Columns[17], c);
        }
    }
}
