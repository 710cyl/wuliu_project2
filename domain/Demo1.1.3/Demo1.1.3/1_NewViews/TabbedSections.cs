using Demo1._1._3.Panel2_MyWorkBench;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo1._1._3.MyWorkBench_SkipForm
{
    public partial class TabbedSections : Form
    {
        FunctionClass fc = new FunctionClass();
        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码
        static public string motorcade_string;//车队
        static public string carid_string;//车号
        static public string driver_string;//司机
        bool IsInternal = true;
        domain.External_Vehicle ev = new domain.External_Vehicle();
        domain.Internal_Vehicle iv = new domain.Internal_Vehicle();
        //定义委托处理
        public delegate void ClickCar(string a,string b,string c);
        //定义返回委托类型的事件  
        public ClickCar ReturnEvent;

        public TabbedSections()
        {
            InitializeComponent();
            domain.Internal_Vehicle iv = new domain.Internal_Vehicle();
            //gridControl1.DataSource = fc.showData<domain.Internal_Vehicle>(iv, now_Page.ToString());
            domain.External_Vehicle ev = new domain.External_Vehicle();
            gridControl1.DataSource = fc.showData<domain.External_Vehicle>(ev, now_Page.ToString());
        }

        //取消
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
        //查询事件
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            String input_val = textBox1.Text;
            if (IsInternal == false)
            {
                if (input_val.Equals(""))
                {
                    MessageBox.Show("请输入查询关键字！");
                }
                else
                {
                    gridControl1.DataSource = fc.showDataLike < domain.External_Vehicle> (ev, now_Page.ToString(), input_val);
                }
            }
            else 
            {
                if (input_val.Equals(""))
                {
                    MessageBox.Show("请输入查询关键字！");
                }
                else
                {
                    gridControl1.DataSource = fc.showDataLike<domain.Internal_Vehicle>(iv, now_Page.ToString(), input_val);
                }
            }
        }
        //确定事件
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            motorcade_string = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[1]);
            carid_string = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[2]);
            driver_string = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[3]);
            Close();
            ReturnEvent?.Invoke(motorcade_string, carid_string, driver_string);
            DriverCheck dc = new DriverCheck();


        }
        //内部车队事件
        private void accordionControlElement2_Click_1(object sender, EventArgs e)
        {
            IsInternal = true;
            domain.Internal_Vehicle iv = new domain.Internal_Vehicle();
            gridControl1.DataSource = fc.showData<domain.Internal_Vehicle>(iv, now_Page.ToString());
        }
        //外部车队事件
        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            IsInternal = false;
            domain.External_Vehicle ev = new domain.External_Vehicle();
            gridControl1.DataSource = fc.showData<domain.External_Vehicle>(ev, now_Page.ToString());
        }


    }
}
