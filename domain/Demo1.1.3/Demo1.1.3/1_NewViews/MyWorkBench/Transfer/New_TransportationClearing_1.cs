using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo1._1._3.Views.MyWorkBench_SkipForm.Transport
{
    public partial class New_TransportationClearing : Form
    {
        private BindingList<domain.TransportationClearing_Detail> tcd_bindinglist;
        domain.TransportationClearing_Main tcm = new domain.TransportationClearing_Main();
        List<domain.TransportationClearing_Detail> sd = new List<domain.TransportationClearing_Detail>();
        FunctionClass fc = new FunctionClass();
        public New_TransportationClearing()
        {
            InitializeComponent();
            if (Panel2_MyWorkBench.TransportationClearing.isExist)
            {
                //主表显示
                textBox_clearing_id.Text = Panel2_MyWorkBench.TransportationClearing.array[0];
                textBox_register_man.Text = Panel2_MyWorkBench.TransportationClearing.array[1];
                textBox_register_time.Text = Panel2_MyWorkBench.TransportationClearing.array[2];
                textBox_modifier.Text = Panel2_MyWorkBench.TransportationClearing.array[3];
                textBox_modify_time.Text = Panel2_MyWorkBench.TransportationClearing.array[4];
                textBox_shipper.Text = Panel2_MyWorkBench.TransportationClearing.array[5];
                textBox_shipper_fullname.Text = Panel2_MyWorkBench.TransportationClearing.array[6];
                textBox_shipper_TFN.Text = Panel2_MyWorkBench.TransportationClearing.array[7];
                textBox_paycompany.Text = Panel2_MyWorkBench.TransportationClearing.array[8];
                textBox_paycompany_fullname.Text = Panel2_MyWorkBench.TransportationClearing.array[9];
                textBox_paycompany_TFN.Text = Panel2_MyWorkBench.TransportationClearing.array[10];
                textBox_billcompany.Text = Panel2_MyWorkBench.TransportationClearing.array[11];
                textBox_billcompany_fullname.Text = Panel2_MyWorkBench.TransportationClearing.array[12];
                textBox_billcompany_TFN.Text = Panel2_MyWorkBench.TransportationClearing.array[13];
                textBox_total_money.Text = Panel2_MyWorkBench.TransportationClearing.array[14];
                textBox_total_volume.Text = Panel2_MyWorkBench.TransportationClearing.array[15];
            }
            else
            {
                DataGridViewInit();

            }
        }
        public void DataGridViewInit()
        {
            List<domain.TransportationClearing_Detail> sd = null;
            sd = JsonConvert.DeserializeObject<List<domain.TransportationClearing_Detail>>(fc.GridViewInit("TransportationClearing_Detail"));
            tcd_bindinglist = new BindingList<domain.TransportationClearing_Detail>(sd);
            gridControl1.DataSource = tcd_bindinglist;
        }
        //添加
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            domain.TransportationClearing_Detail sd = new domain.TransportationClearing_Detail() {/* StorageFormMain = tcm*/ };
            tcd_bindinglist.Add(sd);
        }
        //删除
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                int index = gridView1.SelectedRowsCount + 1;//dataGridView1.CurrentRow.Index;
                tcd_bindinglist.RemoveAt(index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //保存
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (Panel2_MyWorkBench.GodownEntry.isExist) //保存修改
            {
                tcm.clearing_id = textBox_clearing_id.Text;
                tcm.register_man = textBox_register_man.Text;
                tcm.register_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy / MM / dd hh: mm:ss"));
                tcm.modifier = textBox_modifier.Text;
                tcm.modify_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy / MM / dd hh: mm:ss"));
                tcm.shipper = textBox_shipper.Text;
                tcm.shipper_fullname = textBox_shipper_fullname.Text;
                tcm.shipper_TFN = textBox_shipper_TFN.Text;
                tcm.paycompany = textBox_paycompany.Text;
                tcm.paycompany_fullname = textBox_paycompany_fullname.Text;
                tcm.paycompany_TFN = textBox_paycompany_TFN.Text;
                tcm.billcompany = textBox_billcompany.Text;
                tcm.billcompany_fullname = textBox_billcompany_fullname.Text;
                tcm.billcompany_TFN = textBox_billcompany_TFN.Text;
                //decimal total_money=0M;
                //decimal total_volume=0M;
                //for (int i = 0; i < gridView1.RowCount; i++)
                //{
                //    total_money += Convert.ToDecimal(gridView1.Columns["total_money"].ToString());
                //    total_volume += Convert.ToDecimal(gridView1.Columns["total_volume"].ToString());
                //}

                //tcm.total_money = total_money;
                //tcm.total_volume = total_volume;
                tcm.total_money = Convert.ToDecimal(textBox_total_money.Text);
                tcm.total_volume = Convert.ToDecimal(textBox_total_volume.Text);

                List<domain.TransportationClearing_Detail> sd = tcd_bindinglist.ToList<domain.TransportationClearing_Detail>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(tcm);

                fc.ChangeData(jsonMain, Json, tcm.GetType().Name.ToString(), "TransportationClearing_Detail");
            }

            else   //保存
            {
                tcm.clearing_id = textBox_clearing_id.Text;
                tcm.register_man = textBox_register_man.Text;
                tcm.register_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy / MM / dd hh: mm:ss"));
                tcm.modifier = textBox_modifier.Text;
                tcm.modify_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy / MM / dd hh: mm:ss"));
                tcm.shipper = textBox_shipper.Text;
                tcm.shipper_fullname = textBox_shipper_fullname.Text;
                tcm.shipper_TFN = textBox_shipper_TFN.Text;
                tcm.paycompany = textBox_paycompany.Text;
                tcm.paycompany_fullname = textBox_paycompany_fullname.Text;
                tcm.paycompany_TFN = textBox_paycompany_TFN.Text;
                tcm.billcompany = textBox_billcompany.Text;
                tcm.billcompany_fullname = textBox_billcompany_fullname.Text;
                tcm.billcompany_TFN = textBox_billcompany_TFN.Text;
                //decimal total_money = 0M;
                //decimal total_volume = 0M;
                //for (int i = 0; i < gridView1.RowCount; i++)
                //{
                //    total_money += gridView1.
                //    total_volume += Convert.ToDecimal(gridView1.Columns["total_volume"].Value;);
                //}

                //tcm.total_money = total_money;
                //tcm.total_volume = total_volume;
                tcm.total_money = Convert.ToDecimal(textBox_total_money.Text);
                tcm.total_volume = Convert.ToDecimal(textBox_total_volume.Text);

                List<domain.TransportationClearing_Detail> sd = tcd_bindinglist.ToList<domain.TransportationClearing_Detail>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(tcm);
                Panel2_MyWorkBench.GodownEntry.isExist = true;
                fc.SaveData(jsonMain, Json, tcm.GetType().Name.ToString(), "TransportationClearing_Detail");
            }
        }
        //取消
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
