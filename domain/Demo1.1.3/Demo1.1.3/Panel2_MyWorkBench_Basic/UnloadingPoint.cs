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
            up = new New_UnloadingPoint();
            up.ShowDialog();
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
                    up = new New_UnloadingPoint();
                    up.ShowDialog();
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
                    up = new New_UnloadingPoint();
                    up.ShowDialog();
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
                    up = new New_UnloadingPoint();
                    up.ShowDialog();
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
                fc.DeleteData(this.gridView2);
            }
            else if (tabPane1.SelectedPage == tabNavigationPage2)
            {
                fc.DeleteData(this.gridView3);
            }
            else if (tabPane1.SelectedPage == tabNavigationPage3)
            {
                fc.DeleteData(this.gridView4);
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
    }
}
