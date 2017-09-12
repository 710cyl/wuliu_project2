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
    public partial class MainRole : UserControl
    {
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据


        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码
        FunctionForSign fcs = new FunctionForSign();
        FunctionClass fc = new FunctionClass();
        domain.权限.Role roles = new domain.权限.Role();
        public MainRole()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e) //删除
        {
            string ID = gridView1.GetRowCellDisplayText(gridView1.SelectedRowsCount + 1, gridView1.Columns[0]);
            gridView1.DeleteRow(gridView1.FocusedRowHandle);
            fcs.DeleteRole(ID);
        }

        private void toolStripButton1_Click(object sender, EventArgs e) //新建
        {
            Demo1._1._3.Views.Permission.GroupManagement gm = new Views.Permission.GroupManagement();
            gm.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e) //角色授权
        {
            Demo1._1._3.Views.Jurisdictin.PermissionSetting ps = new Views.Jurisdictin.PermissionSetting();
            ps.ShowDialog();
        }

        private void 刷新_Click(object sender, EventArgs e) //刷新
        {
            gridControl1.DataSource =fc.showData<domain.权限.Role>(roles, now_Page.ToString());
        }
    }
}
