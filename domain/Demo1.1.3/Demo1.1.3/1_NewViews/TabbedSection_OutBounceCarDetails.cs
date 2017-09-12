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

        public string order_number;//订单号

        #region
        /// <summary>
        /// 入库标识码
        /// </summary>
        public string store_code { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string order_num { get; set; }

        /// <summary>
        /// 入库性质
        /// </summary>
        public string store_kind { get; set; }
        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime store_date { get; set; }

        /// <summary>
        /// 项目号
        /// </summary>
        public decimal pro_num { get; set; }
        /// <summary>
        /// 卷号
        /// </summary>
        public string roll_num { get; set; }
        /// <summary>
        /// 品种
        /// </summary>
        public string kind { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        public string textures { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string norms { get; set; }

        /// <summary>
        /// 可派件数
        /// </summary>
        public int piece { get; set; }
        /// <summary>
        /// 可派数量
        /// </summary>
        public string out_num { get; set; }

        /// <summary>
        /// 订单卸城
        /// </summary>
        public string order_city { get; set; }
        /// <summary>
        /// 订单卸区
        /// </summary>
        public string order_area { get; set; }
        /// <summary> 
        /// 订单卸点
        /// </summary>
        public string order_point { get; set; }

        /// <summary>
        /// 垛位号
        /// </summary>
        public string crib_num { get; set; }

        #endregion


        domain.Outbound_Car_Detail ocd = new domain.Outbound_Car_Detail();
        //定义委托处理
        public delegate void ClickOutBounceCarDetails(string store_code, string order_num, string store_kind, DateTime store_date, decimal pro_num, string roll_num
                                                     , string kind, string textures, string norms, int piece, string out_num,
                                                     string order_city, string order_area, string order_point, string crib_num);
        //定义返回委托事件
        public ClickOutBounceCarDetails ReturnEvent;

        public TabbedSection_OutBounceCarDetails()
        {
            InitializeComponent();
            order_number = Demo1._1._3.Views.MyWorkBench_SkipForm.New_OutboundOrder.ordernum;
            gridControl1.DataSource = fc.getOutBounceCarDetails(order_number);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e) //确定
        {
            store_code = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[0]);
            order_num = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[1]);
            store_kind = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[2]);
            store_date=Convert.ToDateTime(gridView1.GetFocusedRowCellValue(gridView1.Columns[3]));
            pro_num=Convert.ToDecimal( gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[4]));
            roll_num = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[5]);
            kind = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[6]);
            textures = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[7]);
            norms = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[8]);
            piece = Convert.ToInt32(gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[9]));
            out_num = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[10]);
            order_city = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[14]);
            order_area = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[15]);
            order_point = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[16]);
            crib_num = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[17]);

            Close();
            ReturnEvent?.Invoke(store_code, order_num, store_kind, store_date, pro_num, roll_num
                                                     , kind, textures, norms, piece, out_num,
                                                      order_city, order_area, order_point, crib_num);
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
                gridControl1.DataSource = fc.showDataLike<domain.Outbound_Car_Detail>(ocd, now_Page.ToString(), input_val);
            }
        }
    }
}
