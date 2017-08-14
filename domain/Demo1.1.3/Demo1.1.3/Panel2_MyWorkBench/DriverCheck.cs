using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WebSocketSharp;
using DevExpress.XtraEditors;

namespace Demo1._1._3.Panel2_MyWorkBench
{

    public partial class DriverCheck : UserControl
    {
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据
        public static string str = null;
        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码

        domain.Driver_Check tcm = new domain.Driver_Check();
        FunctionClass fc = new FunctionClass();

        public DriverCheck()
        {
            InitializeComponent();
        }
        //查看
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (isExist)
            {
                panel1.Visible = true;
                textBox_check_id.Text = array[0];
                textBox_check_type.Text = array[1];
                textBox_check_month.Text = array[2];
                comboBox_motorcade.Text = array[3];
                textBox_car_id.Text = array[4];
                textBox_driver.Text = array[5];
                textBox_check_money.Text = array[6];
                textBox_salary_money.Text = array[7];
                comboBox_check_herald.Text = array[8];
                textBox_input_man.Text = array[9];
                textBox_input_time.Text = array[10];
                textBox_check_reason.Text = array[11];
                textBox_bookkeeping_time.Text = array[12];
            }
        }
        //新建
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            isExist = false;
            panel1.Visible = true;
        }
        //修改
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            colCount = gridView2.Columns.Count() - 1;
            array = new string[colCount + 1];
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
                    textBox_check_id.Text = array[0];
                    textBox_check_type.Text = array[1];
                    textBox_check_month.Text = array[2];
                    comboBox_motorcade.Text = array[3];
                    textBox_car_id.Text = array[4];
                    textBox_driver.Text = array[5];
                    textBox_check_money.Text = array[6];
                    textBox_salary_money.Text = array[7];
                    comboBox_check_herald.Text = array[8];
                    textBox_input_man.Text = array[9];
                    textBox_input_time.Text = array[10];
                    textBox_check_reason.Text = array[11];
                    textBox_bookkeeping_time.Text = array[12];
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
            fc.DeleteData(gridView2, "Driver_Check");
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
                tcm.check_id = textBox_check_id.Text;
                tcm.check_type = textBox_check_type.Text;
                tcm.check_month = textBox_check_month.Text;
                tcm.motorcade = comboBox_motorcade.Text;
                tcm.car_id = textBox_car_id.Text;
                tcm.driver = textBox_driver.Text;
                tcm.check_money = Convert.ToDecimal(textBox_check_money.Text);
                tcm.salary_money = Convert.ToDecimal(textBox_salary_money.Text);
                tcm.check_herald = comboBox_check_herald.Text;
                tcm.input_man = textBox_input_man.Text;
                tcm.input_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
                tcm.check_reason = textBox_check_reason.Text;
                tcm.bookkeeping_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));

                fc.updateData(tcm, "Driver_Check");
            }

            else   //保存
            {
                tcm.check_id = textBox_check_id.Text;
                tcm.check_type = textBox_check_type.Text;
                tcm.check_month = textBox_check_month.Text;
                tcm.motorcade = comboBox_motorcade.Text;
                tcm.car_id = textBox_car_id.Text;
                tcm.driver = textBox_driver.Text;
                tcm.check_money = Convert.ToDecimal(textBox_check_money.Text);
                tcm.salary_money = Convert.ToDecimal(textBox_salary_money.Text);
                tcm.check_herald = comboBox_check_herald.Text;
                tcm.input_man = textBox_input_man.Text;
                tcm.input_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
                tcm.check_reason = textBox_check_reason.Text;
                tcm.bookkeeping_time = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
                isExist = true;
                fc.saveData(tcm, "Driver_Check");
            }

            panel1.Visible = false;
            Refresh();
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
                    domain.Driver_Check tcm = new domain.Driver_Check();
                    gridControl2.DataSource = fc.showData<domain.Driver_Check>(tcm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page > 1)
                {
                    now_Page--;
                    dataNavigator1.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Driver_Check tcm = new domain.Driver_Check();
                    gridControl2.DataSource = fc.showData<domain.Driver_Check>(tcm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page = 1;
                    dataNavigator1.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Driver_Check tcm = new domain.Driver_Check();
                    gridControl2.DataSource = fc.showData<domain.Driver_Check>(tcm, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page = total_Page;
                    dataNavigator1.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Driver_Check tcm = new domain.Driver_Check();
                    gridControl2.DataSource = fc.showData<domain.Driver_Check>(tcm, now_Page.ToString());
                }
            }
        }
    }
}
