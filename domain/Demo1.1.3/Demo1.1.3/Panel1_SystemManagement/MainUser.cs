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
    public partial class MainUser : UserControl
    {

        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据
        FunctionForSign fcs = new FunctionForSign();
        FunctionClass fc = new FunctionClass();
        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码
        public MainUser()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) //新建按钮
        {
            Demo1._1._3.Views.Jurisdictin.PermissionSetting ps = new Views.Jurisdictin.PermissionSetting();

            ps.ShowDialog();
        }

        private void toolStripButton4_Click(object sender, EventArgs e) //删除
        {
            if (MessageBox.Show("是否删除此消息？", "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                string ID = gridView1.GetRowCellDisplayText(gridView1.SelectedRowsCount + 1, gridView1.Columns[0]);
                fcs.DeleteUser(ID);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = fc.showData<domain.权限.User>(new domain.权限.User(), now_Page.ToString());
        }
    }
}
