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
    public partial class New_TransportationRegister : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        private BindingList<domain.TransportationRegister_Detail> TransportationRegister_Detail;
        domain.TransportationRegister tr = new TransportationRegister();
        List<domain.TransportationRegister_Detail> trd = new List<TransportationRegister_Detail>();
        FunctionClass fc = new FunctionClass();
        public New_TransportationRegister()
        {
            InitializeComponent();
            if (Panel2_MyWorkBench.TransportationRegister.isExist)
            {
                //主表显示
                textBox2.Text = Panel2_MyWorkBench.TransportationRegister.array[0];
                dateTimePicker1.Value = Convert.ToDateTime(Panel2_MyWorkBench.TransportationRegister.array[1]);
                comboBox1.ValueMember = Panel2_MyWorkBench.TransportationRegister.array[2];
                textBox5.Text = Panel2_MyWorkBench.TransportationRegister.array[3];
                textBox3.Text = Panel2_MyWorkBench.TransportationRegister.array[4];
                textBox9.Text = Panel2_MyWorkBench.TransportationRegister.array[5];
                textBox10.Text = Panel2_MyWorkBench.TransportationRegister.array[9];
                textBox14.Text = Panel2_MyWorkBench.TransportationRegister.array[10];
                textBox23.Text = Panel2_MyWorkBench.TransportationRegister.array[11];
                dateTimePicker2.Value = Convert.ToDateTime(Panel2_MyWorkBench.TransportationRegister.array[12]);
                dateTimePicker3.Value = Convert.ToDateTime(Panel2_MyWorkBench.TransportationRegister.array[13]);
                textBox18.Text = Panel2_MyWorkBench.TransportationRegister.array[14];
                textBox4.Text = Panel2_MyWorkBench.TransportationRegister.array[15];
                textBox16.Text = Panel2_MyWorkBench.TransportationRegister.array[16];
                textBox17.Text = Panel2_MyWorkBench.TransportationRegister.array[17];
                textBox11.Text = Panel2_MyWorkBench.TransportationRegister.array[18];
                textBox24.Text = Panel2_MyWorkBench.TransportationRegister.array[19];
                textBox7.Text = Panel2_MyWorkBench.TransportationRegister.array[21];
                dateTimePicker4.Value = Convert.ToDateTime(Panel2_MyWorkBench.TransportationRegister.array[22]);
                textBox12.Text = Panel2_MyWorkBench.TransportationRegister.array[23];
                dateTimePicker5.Value = Convert.ToDateTime(Panel2_MyWorkBench.TransportationRegister.array[24]);

                //明细表显示
                trd = JsonConvert.DeserializeObject<List<domain.TransportationRegister_Detail>>(fc.FindDeteils(Panel2_MyWorkBench.TransportationRegister.str, "TransportationRegister_Detail"));
                TransportationRegister_Detail = new BindingList<domain.TransportationRegister_Detail>(trd);


                gridControl1.DataSource = TransportationRegister_Detail;
                //gridView1.Columns[2].DisplayFormat.FormatType =DevExpress.Utils.FormatType.DateTime;
                //gridView1.Columns[23].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                //gridView1.Columns[25].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                //gridView1.Columns[26].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;

            }
            else
            {
                DataGridViewInit();
                textBox2.Text = fc.DateTimeToUnix("YJ");

            }

            this.gridView1.Columns[0].Caption = "运输单号";
            this.gridView1.Columns[0].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[1].Caption = "记账日期";
            this.gridView1.Columns[2].Caption = "订单号";
            this.gridView1.Columns[3].Caption = "运输单标识";
            this.gridView1.Columns[3].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[4].Caption = "货主";
            this.gridView1.Columns[5].Caption = "卷号";
            this.gridView1.Columns[6].Caption = "品种";
            this.gridView1.Columns[7].Caption = "材质";
            this.gridView1.Columns[8].Caption = "规格";
            this.gridView1.Columns[9].Caption = "件数";
            this.gridView1.Columns[10].Caption = "数量";
            this.gridView1.Columns[11].Caption = "毛重";
            this.gridView1.Columns[12].Caption = "车队运价";
            this.gridView1.Columns[13].Caption = "车队运费";
            this.gridView1.Columns[14].Caption = "货主运价";
            this.gridView1.Columns[15].Caption = "货主金额";
            this.gridView1.Columns[16].Caption = "已结算金额";
            this.gridView1.Columns[17].Caption = "未结算金额";
            this.gridView1.Columns[18].Caption = "运输方式";
            this.gridView1.Columns[19].Caption = "车队";
            this.gridView1.Columns[20].Caption = "车号";
            this.gridView1.Columns[21].Caption = "司机";
            this.gridView1.Columns[22].Caption = "业务部门";
            this.gridView1.Columns[23].Caption = "业务员";
            this.gridView1.Columns[24].Caption = "出发地点";
            this.gridView1.Columns[25].Caption = "装货地点";
            this.gridView1.Columns[26].Caption = "卸货地点";
            this.gridView1.Columns[27].Caption = "出发城市";
            this.gridView1.Columns[28].Caption = "出发区域";
            this.gridView1.Columns[29].Caption = "装货城市";
            this.gridView1.Columns[30].Caption = "装货区域";
            this.gridView1.Columns[31].Caption = "卸货城市";
            this.gridView1.Columns[32].Caption = "卸货区域";
            this.gridView1.Columns[33].Caption = "出发日期";
            this.gridView1.Columns[34].Caption = "返回日期";
            this.gridView1.Columns[35].Caption = "录入人员";
            this.gridView1.Columns[36].Caption = "录入时间";
            this.gridView1.Columns[37].Caption = "修改人员";
            this.gridView1.Columns[38].Caption = "修改时间";
            this.gridView1.Columns[39].Caption = "说明";
            this.gridView1.Columns[40].Caption = "备注";
        }

        public void DataGridViewInit()
        {
            List<domain.TransportationRegister_Detail> trd = null;
            trd = JsonConvert.DeserializeObject<List<domain.TransportationRegister_Detail>>(fc.GridViewInit("TransportationRegister_Detail"));
            TransportationRegister_Detail = new BindingList<domain.TransportationRegister_Detail>(trd);
            gridControl1.DataSource = TransportationRegister_Detail;
        }


        private void panel_Main_Paint(object sender, PaintEventArgs e)
        {

        }

        private void simpleButton4_Click(object sender, EventArgs e)//添加
        {
            domain.TransportationRegister_Detail trd = new domain.TransportationRegister_Detail()
            { transport_identifying = string.Format("{0}-{1}", textBox2.Text, TransportationRegister_Detail.Count + 1), transport_ID = textBox2.Text };
            TransportationRegister_Detail.Add(trd);
        }

        private void simpleButton3_Click(object sender, EventArgs e)//删除
        {
            try
            {
                int index = gridView1.SelectedRowsCount + 1;//dataGridView1.CurrentRow.Index;
                TransportationRegister_Detail.RemoveAt(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)//保存
        {
            if (Panel2_MyWorkBench.TransportationRegister.isExist) //保存修改
            {
                tr.transport_ID = textBox2.Text;
                tr.tally_date = dateTimePicker1.Value;
                tr.transport_way = comboBox1.ValueMember;
                tr.fleet = textBox5.Text;
                tr.car_number = textBox3.Text;
                tr.driver = textBox9.Text;
                tr.depart_point = textBox10.Text;
                tr.ship_point = textBox14.Text;
                tr.unload_point = textBox23.Text;
                tr.depart_date = dateTimePicker2.Value;
                tr.back_date = dateTimePicker3.Value;
                tr.depart_city = textBox18.Text;
                tr.ship_city = textBox4.Text;
                tr.unload_city = textBox16.Text;
                tr.depart_area = textBox17.Text;
                tr.ship_area = textBox11.Text;
                tr.unload_area = textBox24.Text;
                tr.enter_staff = textBox7.Text;
                tr.enter_time = dateTimePicker4.Value;
                tr.change_staff = textBox12.Text;
                tr.change_time = dateTimePicker5.Value;
                List<domain.TransportationRegister_Detail> sd = TransportationRegister_Detail.ToList<domain.TransportationRegister_Detail>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(tr);

                fc.ChangeData(jsonMain, Json, tr.GetType().Name.ToString(), "TransportationRegister_Detail");
            }

            else   //保存
            {
                tr.transport_ID = textBox2.Text;
                tr.tally_date = dateTimePicker1.Value;
                tr.transport_way = comboBox1.ValueMember;
                tr.fleet = textBox5.Text;
                tr.car_number = textBox3.Text;
                tr.driver = textBox9.Text;
                tr.depart_point = textBox10.Text;
                tr.ship_point = textBox14.Text;
                tr.unload_point = textBox23.Text;
                tr.depart_date = dateTimePicker2.Value;
                tr.back_date = dateTimePicker3.Value;
                tr.depart_city = textBox18.Text;
                tr.ship_city = textBox4.Text;
                tr.unload_city = textBox16.Text;
                tr.depart_area = textBox17.Text;
                tr.ship_area = textBox11.Text;
                tr.unload_area = textBox24.Text;
                tr.enter_staff = textBox7.Text;
                tr.enter_time = dateTimePicker4.Value;
                tr.change_staff = textBox12.Text;
                tr.change_time = dateTimePicker5.Value;
                List<domain.TransportationRegister_Detail> sd = TransportationRegister_Detail.ToList<domain.TransportationRegister_Detail>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(tr);

                fc.SaveData(jsonMain, Json, tr.GetType().Name.ToString(), "TransportationRegister_Detail");
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
            if (e.Column.FieldName == "tally_date" || e.Column.FieldName == "depart_date" || e.Column.FieldName == "back_date" || e.Column.FieldName == "enter_time" || e.Column.FieldName == "change_time")
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



        //private void panel_Main_Paint(object sender, PaintEventArgs e)
        //{

        //}
    }
}
