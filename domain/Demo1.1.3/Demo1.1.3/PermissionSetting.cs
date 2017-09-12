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

namespace Demo1._1._3.Views.Jurisdictin
{
    public partial class PermissionSetting : Form
    {

        public static bool isExist = false;//执行修改操作时判断是否存在数据
        public static int colCount = 0;//所有列数
        public static string[] array;//数组中保存某行数据


        public long total_Page = 0; //页码总条目
        public long now_Page = 1; //当前页码
        private List<domain.权限.User> listuser = new List<domain.权限.User>();
        FunctionClass fc = new FunctionClass();
        FunctionForSign fcs = new FunctionForSign();
        public PermissionSetting()
        {
            InitializeComponent();

            total_Page = fc.getTotal<domain.权限.User>(new domain.权限.User(), total_Page);
            fc.InitPage(dataNavigator_Basic_Set, total_Page, now_Page);

            this.treeList2.ExpandAll();
            listuser = fc.showData(new domain.权限.User(), now_Page.ToString());
            gridControl2.DataSource = listuser;
            gridView2.Columns[0].Visible = false;
            gridView2.Columns[1].Caption = "姓名";
            gridView2.Columns[2].Caption = "密码";
            gridView2.Columns[3].Visible = false;
            gridView2.BestFitColumns();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) //添加用户
        {
            AddUsers addusers = new AddUsers();
            addusers.ShowDialog();
        }

        private void barLargeButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)//保存修改 将操作员列表全部保存
        {

        }

        private void barLargeButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) //分组管理
        {
            Demo1._1._3.Views.Permission.GroupManagement gm = new Permission.GroupManagement();
            gm.ShowDialog();
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) //点击行事件
        {
            int count = e.RowHandle;//获取行号
            

            domain.权限.Role role = new domain.权限.Role();
            role = listuser[count].Role[0];
          
            initTreeList(role.storage);
        }

        private void initTreeList(string Auth_Storage) //treelist设置
        {
            CheckState check = CheckState.Checked;
            if (Auth_Storage.Substring(0,1) == "1")
            {
                treeList2.SetNodeCheckState(treeList2.Nodes[0].FirstNode.FirstNode, check);
            }else
                treeList2.SetNodeCheckState(treeList2.Nodes[0].FirstNode.FirstNode, CheckState.Unchecked);
           
            if (Auth_Storage.Substring(1, 1) == "1")
            {
                treeList2.SetNodeCheckState(treeList2.Nodes[0].FirstNode.LastNode, check);
            }else
                treeList2.SetNodeCheckState(treeList2.Nodes[0].FirstNode.LastNode, CheckState.Unchecked);

            if (Auth_Storage.Substring(2, 1) == "1")
            {
                treeList2.SetNodeCheckState(treeList2.Nodes[0].LastNode.FirstNode, check);
            }else
                treeList2.SetNodeCheckState(treeList2.Nodes[0].LastNode.FirstNode, CheckState.Unchecked);

            if (Auth_Storage.Substring(3, 1) == "1")
            {
                treeList2.SetNodeCheckState(treeList2.Nodes[0].LastNode.LastNode, check);
            }else
                treeList2.SetNodeCheckState(treeList2.Nodes[0].LastNode.LastNode, CheckState.Unchecked);

            if (Auth_Storage.Substring(4, 1) == "1")
            {
                treeList2.SetNodeCheckState(treeList2.Nodes[0].FirstNode.NextNode.FirstNode, check);
            }else
                treeList2.SetNodeCheckState(treeList2.Nodes[0].FirstNode.NextNode.FirstNode, CheckState.Unchecked);

            if (Auth_Storage.Substring(5, 1) == "1")
            {
                treeList2.SetNodeCheckState(treeList2.Nodes[0].FirstNode.NextNode.LastNode, check);
            }else
                treeList2.SetNodeCheckState(treeList2.Nodes[0].FirstNode.NextNode.LastNode, CheckState.Unchecked);

        }

        private void treeList2_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        private void SetCheckedChildNodes(DevExpress.XtraTreeList.Nodes.TreeListNode node, CheckState check)
        {
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                node.Nodes[i].CheckState = check;
                SetCheckedChildNodes(node.Nodes[i], check);
            }
        }

        private void SetCheckedParentNodes(DevExpress.XtraTreeList.Nodes.TreeListNode node, CheckState check)
        {
            if (node.ParentNode != null)
            {
                bool b = false;
                CheckState state;
                for (int i = 0; i < node.ParentNode.Nodes.Count; i++)
                {
                    state = (CheckState)node.ParentNode.Nodes[i].CheckState;
                    if (!check.Equals(state))
                    {
                        b = !b;
                        break;
                    }
                }
                node.ParentNode.CheckState = b ? CheckState.Indeterminate : check;
                SetCheckedParentNodes(node.ParentNode, check);
            }
        }

        private void treeList2_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)//删除
        {
            if (MessageBox.Show("是否删除此消息？", "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                string ID = gridView2.GetRowCellDisplayText(gridView2.SelectedRowsCount + 1, gridView2.Columns[0]);
                gridView2.DeleteRow(gridView2.FocusedRowHandle);
                fcs.DeleteUser(ID);
            }         
        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) //刷新用户
        {
            gridControl2.DataSource = fc.showData(new domain.权限.User(), now_Page.ToString());
        }

        private void dataNavigator_Basic_Set_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            NavigatorButtonType btnType = (NavigatorButtonType)e.Button.ButtonType;
            if (e.Button is NavigatorCustomButton)
            {
                NavigatorCustomButton btn = (NavigatorCustomButton)e.Button;
                if (btn.Tag.ToString() == "下一页" && now_Page < total_Page)
                {
                    now_Page++;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.权限.User bs = new domain.权限.User();
                    gridControl2.DataSource = fc.showData<domain.权限.User > (bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "上一页" && now_Page > 1)
                {
                    now_Page--;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.权限.User bs = new domain.权限.User();
                    gridControl2.DataSource = fc.showData<domain.权限.User>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "首页")
                {
                    now_Page = 1;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.权限.User bs = new domain.权限.User();
                    gridControl2.DataSource = fc.showData<domain.权限.User>(bs, now_Page.ToString());
                }
                else if (btn.Tag.ToString() == "尾页")
                {
                    now_Page = total_Page;
                    dataNavigator_Basic_Set.TextStringFormat = string.Format("第 {0}页，共 {1}页", now_Page, total_Page);
                    domain.权限.User bs = new domain.权限.User();
                    gridControl2.DataSource = fc.showData<domain.权限.User>(bs, now_Page.ToString());
                }
            }
        }
    }
}
