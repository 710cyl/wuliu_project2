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
    public partial class New_OilGasRegister_1 : Form
    {
        private BindingList<domain.OilGasRegister_Detail> tcd_bindinglist;
        domain.OilGasRegister_Main tcm = new domain.OilGasRegister_Main();
        List<domain.OilGasRegister_Detail> sd = new List<domain.OilGasRegister_Detail>();
        FunctionClass fc = new FunctionClass();
        public New_OilGasRegister_1()
        {
            InitializeComponent();
            if (Panel2_MyWorkBench.OilGasRegister.isExist)
            {
                //主表显示
                textBox_register_id.Text = Panel2_MyWorkBench.OilGasRegister.array[0];
                dateTimePicker_fueling_date.Text = Panel2_MyWorkBench.OilGasRegister.array[1];
                comboBox_oilgas_type.Text = Panel2_MyWorkBench.OilGasRegister.array[2];
                textBox_oilgas_unitprice.Text = Panel2_MyWorkBench.OilGasRegister.array[3];
                textBox_register_man.Text = Panel2_MyWorkBench.OilGasRegister.array[4];
                textBox_register_time.Text = Panel2_MyWorkBench.OilGasRegister.array[5];


            }
            else
            {
                DataGridViewInit();

            }
        }
        public void DataGridViewInit()
        {
            List<domain.OilGasRegister_Detail> sd = null;
            sd = JsonConvert.DeserializeObject<List<domain.OilGasRegister_Detail>>(fc.GridViewInit("OilGasRegister_Detail"));
            tcd_bindinglist = new BindingList<domain.OilGasRegister_Detail>(sd);
            gridControl1.DataSource = tcd_bindinglist;
        }
        //添加
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            domain.OilGasRegister_Detail sd = new domain.OilGasRegister_Detail() {/* StorageFormMain = tcm*/ };
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
                tcm.register_id = textBox_register_id.Text;
                tcm.fueling_date = Convert.ToDateTime(dateTimePicker_fueling_date.Text);
                tcm.oilgas_type = comboBox_oilgas_type.Text;
                tcm.oilgas_unitprice = Convert.ToDecimal(textBox_oilgas_unitprice.Text);
                tcm.register_man = textBox_register_man.Text;
                tcm.register_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy / MM / dd hh: mm:ss"));
                //界面中不存在的数据
                tcm.modifier = "修改人";
                tcm.modify_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy / MM / dd hh: mm:ss"));

                List<domain.OilGasRegister_Detail> sd = tcd_bindinglist.ToList<domain.OilGasRegister_Detail>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(tcm);

                fc.ChangeData(jsonMain, Json, tcm.GetType().Name.ToString(), "OilGasRegister_Detail");
            }

            else   //保存
            {
                tcm.register_id = textBox_register_id.Text;
                tcm.fueling_date = Convert.ToDateTime(dateTimePicker_fueling_date.Text);
                tcm.oilgas_type = comboBox_oilgas_type.Text;
                tcm.oilgas_unitprice = Convert.ToDecimal(textBox_oilgas_unitprice.Text);
                tcm.register_man = textBox_register_man.Text;
                tcm.register_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy / MM / dd hh: mm:ss"));
                //界面中不存在的数据
                tcm.modifier = "修改人";
                tcm.modify_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy / MM / dd hh: mm:ss"));


                List<domain.OilGasRegister_Detail> sd = tcd_bindinglist.ToList<domain.OilGasRegister_Detail>();
                string Json = JsonConvert.SerializeObject(sd);
                string jsonMain = JsonConvert.SerializeObject(tcm);
                Panel2_MyWorkBench.GodownEntry.isExist = true;
                fc.SaveData(jsonMain, Json, tcm.GetType().Name.ToString(), "OilGasRegister_Detail");
            }
        }
        //取消
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
