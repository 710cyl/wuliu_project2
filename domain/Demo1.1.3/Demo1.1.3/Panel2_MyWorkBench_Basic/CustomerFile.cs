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

namespace Demo1._1._3.Panel2_Basic_UserControl
{
    public partial class CustomerFile : UserControl
    {
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据


        public long total_Page_Staff = 0; //页码总条目
        public long now_Page_Staff = 1; //当前页码

        domain.Customer_File cf = new domain.Customer_File();

        FunctionClass fc = new FunctionClass();

        public CustomerFile()
        {
            InitializeComponent();

            isEdit();

            total_Page_Staff = fc.getTotal<domain.Customer_File>(cf, total_Page_Staff);
            fc.InitPage(this.dataNavigator_Basic_Set, total_Page_Staff, now_Page_Staff);
        }


        /// <summary>
        /// 判断是否可以编辑
        /// </summary>
        private void isEdit()
        {
            if (Sign_in.basic.Substring(20, 2) == "01")
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton7.Visible = false;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e) //关闭
        {
            panel3.Visible = false;
            simpleButton4.Visible = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e) //新建
        {
            panel3.Visible = true;
            isExist = false;
            textBox9.Text = Sign_in.name;
            textBox7.Text = Sign_in.name;
        }

        private void toolStripButton2_Click(object sender, EventArgs e) //修改
        {
            panel3.Visible = true;
            isExist = true;

            colCount = gridView2.Columns.Count();
            array = new string[colCount];
            for (int i = 0; i < colCount; i++)
            {
                array[i] = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[i]);
            }
            if (array[0].Length > 0)
            {
                panel3.Visible = true;
                textBox17.Text = array[1];
                textBox19.Text = array[2];
                textBox2.Text = array[4];
                textBox5.Text = array[5];
                textBox4.Text = array[6];
                textBox6.Text = array[7];
                textBox3.Text = array[8];
                comboBox2.Text = array[9];
                comboBox3.Text = array[10];
                comboBox4.Text = array[11];
                comboBox5.Text = array[12];
                comboBox1.Text = array[13];
            }
            else
            {
                MessageBox.Show("该条数据不含主键，无法修改");
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e) //删除
        {
            fc.DeleteData(this.gridView2, "Customer_File");
        }

        private void toolStripButton6_Click(object sender, EventArgs e) //导出数据
        {
            string localFilePath = fc.ShowSaveFileDialog();

            if (localFilePath != null)
            {
                gridView2.Export(DevExpress.XtraPrinting.ExportTarget.Xls, localFilePath);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e) //查看
        {
            simpleButton4.Visible = false;
            colCount = gridView2.Columns.Count();
            array = new string[colCount];
            for (int i = 0; i < colCount; i++)
            {
                array[i] = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[i]);
            }
            if (array[0].Length > 0)
            {
                panel3.Visible = true;
                textBox17.Text = array[1];
                textBox19.Text = array[2];
                textBox2.Text = array[4];
                textBox5.Text = array[5];
                textBox4.Text = array[6];
                textBox6.Text = array[7];
                textBox3.Text = array[8];
                comboBox2.Text = array[9];
                comboBox3.Text = array[10];
                comboBox4.Text = array[11];
                comboBox5.Text = array[12];
                comboBox1.Text = array[13];
            }
            else
            {
                MessageBox.Show("该条数据不含主键，无法修改");
            }
        }

