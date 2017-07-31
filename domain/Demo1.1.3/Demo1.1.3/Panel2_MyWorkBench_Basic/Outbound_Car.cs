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
    public partial class Outbound_Car : UserControl
    {
       
        StringReader streamToPrint = null;
        Font printFont;
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static int count = 0;//明细表所有列数
        public static string[] array = null;//

        public static BindingList<domain.Outbound_Car_Detail> carDetails;

        public  long total_Page = 0; //页码总条目
        public  long now_Page = 1; //当前页码
        domain.Outbound_Car bs = new domain.Outbound_Car();
        FunctionClass fc = new FunctionClass();
        private GridHitInfo hi; //点击列表事件
        private Outbound_Car main_outCar;
        private object JavaScriptConvert;
        public static List<domain.Outbound_Car_Detail> sd = new List<Outbound_Car_Detail>(); //得到明细表的list
       // private  BindingList<Outbound_Car_Detail> carDetailList;
        public static string str = null;

        public Outbound_Car()
        {
            InitializeComponent();
            
            total_Page = fc.getTotal<domain.Outbound_Car>(bs,total_Page);
            fc.InitPage(dataNavigator_Outbound_Car, total_Page,now_Page);
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e) //删除出库派车主表
        {
            fc.DeleteMain(this.gridView1, "OutBound_Car", "order_num");
            
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
                    dataNavigator_Outbound_Car.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Outbound_Car bs = new domain.Outbound_Car();
                    gridControl1.DataSource = fc.showData<domain.Outbound_Car>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page > 1)
                {
                    now_Page--;
                    dataNavigator_Outbound_Car.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Outbound_Car bs = new domain.Outbound_Car();
                    gridControl1.DataSource = fc.showData<domain.Outbound_Car>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page = 1;
                    dataNavigator_Outbound_Car.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Outbound_Car bs = new domain.Outbound_Car();
                    gridControl2.DataSource = fc.showData<domain.Outbound_Car>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page = total_Page;
                    dataNavigator_Outbound_Car.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Outbound_Car bs = new domain.Outbound_Car();
                    gridControl2.DataSource = fc.showData<domain.Outbound_Car>(bs, now_Page.ToString());
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
                MessageBox.Show(colValue);
                String carDetail = "Outbound_Car_Detail";
              
                String detail = fc.FindDeteils(colValue, carDetail);
                sd = JsonConvert.DeserializeObject<List<domain.Outbound_Car_Detail>>(detail);
                carDetails = new BindingList<Outbound_Car_Detail>(sd);
                if (carDetails.Count == 0)
                {
                    MessageBox.Show("没有明细数据，请补充！");
                    this.gridControl2.DataSource = "";
                }
                else {
                    this.gridControl2.DataSource = carDetails;
                   // this.gridView2.BestFitColumns();
                }
            }
        }


        //新建 fairy 2017-07-12
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            isExist = false;
            New_OutBound_Car nb = new New_OutBound_Car();
            nb.ShowDialog();
        }


        //修改数据 fairy 2017-07-12
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            isExist = true;
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
                  
                    //如果选择的处理
                    New_OutBound_Car nb = new New_OutBound_Car();
                    nb.textEdit2.Text = array[0];
                    nb.text_sendcar_num.Text = array[1];
                    nb.text_owner_unit.Text = array[2];
                    nb.text_warehouse_send.Text = array[3];
                    nb.text_deliver_quantity.Text = array[4].ToString();//发货量
                    nb.checkedComboBoxEdit3.Text = array[5];//客户自提
                    nb.text_oper_apart.Text = array[6];
                    nb.text_oper_staff.Text = array[7];
                    nb.text_pay_unit.Text = array[8];
                    nb.checkedComboBoxcars.Text = array[9];
                    nb.text_carnum.Text = array[10];
                    nb.text_driver.Text = array[11];
                    nb.text_sendcar_staff.Text = array[12];
                    //bs.sendcar_time = Convert.ToDateTime(date_sendcar_time.SelectedText.ToString());
                    nb.textEdit1.Text = array[14];
                    nb.text_unload_area.Text = array[15];
                    nb.text_unload_point.Text = array[16];
                    nb.checkedComboBoxpackge.SelectedText = array[17].ToString();//打包
                    nb.checkedComboBoxclose.SelectedText = array[18].ToString();
                    //bs.is_close = int.Parse(clo);
                    nb.text_close_staff.Text = array[19];
                    // bs.close_time = Convert.ToDateTime(date_close_time.SelectedText.ToString());
                    nb.text_explain.Text = array[21];

                    //明细表显示
                    str = array[0];
                    sd = JsonConvert.DeserializeObject<List<domain.Outbound_Car_Detail>>(fc.FindDeteils(str, "Outbound_Car_Detail"));
                    carDetails = new BindingList<domain.Outbound_Car_Detail>(sd);
                    nb.gridControl1.DataSource = carDetails;
                    nb.ShowDialog();
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
                gridControl1.DataSource = fc.showDataLike<domain.Outbound_Car>(bs, now_Page.ToString(),input_val);
            }
           

        }
    }
}
