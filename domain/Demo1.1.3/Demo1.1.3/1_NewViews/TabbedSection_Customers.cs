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
    /// 客户档案弹出窗
    /// </summary>
    public partial class TabbedSection_Customers : Form
    {
        FunctionClass fc = new FunctionClass();
        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码

        public string customersname;//客户简称


        domain.Customer_File  cf= new domain.Customer_File();

        //定义委托处理
        public delegate void Customers(string customer);
        //定义返回委托事件
        public Customers ReturnEvent;

        public TabbedSection_Customers()
        {
            
            InitializeComponent();

            
            gridControl1.DataSource = fc.showData(cf, now_Page.ToString());

            this.gridView1.Columns[0].Caption = "编号";
            this.gridView1.Columns[1].Caption = "客户简称";
            this.gridView1.Columns[2].Caption = "客户全称";
            this.gridView1.Columns[3].Caption = "速查码";
            this.gridView1.Columns[4].Caption = "地址";
            this.gridView1.Columns[5].Caption = "开户行";
            this.gridView1.Columns[6].Caption = "税号";
            this.gridView1.Columns[7].Caption = "联系人";
            this.gridView1.Columns[8].Caption = "电话";
            this.gridView1.Columns[9].Caption = "客户类型1";
            this.gridView1.Columns[10].Caption = "客户类型2";
            this.gridView1.Columns[11].Caption = "客户类型3";
            this.gridView1.Columns[12].Caption = "客户类型4";
            this.gridView1.Columns[13].Caption = "客户类型5";

            this.gridView1.BestFitColumns();
        }

        private void simpleButton3_Click(object sender, EventArgs e) //查询
        {
            string input_val = textBox1.Text;
            if (input_val.Equals(""))
            {
                MessageBox.Show("请输入查询关键字！");
            }
            else
            {
                gridControl1.DataSource = fc.showDataLike<domain.Customer_File>(cf, now_Page.ToString(), input_val);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e) //确定
        {
            customersname = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[1]);
            Close();
            ReturnEvent?.Invoke(customersname);
        }

        private void simpleButton2_Click(object sender, EventArgs e) //取消
        {
            Close();
        }
    }
}