        private void dataNavigator_Basic_Set_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page_Staff < total_Page_Staff)
                {
                    now_Page_Staff++;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_Staff, total_Page_Staff);
                    domain.Customer_File bs = new domain.Customer_File();
                    gridControl2.DataSource = fc.showData<domain.Customer_File>(bs, now_Page_Staff.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page_Staff > 1)
                {
                    now_Page_Staff--;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_Staff, total_Page_Staff);
                    domain.Customer_File bs = new domain.Customer_File();
                    gridControl2.DataSource = fc.showData<domain.Customer_File>(bs, now_Page_Staff.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page_Staff = 1;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_Staff, total_Page_Staff);
                    domain.Customer_File bs = new domain.Customer_File();
                    gridControl2.DataSource = fc.showData<domain.Customer_File>(bs, now_Page_Staff.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page_Staff = total_Page_Staff;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_Staff, total_Page_Staff);
                    domain.Customer_File bs = new domain.Customer_File();
                    gridControl2.DataSource = fc.showData<domain.Customer_File>(bs, now_Page_Staff.ToString());
                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e) //保存
        {
            if (isExist == false)
            {
                domain.Customer_File cf = new domain.Customer_File();

                cf.customer_type1 = comboBox2.Text;
                cf.customer_type2 = comboBox3.Text;
                cf.customer_type3 = comboBox4.Text;
                cf.customer_type4 = comboBox5.Text;
                cf.customer_type5 = comboBox1.Text;
                cf.customer_fullname = textBox19.Text;
                cf.customer_name = textBox17.Text;
                cf.quick_code = textBox16.Text;
                cf.address = textBox2.Text;
                cf.duty_number = textBox4.Text;
                cf.bank_deposit = textBox5.Text;
                cf.linkman = textBox6.Text;
                cf.phone_number =Convert.ToInt32(textBox3.Text);
                fc.saveData(cf, "Customer_File");
            }
            else if (isExist == true)
            {
                domain.Customer_File cf = new domain.Customer_File();

                cf.ID =Convert.ToInt32(array[0]);
                cf.customer_type1 = comboBox2.Text;
                cf.customer_type2 = comboBox3.Text;
                cf.customer_type3 = comboBox4.Text;
                cf.customer_type4 = comboBox5.Text;
                cf.customer_type5 = comboBox1.Text;
                cf.customer_fullname = textBox19.Text;
                cf.customer_name = textBox17.Text;
                cf.quick_code = textBox16.Text;
                cf.address = textBox2.Text;
                cf.duty_number = textBox4.Text;
                cf.bank_deposit = textBox5.Text;
                cf.linkman = textBox6.Text;
                cf.phone_number = Convert.ToInt32(textBox3.Text);
                fc.updateData(cf, "Customer_File");
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e) //速查码
        {
            textBox16.Text = GetSpellCode(textBox17.Text);
        }

        /// <summary>
        /// 在指定的字符串列表CnStr中检索符合拼音索引字符串
        /// </summary>
        /// <param name="CnStr">汉字字符串</param>
        /// <returns>相对应的汉语拼音首字母串</returns>
        public static string GetSpellCode(string CnStr)
        {

            string strTemp = "";

            int iLen = CnStr.Length;

            int i = 0;

            for (i = 0; i <= iLen - 1; i++)
            {

                strTemp += GetCharSpellCode(CnStr.Substring(i, 1));

            }

            return strTemp;

        }

        /// <summary>
        /// 得到一个汉字的拼音第一个字母，如果是一个英文字母则直接返回大写字母
        /// </summary>
        /// <param name="CnChar">单个汉字</param>
        /// <returns>单个大写字母</returns>
        private static string GetCharSpellCode(string CnChar)
        {

            long iCnChar;

            byte[] ZW = System.Text.Encoding.Default.GetBytes(CnChar);

            //如果是字母，则直接返回

            if (ZW.Length == 1)
            {

                return CnChar.ToUpper();

            }

            else
            {

                // get the array of byte from the single char

                int i1 = (short)(ZW[0]);

                int i2 = (short)(ZW[1]);

                iCnChar = i1 * 256 + i2;

            }

            // iCnChar match the constant

            if ((iCnChar >= 45217) && (iCnChar <= 45252))
            {

                return "A";

            }

            else if ((iCnChar >= 45253) && (iCnChar <= 45760))
            {

                return "B";

            }
            else if ((iCnChar >= 45761) && (iCnChar <= 46317))
            {

                return "C";

            }
            else if ((iCnChar >= 46318) && (iCnChar <= 46825))
            {

                return "D";

            }
            else if ((iCnChar >= 46826) && (iCnChar <= 47009))
            {

                return "E";

            }
            else if ((iCnChar >= 47010) && (iCnChar <= 47296))
            {

                return "F";

            }
            else if ((iCnChar >= 47297) && (iCnChar <= 47613))
            {

                return "G";

            }
            else if ((iCnChar >= 47614) && (iCnChar <= 48118))
            {

                return "H";

            }
            else if ((iCnChar >= 48119) && (iCnChar <= 49061))
            {

                return "J";

            }
            else if ((iCnChar >= 49062) && (iCnChar <= 49323))
            {

                return "K";

            }
            else if ((iCnChar >= 49324) && (iCnChar <= 49895))
            {

                return "L";

            }
            else if ((iCnChar >= 49896) && (iCnChar <= 50370))
            {

                return "M";

            }
            else if ((iCnChar >= 50371) && (iCnChar <= 50613))
            {

                return "N";

            }
            else if ((iCnChar >= 50614) && (iCnChar <= 50621))
            {

                return "O";

            }
            else if ((iCnChar >= 50622) && (iCnChar <= 50905))
            {

                return "P";

            }
            else if ((iCnChar >= 50906) && (iCnChar <= 51386))
            {

                return "Q";

            }
            else if ((iCnChar >= 51387) && (iCnChar <= 51445))
            {

                return "R";

            }
            else if ((iCnChar >= 51446) && (iCnChar <= 52217))
            {

                return "S";

            }
            else if ((iCnChar >= 52218) && (iCnChar <= 52697))
            {

                return "T";

            }
            else if ((iCnChar >= 52698) && (iCnChar <= 52979))
            {

                return "W";

            }
            else if ((iCnChar >= 52980) && (iCnChar <= 53640))
            {

                return "X";

            }
            else if ((iCnChar >= 53689) && (iCnChar <= 54480))
            {

                return "Y";

            }
            else if ((iCnChar >= 54481) && (iCnChar <= 55289))
            {

                return "Z";

            }
            else

                return ("?");

        }
    }
}
