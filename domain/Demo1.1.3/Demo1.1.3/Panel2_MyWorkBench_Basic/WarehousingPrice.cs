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
    public partial class WarehousingPrice : UserControl
    {
        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据


        public long total_Page_Staff = 0; //页码总条目
        public long now_Page_Staff = 1; //当前页码

        

        FunctionClass fc = new FunctionClass();

        public WarehousingPrice()
        {
            InitializeComponent();

            isEdit();
        }

        /// <summary>
        /// 判断是否可以编辑
        /// </summary>
        private void isEdit()
        {
            if (Sign_in.basic.Substring(22, 2) == "01")
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton7.Visible = false;
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
                    domain.External_Vehicle bs = new domain.External_Vehicle();
                    gridControl2.DataSource = fc.showData<domain.External_Vehicle>(bs, now_Page_Staff.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page_Staff > 1)
                {
                    now_Page_Staff--;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_Staff, total_Page_Staff);
                    domain.External_Vehicle bs = new domain.External_Vehicle();
                    gridControl2.DataSource = fc.showData<domain.External_Vehicle>(bs, now_Page_Staff.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page_Staff = 1;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_Staff, total_Page_Staff);
                    domain.External_Vehicle bs = new domain.External_Vehicle();
                    gridControl2.DataSource = fc.showData<domain.External_Vehicle>(bs, now_Page_Staff.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page_Staff = total_Page_Staff;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page_Staff, total_Page_Staff);
                    domain.External_Vehicle bs = new domain.External_Vehicle();
                    gridControl2.DataSource = fc.showData<domain.External_Vehicle>(bs, now_Page_Staff.ToString());
                }
            }
        }
    }
}
