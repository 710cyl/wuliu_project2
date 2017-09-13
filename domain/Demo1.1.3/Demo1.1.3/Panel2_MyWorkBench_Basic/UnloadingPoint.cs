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
    public partial class UnloadingPoint : UserControl 
    {
        New_UnloadingPoint up;
        StringReader streamToPrint = null;
        Font printFont;
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据


        public long total_Page_Dec = 0; //页码总条目
        public long now_Page_Dec = 1; //当前页码

        public long total_Page_Dis = 0; //页码总条目
        public long now_Page_Dis = 1; //当前页码

        public long total_Page_Trans = 0; //页码总条目
        public long now_Page_Trans = 1; //当前页码
        domain.Decorate dec = new Decorate();
        domain.Discharge dis = new Discharge();
        domain.Transportations tran = new Transportations();
        FunctionClass fc = new FunctionClass();

        public UnloadingPoint()
        {
            InitializeComponent();
            total_Page_Dec = fc.getTotal<domain.Decorate>(dec, total_Page_Dec);
            fc.InitPage(dataNavigator_decorate, total_Page_Dec, now_Page_Dec);

            total_Page_Dis = fc.getTotal<domain.Discharge>(dis, total_Page_Dis);
            fc.InitPage(dataNavigator_discharge, total_Page_Dis, now_Page_Dis);

            total_Page_Trans = fc.getTotal<domain.Transportations>(tran, total_Page_Trans);
            fc.InitPage(dataNavigator_transp, total_Page_Trans, now_Page_Trans);

            isEdit();
        }

        /// <summary>
        /// 判断是否可以编辑
        /// </summary>
        private void isEdit()
        {
            if (Sign_in.basic.Substring(4, 2) == "01")
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton7.Visible = false;
            }
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

        private void toolStripButton1_Click(object sender, EventArgs e) //新建
        {
            isExist = false;
            //up = new New_UnloadingPoint();
            //up.ShowDialog();
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            textBox2.Text = DateTime.Now.ToString();
            textBox8.Text = DateTime.Now.ToString();
            textBox25.Text = DateTime.Now.ToString();
            textBox6.Enabled = false;
            textBox5.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox28.Enabled = false;
            textBox27.Enabled = false;
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e) //修改
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
                    isExist = true;
                    panel3.Visible = true;
                    textBox1.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[1]);
                    textBox3.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[2]);
                    textBox21.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[4]);
                    textBox20.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[5]);
                    textBox19.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[6]);
                    textBox22.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[3]);
                    textBox18.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[7]);
                    textBox11.Enabled = false;
                    textBox10.Text = DateTime.Now.ToString();
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
                    isExist = true;
                    panel2.Visible = true;
                    textBox12.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[1]);
                    textBox7.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[2]);
                    textBox24.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[3]);
                    textBox23.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[4]);
                    textBox16.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[5]);
                    textBox15.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[6]);
                    textBox14.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[7]);
                    textBox6.Enabled = false;
                    textBox5.Text = DateTime.Now.ToString();

                }
                else
                {
                    MessageBox.Show("该条数据不含主键，无法修改");
                }
            }
            else if (tabPane1.SelectedPage == tabNavigationPage3)
            {
                colCount = gridView4.Columns.Count();
                array = new string[colCount];
                for (int i = 0; i < colCount; i++)
                {
                    array[i] = gridView4.GetFocusedRowCellDisplayText(gridView4.Columns[i]);
                }
                if (array[0].Length > 0)
                {
                    isExist = true;
                    panel4.Visible = true;
                    textBox30.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[1]);
                    textBox29.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[2]);
                    textBox36.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[3]);
                    textBox35.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[4]);
                    textBox34.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[5]);
                    textBox33.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[6]);
                    textBox32.Text = gridView2.GetFocusedRowCellDisplayText(gridView2.Columns[7]);
                    textBox28.Enabled = false;
                    textBox27.Text = DateTime.Now.ToString();

                }
                else
                {
                    MessageBox.Show("该条数据不含主键，无法修改");
                }
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e) //删除
        {
            if (tabPane1.SelectedPage == tabNavigationPage1)
            {
                fc.DeleteData(this.gridView2, "Discharge");
            }
            else if (tabPane1.SelectedPage == tabNavigationPage2)
            {
                fc.DeleteData(this.gridView3, "Decorate");
            }
            else if (tabPane1.SelectedPage == tabNavigationPage3)
            {
                fc.DeleteData(this.gridView4, "Transportations");
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e) //导出数据
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
            else if (tabPane1.SelectedPage == tabNavigationPage3)
            {
                string localFilePath = fc.ShowSaveFileDialog();

                if (localFilePath != null)
                {
                    gridView4.Export(DevExpress.XtraPrinting.ExportTarget.Xls, localFilePath);
                }
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)//卸点保存
        {
            if(isExist)
            {
                dis.discharge_place = textBox1.Text;
                dis.city = textBox3.Text;
                dis.adress = textBox32.Text;
                dis.linkman = textBox34.Text;
                dis.phone_number = textBox33.Text;
                dis.region = textBox22.Text;
                dis.statement = textBox21.Text;
                fc.updateData(dis, "Discharge");
            }
            else
            {
                dis.discharge_place = textBox1.Text;
                dis.city = textBox3.Text;
                dis.adress = textBox32.Text;
                dis.linkman = textBox34.Text;
                dis.phone_number = textBox33.Text;
                dis.region = textBox22.Text;
                dis.statement = textBox21.Text;
                fc.saveData(dis, "Discharge");
            }
       
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)//装点保存
        {
            if (isExist)
            {
                dec.decorate_place = textBox12.Text;
                dec.city = textBox7.Text;
                dec.adress = textBox14.Text;
                dec.linkman = textBox16.Text;
                dec.phone_number = textBox15.Text;
                dec.region = textBox24.Text;
                dec.statement = textBox23.Text;
                fc.updateData(dec, "Decorate");
            }
            else
            {
                dec.decorate_place = textBox12.Text;
                dec.city = textBox7.Text;
                dec.adress = textBox14.Text;
                dec.linkman = textBox16.Text;
                dec.phone_number = textBox15.Text;
                dec.region = textBox24.Text;
                dec.statement = textBox23.Text;
                fc.saveData(dec, "Decorate");
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

        private void simpleButton6_Click(object sender, EventArgs e)//集运保存
        {
            if (isExist)
            {
                tran.transportation_place = textBox30.Text;
                tran.city = textBox29.Text;
                tran.region = textBox36.Text;
                tran.statement = textBox35.Text;
                tran.linkman = textBox34.Text;
                tran.phone_number = textBox33.Text;
                tran.adress = textBox32.Text;
                fc.updateData(tran, "Transportations");
            }
            else
            {
                tran.transportation_place = textBox30.Text;
                tran.city = textBox29.Text;
                tran.region = textBox36.Text;
                tran.statement = textBox35.Text;
                tran.linkman = textBox34.Text;
                tran.phone_number = textBox33.Text;
                tran.adress = textBox32.Text;
                fc.saveData(tran, "Transportations");
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }

    }
}
