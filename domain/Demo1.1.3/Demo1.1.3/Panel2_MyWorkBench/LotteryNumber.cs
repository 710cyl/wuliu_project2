using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo1._1._3.Panel2_MyWorkBench
{
    public partial class LotteryNumber : UserControl
    {
        public LotteryNumber()
        {
            InitializeComponent();


        }

        /// <summary>
        /// 判断可否编辑
        /// </summary>
        private void isEdit()
        {
            if (Sign_in.sendcar.Substring(6, 2) == "00")
            {
                toolStripButton1.Visible = false;
                toolStripButton2.Visible = false;
                toolStripButton7.Visible = false;
            }
        }

    }
}
