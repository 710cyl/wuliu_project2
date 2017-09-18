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
    public partial class New_Package : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        FunctionClass fc = new FunctionClass();
        domain.YaohaoPac yp = new domain.YaohaoPac();
        private BindingList<domain.Outbound_Car> carDetailList;
        private BindingList<domain.Outbound_Car> cars;
        List<domain.Outbound_Car> sd = new List<domain.Outbound_Car>();
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int i = 0;//计算增加gridview行数
        public long now_Page = 1; //当前页码
        public New_Package()
        {
            InitializeComponent();
            DataGridViewInit();
            this.gridView1.Columns[0].Caption = "派车单号";
            this.gridView1.Columns[1].Caption = "打包单号";
            this.gridView1.Columns[2].Caption = "货主单位";
            this.gridView1.Columns[3].Caption = "发货仓库";
            this.gridView1.Columns[4].Caption = "发货量";
            this.gridView1.Columns[5].Caption = "出库方式";
            this.gridView1.Columns[6].Caption = "业务部门";
            this.gridView1.Columns[7].Caption = "业务人员";
            this.gridView1.Columns[8].Caption = "付费单位";
            this.gridView1.Columns[9].Caption = "车队";
            this.gridView1.Columns[10].Caption = "车号";
            this.gridView1.Columns[11].Caption = "司机";
            this.gridView1.Columns[12].Caption = "派车人";
            this.gridView1.Columns[13].Caption = "派车时间";
            this.gridView1.Columns[14].Caption = "卸货城市";
            this.gridView1.Columns[15].Caption = "卸货区域";
            this.gridView1.Columns[16].Caption = "实际卸点";
            this.gridView1.Columns[17].Caption = "打包";
            this.gridView1.Columns[18].Caption = "关闭";
            this.gridView1.Columns[19].Caption = "关闭人";
            this.gridView1.Columns[20].Caption = "关闭时间";
            this.gridView1.Columns[21].Caption = "说明";
            this.gridView1.Columns[22].Visible = false;
            
        }

        private void dtp_TextChange(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell.Value = dtp.Text; //时间控件选择时间时，就把时间赋给所在的单元格  
        }


        public void DataGridViewInit()
        {
            List<domain.Outbound_Car> sd = null;
            String str = "Outbound_Car";
            sd = JsonConvert.DeserializeObject<List<domain.Outbound_Car>>(fc.GridViewInit(str));
            carDetailList = new BindingList<domain.Outbound_Car>(sd);
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
            yp.package_num = text_pacnum.Text;
            yp.lottery_state = text_state.Text;
            yp.ordernum_num = text_num.Text;
            yp.quantity_all = Convert.ToDecimal(text_total.Text);
            yp.pac_staff = text_pac_staff.Text;
            yp.pac_time = Convert.ToDateTime(date_pac_time.DateTime);
            int[] rownumber = this.gridView1.GetSelectedRows();//获取选中行号；
            if (rownumber.Length >= 1)
            {
                BindingSource bs = new BindingSource();
                for (int i = 0; i < rownumber.Length; i++)
                {
                    this.gridView1.SetRowCellValue(rownumber[i], gridView1.Columns[17], "是");
                    Object o = this.gridView1.GetRow(rownumber[i]);
                    bs.Add(o);
                }
                this.gridControl1.DataSource = bs;
                gridView1.RefreshData();
            }
            else if (rownumber.Length == 0) {
                this.gridControl1.DataSource = null;
                gridView1.RefreshData();
            }
            string Json = JsonConvert.SerializeObject(this.gridControl1.DataSource);
            string jsonMain = JsonConvert.SerializeObject(yp);
            if (Demo1._1._3.package.isExist) //保存修改数据
            {
               
                fc.ChangeData(jsonMain, Json, yp.GetType().Name.ToString(), "Outbound_Car");
                
           }
            else if (!Demo1._1._3.package.isExist) //保存新增数据
            {
               
                fc.SaveData(jsonMain, Json, yp.GetType().Name.ToString(),"Outbound_Car");
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

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
            Demo1._1._3.package.isExist = false;
        }

        private void button_yaohao_Click(object sender, EventArgs e)//摇号按钮
        {
                text_pacnum.Text = fc.DateTimeToUnix("DB");
                text_state.Text = "完成摇号";
                text_pacnum.ReadOnly = true;
                text_state.ReadOnly = true;
                text_total.ReadOnly = true;
                text_num.ReadOnly = true;
                domain.Outbound_Car bs = new domain.Outbound_Car();
                List<domain.Outbound_Car> yp = null;
                yp = fc.getPacList<domain.Outbound_Car>(bs, now_Page.ToString());
                carDetailList = new BindingList<domain.Outbound_Car>(yp);
                this.gridControl1.DataSource = carDetailList;
                for (int i = 0; i < this.gridView1.RowCount; i++)
                {
                    this.gridView1.SetRowCellValue(i, gridView1.Columns[1], this.text_pacnum.Text);
                }
                this.gridView1.Columns[22].Visible = false;
               

        }

        private void checkBoxClick(object sender, EventArgs e)
        {
            int[] rownumber = this.gridView1.GetSelectedRows();//获取选中行号；
            float num = 0;
            if (rownumber.Length > 0)
            {

                for (int i = 0; i < rownumber.Length; i++)
                {
                    num += float.Parse(this.gridView1.GetRowCellValue(rownumber[i], gridView1.Columns[4]).ToString());
                }
                
            }
            text_total.Text = num.ToString();
            text_num.Text = rownumber.Length.ToString();
        }

       
    }
}
