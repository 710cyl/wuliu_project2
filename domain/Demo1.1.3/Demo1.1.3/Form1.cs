﻿using Demo1._1._3.Panel1_SystemManagement;
using Demo1._1._3.Panel2_Basic_UserControl;
using Demo1._1._3.Panel2_MyWorkBench;
using Demo1._1._3.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
namespace Demo1._1._3
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private string IP = "localhost";
        private string Host = "9000";


        public MainOganization main_oganization;
        public MainRole main_role;
        public TaskManagement tm;
        public Journal journal;
        public Link link;
        public MainUser muser;

        public Basic_Set main_basic;
        public Internal_Fleet internal_fleet;
        public UnloadingPoint up;
        public VarietyMaterial vm;
        public ExternalFleet ef;
        public WarehouseFile wf;
        public OwnVehicle ov;
        public OfficeSupplies os;
        public MaintenanceMaterial mm;
        public CapitalAccount ca;
        public CustomerFile cf;
        public WarehousingPrice wp;
        public OrderFile of;

        public GodownEntry ge;
        public OutboundOrder obo;
        public TransferList tl;
        public LotteryNumber lotn;
        public Demo1._1._3.Panel2_MyWorkBench.TransportationRegister tr;
        public Demo1._1._3.Panel2_MyWorkBench.FleetPrice fleetp;
        public Demo1._1._3.Panel2_MyWorkBench.FleetPayment fleetpay;
        public Demo1._1._3.Panel2_MyWorkBench.ShipperPrice shipperp;
        public TransportationClearing tpc;
        public CarReimbursement carr;
        public OilGasRegister ogr;
        public DriverCheck drc;
        public CarFee carf;

        #region fairy 0914
        public Outbound_Car main_outCar; //出库派车
        public OutCar_Close outCar_close; //派车关闭
        public package pac;//摇号打包
        public FunctionClass fc = new FunctionClass();
        #endregion

        public Form1()
        {
            InitializeComponent();

            isAdmin();

            isStorage();
            isSendcar();
            isTranpotation();
            isBasic();
        }

        private void isAdmin()
        {
            if (Sign_in.name != "admin")
            {
                xtraTabPage2.PageVisible = false;
            }
        }

        /// <summary>
        /// 仓库权限
        /// </summary>
        private void isStorage()
        {
            if (Sign_in.storage.Substring(4, 2) == "00")
            {
                accordionControlElement64.Visible = false;
            }
            if (Sign_in.storage.Substring(2, 2) == "00")
            {
                accordionControlElement63.Visible = false;
            }
            if (Sign_in.storage.Substring(0, 2) == "00")
            {
                accordionControlElement62.Visible = false;
            }
        }

        /// <summary>
        /// 派车权限
        /// </summary>
        private void isSendcar()
        {
            if (Sign_in.sendcar.Substring(6, 2) == "00")
            {
                accordionControlElement70.Visible = false;
            }
            if (Sign_in.sendcar.Substring(4, 2) == "00")
            {   
                accordionControlElementClosecar.Visible = false;  
            }
            if (Sign_in.sendcar.Substring(2, 2) == "00")
            {
                accordionControlElementPackage.Visible = false;
            }
            if (Sign_in.sendcar.Substring(0, 2) == "00")
            {
                accordionControlElementSendcar.Visible = false;
            }
        }

        /// <summary>
        /// 运输权限
        /// </summary>
        private void isTranpotation()
        {
            if (Sign_in.transpotation.Substring(14, 2) == "00")
            {
                accordionControlElement82.Visible = false;
            }
            if (Sign_in.transpotation.Substring(12, 2) == "00")
            {
                accordionControlElement78.Visible = false;
            }
            if (Sign_in.transpotation.Substring(10, 2) == "00")
            {
                accordionControlElement77.Visible = false;
            }
            if (Sign_in.transpotation.Substring(8, 2) == "00")
            {
                accordionControlElement76.Visible = false;
            }
            if (Sign_in.transpotation.Substring(6, 2) == "00")
            {
                accordionControlElement67.Visible = false;
            }
            if (Sign_in.transpotation.Substring(4, 2) == "00")
            {
                accordionControlElement79.Visible = false;
            }
            if (Sign_in.transpotation.Substring(2, 2) == "00")
            {
                accordionControlElement66.Visible = false;
            }
            if (Sign_in.transpotation.Substring(0, 2) == "00")
            {
                accordionControlElement65.Visible = false;
            }
        }

        /// <summary>
        /// 基础权限
        /// </summary>
        private void isBasic()
        {
            if (Sign_in.basic.Substring(24, 2) == "00")
            {
                accordionControlElement47.Visible = false;
            }
            if (Sign_in.basic.Substring(22, 2) == "00")
            {
                accordionControlElement46.Visible = false;
            }
            if (Sign_in.basic.Substring(20, 2) == "00")
            {
                accordionControlElement45.Visible = false;
            }
            if (Sign_in.basic.Substring(18, 2) == "00")
            {
                accordionControlElement44.Visible = false;
            }
            if (Sign_in.basic.Substring(16, 2) == "00")
            {
                accordionControlElement43.Visible = false;
            }

            if (Sign_in.basic.Substring(14, 2) == "00")
            {
                accordionControlElement42.Visible = false;
            }
            if (Sign_in.basic.Substring(12, 2) == "00")
            {
                accordionControlElement41.Visible = false;
            }
            if (Sign_in.basic.Substring(10, 2) == "00")
            {
                accordionControlElement40.Visible = false;
            }
            if (Sign_in.basic.Substring(8, 2) == "00")
            {
                accordionControlElement39.Visible = false;
            }
            if (Sign_in.basic.Substring(6, 2) == "00")
            {
                accordionControlElement38.Visible = false;
            }
            if (Sign_in.basic.Substring(4, 2) == "00")
            {
                accordionControlElement37.Visible = false;
            }
            if (Sign_in.basic.Substring(2, 2) == "00")
            {
                accordionControlElement36.Visible = false;
            }
            if (Sign_in.basic.Substring(0, 2) == "00")
            {
                accordionControlElement35.Visible = false;
            }
        }
        private void accordionControlElement1_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement1_Click_1(object sender, EventArgs e)
        {

        }

        private void navigationPage2_Paint(object sender, PaintEventArgs e)
        {

        }

        /**************************系统管理，左测导航栏点击事件*********************************/
        private void accordionControlElement1_Click_2(object sender, EventArgs e)
        {
            main_oganization = new MainOganization();
            main_oganization.Show();
            main_oganization.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(main_oganization);

        }
        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            main_role = new MainRole();
            main_role.Show();
            main_role.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(main_role);

            domain.权限.Role basic_set = new domain.权限.Role();

            main_role.gridControl1.DataSource = showData<domain.权限.Role>(basic_set, main_role.now_Page.ToString());
            main_role.gridView1.Columns[0].Visible = false;
            main_role.gridView1.Columns[1].Caption = "角色名称";
            main_role.gridView1.Columns[2].Caption = "派车权限码";
            main_role.gridView1.Columns[3].Caption = "仓库权限码";
            main_role.gridView1.Columns[4].Caption = "运输权限码";
            main_role.gridView1.Columns[5].Caption = "基础权限码";
            main_role.gridView1.Columns[6].Visible = false;
            main_role.gridView1.BestFitColumns();

        }
        private void accordionControlElement4_Click(object sender, EventArgs e)
        {
            tm = new TaskManagement();
            tm.Show();
            tm.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(tm);
        }
        private void accordionControlElement5_Click(object sender, EventArgs e)
        {
            journal = new Journal();
            journal.Show();
            journal.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(journal);
        }
        private void accordionControlElement34_Click(object sender, EventArgs e)
        {
            link = new Link();
            link.Show();
            link.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(link);
        }
        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            muser = new MainUser();
            muser.Show();
            muser.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(muser);

            domain.权限.User basic_set = new domain.权限.User();
           
            muser.gridControl1.DataSource = showData<domain.权限.User>(basic_set, muser.now_Page.ToString());
            muser.gridView1.Columns[0].Visible = false;
            muser.gridView1.Columns[1].Caption = "姓名";
            muser.gridView1.Columns[2].Caption = "密码";
            muser.gridView1.Columns[3].Visible=false;
            muser.gridView1.BestFitColumns();
        }

        /***************************************************************************************/


        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement30_Click(object sender, EventArgs e)
        {
            
        }

        private void accordionControl3_Click(object sender, EventArgs e)
        {

        }
        public List<T> showData<T>(T t, string nowpage)
        {
            List<T> bs = null;
            string msg = null;
            string sendMsg = t.GetType().Name.ToString();
            using (var ws = new WebSocket("ws://" + IP + ":" + Host + "/ShowData"))
            {
                ws.Connect();
                ws.Send(sendMsg);
                using (var wsp = new WebSocket("ws://" + IP + ":" + Host + "/NowPage"))
                {
                    wsp.Connect();
                    wsp.Send(nowpage);
                    wsp.Close();
                }
                while (msg == null)
                {
                    ws.OnMessage += (sender, e) =>
                    msg = e.Data;
                }
                ws.Close();
                bs = JsonConvert.DeserializeObject<List<T>>(msg);
                //   main_basic.gridControl2.DataSource = bs;
            }
            return bs;
        }
        #region //@fairy 2017-08-29
        public List<T> ShowDataType<T>(T t, string kind, string nowpage)
        {
            List<T> bs = null;
            string msg = null;
            string sendMsg = t.GetType().Name.ToString();
            using (var ws = new WebSocket("ws://localhost:9000/ShowDataType"))
            {
                ws.Connect();
                ws.Send(sendMsg);
                using (var wsp = new WebSocket("ws://localhost:9000/getKind"))
                {
                    wsp.Connect();
                    wsp.Send(kind);
                    wsp.Close();
                }
                using (var wsp = new WebSocket("ws://localhost:9000/NowPage"))
                {
                    wsp.Connect();
                    wsp.Send(nowpage);
                    wsp.Close();
                }
                while (msg == null)
                {
                    ws.OnMessage += (sender, e) =>
                    msg = e.Data;
                }
                ws.Close();
                bs = JsonConvert.DeserializeObject<List<T>>(msg);
            }
            return bs;
        }
        #endregion //@fairy 2017-08-29

        /****************************我的工作台左测导航栏点击事件****************************************/
        private void accordionControlElement35_Click(object sender, EventArgs e)
        {
             main_basic = new Basic_Set();
            main_basic.Show();
            main_basic.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(main_basic);
            domain.Basic_Set basic_set = new domain.Basic_Set();
            Basic_Set dbs = new Basic_Set();
            main_basic.gridControl2.DataSource = showData<domain.Basic_Set>(basic_set, main_basic.now_Page.ToString());
            main_basic.gridView2.Columns[0].Caption ="编号";
            main_basic.gridView2.Columns[1].Caption = "岗位设置";
            main_basic.gridView2.Columns[2].Caption = "应收账款";
            main_basic.gridView2.Columns[3].Caption = "应付账款";
            main_basic.gridView2.Columns[4].Caption = "入库方式";
            main_basic.gridView2.Columns[5].Caption = "出库方式";
            main_basic.gridView2.Columns[6].Caption = "运输方式";
            main_basic.gridView2.Columns[7].Caption = "岗位性质";
            main_basic.gridView2.Columns[8].Caption = "借款性质";
            main_basic.gridView2.Columns[9].Caption = "客户类型";
            main_basic.gridView2.Columns[10].Caption = "费用类型";
            main_basic.gridView2.Columns[11].Caption = "民族";
            main_basic.gridView2.Columns[12].Caption = "仓库";
            main_basic.gridView2.Columns[13].Caption = "报销类型";
            main_basic.gridView2.Columns[14].Caption = "油气类型";
            main_basic.gridView2.BestFitColumns();

        }

        
        private void accordionControlElement36_Click(object sender, EventArgs e)
        {
            internal_fleet = new Internal_Fleet();
            internal_fleet.Show();
            internal_fleet.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(internal_fleet);
            domain.Internal_Vehicle div = new Internal_Vehicle();
            internal_fleet.gridControl2.DataSource = showData<domain.Internal_Vehicle>(div, internal_fleet.now_Page.ToString());

            internal_fleet.gridView2.Columns[0].Caption = "编号";
            internal_fleet.gridView2.Columns[1].Caption = "车队";
            internal_fleet.gridView2.Columns[2].Caption = "车号";
            internal_fleet.gridView2.Columns[3].Caption = "司机";
            internal_fleet.gridView2.Columns[4].Caption = "说明";
        }

        private void accordionControlElement37_Click(object sender, EventArgs e)
        {
            up = new UnloadingPoint();
            up.Show();
            up.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(up);
            domain.Decorate dec = new Decorate();
            domain.Discharge dis = new Discharge();
            domain.Transportations trans = new Transportations();
            up.gridControl3.DataSource = showData<domain.Decorate>(dec,up.now_Page_Dec.ToString());
            up.gridControl2.DataSource = showData<domain.Discharge>(dis,up.now_Page_Dis.ToString());
            up.gridControl4.DataSource = showData<domain.Transportations>(trans,up.now_Page_Trans.ToString());
            up.gridView2.Columns[0].Caption = "编号";
            up.gridView2.Columns[1].Caption = "卸点";
            up.gridView2.Columns[2].Caption = "所在城市";
            up.gridView2.Columns[3].Caption = "所在区域";
            up.gridView2.Columns[4].Caption = "说明";
            up.gridView2.Columns[5].Caption = "联系人";
            up.gridView2.Columns[6].Caption = "电话";
            up.gridView2.Columns[7].Caption = "地址";

            up.gridView3.Columns[0].Caption = "编号";
            up.gridView3.Columns[1].Caption = "装点";
            up.gridView3.Columns[2].Caption = "所在城市";
            up.gridView3.Columns[3].Caption = "所在区域";
            up.gridView3.Columns[4].Caption = "说明";
            up.gridView3.Columns[5].Caption = "联系人";
            up.gridView3.Columns[6].Caption = "电话";
            up.gridView3.Columns[7].Caption = "地址";

            up.gridView4.Columns[0].Caption = "编号";
            up.gridView4.Columns[1].Caption = "集运卸点";
            up.gridView4.Columns[2].Caption = "所在城市";
            up.gridView4.Columns[3].Caption = "所在区域";
            up.gridView4.Columns[4].Caption = "说明";
            up.gridView4.Columns[5].Caption = "联系人";
            up.gridView4.Columns[6].Caption = "电话";
            up.gridView4.Columns[7].Caption = "地址";

        }

        private void accordionControlElement38_Click(object sender, EventArgs e)
        {
            vm = new VarietyMaterial();
            vm.Show();
            vm.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(vm);
            vm.gridControl2.DataSource = showData(new domain.Variety_Texture(), vm.now_Page_vm.ToString());
            vm.gridView2.Columns[0].Caption = "编号";
            vm.gridView2.Columns[1].Caption = "品种";
            vm.gridView2.Columns[2].Caption = "材质";
            vm.gridView2.Columns[3].Caption = "说明";
        }

        private void accordionControlElement39_Click(object sender, EventArgs e)
        {
            ef = new ExternalFleet();
            ef.Show();
            ef.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(ef);

            ef.gridControl2.DataSource = showData(new domain.External_Vehicle(),ef.now_Page_Staff.ToString());

            ef.gridView2.Columns[0].Visible = false;
            ef.gridView2.Columns[1].Caption = "车队";
            ef.gridView2.Columns[2].Caption = "车号";
            ef.gridView2.Columns[3].Caption = "司机";
            ef.gridView2.Columns[4].Caption = "说明";
        }

        #region 派车 2017-7-4 start gxj
        private void accordionControlElementSendcar_Click(object sender, EventArgs e)
        {
            main_outCar = new Outbound_Car();//出库派车
            main_outCar.Show();
            main_outCar.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(main_outCar);
            domain.Outbound_Car outbound_Car = new domain.Outbound_Car();
            main_outCar.gridControl1.DataSource = showData<domain.Outbound_Car>(outbound_Car, main_outCar.now_Page.ToString());
            main_outCar.gridView1.Columns[0].Caption = "派车单号";
            main_outCar.gridView1.Columns[1].Caption = "打包单号";
            main_outCar.gridView1.Columns[2].Caption = "货主单位";
            main_outCar.gridView1.Columns[3].Caption = "发货仓库";
            main_outCar.gridView1.Columns[4].Caption = "发货量";
            main_outCar.gridView1.Columns[5].Caption = "出库方式";
            main_outCar.gridView1.Columns[6].Caption = "业务部门";
            main_outCar.gridView1.Columns[7].Caption = "业务人员";
            main_outCar.gridView1.Columns[8].Caption = "付费单位";
            main_outCar.gridView1.Columns[9].Caption = "车队";
            main_outCar.gridView1.Columns[10].Caption = "车号";
            main_outCar.gridView1.Columns[11].Caption = "司机";
            main_outCar.gridView1.Columns[12].Caption = "派车人";
            main_outCar.gridView1.Columns[13].Caption = "派车时间";
            main_outCar.gridView1.Columns[14].Caption = "卸货城市";
            main_outCar.gridView1.Columns[15].Caption = "卸货区域";
            main_outCar.gridView1.Columns[16].Caption = "实际卸点";
            main_outCar.gridView1.Columns[17].Caption = "打包";
            main_outCar.gridView1.Columns[18].Caption = "关闭";
            main_outCar.gridView1.Columns[19].Caption = "关闭人";
            main_outCar.gridView1.Columns[20].Caption = "关闭时间";
            main_outCar.gridView1.Columns[21].Caption = "说明";
            main_outCar.gridView1.Columns[22].Visible = false;
            main_outCar.gridView1.BestFitColumns();
        }

        private void accordionControlElementPackage_Click(object sender, EventArgs e)
        {
            pac = new package();//摇号打包入口
            pac.Show();
            pac.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(pac);
            domain.YaohaoPac YaohaoPac = new domain.YaohaoPac();
            pac.gridControl1.DataSource = showData<domain.YaohaoPac>(YaohaoPac, pac.now_Page.ToString());
            pac.gridView1.Columns[0].Caption = "打包单号";
            pac.gridView1.Columns[1].Caption = "摇号状态";
            pac.gridView1.Columns[2].Caption = "派车单数量";
            pac.gridView1.Columns[3].Caption = "发货总量";
            pac.gridView1.Columns[4].Caption = "打包人";
            pac.gridView1.Columns[5].Caption = "打包日期";
            pac.gridView1.Columns[6].Visible = false;
            pac.gridView1.BestFitColumns();
        }

        private void accordionControlElementClosecar_Click(object sender, EventArgs e)
        {
            domain.Outbound_Car Outbound_Car = new domain.Outbound_Car();
            outCar_close = new OutCar_Close();//派车关闭 入口
            outCar_close.Show();
            outCar_close.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(outCar_close);
            outCar_close.gridControl1.DataSource = ShowDataType<domain.Outbound_Car>(Outbound_Car, '2'.ToString(), outCar_close.now_Page.ToString());
            outCar_close.gridView1.Columns[0].Caption = "派车单号";
            outCar_close.gridView1.Columns[1].Caption = "打包单号";
            outCar_close.gridView1.Columns[2].Caption = "货主单位";
            outCar_close.gridView1.Columns[3].Caption = "发货仓库";
            outCar_close.gridView1.Columns[4].Caption = "发货量";
            outCar_close.gridView1.Columns[5].Caption = "出库方式";
            outCar_close.gridView1.Columns[6].Caption = "业务部门";
            outCar_close.gridView1.Columns[7].Caption = "业务人员";
            outCar_close.gridView1.Columns[8].Caption = "付费单位";
            outCar_close.gridView1.Columns[9].Caption = "车队";
            outCar_close.gridView1.Columns[10].Caption = "车号";
            outCar_close.gridView1.Columns[11].Caption = "司机";
            outCar_close.gridView1.Columns[12].Caption = "派车人";
            outCar_close.gridView1.Columns[13].Caption = "派车时间";
            outCar_close.gridView1.Columns[14].Caption = "卸货城市";
            outCar_close.gridView1.Columns[15].Caption = "卸货区域";
            outCar_close.gridView1.Columns[16].Caption = "实际卸点";
            outCar_close.gridView1.Columns[17].Caption = "打包";
            outCar_close.gridView1.Columns[18].Caption = "关闭";
            outCar_close.gridView1.Columns[19].Caption = "关闭人";
            outCar_close.gridView1.Columns[20].Caption = "关闭时间";
            outCar_close.gridView1.Columns[21].Caption = "说明";
            outCar_close.gridView1.Columns[22].Visible = false;
            outCar_close.gridView1.BestFitColumns();
        }
        #endregion fairy 20170914

        private void accordionControlElement41_Click(object sender, EventArgs e)
        {
            ov = new OwnVehicle();
            ov.Show();
            ov.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(ov);
        }

        private void accordionControlElement42_Click(object sender, EventArgs e)
        {
            os = new OfficeSupplies();
            os.Show();
            os.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(os);
        }

        private void accordionControlElement43_Click(object sender, EventArgs e)
        {
            mm = new MaintenanceMaterial();
            mm.Show();
            mm.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(mm);
        }

        private void accordionControlElement44_Click(object sender, EventArgs e) //账户资金
        {
            ca = new CapitalAccount();
            ca.Show();
            ca.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(ca);
            CapitalAccount dca = new CapitalAccount();
            domain.Fund_Accounts fund_account = new domain.Fund_Accounts();
            ca.gridControl2.DataSource=showData<domain.Fund_Accounts>(fund_account, dca.now_Page.ToString());

            ca.gridView2.Columns[0].Caption = "编号";
            ca.gridView2.Columns[1].Caption = "账户性质";
            ca.gridView2.Columns[2].Caption = "账户名称";
            ca.gridView2.Columns[3].Caption = "开户行";
            ca.gridView2.Columns[4].Caption = "账号";
            ca.gridView2.Columns[5].Caption = "期初余额";
            ca.gridView2.Columns[6].Caption = "收款总额";
            ca.gridView2.Columns[7].Caption = "付款总额";
            ca.gridView2.Columns[8].Caption = "现余额";
            ca.gridView2.Columns[9].Caption = "说明";
            ca.gridView2.BestFitColumns();
        }

        private void accordionControlElement45_Click(object sender, EventArgs e)
        {
            cf = new CustomerFile();
            cf.Show();
            cf.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(cf);

            cf.gridControl2.DataSource = showData<domain.Customer_File>(new Customer_File(), cf.now_Page_Staff.ToString());

            cf.gridView2.Columns[0].Caption = "客户编号";
            cf.gridView2.Columns[1].Caption = "客户简称";
            cf.gridView2.Columns[2].Caption = "客户全称";
            cf.gridView2.Columns[3].Caption = "速查码";
            cf.gridView2.Columns[4].Caption = "地址";
            cf.gridView2.Columns[5].Caption = "开户行";
            cf.gridView2.Columns[6].Caption = "税号";
            cf.gridView2.Columns[7].Caption = "联系人";
            cf.gridView2.Columns[8].Caption = "电话";
            cf.gridView2.Columns[9].Caption = "客户类型1";
            cf.gridView2.Columns[10].Caption = "客户类型2";
            cf.gridView2.Columns[11].Caption = "客户类型3";
            cf.gridView2.Columns[12].Caption = "客户类型4";
            cf.gridView2.Columns[13].Caption = "客户类型5";


            cf.gridView2.BestFitColumns();
        }

        private void accordionControlElement46_Click(object sender, EventArgs e)
        {
            wp = new WarehousingPrice();
            wp.Show();
            wp.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(wp);
        }

        private void accordionControlElement47_Click(object sender, EventArgs e)
        {
            of = new OrderFile();
            of.Show();
            of.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(of);
        }

        private void accordionControlElement62_Click(object sender, EventArgs e)
        {
            ge = new GodownEntry();
            ge.Show();
            ge.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(ge);
            domain.StorageFormMain sf = new domain.StorageFormMain();
            ge.gridControl3.DataSource = showData<domain.StorageFormMain>(sf, ge.now_Page.ToString());
            ge.gridView3.Columns[23].Visible = false;
            ge.gridView3.Columns[0].Caption = "入库单号";
            ge.gridView3.Columns[1].Caption = "仓库";
            ge.gridView3.Columns[2].Caption = "入库时间";
            ge.gridView3.Columns[3].Caption = "入库方式";
            ge.gridView3.Columns[4].Caption = "车队";
            ge.gridView3.Columns[5].Caption = "车号";
            ge.gridView3.Columns[6].Caption = "司机";
            ge.gridView3.Columns[7].Caption = "入库总量";
            ge.gridView3.Columns[8].Caption = "装货城市";
            ge.gridView3.Columns[9].Caption = "装货地点";
            ge.gridView3.Columns[10].Caption = "装货区域";
            ge.gridView3.Columns[11].Caption = "录入员";
            ge.gridView3.Columns[12].Caption = "录入时间";
            ge.gridView3.Columns[13].Caption = "修改人";
            ge.gridView3.Columns[14].Caption = "修改时间";
            ge.gridView3.Columns[15].Caption = "库管";
            ge.gridView3.Columns[16].Caption = "吊车工";
            ge.gridView3.Columns[17].Caption = "装卸工";
            ge.gridView3.Columns[18].Caption = "其他人";
            ge.gridView3.Columns[19].Caption = "备注";
            ge.gridView3.Columns[20].Caption = "发卸点";
            ge.gridView3.Columns[21].Caption = "发卸城市";
            ge.gridView3.Columns[22].Caption = "发卸区域";
            ge.gridView3.BestFitColumns();

            
        }

        private void accordionControlElement63_Click(object sender, EventArgs e)
        {
            obo = new OutboundOrder();
            obo.Show();
            obo.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(obo);
            domain.StorageFormMainOut sf = new domain.StorageFormMainOut();
            obo.gridControl3.DataSource = showData<domain.StorageFormMainOut>(sf, obo.now_Page.ToString());
            obo.gridView3.Columns[33].Visible = false;

            obo.gridView3.Columns[0].Caption = "出库单号";
            obo.gridView3.Columns[1].Caption = "登记时间";
            obo.gridView3.Columns[2].Caption = "出库方式";
            obo.gridView3.Columns[3].Caption = "车队";
            obo.gridView3.Columns[4].Caption = "车号";
            obo.gridView3.Columns[5].Caption = "司机";
            obo.gridView3.Columns[6].Caption = "出库总量";
            obo.gridView3.Columns[7].Caption = "库管";
            obo.gridView3.Columns[8].Caption = "吊车工";
            obo.gridView3.Columns[9].Caption = "装卸工";
            obo.gridView3.Columns[10].Caption = "发货人员";
            obo.gridView3.Columns[11].Caption = "修改人";
            obo.gridView3.Columns[12].Caption = "修改时间";
            obo.gridView3.Columns[13].Caption = "备注";
            obo.gridView3.Columns[14].Caption = "发装点";
            obo.gridView3.Columns[15].Caption = "发装城市";
            obo.gridView3.Columns[16].Caption = "发装区域";
            obo.gridView3.Columns[17].Caption = "实际卸点";
            obo.gridView3.Columns[18].Caption = "卸货城市";
            obo.gridView3.Columns[19].Caption = "卸货区域";
            obo.gridView3.Columns[20].Caption = "车队标识";
            obo.gridView3.Columns[21].Caption = "出库时间";
            obo.gridView3.Columns[22].Caption = "发货仓库";
            obo.gridView3.Columns[23].Caption = "货主";
            obo.gridView3.Columns[24].Caption = "付费单位";
            obo.gridView3.Columns[25].Caption = "收款人";
            obo.gridView3.Columns[26].Caption = "资金账户";
            obo.gridView3.Columns[27].Caption = "账户名称";
            obo.gridView3.Columns[28].Caption = "仓储费";
            obo.gridView3.Columns[29].Caption = "收款时间";
            obo.gridView3.Columns[30].Caption = "实收金额";
            obo.gridView3.Columns[31].Caption = "收款完成";
            obo.gridView3.Columns[32].Caption = "未收仓储费";
           // obo.gridView3.Columns[33].Caption = "装卸工1";

            obo.gridView3.BestFitColumns();
        }

        private void accordionControlElement64_Click(object sender, EventArgs e)
        {
            tl = new TransferList();
            tl.Show();
            tl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(tl);
            domain.StorageFormMainTrans sf = new domain.StorageFormMainTrans();
            tl.gridControl1.DataSource = showData<domain.StorageFormMainTrans>(sf, tl.now_Page.ToString());

            tl.gridView1.Columns[0].Caption = "仓库名称";
            tl.gridView1.Columns[1].Caption = "移库单号";
            tl.gridView1.Columns[2].Caption = "移库方式";
            tl.gridView1.Columns[3].Caption = "移出客户";
            tl.gridView1.Columns[4].Caption = "移入客户";
            tl.gridView1.Columns[5].Caption = "记账日期";
            tl.gridView1.Columns[6].Caption = "录入员";
            tl.gridView1.Columns[7].Caption = "录入时间";
            tl.gridView1.Columns[8].Caption = "修改人";
            tl.gridView1.Columns[9].Caption = "修改时间";
            tl.gridView1.Columns[10].Caption = "库管";
            tl.gridView1.Columns[11].Caption = "吊车工";
            tl.gridView1.Columns[12].Caption = "装卸工";
            tl.gridView1.Columns[13].Caption = "备注";
            tl.gridView1.Columns[14].Caption = "移库总量";
            tl.gridView1.Columns[15].Caption = "仓储费单位";
            tl.gridView1.Columns[16].Caption = "移库单价";
            tl.gridView1.Columns[17].Caption = "移库金额";
            tl.gridView1.Columns[18].Caption = "移库费单位";
            tl.gridView1.Columns[19].Caption = "装卸工1";

            tl.gridView1.BestFitColumns();
        }

        private void accordionControlElement70_Click(object sender, EventArgs e)
        {
            lotn = new LotteryNumber();
            lotn.Show();
            lotn.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(lotn);
        }

        private void accordionControlElement65_Click(object sender, EventArgs e)
        {
            tr = new Demo1._1._3.Panel2_MyWorkBench.TransportationRegister();
            tr.Show();
            tr.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(tr);
            domain.TransportationRegister transportationregister = new domain.TransportationRegister();
            Demo1._1._3.Panel2_MyWorkBench.TransportationRegister dbs = new Panel2_MyWorkBench.TransportationRegister();
            domain.TransportationRegister_Detail transportationregister_detail = new domain.TransportationRegister_Detail();
            tr.gridControl1.DataSource = showData<domain.TransportationRegister>(transportationregister, dbs.now_Page1.ToString());
            tr.gridControl2.DataSource = showData<domain.TransportationRegister_Detail>(transportationregister_detail, dbs.now_Page2.ToString());
            tr.gridView1.Columns["TransportationRegister_Details"].Visible = false;
            tr.gridView1.Columns[0].Caption = "运输单号";
            tr.gridView1.Columns[1].Caption = "记账日期";
            tr.gridView1.Columns[2].Caption = "运输方式";
            tr.gridView1.Columns[3].Caption = "车队";
            tr.gridView1.Columns[4].Caption = "车号";
            tr.gridView1.Columns[5].Caption = "司机";
            tr.gridView1.Columns[6].Caption = "运输总量";
            tr.gridView1.Columns[7].Caption = "货主运费";
            tr.gridView1.Columns[8].Caption = "车队运费";
            tr.gridView1.Columns[9].Caption = "出发地点";
            tr.gridView1.Columns[10].Caption = "装货地点";
            tr.gridView1.Columns[11].Caption = "卸货地点";
            tr.gridView1.Columns[12].Caption = "出发日期";
            tr.gridView1.Columns[13].Caption = "返回日期";
            tr.gridView1.Columns[14].Caption = "出发城市";
            tr.gridView1.Columns[15].Caption = "装货城市";
            tr.gridView1.Columns[16].Caption = "卸货城市";
            tr.gridView1.Columns[17].Caption = "出发区域";
            tr.gridView1.Columns[18].Caption = "装货区域";
            tr.gridView1.Columns[19].Caption = "卸货区域";
            tr.gridView1.Columns[20].Caption = "自动生成";
            tr.gridView1.Columns[21].Caption = "录入人员";
            tr.gridView1.Columns[22].Caption = "录入时间";
            tr.gridView1.Columns[23].Caption = "修改人员";
            tr.gridView1.Columns[24].Caption = "修改时间";
            tr.gridView1.Columns[25].Caption = "说明";
            tr.gridView1.BestFitColumns();
            tr.gridView2.Columns[0].Caption = "运输单号";
            tr.gridView2.Columns[1].Caption = "记账日期";
            tr.gridView2.Columns[2].Caption = "订单号";
            tr.gridView2.Columns[3].Caption = "运输单标识";
            tr.gridView2.Columns[4].Caption = "货主";
            tr.gridView2.Columns[5].Caption = "卷号";
            tr.gridView2.Columns[6].Caption = "品种";
            tr.gridView2.Columns[7].Caption = "材质";
            tr.gridView2.Columns[8].Caption = "规格";
            tr.gridView2.Columns[9].Caption = "件数";
            tr.gridView2.Columns[10].Caption = "数量";
            tr.gridView2.Columns[11].Caption = "毛重";
            tr.gridView2.Columns[12].Caption = "车队运价";
            tr.gridView2.Columns[13].Caption = "车队运费";
            tr.gridView2.Columns[14].Caption = "货主运价";
            tr.gridView2.Columns[15].Caption = "货主金额";
            tr.gridView2.Columns[16].Caption = "已结算金额";
            tr.gridView2.Columns[17].Caption = "未结算金额";
            tr.gridView2.Columns[18].Caption = "运输方式";
            tr.gridView2.Columns[19].Caption = "车队";
            tr.gridView2.Columns[20].Caption = "车号";
            tr.gridView2.Columns[21].Caption = "司机";
            tr.gridView2.Columns[22].Caption = "业务部门";
            tr.gridView2.Columns[23].Caption = "业务员";
            tr.gridView2.Columns[24].Caption = "出发地点";
            tr.gridView2.Columns[25].Caption = "装货地点";
            tr.gridView2.Columns[26].Caption = "卸货地点";
            tr.gridView2.Columns[27].Caption = "出发城市";
            tr.gridView2.Columns[28].Caption = "出发区域";
            tr.gridView2.Columns[29].Caption = "装货城市";
            tr.gridView2.Columns[30].Caption = "装货区域";
            tr.gridView2.Columns[31].Caption = "卸货城市";
            tr.gridView2.Columns[32].Caption = "卸货区域";
            tr.gridView2.Columns[33].Caption = "出发日期";
            tr.gridView2.Columns[34].Caption = "返回日期";
            tr.gridView2.Columns[35].Caption = "录入人员";
            tr.gridView2.Columns[36].Caption = "录入时间";
            tr.gridView2.Columns[37].Caption = "修改人员";
            tr.gridView2.Columns[38].Caption = "修改时间";
            tr.gridView2.Columns[39].Caption = "说明";
            tr.gridView2.Columns[40].Caption = "备注";
            tr.gridView2.BestFitColumns();
        }

        private void accordionControlElement66_Click(object sender, EventArgs e)
        {
            fleetp = new Demo1._1._3.Panel2_MyWorkBench.FleetPrice();
            fleetp.Show();
            fleetp.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(fleetp);
            domain.FleetPrice fleetprice = new domain.FleetPrice();
            Demo1._1._3.Panel2_MyWorkBench.FleetPrice dbs = new Panel2_MyWorkBench.FleetPrice();
            domain.FleetPrice_Detail fleetprice_detail = new domain.FleetPrice_Detail();
            fleetp.gridControl1.DataSource = showData<domain.FleetPrice>(fleetprice, dbs.now_Page1.ToString());
            fleetp.gridControl2.DataSource = showData<domain.FleetPrice_Detail>(fleetprice_detail, dbs.now_Page2.ToString());
            fleetp.gridView1.Columns["FleetPrice_Details"].Visible = false;
            fleetp.gridView2.Columns["transport_ID"].Visible = false;
            fleetp.gridView1.Columns[0].Caption = "定价单号";
            fleetp.gridView1.Columns[1].Caption = "运输单号";
            fleetp.gridView1.Columns[2].Caption = "总运量";
            fleetp.gridView1.Columns[3].Caption = "总运费";
            fleetp.gridView1.Columns[4].Caption = "是否付款";
            fleetp.gridView1.Columns[5].Caption = "车队";
            fleetp.gridView1.Columns[6].Caption = "车号";
            fleetp.gridView1.Columns[7].Caption = "司机";
            fleetp.gridView1.Columns[8].Caption = "运输方式";
            fleetp.gridView1.Columns[9].Caption = "出发地点";
            fleetp.gridView1.Columns[10].Caption = "装货地点";
            fleetp.gridView1.Columns[11].Caption = "卸货地点";
            fleetp.gridView1.Columns[12].Caption = "出发日期";
            fleetp.gridView1.Columns[13].Caption = "返回日期";
            fleetp.gridView1.Columns[14].Caption = "登记人员";
            fleetp.gridView1.Columns[15].Caption = "修改人员";
            fleetp.gridView1.Columns[16].Caption = "登记时间";
            fleetp.gridView1.Columns[17].Caption = "修改时间";
            fleetp.gridView1.Columns[18].Caption = "说明";
            fleetp.gridView1.BestFitColumns();
            fleetp.gridView2.Columns[0].Caption = "订单号";
            fleetp.gridView2.Columns[1].Caption = "货主";
            fleetp.gridView2.Columns[2].Caption = "卷号";
            fleetp.gridView2.Columns[3].Caption = "品种";
            fleetp.gridView2.Columns[4].Caption = "材质";
            fleetp.gridView2.Columns[5].Caption = "规格";
            fleetp.gridView2.Columns[6].Caption = "件数";
            fleetp.gridView2.Columns[7].Caption = "数量";
            fleetp.gridView2.Columns[8].Caption = "车队运价";
            fleetp.gridView2.Columns[9].Caption = "车队运费";
            fleetp.gridView2.Columns[10].Caption = "运输单标识";
            fleetp.gridView2.Columns[11].Caption = "业务部门";
            fleetp.gridView2.Columns[12].Caption = "业务员";
            fleetp.gridView2.Columns[13].Caption = "备注";
            fleetp.gridView2.BestFitColumns();
        }

        private void accordionControlElement79_Click(object sender, EventArgs e)
        {
            fleetpay = new Demo1._1._3.Panel2_MyWorkBench.FleetPayment();
            fleetpay.Show();
            fleetpay.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(fleetpay);
            domain.FleetPayment fleetprice = new domain.FleetPayment();
            Demo1._1._3.Panel2_MyWorkBench.FleetPayment dbs = new Panel2_MyWorkBench.FleetPayment();
            domain.FleetPayment_Detail fleetprice_detail = new domain.FleetPayment_Detail();
            fleetpay.gridControl1.DataSource = showData<domain.FleetPayment>(fleetprice, dbs.now_Page1.ToString());
            fleetpay.gridControl2.DataSource = showData<domain.FleetPayment_Detail>(fleetprice_detail, dbs.now_Page2.ToString());
            fleetpay.gridView1.Columns["FleetPayment_Details"].Visible = false;
            fleetpay.gridView2.Columns["list_ID"].Visible = false;
            fleetpay.gridView1.Columns[0].Caption = "清单号";
            fleetpay.gridView1.Columns[1].Caption = "车队";
            fleetpay.gridView1.Columns[2].Caption = "车号";
            fleetpay.gridView1.Columns[3].Caption = "总运量";
            fleetpay.gridView1.Columns[4].Caption = "总运费";
            fleetpay.gridView1.Columns[5].Caption = "制单人员";
            fleetpay.gridView1.Columns[6].Caption = "制单时间";
            fleetpay.gridView1.Columns[7].Caption = "说明";
            fleetpay.gridView1.BestFitColumns();
            fleetpay.gridView2.Columns[0].Caption = "定价单号";
            fleetpay.gridView2.Columns[1].Caption = "运输方式";
            fleetpay.gridView2.Columns[2].Caption = "出发地点";
            fleetpay.gridView2.Columns[3].Caption = "装货地点";
            fleetpay.gridView2.Columns[4].Caption = "卸货地点";
            fleetpay.gridView2.Columns[5].Caption = "出发日期";
            fleetpay.gridView2.Columns[6].Caption = "返回日期";
            fleetpay.gridView2.Columns[7].Caption = "运量";
            fleetpay.gridView2.Columns[8].Caption = "单价";
            fleetpay.gridView2.Columns[9].Caption = "运费";
            fleetpay.gridView2.Columns[10].Caption = "备注";
            fleetpay.gridView2.Columns[11].Caption = "运输单号";
            fleetpay.gridView2.BestFitColumns();
        }

        private void accordionControlElement67_Click(object sender, EventArgs e)
        {
            shipperp = new Demo1._1._3.Panel2_MyWorkBench.ShipperPrice();
            shipperp.Show();
            shipperp.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(shipperp);
            domain.ShipperPrice fleetprice = new domain.ShipperPrice();
            Demo1._1._3.Panel2_MyWorkBench.ShipperPrice dbs = new Panel2_MyWorkBench.ShipperPrice();
            domain.ShipperPrice_Detail fleetprice_detail = new domain.ShipperPrice_Detail();
            shipperp.gridControl1.DataSource = showData<domain.ShipperPrice>(fleetprice, dbs.now_Page1.ToString());
            shipperp.gridControl2.DataSource = showData<domain.ShipperPrice_Detail>(fleetprice_detail, dbs.now_Page2.ToString());
            shipperp.gridView1.Columns["ShipperPrice_Details"].Visible = false;
            shipperp.gridView2.Columns["price_ID"].Visible = false;
            shipperp.gridView1.Columns[0].Caption = "定价单号";
            shipperp.gridView1.Columns[1].Caption = "总金额";
            shipperp.gridView1.Columns[2].Caption = "登记人员";
            shipperp.gridView1.Columns[3].Caption = "登记时间";
            shipperp.gridView1.Columns[4].Caption = "修改人员";
            shipperp.gridView1.Columns[5].Caption = "修改时间";
            shipperp.gridView1.BestFitColumns();
            shipperp.gridView2.Columns[0].Caption = "货主";
            shipperp.gridView2.Columns[1].Caption = "运输单标识";
            shipperp.gridView2.Columns[2].Caption = "订单号";
            shipperp.gridView2.Columns[3].Caption = "运输方式";
            shipperp.gridView2.Columns[4].Caption = "出发地点";
            shipperp.gridView2.Columns[5].Caption = "装货地点";
            shipperp.gridView2.Columns[6].Caption = "卸货地点";
            shipperp.gridView2.Columns[7].Caption = "出发日期";
            shipperp.gridView2.Columns[8].Caption = "返回日期";
            shipperp.gridView2.Columns[9].Caption = "卷号";
            shipperp.gridView2.Columns[10].Caption = "品种";
            shipperp.gridView2.Columns[11].Caption = "材质";
            shipperp.gridView2.Columns[12].Caption = "规格";
            shipperp.gridView2.Columns[13].Caption = "件数";
            shipperp.gridView2.Columns[14].Caption = "数量";
            shipperp.gridView2.Columns[15].Caption = "货主运价";
            shipperp.gridView2.Columns[16].Caption = "货主金额";
            shipperp.gridView2.Columns[17].Caption = "备注";
            shipperp.gridView2.Columns[18].Caption = "车队";
            shipperp.gridView2.Columns[19].Caption = "车号";
            shipperp.gridView2.Columns[20].Caption = "司机";
            shipperp.gridView2.Columns[21].Caption = "出发城市";
            shipperp.gridView2.Columns[22].Caption = "出发区域";
            shipperp.gridView2.Columns[23].Caption = "装货城市";
            shipperp.gridView2.Columns[24].Caption = "装货区域";
            shipperp.gridView2.Columns[25].Caption = "卸货城市";
            shipperp.gridView2.Columns[26].Caption = "卸货区域";
            shipperp.gridView2.BestFitColumns();
        }

        private void accordionControlElement76_Click(object sender, EventArgs e)
        {
            tpc = new TransportationClearing();
            tpc.Show();
            tpc.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(tpc);

            domain.TransportationClearing_Main transportation_clearing_main = new domain.TransportationClearing_Main();
            tpc.gridControl1.DataSource = showData<domain.TransportationClearing_Main>(transportation_clearing_main, tpc.now_Page1.ToString());
            //明细表显示??
            string str;
            str = null;
            str = tpc.gridView1.GetFocusedRowCellDisplayText(tpc.gridView1.Columns["clearing_id"]); //获取主键内容
            if (str != "")
            {
                List<domain.TransportationClearing_Detail> tcd_list = new List<TransportationClearing_Detail>(); //得到明细表的list
                string detailString = fc.FindDeteils(str, "TransportationClearing_Detail");
                tcd_list = JsonConvert.DeserializeObject<List<domain.TransportationClearing_Detail>>(detailString);
                tpc.gridControl2.DataSource = tcd_list;
            }

            tpc.gridView1.Columns[0].Caption = "结算单号";
            tpc.gridView1.Columns[1].Caption = "登记人员";
            tpc.gridView1.Columns[2].Caption = "登记时间";
            tpc.gridView1.Columns[3].Caption = "修改人员";
            tpc.gridView1.Columns[4].Caption = "修改时间";
            tpc.gridView1.Columns[5].Caption = "货主";
            tpc.gridView1.Columns[6].Caption = "货主全称";
            tpc.gridView1.Columns[7].Caption = "货主税号";
            tpc.gridView1.Columns[8].Caption = "付款单位";
            tpc.gridView1.Columns[9].Caption = "付款单位全称";
            tpc.gridView1.Columns[10].Caption = "付款单位税号";
            tpc.gridView1.Columns[11].Caption = "开票单位";
            tpc.gridView1.Columns[12].Caption = "开票单位全称";
            tpc.gridView1.Columns[13].Caption = "开票单位税号";
            tpc.gridView1.Columns[14].Caption = "总金额";
            tpc.gridView1.Columns[15].Caption = "说明";
            tpc.gridView1.Columns[16].Caption = "总运量";
            tpc.gridView1.Columns[17].Visible = false;

            tpc.gridView2.Columns[0].Caption = "订单号";
            tpc.gridView2.Columns[1].Caption = "装货地点";
            tpc.gridView2.Columns[2].Caption = "卸货地点";
            tpc.gridView2.Columns[3].Caption = "出发日期";
            tpc.gridView2.Columns[4].Caption = "返回日期";
            tpc.gridView2.Columns[5].Caption = "品种";
            tpc.gridView2.Columns[6].Caption = "材质";
            tpc.gridView2.Columns[7].Caption = "规格";
            tpc.gridView2.Columns[8].Caption = "件数";
            tpc.gridView2.Columns[9].Caption = "数量";
            tpc.gridView2.Columns[10].Caption = "运价";
            tpc.gridView2.Columns[11].Caption = "金额";
            tpc.gridView2.Columns[12].Caption = "备注";
            tpc.gridView2.Columns[13].Caption = "运输单标识";
            tpc.gridView2.Columns[14].Caption = "货主";
            tpc.gridView2.Columns[15].Visible = false;


        }

        private void accordionControlElement77_Click(object sender, EventArgs e)
        {
            carr = new CarReimbursement();
            carr.Show();
            carr.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(carr);

            domain.Car_Reimbursement crb = new domain.Car_Reimbursement();
            carr.gridControl2.DataSource = showData<domain.Car_Reimbursement>(crb, carr.now_Page.ToString());

            carr.gridView2.Columns[0].Caption = "报销单号";
            carr.gridView2.Columns[1].Caption = "车队";
            carr.gridView2.Columns[2].Caption = "车号";
            carr.gridView2.Columns[3].Caption = "司机";
            carr.gridView2.Columns[4].Caption = "登记人员";
            carr.gridView2.Columns[5].Caption = "付款人员";
            carr.gridView2.Columns[6].Caption = "录入时间";
            carr.gridView2.Columns[7].Caption = "付款时间";
            carr.gridView2.Columns[8].Caption = "报销金额";
            carr.gridView2.Columns[9].Caption = "是否付款";
            carr.gridView2.Columns[10].Caption = "付款账户编号";
            carr.gridView2.Columns[11].Caption = "付款账户";
            carr.gridView2.Columns[12].Caption = "报销内容";
            carr.gridView2.Columns[13].Caption = "备注";
        }

        private void accordionControlElement78_Click(object sender, EventArgs e)
        {
            ogr = new OilGasRegister();
            ogr.Show();
            ogr.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(ogr);

            domain.OilGasRegister_Main orm = new domain.OilGasRegister_Main();
            ogr.gridControl1.DataSource = showData<domain.OilGasRegister_Main>(orm, ogr.now_Page.ToString());
            //明细表显示??
            string str;
            str = null;
            str = ogr.gridView1.GetFocusedRowCellDisplayText(ogr.gridView1.Columns["register_id"]); //获取主键内容
            if (str != "")
            {
                List<domain.OilGasRegister_Detail> ogr_list = new List<OilGasRegister_Detail>(); //得到明细表的list
                string detailString = fc.FindDeteils(str, "OilGasRegister_Detail");
                ogr_list = JsonConvert.DeserializeObject<List<domain.OilGasRegister_Detail>>(detailString);
                ogr.gridControl2.DataSource = ogr_list;
            }

            ogr.gridView1.Columns[0].Caption = "登记单号";
            ogr.gridView1.Columns[1].Caption = "加注日期";
            ogr.gridView1.Columns[2].Caption = "油气种类";
            ogr.gridView1.Columns[3].Caption = "油气单价";
            ogr.gridView1.Columns[4].Caption = "登记人";
            ogr.gridView1.Columns[5].Caption = "登记时间";
            ogr.gridView1.Columns[6].Caption = "修改人";
            ogr.gridView1.Columns[7].Caption = "修改时间";
            ogr.gridView1.Columns[8].Visible = false;

            ogr.gridView2.Columns[0].Caption = "油气登记详细单号";
            ogr.gridView2.Columns[1].Caption = "车队";
            ogr.gridView2.Columns[2].Caption = "车号";
            ogr.gridView2.Columns[3].Caption = "司机";
            ogr.gridView2.Columns[4].Caption = "油气量";
            ogr.gridView2.Columns[5].Caption = "金额";
            ogr.gridView2.Columns[6].Caption = "备注";
            ogr.gridView2.Columns[7].Caption = "加注日期";
            ogr.gridView2.Columns[8].Caption = "油气种类";
            ogr.gridView2.Columns[9].Caption = "油气单价";
            ogr.gridView2.Columns[10].Visible = false;

        }

        private void accordionControlElement82_Click(object sender, EventArgs e)

        {
            drc = new DriverCheck();
            drc.Show();
            drc.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(drc);
            domain.Driver_Check crb = new domain.Driver_Check();
            drc.gridControl2.DataSource = showData<domain.Driver_Check>(crb, drc.now_Page.ToString());

            drc.gridView2.Columns[0].Caption = "考核单号";
            drc.gridView2.Columns[1].Caption = "考核类别";
            drc.gridView2.Columns[2].Caption = "考核月份";
            drc.gridView2.Columns[3].Caption = "车队";
            drc.gridView2.Columns[4].Caption = "车号";
            drc.gridView2.Columns[5].Caption = "司机";
            drc.gridView2.Columns[6].Caption = "考核金额";
            drc.gridView2.Columns[7].Caption = "工资金额";
            drc.gridView2.Columns[8].Caption = "考核下达人";
            drc.gridView2.Columns[9].Caption = "录入人员";
            drc.gridView2.Columns[10].Caption = "录入时间";
            drc.gridView2.Columns[11].Caption = "考核事由";
            drc.gridView2.Columns[12].Caption = "记账日期";



        }

        //private void accordionControlElementPackage_Click(object sender, EventArgs e)
        //{
         
        //}

        //private void accordionControlElementClosecar_Click(object sender, EventArgs e)
        //{
           
        //}
        // 派车 2017-7-4 end gxj
        


       private void accordionControlElement40_Click(object sender, EventArgs e)
       {
           wf = new WarehouseFile();
           wf.Show();
           wf.Dock = DockStyle.Fill;
           panel2.Controls.Clear();
           panel2.Controls.Add(wf);

           wf.gridControl2.DataSource = showData(new Warehouse_Staff(), wf.now_Page_Staff.ToString());
            wf.gridView2.Columns[0].Caption = "编号ID";
            wf.gridView2.Columns[1].Caption = "库管";
            wf.gridView2.Columns[2].Caption = "吊车";
            wf.gridView2.Columns[3].Caption = "装卸工";
            wf.gridView2.Columns[4].Caption = "其他";
            wf.gridView2.Columns[5].Caption = "说明";

            wf.gridControl3.DataSource = showData(new Warehouse_Space(), wf.now_Page_Space.ToString());
            wf.gridView3.Columns[0].Caption = "编号ID";
            wf.gridView3.Columns[1].Caption = "仓库";
            wf.gridView3.Columns[2].Caption = "垛位号";
            wf.gridView3.Columns[3].Caption = "说明";
        }
       private void accordionControlElement83_Click(object sender, EventArgs e)
       {
           carf = new CarFee();
           carf.Show();
           carf.Dock = DockStyle.Fill;
           panel2.Controls.Clear();
           panel2.Controls.Add(carf);
       }

        private void accordionControl4_Click(object sender, EventArgs e)
        {

        }



        /*********************************************************************************************************/
    }
}
