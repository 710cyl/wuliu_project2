using Demo1._1._3.MyWorkBench_SkipForm;
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
        /// <summary>
        /// 车队、司机、车号
        /// </summary>
        private TabbedSections child_form = new TabbedSections();


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
            textBox_register_id.Text = fc.DateTimeToUnix("OR");
            textBox_register_man.Text = "裴哥";
            textBox_register_time.Text = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            //设置下拉控件
            comboBox_oilgas_type.ValueMember = "value";
            comboBox_oilgas_type.DataSource = fc.getOilGasType();
            //设置明细表列表名
            this.gridView1.Columns[0].Caption = "油气登记详细单号";
            this.gridView1.Columns[1].Caption = "车队";
            this.gridView1.Columns[2].Caption = "车号";
            this.gridView1.Columns[3].Caption = "司机";
            this.gridView1.Columns[4].Caption = "油气量";
            this.gridView1.Columns[5].Caption = "金额";
            this.gridView1.Columns[6].Caption = "备注";
            this.gridView1.Columns[7].Caption = "加注日期";
            this.gridView1.Columns[8].Caption = "油气种类";
            this.gridView1.Columns[9].Caption = "油气单价";
            this.gridView1.Columns[10].Visible = false;
            //绑定委托
            child_form.ReturnEvent += new TabbedSections.ClickCar(getCarValue);
            //不可编辑
            this.gridView1.Columns[1].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[2].OptionsColumn.AllowEdit = false;
            this.gridView1.Columns[3].OptionsColumn.AllowEdit = false;
            //明细表下拉列表 油气种类
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox combobox_OilGasType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            combobox_OilGasType.Items.AddRange(fc.getOilGasType());
            this.gridView1.Columns[8].ColumnEdit = combobox_OilGasType;
        }
        //添加
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            domain.OilGasRegister_Detail sd = new domain.OilGasRegister_Detail()
            {
                OilGasRegister_Detail_Id = string.Format("{0}-{1}", textBox_register_id.Text, tcd_bindinglist.Count + 1),
                register_id = textBox_register_id.Text
            };
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
            if (Panel2_MyWorkBench.GodownEntry.isExist) //修改
            {
                tcm.register_id = textBox_register_id.Text;
                tcm.fueling_date = Convert.ToDateTime(dateTimePicker_fueling_date.Text);
                tcm.oilgas_type = comboBox_oilgas_type.Text;
                tcm.oilgas_unitprice = Convert.ToDecimal(textBox_oilgas_unitprice.Text);
                tcm.register_man = textBox_register_man.Text;
                tcm.register_time = Convert.ToDateTime(textBox_register_time.Text.ToString());
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
                tcm.register_time = Convert.ToDateTime(textBox_register_time.Text.ToString());
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
        //明细表单击显示车队
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.Caption == "车队" || e.Column.Caption == "车号" || e.Column.Caption == "司机")
            {
                child_form.ShowDialog();
            }
        }
        //实现委托
        void getCarValue(string a, string b, string c)
        {
            gridView1.SetRowCellValue(gridView1.SelectedRowsCount - 1, gridView1.Columns[1], a);
            gridView1.SetRowCellValue(gridView1.SelectedRowsCount - 1, gridView1.Columns[2], b);
            gridView1.SetRowCellValue(gridView1.SelectedRowsCount - 1, gridView1.Columns[3], c);
        }
    }
}
