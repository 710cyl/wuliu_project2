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
    public partial class TabbedSection_OutBounceCarDetails : Form
    {
        FunctionClass fc = new FunctionClass();
        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码

        public string order_num;//客户简称


        domain.Customer_File cf = new domain.Customer_File();
        public TabbedSection_OutBounceCarDetails()
        {
            InitializeComponent();
            order_num = Demo1._1._3.Views.MyWorkBench_SkipForm.New_OutboundOrder.ordernum;
            gridControl1.DataSource = fc.getOutBounceCarDetails(order_num);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e) //确定
        {

        }

        private void simpleButton3_Click(object sender, EventArgs e) //查询
        {

        }
    }
}
