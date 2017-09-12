namespace Demo1._1._3
{
    partial class AddRoles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(30, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 18);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "角色名称 :";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(115, 33);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(295, 24);
            this.textEdit1.TabIndex = 5;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(12, 444);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(128, 36);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "保存";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(146, 444);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(128, 36);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.treeList1.CustomizationFormBounds = new System.Drawing.Rectangle(3365, 621, 220, 266);
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.BeginUnboundLoad();
            this.treeList1.AppendNode(new object[] {
            "入库单"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 0);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 0);
            this.treeList1.AppendNode(new object[] {
            "出库单"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 3);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 3);
            this.treeList1.AppendNode(new object[] {
            "移库单"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 6);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 6);
            this.treeList1.AppendNode(new object[] {
            "出库派车"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 9);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 9);
            this.treeList1.AppendNode(new object[] {
            "摇号打包"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 12);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 12);
            this.treeList1.AppendNode(new object[] {
            "派车关闭"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 15);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 15);
            this.treeList1.AppendNode(new object[] {
            "摇号"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 18);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 18);
            this.treeList1.AppendNode(new object[] {
            "运输登记"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 21);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 21);
            this.treeList1.AppendNode(new object[] {
            "车队定价"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 24);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 24);
            this.treeList1.AppendNode(new object[] {
            "车队付款"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 27);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 27);
            this.treeList1.AppendNode(new object[] {
            "货主定价"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 30);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 30);
            this.treeList1.AppendNode(new object[] {
            "运输结算"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 33);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 33);
            this.treeList1.AppendNode(new object[] {
            "出车报销"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 36);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 36);
            this.treeList1.AppendNode(new object[] {
            "油气登记"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 39);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 39);
            this.treeList1.AppendNode(new object[] {
            "司机考评"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 42);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 42);
            this.treeList1.AppendNode(new object[] {
            "基础设置"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 45);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 45);
            this.treeList1.AppendNode(new object[] {
            "内部车队"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 48);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 48);
            this.treeList1.AppendNode(new object[] {
            "卸点档案"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 51);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 51);
            this.treeList1.AppendNode(new object[] {
            "品种材质"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 54);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 54);
            this.treeList1.AppendNode(new object[] {
            "外部车队"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 57);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 57);
            this.treeList1.AppendNode(new object[] {
            "仓库档案"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 60);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 60);
            this.treeList1.AppendNode(new object[] {
            "自有车辆"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 63);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 63);
            this.treeList1.AppendNode(new object[] {
            "办公用品"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 66);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 66);
            this.treeList1.AppendNode(new object[] {
            "维修物料"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 69);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 69);
            this.treeList1.AppendNode(new object[] {
            "资金账户"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 72);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 72);
            this.treeList1.AppendNode(new object[] {
            "客户档案"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 75);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 75);
            this.treeList1.AppendNode(new object[] {
            "仓储价格"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 78);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 78);
            this.treeList1.AppendNode(new object[] {
            "订单档案"}, -1);
            this.treeList1.AppendNode(new object[] {
            "查阅"}, 81);
            this.treeList1.AppendNode(new object[] {
            "编辑"}, 81);
            this.treeList1.EndUnboundLoad();
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treeList1.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treeList1.OptionsView.ShowCheckBoxes = true;
            this.treeList1.Size = new System.Drawing.Size(468, 492);
            this.treeList1.TabIndex = 0;
            this.treeList1.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.treeList1_BeforeCheckNode);
            this.treeList1.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList1_AfterCheckNode);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "权限视图";
            this.treeListColumn1.FieldName = "权限视图";
            this.treeListColumn1.MinWidth = 70;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeList1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(434, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(468, 492);
            this.panel1.TabIndex = 15;
            // 
            // AddRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 492);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Name = "AddRoles";
            this.Text = "AddRoles";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private System.Windows.Forms.Panel panel1;
    }
}