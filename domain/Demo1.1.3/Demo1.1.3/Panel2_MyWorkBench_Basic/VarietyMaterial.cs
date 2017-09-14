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
using System.Windows.Forms;

namespace Demo1._1._3
{
    public partial class VarietyMaterial : UserControl
    {
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据

        public long total_Page_vm = 0; //页码总条目
        public long now_Page_vm = 1; //当前页码
        domain.Variety_Texture vt = new Variety_Texture();
        FunctionClass fc = new FunctionClass();
        public VarietyMaterial()
        {
            InitializeComponent();
            total_Page_vm = fc.getTotal<domain.Variety_Texture>(vt, total_Page_vm);
            fc.InitPage(dataNavigator_variety, total_Page_vm, now_Page_vm);

            isEdit();
        }

        /// <summary>
        /// 判断是否可以编辑
        /// </summary>
        private void isEdit()
        {
            if (Sign_in.basic.Substring(6, 2) == "01")
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton7.Visible = false;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)//新建
        {
            isExist = false;
            panel3.Visible = true;
            textBox8.Text = DateTime.Now.ToString();
            textBox9.Text = Demo1._1._3.Sign_in.name;
            textBox11.Text = Demo1._1._3.Sign_in.name;
            textBox11.Enabled = false;
            textBox10.Enabled = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)//修改
        {
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
                textBox1.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[1]);
                textBox3.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[2]);
                textBox22.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[3]);
                textBox11.Enabled = false;
                textBox10.Text = DateTime.Now.ToString();
            }
            else
            {
                MessageBox.Show("该条数据不含主键，无法修改");
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)//删除
        {
            fc.DeleteData(this.gridView2, "Variety_Texture");
        }

        private void toolStripButton6_Click(object sender, EventArgs e)//导入数据
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

        private void 导出表单ToolStripMenuItem_Click(object sender, EventArgs e)//导出数据
        {
            string localFilePath = fc.ShowSaveFileDialog();

            if (localFilePath != null)
            {
                gridView2.Export(DevExpress.XtraPrinting.ExportTarget.Xls, localFilePath);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)//保存
        {
            if (isExist)
            {
                vt.ID = Convert.ToInt32(gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[0]));
                vt.variety = textBox1.Text;
                vt.texture = textBox3.Text;
                vt.statement = textBox22.Text;
                fc.updateData(vt, "Variety_Texture");
                MessageBox.Show("修改成功");
                panel3.Visible = false;
            }
            else
            {
                vt.variety = textBox1.Text;
                vt.texture = textBox3.Text;
                vt.statement = textBox22.Text;
                fc.saveData(vt, "Variety_Texture");
                MessageBox.Show("保存成功");
                panel3.Visible = false;
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)//关闭
        {
            panel3.Visible = false;
        }

        private void dataNavigator_variety_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page_vm < total_Page_vm)
                {
                    now_Page_vm++;
                    dataNavigator_variety.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_vm, total_Page_vm);
                    domain.TransportationRegister bs = new domain.TransportationRegister();
                    gridControl1.DataSource = fc.showData<domain.TransportationRegister>(bs, now_Page_vm.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page_vm > 1)
                {
                    now_Page_vm--;
                    dataNavigator_variety.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_vm, total_Page_vm);
                    domain.TransportationRegister bs = new domain.TransportationRegister();
                    gridControl1.DataSource = fc.showData<domain.TransportationRegister>(bs, now_Page_vm.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page_vm = 1;
                    dataNavigator_variety.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_vm, total_Page_vm);
                    domain.TransportationRegister bs = new domain.TransportationRegister();
                    gridControl1.DataSource = fc.showData<domain.TransportationRegister>(bs, now_Page_vm.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page_vm = total_Page_vm;
                    dataNavigator_variety.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_vm, total_Page_vm);
                    domain.TransportationRegister bs = new domain.TransportationRegister();
                    gridControl1.DataSource = fc.showData<domain.TransportationRegister>(bs, now_Page_vm.ToString());
                }
            }
        }
    }
}
