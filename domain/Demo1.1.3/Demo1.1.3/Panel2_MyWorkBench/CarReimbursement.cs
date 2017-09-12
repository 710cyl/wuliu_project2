using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using WebSocketSharp;
using Demo1._1._3.MyWorkBench_SkipForm;
using System.Text.RegularExpressions;
using System.Threading;

namespace Demo1._1._3.Panel2_MyWorkBench
{
    public partial class CarReimbursement : UserControl
    {
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据
        public static string str = null;
        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码
        private TabbedSections child_form = new TabbedSections();//车队界面

        domain.Car_Reimbursement tcm = new domain.Car_Reimbursement();
        FunctionClass fc = new FunctionClass();
        public CarReimbursement()
        {
            InitializeComponent();
            total_Page = fc.getTotal<domain.Car_Reimbursement>(tcm, total_Page);
            fc.InitPage(dataNavigator1, total_Page, now_Page);
            child_form.ReturnEvent += new TabbedSections.ClickCar(getCarValue);

            //设置下拉菜单
            comboBox_reimbursement_content.DisplayMember = "报销内容";
            comboBox_reimbursement_content.ValueMember = "value";
            comboBox_reimbursement_content.DataSource = fc.getRefundMode();

            isEdit();
        }

        /// <summary>
        /// 判断是否可以编辑
        /// </summary>
        private void isEdit()
        {
            if (Sign_in.transpotation.Substring(10, 2) == "01")
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton7.Visible = false;
            }
        }

