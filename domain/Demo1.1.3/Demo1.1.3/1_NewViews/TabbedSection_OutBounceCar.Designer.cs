namespace Demo1._1._3._1_NewViews
{
    partial class TabbedSection_OutBounceCar
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.dataNavigator_Basic_Set = new DevExpress.XtraEditors.DataNavigator();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 59);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1059, 451);
            this.gridControl1.TabIndex = 12;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.simpleButton3);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.simpleButton2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1059, 59);
            this.panel1.TabIndex = 13;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 15);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(236, 25);
            this.textBox1.TabIndex = 4;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Image = global::Demo1._1._3.Properties.Resources.lookup_reference_16x16;
            this.simpleButton3.Location = new System.Drawing.Point(261, 15);
            this.simpleButton3.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(100, 29);
            this.simpleButton3.TabIndex = 3;
            this.simpleButton3.Text = "查询";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Image = global::Demo1._1._3.Properties.Resources.add_16x16;
            this.simpleButton1.Location = new System.Drawing.Point(820, 15);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(106, 29);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "确定";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton2.Image = global::Demo1._1._3.Properties.Resources.cancel_16x16;
            this.simpleButton2.Location = new System.Drawing.Point(940, 15);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(106, 29);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // dataNavigator_Basic_Set
            // 
            this.dataNavigator_Basic_Set.Appearance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataNavigator_Basic_Set.Appearance.Options.UseBackColor = true;
            this.dataNavigator_Basic_Set.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dataNavigator_Basic_Set.Buttons.Append.Enabled = false;
            this.dataNavigator_Basic_Set.Buttons.Append.Visible = false;
            this.dataNavigator_Basic_Set.Buttons.CancelEdit.Enabled = false;
            this.dataNavigator_Basic_Set.Buttons.CancelEdit.Visible = false;
            this.dataNavigator_Basic_Set.Buttons.EnabledAutoRepeat = false;
            this.dataNavigator_Basic_Set.Buttons.EndEdit.Enabled = false;
            this.dataNavigator_Basic_Set.Buttons.EndEdit.Visible = false;
            this.dataNavigator_Basic_Set.Buttons.First.Enabled = false;
            this.dataNavigator_Basic_Set.Buttons.First.Visible = false;
            this.dataNavigator_Basic_Set.Buttons.Last.Enabled = false;
            this.dataNavigator_Basic_Set.Buttons.Last.Visible = false;
            this.dataNavigator_Basic_Set.Buttons.Next.Enabled = false;
            this.dataNavigator_Basic_Set.Buttons.Next.Visible = false;
            this.dataNavigator_Basic_Set.Buttons.NextPage.Enabled = false;
            this.dataNavigator_Basic_Set.Buttons.NextPage.Visible = false;
            this.dataNavigator_Basic_Set.Buttons.Prev.Enabled = false;
            this.dataNavigator_Basic_Set.Buttons.Prev.Visible = false;
            this.dataNavigator_Basic_Set.Buttons.PrevPage.Enabled = false;
            this.dataNavigator_Basic_Set.Buttons.PrevPage.Visible = false;
            this.dataNavigator_Basic_Set.Buttons.Remove.Enabled = false;
            this.dataNavigator_Basic_Set.Buttons.Remove.Visible = false;
            this.dataNavigator_Basic_Set.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.dataNavigator_Basic_Set.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 0, true, true, "首页", "首页"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 1, true, true, "上一页", "上一页"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 4, true, true, "下一页", "下一页"),
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 5, true, true, "尾页", "尾页")});
            this.dataNavigator_Basic_Set.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataNavigator_Basic_Set.Location = new System.Drawing.Point(0, 510);
            this.dataNavigator_Basic_Set.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataNavigator_Basic_Set.Name = "dataNavigator_Basic_Set";
            this.dataNavigator_Basic_Set.ShowToolTips = true;
            this.dataNavigator_Basic_Set.Size = new System.Drawing.Size(1059, 32);
            this.dataNavigator_Basic_Set.TabIndex = 14;
            this.dataNavigator_Basic_Set.Text = "dataNavigator1";
            this.dataNavigator_Basic_Set.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Begin;
            this.dataNavigator_Basic_Set.TextStringFormat = "第 {0}页，共 {1}页";
            this.dataNavigator_Basic_Set.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.dataNavigator_Basic_Set_ButtonClick);
            // 
            // TabbedSection_OutBounceCar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 542);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataNavigator_Basic_Set);
            this.Name = "TabbedSection_OutBounceCar";
            this.Text = "TabbedSection_OutBounceCar";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        public DevExpress.XtraEditors.DataNavigator dataNavigator_Basic_Set;
    }
}