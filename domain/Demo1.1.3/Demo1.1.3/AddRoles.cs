using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Demo1._1._3
{
    public partial class AddRoles : Form
    {
        FunctionForSign fcs = new FunctionForSign();

        public AddRoles()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e) //保存
        {
            domain.权限.Role role= new domain.权限.Role();
            role.rolename = textEdit1.Text;
            role.sendcar = SenderCar_Auth();
            role.storage = Storage_Auth();
            role.transpotation = Transpotation_Auth();
            role.basic = Basic_Auth();
           // MessageBox.Show(Storage_Auth());
            //MessageBox.Show(SenderCar_Auth());
            fcs.saveRole(role);

            Thread.Sleep(200);
            Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e) //取消
        {
            Close();
        }

        private string Storage_Auth() //权限视图
        {
            string storage  = "000000";
            char[] cc = storage.ToCharArray();

            #region  仓库
            if (this.treeList1.Nodes[0].FirstNode.CheckState  == CheckState.Checked)
            {
                cc[0] =Convert.ToChar("1");
            }else
                cc[0] = Convert.ToChar("0");
            if (this.treeList1.Nodes[0].LastNode.CheckState == CheckState.Checked)
            {
                cc[1] = Convert.ToChar("1");
            }else
                cc[1] = Convert.ToChar("0");
            if (this.treeList1.Nodes[1].FirstNode.CheckState == CheckState.Checked)
            {
                cc[2] = Convert.ToChar("1");
            }else
                cc[2] = Convert.ToChar("0");
            if (this.treeList1.Nodes[1].LastNode.CheckState == CheckState.Checked)
            {
                cc[3] = Convert.ToChar("1");
            }else
                cc[3] = Convert.ToChar("0");
            if (this.treeList1.Nodes[2].FirstNode.CheckState == CheckState.Checked)
            {
                cc[4] = Convert.ToChar("1");
            }else
                cc[4] = Convert.ToChar("0");
            if (this.treeList1.Nodes[2].LastNode.CheckState == CheckState.Checked)
            {
                cc[5] = Convert.ToChar("1");
            }else
                cc[5] = Convert.ToChar("0");
            #endregion
            string storage_Auth = new string(cc);
            return storage_Auth;
        }

        private string SenderCar_Auth()
        {
            string sendcar = "00000000";
            char[] dd = sendcar.ToCharArray();
            #region 派车
            if (this.treeList1.Nodes[3].FirstNode.CheckState == CheckState.Checked)
            {
                dd[0] = Convert.ToChar("1");
            }
            else
                dd[0] = Convert.ToChar("0");

            if (this.treeList1.Nodes[3].LastNode.CheckState == CheckState.Checked)
            {
                dd[1] = Convert.ToChar("1");
            }
            else
                dd[1] = Convert.ToChar("0");

            if (this.treeList1.Nodes[4].FirstNode.CheckState == CheckState.Checked)
            {
                dd[2] = Convert.ToChar("1");
            }
            else
                dd[2] = Convert.ToChar("0");

            if (this.treeList1.Nodes[4].LastNode.CheckState == CheckState.Checked)
            {
                dd[3] = Convert.ToChar("1");
            }
            else
                dd[3] = Convert.ToChar("0");

            if (this.treeList1.Nodes[5].FirstNode.CheckState == CheckState.Checked)
            {
                dd[4] = Convert.ToChar("1");
            }
            else
                dd[4] = Convert.ToChar("0");

            if (this.treeList1.Nodes[5].LastNode.CheckState == CheckState.Checked)
            {
                dd[5] = Convert.ToChar("1");
            }
            else
                dd[5] = Convert.ToChar("0");

            if (this.treeList1.Nodes[6].FirstNode.CheckState == CheckState.Checked)
            {
                dd[6] = Convert.ToChar("1");
            }
            else
                dd[6] = Convert.ToChar("0");

            if (this.treeList1.Nodes[6].LastNode.CheckState == CheckState.Checked)
            {
                dd[7] = Convert.ToChar("1");
            }
            else
                dd[7] = Convert.ToChar("0");
            #endregion
            string sendcar_Auth = new string(dd);
            return sendcar_Auth;
        }

        private string Transpotation_Auth()
        {
            string transpotation = "0000000000000000";
            char[] ee = transpotation.ToCharArray();
            #region 运输
            if (this.treeList1.Nodes[7].FirstNode.CheckState == CheckState.Checked)
            {
                ee[0] = Convert.ToChar("1");
            }
            else
                ee[0] = Convert.ToChar("0");
            if (this.treeList1.Nodes[7].LastNode.CheckState == CheckState.Checked)
            {
                ee[1] = Convert.ToChar("1");
            }
            else
                ee[1] = Convert.ToChar("0");


            if (this.treeList1.Nodes[8].FirstNode.CheckState == CheckState.Checked)
            {
                ee[2] = Convert.ToChar("1");
            }
            else
                ee[2] = Convert.ToChar("0");
            if (this.treeList1.Nodes[8].LastNode.CheckState == CheckState.Checked)
            {
                ee[3] = Convert.ToChar("1");
            }
            else
                ee[3] = Convert.ToChar("0");

            if (this.treeList1.Nodes[9].FirstNode.CheckState == CheckState.Checked)
            {
                ee[4] = Convert.ToChar("1");
            }
            else
                ee[4] = Convert.ToChar("0");
            if (this.treeList1.Nodes[9].LastNode.CheckState == CheckState.Checked)
            {
                ee[5] = Convert.ToChar("1");
            }
            else
                ee[5] = Convert.ToChar("0");

            if (this.treeList1.Nodes[10].FirstNode.CheckState == CheckState.Checked)
            {
                ee[6] = Convert.ToChar("1");
            }
            else
                ee[6] = Convert.ToChar("0");
            if (this.treeList1.Nodes[10].LastNode.CheckState == CheckState.Checked)
            {
                ee[7] = Convert.ToChar("1");
            }
            else
                ee[7] = Convert.ToChar("0");

            if (this.treeList1.Nodes[11].FirstNode.CheckState == CheckState.Checked)
            {
                ee[8] = Convert.ToChar("1");
            }
            else
                ee[8] = Convert.ToChar("0");
            if (this.treeList1.Nodes[11].LastNode.CheckState == CheckState.Checked)
            {
                ee[9] = Convert.ToChar("1");
            }
            else
                ee[9] = Convert.ToChar("0");

            if (this.treeList1.Nodes[12].FirstNode.CheckState == CheckState.Checked)
            {
                ee[10] = Convert.ToChar("1");
            }
            else
                ee[10] = Convert.ToChar("0");
            if (this.treeList1.Nodes[12].LastNode.CheckState == CheckState.Checked)
            {
                ee[11] = Convert.ToChar("1");
            }
            else
                ee[11] = Convert.ToChar("0");

            if (this.treeList1.Nodes[13].FirstNode.CheckState == CheckState.Checked)
            {
                ee[12] = Convert.ToChar("1");
            }
            else
                ee[12] = Convert.ToChar("0");
            if (this.treeList1.Nodes[13].LastNode.CheckState == CheckState.Checked)
            {
                ee[13] = Convert.ToChar("1");
            }
            else
                ee[13] = Convert.ToChar("0");

            if (this.treeList1.Nodes[14].FirstNode.CheckState == CheckState.Checked)
            {
                ee[14] = Convert.ToChar("1");
            }
            else
                ee[14] = Convert.ToChar("0");
            if (this.treeList1.Nodes[14].LastNode.CheckState == CheckState.Checked)
            {
                ee[15] = Convert.ToChar("1");
            }
            else
                ee[15] = Convert.ToChar("0");
            #endregion
            string transpotation_Auth = new string(ee);
            return transpotation_Auth;
        }

        private string Basic_Auth()
        {
            string basic = "0000 0000 0000 0000 0000 0000 00";
            char[] ff = basic.ToCharArray();
            #region 基础
            if (this.treeList1.Nodes[15].FirstNode.CheckState == CheckState.Checked)
            {
                ff[0] = Convert.ToChar("1");
            }
            else
                ff[0] = Convert.ToChar("0");
            if (this.treeList1.Nodes[15].LastNode.CheckState == CheckState.Checked)
            {
                ff[1] = Convert.ToChar("1");
            }
            else
                ff[1] = Convert.ToChar("0");

            if (this.treeList1.Nodes[16].FirstNode.CheckState == CheckState.Checked)
            {
                ff[2] = Convert.ToChar("1");
            }
            else
                ff[2] = Convert.ToChar("0");
            if (this.treeList1.Nodes[16].LastNode.CheckState == CheckState.Checked)
            {
                ff[3] = Convert.ToChar("1");
            }
            else
                ff[3] = Convert.ToChar("0");

            if (this.treeList1.Nodes[17].FirstNode.CheckState == CheckState.Checked)
            {
                ff[4] = Convert.ToChar("1");
            }
            else
                ff[4] = Convert.ToChar("0");
            if (this.treeList1.Nodes[17].LastNode.CheckState == CheckState.Checked)
            {
                ff[5] = Convert.ToChar("1");
            }
            else
                ff[5] = Convert.ToChar("0");

            if (this.treeList1.Nodes[18].FirstNode.CheckState == CheckState.Checked)
            {
                ff[6] = Convert.ToChar("1");
            }
            else
                ff[6] = Convert.ToChar("0");
            if (this.treeList1.Nodes[18].LastNode.CheckState == CheckState.Checked)
            {
                ff[7] = Convert.ToChar("1");
            }
            else
                ff[7] = Convert.ToChar("0");

            if (this.treeList1.Nodes[19].FirstNode.CheckState == CheckState.Checked)
            {
                ff[8] = Convert.ToChar("1");
            }
            else
                ff[8] = Convert.ToChar("0");
            if (this.treeList1.Nodes[19].LastNode.CheckState == CheckState.Checked)
            {
                ff[9] = Convert.ToChar("1");
            }
            else
                ff[9] = Convert.ToChar("0");

            if (this.treeList1.Nodes[20].FirstNode.CheckState == CheckState.Checked)
            {
                ff[10] = Convert.ToChar("1");
            }
            else
                ff[10] = Convert.ToChar("0");
            if (this.treeList1.Nodes[20].LastNode.CheckState == CheckState.Checked)
            {
                ff[11] = Convert.ToChar("1");
            }
            else
                ff[11] = Convert.ToChar("0");

            if (this.treeList1.Nodes[21].FirstNode.CheckState == CheckState.Checked)
            {
                ff[12] = Convert.ToChar("1");
            }
            else
                ff[12] = Convert.ToChar("0");
            if (this.treeList1.Nodes[21].LastNode.CheckState == CheckState.Checked)
            {
                ff[13] = Convert.ToChar("1");
            }
            else
                ff[13] = Convert.ToChar("0");

            if (this.treeList1.Nodes[22].FirstNode.CheckState == CheckState.Checked)
            {
                ff[14] = Convert.ToChar("1");
            }
            else
                ff[14] = Convert.ToChar("0");
            if (this.treeList1.Nodes[22].LastNode.CheckState == CheckState.Checked)
            {
                ff[15] = Convert.ToChar("1");
            }
            else
                ff[15] = Convert.ToChar("0");

            if (this.treeList1.Nodes[23].FirstNode.CheckState == CheckState.Checked)
            {
                ff[16] = Convert.ToChar("1");
            }
            else
                ff[16] = Convert.ToChar("0");
            if (this.treeList1.Nodes[23].LastNode.CheckState == CheckState.Checked)
            {
                ff[17] = Convert.ToChar("1");
            }
            else
                ff[17] = Convert.ToChar("0");

            if (this.treeList1.Nodes[24].FirstNode.CheckState == CheckState.Checked)
            {
                ff[18] = Convert.ToChar("1");
            }
            else
                ff[18] = Convert.ToChar("0");
            if (this.treeList1.Nodes[24].LastNode.CheckState == CheckState.Checked)
            {
                ff[19] = Convert.ToChar("1");
            }
            else
                ff[19] = Convert.ToChar("0");

            if (this.treeList1.Nodes[25].FirstNode.CheckState == CheckState.Checked)
            {
                ff[20] = Convert.ToChar("1");
            }
            else
                ff[20] = Convert.ToChar("0");
            if (this.treeList1.Nodes[25].LastNode.CheckState == CheckState.Checked)
            {
                ff[21] = Convert.ToChar("1");
            }
            else
                ff[21] = Convert.ToChar("0");

            if (this.treeList1.Nodes[26].FirstNode.CheckState == CheckState.Checked)
            {
                ff[22] = Convert.ToChar("1");
            }
            else
                ff[22] = Convert.ToChar("0");
            if (this.treeList1.Nodes[26].LastNode.CheckState == CheckState.Checked)
            {
                ff[23] = Convert.ToChar("1");
            }
            else
                ff[23] = Convert.ToChar("0");

            if (this.treeList1.Nodes[27].FirstNode.CheckState == CheckState.Checked)
            {
                ff[24] = Convert.ToChar("1");
            }
            else
                ff[24] = Convert.ToChar("0");
            if (this.treeList1.Nodes[27].LastNode.CheckState == CheckState.Checked)
            {
                ff[25] = Convert.ToChar("1");
            }
            else
                ff[25] = Convert.ToChar("0");
            #endregion
            string basic_Auth = new string(ff);
            return basic_Auth;
        }
        #region treelist设置
        private void treeList1_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            SetCheckedChildNodes(e.Node, e.Node.CheckState);
            SetCheckedParentNodes(e.Node, e.Node.CheckState);
        }

        private void treeList1_BeforeCheckNode(object sender, DevExpress.XtraTreeList.CheckNodeEventArgs e)
        {
            e.State = (e.PrevState == CheckState.Checked ? CheckState.Unchecked : CheckState.Checked);
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
        #endregion
    }
}
