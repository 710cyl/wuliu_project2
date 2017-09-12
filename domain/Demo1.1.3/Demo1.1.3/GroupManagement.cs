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

namespace Demo1._1._3.Views.Permission
{
    public partial class GroupManagement : Form
    {
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据


        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码

        FunctionClass fc = new FunctionClass();
        FunctionForSign fcs = new FunctionForSign();
        public GroupManagement()
        {
            InitializeComponent();

            total_Page = fc.getTotal<domain.权限.Role>(new domain.权限.Role(), total_Page);
            fc.InitPage(dataNavigator_Basic_Set, total_Page, now_Page);


            gridControl1.DataSource = fc.showData(new domain.权限.Role(), now_Page.ToString());
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "角色名称";
            gridView1.Columns[2].Caption = "派车权限码";
            gridView1.Columns[3].Caption = "仓库权限码";
            gridView1.Columns[4].Caption = "运输权限码";
            gridView1.Columns[5].Caption = "基础权限码";
            gridView1.Columns[6].Visible = false;
            gridView1.BestFitColumns();
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.DataSource = fc.showData(new domain.权限.Role(), now_Page.ToString());
        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) //添加分组
        {
            AddRoles addrole = new AddRoles();
            addrole.ShowDialog();
        }

        private void barLargeButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) //删除分组
        {
            
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("是否删除此消息？", "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                string ID = gridView1.GetRowCellDisplayText(gridView1.SelectedRowsCount + 1, gridView1.Columns[0]);
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                fcs.DeleteRole(ID);
            }
        }

        private void dataNavigator_Basic_Set_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page < total_Page)
                {
                    now_Page++;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.权限.Role bs = new domain.权限.Role();
                    gridControl1.DataSource = fc.showData<domain.权限.Role>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page > 1)
                {
                    now_Page--;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.权限.Role bs = new domain.权限.Role();
                    gridControl1.DataSource = fc.showData<domain.权限.Role>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page = 1;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.权限.Role bs = new domain.权限.Role();
                    gridControl1.DataSource = fc.showData<domain.权限.Role>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page = total_Page;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.权限.Role bs = new domain.权限.Role();
                    gridControl1.DataSource = fc.showData<domain.权限.Role>(bs, now_Page.ToString());
                }
            }
        }
    }
}
