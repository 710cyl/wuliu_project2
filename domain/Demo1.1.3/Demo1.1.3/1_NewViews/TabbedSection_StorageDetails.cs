using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo1._1._3._1_NewViews.MyWorkBench
{
    public partial class TabbedSection_StorageDetails : Form
    {
        FunctionClass fc = new FunctionClass();
        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码
        private static string name;
        domain.StorageDetails cf = new domain.StorageDetails();

        #region 明细表传参
        public string storagename;//仓库
        public string cargoowner;//货主
        public string variety;//品种
        public string storagecode;//入库单识别码
        public string ordernumber;//订单号
        public string itemnumber;//项目号
        public int InventoryNumber;//库存件数
        public decimal StockQuantity;// 库存数量
        public string ReelNumber;//卷号
        public string Material;// 材质
        public string Specification;// 规格
        public string CribNumber;// 垛位号

        public string Statement;// 备注
        #endregion

        //定义委托处理
        public delegate void ClickStorageDetails(/*string storagename, string cargoowner,*/ string variety, string storagecode
                                                , string ordernumber, string itemnumber, int InventoryNumber, decimal StockQuantity
                                                , string ReelNumber, string Material, string Specification, string CribNumber, string Statement);
        //定义返回委托事件
        public ClickStorageDetails ReturnEvent;
        /// <summary>
        /// 入库单明细表
        /// </summary>
        public TabbedSection_StorageDetails()
        {  
            InitializeComponent();
            name = Demo1._1._3.Views.MyWorkBench_SkipForm.New_TransferList.storagename;
            gridControl1.DataSource = fc.getStorageDetails(name);

            this.gridView1.Columns[0].Caption = "入库单识别码";
            this.gridView1.Columns[1].Caption = "入库单号";
            this.gridView1.Columns[2].Caption = "仓库名称";
            this.gridView1.Columns[3].Caption = "出厂日期";
            this.gridView1.Columns[4].Caption = "订单号";
            this.gridView1.Columns[5].Caption = "货主";
            this.gridView1.Columns[6].Caption = "卸货点";
            this.gridView1.Columns[7].Caption = "卸货城市";
            this.gridView1.Columns[8].Caption = "卸货区域";
            this.gridView1.Columns[9].Caption = "卷号";
            this.gridView1.Columns[10].Caption = "品种";
            this.gridView1.Columns[11].Caption = "材质";
            this.gridView1.Columns[12].Caption = "规格";
            this.gridView1.Columns[13].Caption = "件数";
            this.gridView1.Columns[14].Caption = "数量";
            this.gridView1.Columns[15].Caption = "垛位号";
            this.gridView1.Columns[16].Caption = "入库方式";
            this.gridView1.Columns[17].Caption = "车队";
            this.gridView1.Columns[18].Caption = "车号";
            this.gridView1.Columns[19].Caption = "司机";
            this.gridView1.Columns[20].Caption = "装货城市";
            this.gridView1.Columns[21].Caption = "装货地点";
            this.gridView1.Columns[22].Caption = "装货区域";
            this.gridView1.Columns[23].Caption = "录入员";
            this.gridView1.Columns[24].Caption = "录入时间";
            this.gridView1.Columns[25].Caption = "修改人";
            this.gridView1.Columns[26].Caption = "修改时间";
            this.gridView1.Columns[27].Caption = "入库时间";
            this.gridView1.Columns[28].Caption = "库管";
            this.gridView1.Columns[28].Visible = false;
            this.gridView1.Columns[29].Caption = "吊车工";
            this.gridView1.Columns[29].Visible = false;
            this.gridView1.Columns[30].Caption = "装卸工";
            this.gridView1.Columns[30].Visible = false;
            this.gridView1.Columns[31].Caption = "其他人";
            this.gridView1.Columns[31].Visible = false;

            this.gridView1.Columns[32].Caption = "备注";
            this.gridView1.Columns[33].Caption = "库存件数";
            this.gridView1.Columns[33].Visible = false;
            this.gridView1.Columns[34].Caption = "库存数量";
            this.gridView1.Columns[34].Visible = false;
            this.gridView1.Columns[35].Caption = "票数";
            this.gridView1.Columns[36].Caption = "车队标识";
            this.gridView1.Columns[36].Visible = false;
            this.gridView1.Columns[37].Caption = "项目号";
            this.gridView1.Columns[38].Caption = "可派件数";
            this.gridView1.Columns[38].Visible = false;
            this.gridView1.Columns[39].Caption = "可派数量";
            this.gridView1.Columns[39].Visible = false;
            this.gridView1.BestFitColumns();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
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
                gridControl1.DataSource = fc.showDataLike<domain.StorageDetails>(cf, now_Page.ToString(), input_val);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e) //确定
        {
            //storagename = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[2]);
           // cargoowner = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[5]);
            variety = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[10]);
            storagecode = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[0]);
            ordernumber = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[4]);
            itemnumber = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[37]);
            InventoryNumber =Convert.ToInt32(gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[33])) ;
            StockQuantity = Convert.ToDecimal(gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[34])); 
            ReelNumber = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[9]);
            Material = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[11]);
            Specification = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[12]);
            CribNumber = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[15]);
            Statement = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[32]);

            Close();

            ReturnEvent?.Invoke(/*storagename, cargoowner,*/ variety, storagecode, ordernumber
                                , itemnumber, InventoryNumber, StockQuantity, ReelNumber, Material
                                , Specification, CribNumber, Statement);
        }

        private void dataNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e) //分页
        {

        }
    }
}