        //实现委托方法
        void getCarValue(string a, string b, string c)
        {
            textBox_motorcade.Text = a;
            textBox_car_id.Text = b;
            textBox_driver.Text = c;
        }
        //查看
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            colCount = gridView2.Columns.Count();
            array = new string[colCount];
            for (int i = 0; i < colCount; i++)
            {
                array[i] = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[i]);
            }
            if (array[0].Length > 0)
            {
                try
                {
                    isExist = true;
                    panel1.Visible = true;
                    textBox_reimbursement_id.Text = array[0];
                    textBox_motorcade.Text = array[1];
                    textBox_car_id.Text = array[2];
                    textBox_driver.Text = array[3];
                    textBox_regist_man.Text = array[4];
                    //tcm.pay_man = textBox_pay_man.Text;
                    textBox_input_time.Text = array[6];
                    //tcm.pay_time = Convert.ToDateTime(textBox_pay_time.Text);
                    textBox_reimbursement_money.Text = array[8];
                    //tcm.is_payment = textBox_is_payment.Text;
                    //tcm.pay_account_id = textBox_pay_account_id.Text;
                    //tcm.pay_account = textBox_pay_account.Text;
                    comboBox_reimbursement_content.Text = array[12];
                    textBox_remark.Text = array[13];
                    textBox_FeeinChinese.Text = DaXie(array[8]);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("无法查看");
            }
        }
        //新建
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            isExist = false;
            panel1.Visible = true;
            textBox_reimbursement_id.Text = fc.DateTimeToUnix("CR");
            textBox_regist_man.Text = "裴哥";
            textBox_input_time.Text = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
        }
        //修改
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            colCount = gridView2.Columns.Count();
            array = new string[colCount];
            for (int i = 0; i < colCount; i++)
            {
                array[i] = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[i]);
            }
            if (array[0].Length > 0)
            {
                try
                {
                    isExist = true;
                    panel1.Visible = true;
                    textBox_reimbursement_id.Text = array[0];
                    textBox_motorcade.Text = array[1];
                    textBox_car_id.Text = array[2];
                    textBox_driver.Text = array[3];
                    textBox_regist_man.Text = array[4];
                    //tcm.pay_man = textBox_pay_man.Text;
                    textBox_input_time.Text = array[6];
                    //tcm.pay_time = Convert.ToDateTime(textBox_pay_time.Text);
                    textBox_reimbursement_money.Text = array[8];
                    //tcm.is_payment = textBox_is_payment.Text;
                    //tcm.pay_account_id = textBox_pay_account_id.Text;
                    //tcm.pay_account = textBox_pay_account.Text;
                    comboBox_reimbursement_content.Text = array[12];
                    textBox_remark.Text = array[13];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("该条数据不含主键，无法修改");
            }
        }
        //删除
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            fc.DeleteData(gridView2, "Car_Reimbursement");
        }
        //导入数据
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            string dataString = fc.getDataTable();

            if (dataString != null)
            {
                using (var ws = new WebSocket("ws://localhost:9000/BatchSave"))
                {
                    ws.Connect();
                    ws.Send(dataString);
                    using (var wss = new WebSocket("ws://localhost:9000/GetClassName/Main"))
                    {
                        wss.Connect();
                        wss.Send(tcm.GetType().Name);
                        wss.Close();
                    }
                    ws.Close();
                }
                MessageBox.Show("导入成功！！");
            }
        }
        //保存
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (isExist) //保存修改
            {
                tcm.reimbursement_id = textBox_reimbursement_id.Text;
                tcm.motorcade = textBox_motorcade.Text;
                tcm.car_id = textBox_car_id.Text;
                tcm.driver = textBox_driver.Text;
                tcm.regist_man = textBox_regist_man.Text;
                tcm.pay_man = "付款人";
                tcm.input_time = Convert.ToDateTime(textBox_input_time.Text);
                tcm.pay_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
                tcm.reimbursement_money = Convert.ToDecimal(textBox_reimbursement_money.Text);
                tcm.is_payment = "是";
                tcm.pay_account_id = "付款账户编号";
                tcm.pay_account = "付款账户";
                tcm.reimbursement_content = comboBox_reimbursement_content.Text;
                tcm.remark = textBox_remark.Text;


                fc.updateData(tcm, "Car_Reimbursement");

            }

            else   //保存
            {
                tcm.reimbursement_id = textBox_reimbursement_id.Text;
                tcm.motorcade = textBox_motorcade.Text;
                tcm.car_id = textBox_car_id.Text;
                tcm.driver = textBox_driver.Text;
                tcm.regist_man = textBox_regist_man.Text;
                tcm.pay_man = "付款人";
                tcm.input_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
                tcm.pay_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
                tcm.reimbursement_money = Convert.ToDecimal(textBox_reimbursement_money.Text);
                tcm.is_payment = "是";
                tcm.pay_account_id = "付款账户编号";
                tcm.pay_account = "付款账户";
                tcm.reimbursement_content = comboBox_reimbursement_content.Text;
                tcm.remark = textBox_remark.Text;


                fc.saveData(tcm, "Car_Reimbursement");
            }
            Thread.Sleep(500);
            gridView2.ClearGrouping();
            gridControl2.DataSource = fc.showData<domain.Car_Reimbursement>(tcm, now_Page.ToString());
            panel1.Visible = false;

        }
        //关闭
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
        //分页
        private void dataNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page < total_Page)
                {
                    now_Page++;
                    dataNavigator1.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Car_Reimbursement tcm = new domain.Car_Reimbursement();
                    gridControl2.DataSource = fc.showData<domain.Car_Reimbursement>(tcm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page > 1)
                {
                    now_Page--;
                    dataNavigator1.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Car_Reimbursement tcm = new domain.Car_Reimbursement();
                    gridControl2.DataSource = fc.showData<domain.Car_Reimbursement>(tcm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page = 1;
                    dataNavigator1.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Car_Reimbursement tcm = new domain.Car_Reimbursement();
                    gridControl2.DataSource = fc.showData<domain.Car_Reimbursement>(tcm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page = total_Page;
                    dataNavigator1.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Car_Reimbursement tcm = new domain.Car_Reimbursement();
                    gridControl2.DataSource = fc.showData<domain.Car_Reimbursement>(tcm, now_Page.ToString());
                }
            }
        }
        //单击车队事件
        private void textBox_motorcade_Click(object sender, EventArgs e)
        {
            child_form.ShowDialog();
        }
        //单击车号事件
        private void textBox_car_id_Click(object sender, EventArgs e)
        {
            child_form.ShowDialog();
        }
        //单击司机事件
        private void textBox_driver_Click(object sender, EventArgs e)
        {
            child_form.ShowDialog();
        }
        //金额大写转换
        private string DaXie(string money)
        {
            string s = double.Parse(money).ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");
            string d = Regex.Replace(s, @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[.]|$))))", "${b}${z}");
            return Regex.Replace(d, ".", delegate (Match m) { return "负圆空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟万億兆京垓秭穰"[m.Value[0] - '-'].ToString(); });
        }
    }
}
