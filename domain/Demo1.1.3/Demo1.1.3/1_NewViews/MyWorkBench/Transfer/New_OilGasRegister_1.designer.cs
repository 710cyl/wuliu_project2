namespace Demo1._1._3.Views.MyWorkBench_SkipForm.Transport
{
    partial class New_OilGasRegister_1
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
            this.dateTimePicker_fueling_date = new System.Windows.Forms.DateTimePicker();
            this.comboBox_oilgas_type = new System.Windows.Forms.ComboBox();
            this.textBox_register_time = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_register_man = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_register_id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox_oilgas_unitprice = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel_button.SuspendLayout();
            this.panel_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridControl1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(903, 437);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "明细表";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 17);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(897, 417);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
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
            this.panel_button.Location = new System.Drawing.Point(903, 118);
            this.panel_button.Margin = new System.Windows.Forms.Padding(2);
            this.panel_button.Name = "panel_button";
            this.panel_button.Size = new System.Drawing.Size(165, 437);
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
            this.panel_Main.AutoScrollMinSize = new System.Drawing.Size(1068, 118);
            this.panel_Main.Controls.Add(this.dateTimePicker_fueling_date);
            this.panel_Main.Controls.Add(this.comboBox_oilgas_type);
            this.panel_Main.Controls.Add(this.textBox_register_time);
            this.panel_Main.Controls.Add(this.label2);
            this.panel_Main.Controls.Add(this.textBox_register_man);
            this.panel_Main.Controls.Add(this.label3);
            this.panel_Main.Controls.Add(this.textBox_register_id);
            this.panel_Main.Controls.Add(this.label4);
            this.panel_Main.Controls.Add(this.label23);
            this.panel_Main.Controls.Add(this.textBox_oilgas_unitprice);
            this.panel_Main.Controls.Add(this.label12);
            this.panel_Main.Controls.Add(this.label13);
            this.panel_Main.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Main.Location = new System.Drawing.Point(0, 0);
            this.panel_Main.Margin = new System.Windows.Forms.Padding(2);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(1068, 118);
            this.panel_Main.TabIndex = 14;
            // 
            // dateTimePicker_fueling_date
            // 
            this.dateTimePicker_fueling_date.Location = new System.Drawing.Point(686, 61);
            this.dateTimePicker_fueling_date.Name = "dateTimePicker_fueling_date";
            this.dateTimePicker_fueling_date.Size = new System.Drawing.Size(148, 21);
            this.dateTimePicker_fueling_date.TabIndex = 427;
            // 
            // comboBox_oilgas_type
            // 
            this.comboBox_oilgas_type.Font = new System.Drawing.Font("宋体", 9.5F);
            this.comboBox_oilgas_type.FormattingEnabled = true;
            this.comboBox_oilgas_type.Location = new System.Drawing.Point(148, 63);
            this.comboBox_oilgas_type.Name = "comboBox_oilgas_type";
            this.comboBox_oilgas_type.Size = new System.Drawing.Size(149, 21);
            this.comboBox_oilgas_type.TabIndex = 426;
            // 
            // textBox_register_time
            // 
            this.textBox_register_time.Font = new System.Drawing.Font("宋体", 9.5F);
            this.textBox_register_time.Location = new System.Drawing.Point(686, 34);
            this.textBox_register_time.Name = "textBox_register_time";
            this.textBox_register_time.ReadOnly = true;
            this.textBox_register_time.Size = new System.Drawing.Size(148, 22);
            this.textBox_register_time.TabIndex = 425;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label2.Location = new System.Drawing.Point(607, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 424;
            this.label2.Text = "登记时间：";
            // 
            // textBox_register_man
            // 
            this.textBox_register_man.Font = new System.Drawing.Font("宋体", 9.5F);
            this.textBox_register_man.Location = new System.Drawing.Point(415, 35);
            this.textBox_register_man.Name = "textBox_register_man";
            this.textBox_register_man.Size = new System.Drawing.Size(148, 22);
            this.textBox_register_man.TabIndex = 423;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label3.Location = new System.Drawing.Point(349, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 422;
            this.label3.Text = "登记人：";
            // 
            // textBox_register_id
            // 
            this.textBox_register_id.Font = new System.Drawing.Font("宋体", 9.5F);
            this.textBox_register_id.Location = new System.Drawing.Point(149, 35);
            this.textBox_register_id.Name = "textBox_register_id";
            this.textBox_register_id.Size = new System.Drawing.Size(148, 22);
            this.textBox_register_id.TabIndex = 421;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label4.Location = new System.Drawing.Point(70, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 420;
            this.label4.Text = "登记单号：";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label23.Location = new System.Drawing.Point(607, 66);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 13);
            this.label23.TabIndex = 418;
            this.label23.Text = "加注日期：";
            // 
            // textBox_oilgas_unitprice
            // 
            this.textBox_oilgas_unitprice.Font = new System.Drawing.Font("宋体", 9.5F);
            this.textBox_oilgas_unitprice.Location = new System.Drawing.Point(415, 64);
            this.textBox_oilgas_unitprice.Name = "textBox_oilgas_unitprice";
            this.textBox_oilgas_unitprice.Size = new System.Drawing.Size(148, 22);
            this.textBox_oilgas_unitprice.TabIndex = 417;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label12.Location = new System.Drawing.Point(336, 66);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 416;
            this.label12.Text = "油气单价：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9.5F);
            this.label13.Location = new System.Drawing.Point(70, 64);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 415;
            this.label13.Text = "油气种类：";
            // 
            // New_OilGasRegister_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 555);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel_button);
            this.Controls.Add(this.panel_Main);
            this.Name = "New_OilGasRegister_1";
            this.Text = "油气登记单";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel_button.ResumeLayout(false);
            this.panel_Main.ResumeLayout(false);
            this.panel_Main.PerformLayout();
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
        private System.Windows.Forms.ComboBox comboBox_oilgas_type;
        private System.Windows.Forms.TextBox textBox_register_time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_register_man;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_register_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBox_oilgas_unitprice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fueling_date;
    }
}