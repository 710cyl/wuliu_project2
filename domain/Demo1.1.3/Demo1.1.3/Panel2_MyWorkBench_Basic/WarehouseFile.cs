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

namespace Demo1._1._3
{
    public partial class WarehouseFile : UserControl
    {

        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据


        public long total_Page_Staff = 0; //页码总条目
        public long now_Page_Staff = 1; //当前页码

        public long total_Page_Space = 0; //页码总条目
        public long now_Page_Space = 1; //当前页码
        domain.Warehouse_Space ws = new domain.Warehouse_Space();
        domain.Warehouse_Staff wst = new domain.Warehouse_Staff();
        FunctionClass fc = new FunctionClass();

        public WarehouseFile()
        {
            InitializeComponent();

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Value = DateTime.Now; 
            dateTimePicker4.Value = DateTime.Now;

            total_Page_Staff = fc.getTotal<domain.Warehouse_Staff>(wst, total_Page_Staff);
            fc.InitPage(this.dataNavigator_Basic_Set, total_Page_Staff, now_Page_Staff);

            total_Page_Space = fc.getTotal<domain.Warehouse_Space>(ws, total_Page_Space);
            fc.InitPage(this.dataNavigator1, total_Page_Space, now_Page_Space);
            isEdit();
        }

        private void dataNavigator2_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 判断是否可以编辑
        /// </summary>
        private void isEdit()
        {
            if (Sign_in.basic.Substring(10, 2) == "01")
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton7.Visible = false;
            }
        }
        #region
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
                    domain.Warehouse_Staff bs = new domain.Warehouse_Staff();
                    gridControl2.DataSource = fc.showData<domain.Warehouse_Staff>(bs, now_Page_Staff.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page_Staff > 1)
                {
                    now_Page_Staff--;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_Staff, total_Page_Staff);
                    domain.Warehouse_Staff bs = new domain.Warehouse_Staff();
                    gridControl2.DataSource = fc.showData<domain.Warehouse_Staff>(bs, now_Page_Staff.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page_Staff = 1;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_Staff, total_Page_Staff);
                    domain.Warehouse_Staff bs = new domain.Warehouse_Staff();
                    gridControl2.DataSource = fc.showData<domain.Warehouse_Staff>(bs, now_Page_Staff.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page_Staff = total_Page_Staff;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_Staff, total_Page_Staff);
                    domain.Warehouse_Staff bs = new domain.Warehouse_Staff();
                    gridControl2.DataSource = fc.showData<domain.Warehouse_Staff>(bs, now_Page_Staff.ToString());
                }
            }
        }

        private void dataNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page_Space < total_Page_Space)
                {
                    now_Page_Space++;
                    dataNavigator1.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_Space, total_Page_Space);
                    domain.Warehouse_Space bs = new domain.Warehouse_Space();
                    gridControl3.DataSource = fc.showData<domain.Warehouse_Space>(bs, now_Page_Space.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page_Space > 1)
                {
                    now_Page_Space--;
                    dataNavigator1.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_Space, total_Page_Space);
                    domain.Warehouse_Space bs = new domain.Warehouse_Space();
                    gridControl3.DataSource = fc.showData<domain.Warehouse_Space>(bs, now_Page_Space.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page_Space = 1;
                    dataNavigator1.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_Space, total_Page_Space);
                    domain.Warehouse_Space bs = new domain.Warehouse_Space();
                    gridControl3.DataSource = fc.showData<domain.Warehouse_Space>(bs, now_Page_Space.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page_Space = total_Page_Space;
                    dataNavigator1.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_Space, total_Page_Space);
                    domain.Warehouse_Space bs = new domain.Warehouse_Space();
                    gridControl3.DataSource = fc.showData<domain.Warehouse_Space>(bs, now_Page_Space.ToString());
                }
            }
        }
        #endregion
        private void toolStripButton1_Click(object sender, EventArgs e) //新建
        {
            isExist = false;
            if (tabPane1.SelectedPage == tabNavigationPage1)
            {
                panel3.Visible = true;
                textBox9.Text = Sign_in.name;
                textBox11.Text = Sign_in.name;

            }
            else if (tabPane1.SelectedPage == tabNavigationPage2)
            {
                panel2.Visible = true;
                textBox4.Text = Sign_in.name;
                textBox6.Text = Sign_in.name;
            }  
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            simpleButton4.Visible = true ;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            simpleButton2.Visible = true;
        }

        private void simpleButton4_Click(object sender, EventArgs e) //仓库人员保存
        {
            if (isExist == false)
            {
                Warehouse_Staff wsf = new Warehouse_Staff();
                wsf.inventory_keeper = textBox1.Text;
                wsf.loader = textBox21.Text;
                wsf.other = textBox22.Text;
                wsf.statement = textBox20.Text;
                wsf.crane = textBox3.Text;
                fc.saveData(wsf, "Warehouse_Staff");
            }
            else if (isExist == true)
            {
                Warehouse_Staff wsf = new Warehouse_Staff();
                wsf.ID =Convert.ToInt32(array[0]);
                wsf.inventory_keeper = textBox1.Text;
                wsf.loader = textBox21.Text;
                wsf.other = textBox22.Text;
                wsf.statement = textBox20.Text;
                wsf.crane = textBox3.Text;
                fc.updateData(wsf, "Warehouse_Staff");

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e) //仓库货位保存
        {
            if (isExist == false)
            {
                domain.Warehouse_Space ws = new domain.Warehouse_Space();
                ws.storage = textBox12.Text;
                ws.crib_number = textBox7.Text;
                ws.statement = textBox13.Text;
                fc.saveData(ws, "Warehouse_Space");
            }
            else if(isExist == true)
            {
                domain.Warehouse_Space ws = new domain.Warehouse_Space();
                ws.ID = Convert.ToInt32(array[0]);
                ws.storage = textBox12.Text;
                ws.crib_number = textBox7.Text;
                ws.statement = textBox13.Text;
                fc.updateData(ws, "Warehouse_Space");

            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e) //删除
        {
            if (tabPane1.SelectedPage == tabNavigationPage1)
            {
                fc.DeleteData(this.gridView2, "Warehouse_Staff");
            }
            else if (tabPane1.SelectedPage == tabNavigationPage2)
            {
                fc.DeleteData(this.gridView3, "Warehouse_Space");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e) //修改
        {
            isExist = true;
            if (tabPane1.SelectedPage == tabNavigationPage1)
            {
                colCount = gridView2.Columns.Count();
                array = new string[colCount];
                for (int i = 0; i < colCount; i++)
                {
                    array[i] = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[i]);
                }
                if (array[0].Length > 0)
                {
                    panel3.Visible = true;
                    textBox1.Text = array[1];
                    textBox3.Text = array[2];
                    textBox21.Text = array[3];
                    textBox22.Text = array[4];
                    textBox20.Text = array[5];
                }
                else
                {
                    MessageBox.Show("该条数据不含主键，无法修改");
                }
            }
            else if (tabPane1.SelectedPage == tabNavigationPage2)
            {
                colCount = gridView3.Columns.Count();
                array = new string[colCount];
                for (int i = 0; i < colCount; i++)
                {
                    array[i] = gridView3.GetFocusedRowCellDisplayText(gridView3.Columns[i]);
                }
                if (array[0].Length > 0)
                {
                    panel2.Visible = true;
                    textBox12.Text = array[1];
                    textBox7.Text = array[2];
                    textBox13.Text = array[3];
                }
                else
                {
                    MessageBox.Show("该条数据不含主键，无法修改");
                }
            }

        }

        private void toolStripButton6_Click(object sender, EventArgs e) //导出数据
        {
            if (tabPane1.SelectedPage == tabNavigationPage1)
            {
                string localFilePath = fc.ShowSaveFileDialog();

                if (localFilePath != null)
                {
                    gridView2.Export(DevExpress.XtraPrinting.ExportTarget.Xls, localFilePath);
                }
            }
            else if (tabPane1.SelectedPage == tabNavigationPage2)
            {
                string localFilePath = fc.ShowSaveFileDialog();

                if (localFilePath != null)
                {
                    gridView3.Export(DevExpress.XtraPrinting.ExportTarget.Xls, localFilePath);
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e) //查看
        {
            if (tabPane1.SelectedPage == tabNavigationPage1)
            {
                colCount = gridView2.Columns.Count();
                array = new string[colCount];
                for (int i = 0; i < colCount; i++)
                {
                    array[i] = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[i]);
                }
                if (array[0].Length > 0)
                {
                    panel3.Visible = true;
                    textBox1.Text = array[1];
                    textBox3.Text = array[2];
                    textBox21.Text = array[3];
                    textBox22.Text = array[4];
                    textBox20.Text = array[5];

                    simpleButton4.Visible = false;
                }
                else
                {
                    MessageBox.Show("该条数据不含主键，无法修改");
                }
            }
            else if (tabPane1.SelectedPage == tabNavigationPage2)
            {
                colCount = gridView3.Columns.Count();
                array = new string[colCount];
                for (int i = 0; i < colCount; i++)
                {
                    array[i] = gridView3.GetFocusedRowCellDisplayText(gridView3.Columns[i]);
                }
                if (array[0].Length > 0)
                {
                    panel2.Visible = true;
                    textBox12.Text = array[1];
                    textBox7.Text = array[2];
                    textBox13.Text = array[3];

                    simpleButton2.Visible = false;
                }
                else
                {
                    MessageBox.Show("该条数据不含主键，无法修改");
                }
            }
        }
    }
}
