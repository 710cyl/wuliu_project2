﻿using System;
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
    public partial class Internal_Fleet : UserControl
    {

        New_InternalFleet ni;
        StringReader streamToPrint = null;
        Font printFont;
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据


        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码
        domain.Internal_Vehicle iv = new Internal_Vehicle();
        FunctionClass fc = new FunctionClass();

        public Internal_Fleet()
        {
            InitializeComponent();
            total_Page = fc.getTotal<domain.Internal_Vehicle>(iv, total_Page);
            fc.InitPage(dataNavigator_InternalFleet, total_Page, now_Page);

            isEdit();
        }

        /// <summary>
        /// 判断是否可以编辑
        /// </summary>
        private void isEdit()
        {
            if (Sign_in.basic.Substring(2, 2) == "01")
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton7.Visible = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e) //新建
        {
            panel3.Visible = true;
            isExist = false;
            textBox9.Text = Sign_in.name;
            textBox11.Text = Sign_in.name;
        }

        private void toolStripButton2_Click(object sender, EventArgs e) //修改
        {
            isExist = true;
            colCount = gridView2.Columns.Count();
            array = new string[colCount];
            for (int i = 0; i < colCount; i++)
            {
                array[i] = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[i]);
            }
            if (array[0].Length > 0)
            {
                isExist = true;
                panel3.Visible = true;
                textBox1.Text = array[1];
                textBox3.Text = array[2];
                textBox22.Text = array[3];
                textBox20.Text = array[4];
            }
            else
            {
                MessageBox.Show("该条数据不含主键，无法修改");
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e) //删除
        {
            fc.DeleteData(this.gridView2, "Internal_Vehicle");
        }

        private void toolStripButton6_Click(object sender, EventArgs e) //导入数据
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

        private void toolStripButton3_Click(object sender, EventArgs e) //导出数据
        {
            string localFilePath = fc.ShowSaveFileDialog();

            if (localFilePath != null)
            {
                gridView2.Export(DevExpress.XtraPrinting.ExportTarget.Xls, localFilePath);
            }
        }

        private void dataNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page < total_Page)
                {
                    now_Page++;
                    dataNavigator_InternalFleet.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Internal_Vehicle bs = new domain.Internal_Vehicle();
                    gridControl2.DataSource = fc.showData<domain.Internal_Vehicle>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page > 1)
                {
                    now_Page--;
                    dataNavigator_InternalFleet.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Internal_Vehicle bs = new domain.Internal_Vehicle();
                    gridControl2.DataSource = fc.showData<domain.Internal_Vehicle>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page = 1;
                    dataNavigator_InternalFleet.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Internal_Vehicle bs = new domain.Internal_Vehicle();
                    gridControl2.DataSource = fc.showData<domain.Internal_Vehicle>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page = total_Page;
                    dataNavigator_InternalFleet.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.Internal_Vehicle bs = new domain.Internal_Vehicle();
                    gridControl2.DataSource = fc.showData<domain.Internal_Vehicle>(bs, now_Page.ToString());
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e) //关闭
        {
            panel3.Visible = false;
            simpleButton4.Visible = true;
        }

        private void simpleButton4_Click(object sender, EventArgs e) //保存
        {
            if (isExist == false)
            {
                domain.Internal_Vehicle iv = new Internal_Vehicle();
                iv.motorcade = textBox1.Text;
                iv.car_number = textBox3.Text;
                iv.car_driver = textBox22.Text;
                iv.statement = textBox20.Text;
                fc.saveData(iv, "Internal_Vehicle");
            }
            else if (isExist == true)
            {
                domain.Internal_Vehicle iv = new Internal_Vehicle();
                iv.ID = Convert.ToInt32(array[0]);
                iv.motorcade = textBox1.Text;
                iv.car_number = textBox3.Text;
                iv.car_driver = textBox22.Text;
                iv.statement = textBox20.Text;
                fc.updateData(iv, "Internal_Vehicle");
            }
        }
    }
}
