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

        public New_OutBound_Car()
        {
            InitializeComponent();

            DataGridViewInit();
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
            bs.order_num = textEdit2.Text;
            bs.sendcar_num = text_sendcar_num.Text;
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
            bs.packge = checkedComboBoxpackge.SelectedText.ToString();
            bs.unload_city = textEdit1.Text;
            bs.unload_area = text_unload_area.Text;
            bs.unload_point = text_unload_point.Text;
            bs.is_close = checkedComboBoxclose.SelectedText.ToString();
            bs.close_staff = text_close_staff.Text;
            bs.close_time = Convert.ToDateTime(date_close_time.DateTime);
            bs.explain = text_explain.Text;
            
            
            if (Demo1._1._3.Outbound_Car.isExist) //保存修改数据
            {
                List<domain.Outbound_Car_Detail> sd = Outbound_Car.carDetails.ToList<Outbound_Car_Detail>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(bs);
                fc.ChangeData(jsonMain, Json, bs.GetType().Name.ToString(), "Outbound_Car_Detail");
            }
            else
            {  //保存新增数据
                List<domain.Outbound_Car_Detail> sd = carDetailList.ToList<Outbound_Car_Detail>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(bs);
                fc.SaveData(jsonMain, Json, bs.GetType().Name.ToString(), "Outbound_Car_Detail");
            }

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e) //设置指定列为日期下拉菜单
        {
            try
            {
                if (this.dataGridView1.CurrentCell.ColumnIndex.ToString() == "2" || this.dataGridView1.CurrentCell.ColumnIndex.ToString() == "23" || this.dataGridView1.CurrentCell.ColumnIndex.ToString() == "25" || this.dataGridView1.CurrentCell.ColumnIndex.ToString() == "26")
                {
                    System.Drawing.Rectangle rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex,dataGridView1.CurrentCell.RowIndex,false);
                    dtp.Value = System.DateTime.Now;
                    dtp.Left = rect.Left;
                    dtp.Top = rect.Top;
                    dtp.Width = rect.Width;
                    dtp.Height = dtp.Height;
                    dtp.Visible = true;
                    dataGridView1.CurrentCell.Value = dtp.Value;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
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
           domain.Outbound_Car_Detail sd = new domain.Outbound_Car_Detail() { };
            if (Demo1._1._3.Outbound_Car.isExist)
            {//修改
                Outbound_Car.carDetails.Add(sd);
            }
            else {//新增
                carDetailList.Add(sd);
            }
                

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
