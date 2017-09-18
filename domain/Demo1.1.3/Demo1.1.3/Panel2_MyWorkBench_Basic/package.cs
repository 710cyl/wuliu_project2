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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Demo1._1._3
{
    public partial class package : UserControl
    {
       
        StringReader streamToPrint = null;
        Font printFont;
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static int count = 0;//明细表所有列数
        public static string[] array = null;//

        //public static BindingList<domain.Outbound_Car> carDetails;

        public  long total_Page = 0; //页码总条目
        public  long now_Page = 1; //当前页码
        domain.YaohaoPac yp = new domain.YaohaoPac();
        FunctionClass fc = new FunctionClass();
        private GridHitInfo hi; //点击列表事件
        private package pac;
        private object JavaScriptConvert;
        public  List<domain.Outbound_Car> sd = new List<domain.Outbound_Car>(); //得到明细表的list
        private  BindingList<domain.Outbound_Car> carDetailList;
        public static string str = null;

        public package()
        {
            InitializeComponent();
            
            total_Page = fc.getTotal<domain.YaohaoPac>(yp,total_Page);
            fc.InitPage(dataNavigator_package, total_Page,now_Page);
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e) //删除出库派车主表
        {
            fc.DeleteMain(this.gridView1, "YaohaoPac", "package_num");
            
        }

       
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            string localFilePath = fc.ShowSaveFileDialog();

            if (localFilePath != null)
            {
                gridView2.Export(DevExpress.XtraPrinting.ExportTarget.Xls, localFilePath);
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e) //复选功能
        {
            if (this.gridView2.OptionsSelection.MultiSelect == true)
            {
                if (MessageBox.Show("是否关闭复选框", "复选框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    this.gridView2.OptionsSelection.MultiSelect = false;
                    // this.gridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
                }
            }
            else if (MessageBox.Show("是否打开复选框", "复选框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                this.gridView2.OptionsSelection.MultiSelect = true;
                this.gridView2.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e) //导入数据
        {
            string dataString = fc.getDataTable();

            if (dataString != null)
            {
                using (var ws = new WebSocket("ws://localhost:9000/BatchSave"))
                {
                    ws.Connect();
                    ws.Send(dataString);
                    ws.Close();
                }
                MessageBox.Show("导入成功！！");
            }

        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            fc.PrintDocument(sender, e);
        }

        private void 页面设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fc.PageSet(pageSetupDialog1, printDocument1);
        }

        private void 页面预览ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            fc.PageView(pageSetupDialog1, printDocument1);
        }

        private void 打印ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
                printDocument1.Print();
        }

        private void dataNavigator_Outbound_Car_ButtonClick(object sender, NavigatorButtonClickEventArgs e) //分页
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page < total_Page)
                {
                    now_Page++;
                    dataNavigator_package.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.YaohaoPac bs = new domain.YaohaoPac();
                    gridControl1.DataSource = fc.showData<domain.YaohaoPac>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page > 1)
                {
                    now_Page--;
                    dataNavigator_package.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.YaohaoPac bs = new domain.YaohaoPac();
                    gridControl1.DataSource = fc.showData<domain.YaohaoPac>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page = 1;
                    dataNavigator_package.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.YaohaoPac bs = new domain.YaohaoPac();
                    gridControl1.DataSource = fc.showData<domain.YaohaoPac>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page = total_Page;
                    dataNavigator_package.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.YaohaoPac bs = new domain.YaohaoPac();
                    gridControl1.DataSource = fc.showData<domain.YaohaoPac>(bs, now_Page.ToString());
                }
            }
        }

     
        private void dataNavigato1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {

        }
       

        //主表触发明细 fairy
        private void gridControl1_MouseClick(object sender, MouseEventArgs e)
        {
            hi = gridView1.CalcHitInfo(new Point(e.X, e.Y));
            //单击的是列头
            if (hi.InColumn)
            {
            }
            //单击数据行
            if (hi.InRow)
            {
                string colValue = this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, this.gridView1.Columns[0]).ToString();
                String package = "YaohaoPac";
                String detail = fc.FindDeteils(colValue, package);
                sd = JsonConvert.DeserializeObject<List<domain.Outbound_Car>>(detail);
                carDetailList = new BindingList<domain.Outbound_Car>(sd);
                if (sd.Count == 0)
                {
                    this.gridControl2.DataSource = carDetailList;
                    MessageBox.Show("没有详细数据，请输入！");
                    
                }
                else { 
                    this.gridControl2.DataSource = carDetailList;
                    this.gridView2.Columns[0].Caption = "派车单号";
                    this.gridView2.Columns[1].Visible = false;
                    this.gridView2.Columns[2].Caption = "货主单位";
                    this.gridView2.Columns[3].Caption = "仓库";
                    this.gridView2.Columns[4].Caption = "发货量";
                    this.gridView2.Columns[5].Visible = false;
                    this.gridView2.Columns[6].Caption = "业务部门";
                    this.gridView2.Columns[7].Caption = "业务经理";
                    this.gridView2.Columns[8].Visible = false;
                    this.gridView2.Columns[9].Visible = false;
                    this.gridView2.Columns[10].Visible = false;
                    this.gridView2.Columns[11].Visible = false;
                    this.gridView2.Columns[12].Visible = false;
                    this.gridView2.Columns[13].Visible = false;
                    this.gridView2.Columns[14].Caption = "卸货城市";
                    this.gridView2.Columns[15].Visible = false;
                    this.gridView2.Columns[16].Caption = "实际卸点";
                    this.gridView2.Columns[17].Visible = false;
                    this.gridView2.Columns[18].Visible = false;
                    this.gridView2.Columns[19].Visible = false;
                    this.gridView2.Columns[20].Visible = false;
                    this.gridView2.Columns[21].Visible = false;
                    this.gridView2.Columns[22].Visible = false;
                    this.gridView2.BestFitColumns();
                }
           
            }
        }


        //新建 fairy 2017-07-12
        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            New_Package np = new New_Package();
            np.ShowDialog();
            
        }


        //修改数据 fairy 2017-09-09
        private void toolStripButton2_Click(object sender, EventArgs e)
        {   
            if (gridView1.SelectedRowsCount > 0)// && gridView1.GetFocusedDataSourceRowIndex() >0
            {
                colCount = gridView1.Columns.Count();
                array = new string[colCount];
                for (int i = 0; i < colCount; i++)
                {
                    array[i] = gridView1.GetFocusedRowCellDisplayText(gridView1.Columns[i]);
                }
                if (array[0].Length > 0)
                {
                    isExist = true;
                    //如果选择的处理
                    New_Package yp = new New_Package();
                    yp.text_pacnum.Text = array[0];
                    yp.text_state.Text = array[1];
                    yp.text_num.Text =array[2];
                    yp.text_total.Text = array[3];
                    yp.text_pac_staff.Text = array[4];
                    yp.date_pac_time.DateTime = Convert.ToDateTime(array[5]);
                  
                    //明细表显示
                    str = array[0];
                    sd = JsonConvert.DeserializeObject<List<domain.Outbound_Car>>(fc.FindDeteils(str, "Outbound_Car"));
                    carDetailList = new BindingList<domain.Outbound_Car>(sd);
                    yp.gridControl1.DataSource = carDetailList;
                    yp.ShowDialog();
                    

                }
                else
                {
                    MessageBox.Show("请选中数据源再操作！");
                }

            }
        }
        


        public List<T> showDataDetail<T>(T t, string nowpage, string id)
        {
            List<T> bs = null;
            string msg = null;
            string sendMsg = t.GetType().Name.ToString();
           
                using (var ws = new WebSocket("ws://localhost:9000/ShowDatadetail"))
                {
                    ws.Connect();
                    ws.Send(sendMsg);
                    
                using (var wb = new WebSocket("ws://localhost:9000/GetId"))
                {
                    wb.Connect();
                    wb.Send(id);
                    wb.Close();
                }
                using (var wsp = new WebSocket("ws://localhost:9000/NowPage"))
                     {
                         wsp.Connect();
                         wsp.Send(nowpage);
                         wsp.Close();
                     }
                    while (msg == null)
                    {
                        ws.OnMessage += (sender, e) =>
                        msg = e.Data;

                    }
                    ws.Close();
              
                bs = JsonConvert.DeserializeObject<List<T>>(msg);
                   
                }
            return bs;
          }
        public List<T> showData<T>(T t, string nowpage)
        {
            List<T> bs = null;
            string msg = null;
            string sendMsg = t.GetType().Name.ToString();
            using (var ws = new WebSocket("ws://localhost:9000/ShowData"))
            {
                ws.Connect();
                ws.Send(sendMsg);
                using (var wsp = new WebSocket("ws://localhost:9000/NowPage"))
                {
                    wsp.Connect();
                    wsp.Send(nowpage);
                    wsp.Close();
                }
                while (msg == null)
                {
                    ws.OnMessage += (sender, e) =>
                    msg = e.Data;
                }
                ws.Close();
                bs = JsonConvert.DeserializeObject<List<T>>(msg);
                //   main_basic.gridControl2.DataSource = bs;
            }
            return bs;
        }




        private void gridControl2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        //模糊查询 fairy 2017-07-17
        private void label_like_search(object sender, EventArgs e)
        {
            //清空明细表数据
            gridControl2.DataSource = "";
            String input_val =  textBox1.Text;
            if (input_val.Equals(""))
            {
                MessageBox.Show("请输入查询关键字！");
            }
            else {
                gridControl1.DataSource = fc.showDataLike<domain.YaohaoPac>(yp, now_Page.ToString(),input_val);
            }
           

        }
    }
}
