using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo1._1._3
{
    public partial class VarietyMaterial : UserControl
    {
        public VarietyMaterial()
        {
            InitializeComponent();

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
    }
}
