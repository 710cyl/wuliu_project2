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
        
        public New_OutBound_Car()
        {
            InitializeComponent();
            dataGridView1.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);
        }

        private void dtp_TextChange(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dtp.Text; //时间控件选择时间时，就把时间赋给所在的单元格  
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 1)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows.Count);
            }
            else
            {
                MessageBox.Show("明细至少存在一条！");
            }
        }

        private void button3_Click(object sender, EventArgs e) //保存按钮 
        {

              bs.order_num = textEdit2.Text;
              bs.sendcar_num = text_sendcar_num.Text ;
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
              //bs.sendcar_time = Convert.ToDateTime(date_sendcar_time.SelectedText.ToString());
              bs.packge = checkedComboBoxpackge.SelectedText.ToString();
              // bs.packge = int.Parse(pac);
              bs.unload_city = textEdit1.Text;
              bs.unload_area = text_unload_area.Text;
              bs.unload_point = text_unload_point.Text;
              bs.is_close = checkedComboBoxclose.SelectedText.ToString();
              //bs.is_close = int.Parse(clo);
              bs.close_staff = text_close_staff.Text;
             // bs.close_time = Convert.ToDateTime(date_close_time.SelectedText.ToString());
              bs.explain = text_explain.Text;
           
               List<domain.Outbound_Car_Detail> list = new List<domain.Outbound_Car_Detail>();
            for (int rowindex=0; rowindex < dataGridView1.Rows.Count-1; rowindex++) {
                    domain.Outbound_Car_Detail bsDetail = new domain.Outbound_Car_Detail();
                    bsDetail.store_code = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
                    bsDetail.order_num = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
                    if (!bs.order_num.Equals(bsDetail.order_num))
                    {
                        MessageBox.Show("订单号有误请重新输入！");
                        break;
                    }
                    bsDetail.store_kind = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
                   // bsDetail.store_date = Convert.ToDateTime(dataGridView1.Rows[rowindex].Cells[3].Value.ToString());
                    bsDetail.pro_num = Convert.ToDecimal(dataGridView1.Rows[rowindex].Cells[4].Value.ToString());
                    bsDetail.roll_num = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();
                    bsDetail.kind = dataGridView1.Rows[rowindex].Cells[6].Value.ToString();
                    bsDetail.textures = dataGridView1.Rows[rowindex].Cells[7].Value.ToString();
                    bsDetail.norms = dataGridView1.Rows[rowindex].Cells[8].Value.ToString();
                    bsDetail.piece = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[9].Value.ToString());
                    bsDetail.out_num = dataGridView1.Rows[rowindex].Cells[10].Value.ToString();
                    bsDetail.crib_num = dataGridView1.Rows[rowindex].Cells[11].Value.ToString();
                    bsDetail.retail_piece = Convert.ToInt32(dataGridView1.Rows[rowindex].Cells[12].Value.ToString());
                    bsDetail.retail_num = dataGridView1.Rows[rowindex].Cells[13].Value.ToString();
                   // bsDetail.sendcar_time = Convert.ToDateTime(dataGridView1.Rows[rowindex].Cells[14].Value.ToString());
                    bsDetail.order_city = dataGridView1.Rows[rowindex].Cells[15].Value.ToString();
                    bsDetail.order_area = dataGridView1.Rows[rowindex].Cells[16].Value.ToString();
                    bsDetail.order_point = dataGridView1.Rows[rowindex].Cells[17].Value.ToString();
                    bsDetail.remark = dataGridView1.Rows[rowindex].Cells[18].Value.ToString();
                    list.Add(bsDetail);
                    //list1.Insert(rowindex,bsDetail);

            }
                if (Outbound_Car_Detail.isExist)
                    {
                    DialogResult dr;
                     dr = MessageBox.Show("该数据已存在，请重新输入！", "", MessageBoxButtons.YesNoCancel,
                              MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                
                }
                else
                {
               
               // fc.saveData(bs,list, bs.GetType().Name,list[0].GetType().Name);
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
            dataGridView1.Rows.Add();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
