namespace Demo1._1._3.Views.MyWorkBench_SkipForm.Transport
{
    partial class New_FleetPayment_1
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel_button = new System.Windows.Forms.Panel();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label32 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel_button.SuspendLayout();
            this.panel_Main.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(838, 468);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "明细表";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(647, 434);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            // 
            // panel_button
            // 
            this.panel_button.AutoScroll = true;
            this.panel_button.AutoScrollMinSize = new System.Drawing.Size(36, 320);
            this.panel_button.Controls.Add(this.simpleButton2);
            this.panel_button.Controls.Add(this.simpleButton5);
            this.panel_button.Controls.Add(this.simpleButton3);
            this.panel_button.Controls.Add(this.simpleButton4);
            this.panel_button.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_button.Location = new System.Drawing.Point(647, 0);
            this.panel_button.Margin = new System.Windows.Forms.Padding(2);
            this.panel_button.Name = "panel_button";
            this.panel_button.Size = new System.Drawing.Size(165, 434);
            this.panel_button.TabIndex = 15;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Image = global::Demo1._1._3.Properties.Resources.cancel_16x16;
            this.simpleButton2.Location = new System.Drawing.Point(44, 302);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 31);
            this.simpleButton2.TabIndex = 162;
            this.simpleButton2.Text = "取消";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton5
            // 
            this.simpleButton5.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.simpleButton5.Appearance.Options.UseFont = true;
            this.simpleButton5.Image = global::Demo1._1._3.Properties.Resources.save_16x16;
            this.simpleButton5.Location = new System.Drawing.Point(44, 265);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(75, 31);
            this.simpleButton5.TabIndex = 165;
            this.simpleButton5.Text = "保存";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.Image = global::Demo1._1._3.Properties.Resources.delete_16x16;
            this.simpleButton3.Location = new System.Drawing.Point(44, 104);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(75, 31);
            this.simpleButton3.TabIndex = 164;
            this.simpleButton3.Text = "删除";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Appearance.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.simpleButton4.Appearance.Options.UseFont = true;
            this.simpleButton4.Image = global::Demo1._1._3.Properties.Resources.add_16x16;
            this.simpleButton4.Location = new System.Drawing.Point(44, 67);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(75, 31);
            this.simpleButton4.TabIndex = 163;
            this.simpleButton4.Text = "添加";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // panel_Main
            // 
            this.panel_Main.AutoScroll = true;
            this.panel_Main.Controls.Add(this.panel1);
            this.panel_Main.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Main.Location = new System.Drawing.Point(0, 0);
            this.panel_Main.Margin = new System.Windows.Forms.Padding(2);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(838, 118);
            this.panel_Main.TabIndex = 14;
            this.panel_Main.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Main_Paint);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(602, 50);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(136, 21);
            this.dateTimePicker1.TabIndex = 230;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label32.Location = new System.Drawing.Point(523, 55);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(72, 13);
            this.label32.TabIndex = 229;
            this.label32.Text = "制单时间：";
            // 
            // textBox17
            // 
            this.textBox17.Font = new System.Drawing.Font("宋体", 9.5F);
            this.textBox17.Location = new System.Drawing.Point(342, 52);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(148, 22);
            this.textBox17.TabIndex = 228;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label33.Location = new System.Drawing.Point(263, 55);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(72, 13);
            this.label33.TabIndex = 227;
            this.label33.Text = "制单人员：";
            // 
            // textBox18
            // 
            this.textBox18.Font = new System.Drawing.Font("宋体", 9.5F);
            this.textBox18.Location = new System.Drawing.Point(89, 55);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(148, 22);
            this.textBox18.TabIndex = 226;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label34.Location = new System.Drawing.Point(23, 58);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(59, 13);
            this.label34.TabIndex = 225;
            this.label34.Text = "清单号：";
            // 
            // textBox19
            // 
            this.textBox19.Font = new System.Drawing.Font("宋体", 9.5F);
            this.textBox19.Location = new System.Drawing.Point(342, 24);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(148, 22);
            this.textBox19.TabIndex = 224;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label35.Location = new System.Drawing.Point(289, 27);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(46, 13);
            this.label35.TabIndex = 223;
            this.label35.Text = "车号：";
            // 
            // textBox20
            // 
            this.textBox20.Font = new System.Drawing.Font("宋体", 9.5F);
            this.textBox20.Location = new System.Drawing.Point(89, 27);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(148, 22);
            this.textBox20.TabIndex = 222;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label36.Location = new System.Drawing.Point(36, 30);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(46, 13);
            this.label36.TabIndex = 221;
            this.label36.Text = "车队：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label36);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.textBox20);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.label35);
            this.panel1.Controls.Add(this.textBox17);
            this.panel1.Controls.Add(this.textBox19);
            this.panel1.Controls.Add(this.label33);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Controls.Add(this.textBox18);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 100);
            this.panel1.TabIndex = 231;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Controls.Add(this.panel_button);
            this.panel2.Location = new System.Drawing.Point(12, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 436);
            this.panel2.TabIndex = 16;
            // 
            // New_FleetPayment_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 586);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel_Main);
            this.Name = "New_FleetPayment_1";
            this.Text = "外部车队运费付款清单";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel_button.ResumeLayout(false);
            this.panel_Main.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel_button;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private System.Windows.Forms.Panel panel_Main;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}