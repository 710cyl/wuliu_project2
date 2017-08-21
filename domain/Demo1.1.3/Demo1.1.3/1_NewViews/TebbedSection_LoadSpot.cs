using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo1._1._3._1_NewViews
{
    /// <summary>
    /// 装点
    /// </summary>
    public partial class TebbedSection_LoadSpot : Form
    {

        FunctionClass fc = new FunctionClass();
        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码

        public string city;//城市
        public string spot;//点
        public string area;//地区
        private int Mark = 1;//标记1为装点，2为卸点，4位集运卸点

        domain.Decorate de = new domain.Decorate();
       
        domain.Transportations tr = new domain.Transportations();

        //定义委托处理
        public delegate void ClickCity(string citys, string spot, string area);
        //定义返回委托事件
        public ClickCity ReturnEvent;

        public TebbedSection_LoadSpot()
        {
            InitializeComponent();
            domain.Decorate de = new domain.Decorate();
            gridControl1.DataSource = fc.showData<domain.Decorate>(de, now_Page.ToString());
            this.gridView1.Columns[0].Caption = "编号";
            this.gridView1.Columns[1].Caption = "装点";
            this.gridView1.Columns[2].Caption = "所在城市";
            this.gridView1.Columns[3].Caption = "所在区域";
            this.gridView1.Columns[4].Caption = "说明";
            this.gridView1.Columns[5].Caption = "联系人";
            this.gridView1.Columns[6].Caption = "电话";
            this.gridView1.Columns[7].Caption = "地址";
            this.gridView1.BestFitColumns();
        }

        private void accordionControlElement2_Click(object sender, EventArgs e) //集运卸点
        {
             
        }

        private void accordionControlElement3_Click(object sender, EventArgs e) //卸货点
        {
           
        }

        private void accordionControlElement4_Click(object sender, EventArgs e) //装货点
        {
            domain.Decorate de = new domain.Decorate();
            gridView1.ClearGrouping();
            gridControl1.DataSource = fc.showData(de, now_Page.ToString());
            Mark = 1;

            this.gridView1.Columns[0].Caption = "编号";
            this.gridView1.Columns[1].Caption = "装点";
            this.gridView1.Columns[2].Caption = "所在城市";
            this.gridView1.Columns[3].Caption = "所在区域";
            this.gridView1.Columns[4].Caption = "说明";
            this.gridView1.Columns[5].Caption = "联系人";
            this.gridView1.Columns[6].Caption = "电话";
            this.gridView1.Columns[7].Caption = "地址";

            this.gridView1.BestFitColumns();
        }

        private void simpleButton2_Click(object sender, EventArgs e) //取消
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e) //确定按键事件
        {
            city = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[2]);
            spot = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[1]);
            area = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[3]);
            Close();
            ReturnEvent?.Invoke(city,spot,area);


            //Demo1._1._3.MyWorkBench_SkipForm.New_GoDownEntry gde = new MyWorkBench_SkipForm.New_GoDownEntry();
        }

        private void simpleButton3_Click(object sender, EventArgs e) //查询事件
        {
            if (Mark == 1)
            {
                string input_val = textBox1.Text;
                if (input_val.Equals(""))
                {
                    MessageBox.Show("请输入查询关键字！");
                }
                else
                {
                    gridControl1.DataSource = fc.showDataLike<domain.Decorate>(de, now_Page.ToString(), input_val);
                }
            }else if(Mark == 2)
            {
                
            }else if (Mark == 4)
            {
                string input_val = textBox1.Text;
                if (input_val.Equals(""))
                {
                    MessageBox.Show("请输入查询关键字！");
                }
                else
                {
                    gridControl1.DataSource = fc.showDataLike<domain.Transportations>(tr, now_Page.ToString(), input_val);
                }
            }


        }
    }
}
