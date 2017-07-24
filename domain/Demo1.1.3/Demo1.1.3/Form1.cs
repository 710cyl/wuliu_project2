using Demo1._1._3.Panel1_SystemManagement;
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
        public TransportationRegister tr;
        public FleetPrice fleetp;
        public FleetPayment fleetpay;
        public ShipperPrice shipperp;
        public TransportationClearing tpc;
        public CarReimbursement carr;
        public OilGasRegister ogr;
        public DriverCheck drc;
        public CarFee carf;

        /*        private void Form1_Load(object sender, EventArgs e)
                {
                   u1 = new UserControl1();
                    u2 = new UserControl2();
                }*/
        public FunctionClass fc;

        public Form1()
        {
            InitializeComponent();
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
            using (var ws = new WebSocket("ws://localhost:9000/ShowData"))
            {
                ws.Connect();
                ws.Send(sendMsg);
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
                //   main_basic.gridControl2.DataSource = bs;
            }
            return bs;
        }

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
            up.gridControl2.DataSource = showData<domain.Decorate>(dec,up.now_Page_Dec.ToString());
            up.gridControl3.DataSource = showData<domain.Discharge>(dis,up.now_Page_Dis.ToString());
            up.gridControl4.DataSource = showData<domain.Transportations>(trans,up.now_Page_Trans.ToString());
        }

        private void accordionControlElement38_Click(object sender, EventArgs e)
        {
            vm = new VarietyMaterial();
            vm.Show();
            vm.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(vm);
        }

        private void accordionControlElement39_Click(object sender, EventArgs e)
        {
            ef = new ExternalFleet();
            ef.Show();
            ef.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(ef);
        }

        private void accordionControlElement40_Click(object sender, EventArgs e)
        {
            wf = new WarehouseFile();
            wf.Show();
            wf.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(wf);
        }

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
        }

        private void accordionControlElement45_Click(object sender, EventArgs e)
        {
            cf = new CustomerFile();
            cf.Show();
            cf.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(cf);
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
            ge.gridControl1.DataSource = showData<domain.StorageFormMain>(sf, ge.now_Page.ToString());
            ge.gridView1.Columns[23].Visible = false;
        }

        private void accordionControlElement63_Click(object sender, EventArgs e)
        {
            obo = new OutboundOrder();
            obo.Show();
            obo.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(obo);
        }

        private void accordionControlElement64_Click(object sender, EventArgs e)
        {
            tl = new TransferList();
            tl.Show();
            tl.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(tl);
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
            tr = new TransportationRegister();
            tr.Show();
            tr.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(tr);
        }

        private void accordionControlElement66_Click(object sender, EventArgs e)
        {
            fleetp = new FleetPrice();
            fleetp.Show();
            fleetp.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(fleetp);
        }

        private void accordionControlElement79_Click(object sender, EventArgs e)
        {
            fleetpay = new FleetPayment();
            fleetpay.Show();
            fleetpay.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(fleetpay);
        }

        private void accordionControlElement67_Click(object sender, EventArgs e)
        {
            shipperp = new ShipperPrice();
            shipperp.Show();
            shipperp.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(shipperp);
        }

        private void accordionControlElement76_Click(object sender, EventArgs e)
        {
            tpc = new TransportationClearing();
            tpc.Show();
            tpc.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(tpc);
        }

        private void accordionControlElement77_Click(object sender, EventArgs e)
        {
            carr = new CarReimbursement();
            carr.Show();
            carr.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(carr);
        }

        private void accordionControlElement78_Click(object sender, EventArgs e)
        {
            ogr = new OilGasRegister();
            ogr.Show();
            ogr.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(ogr);
        }

        private void accordionControlElement82_Click(object sender, EventArgs e)
        {
            drc = new DriverCheck();
            drc.Show();
            drc.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(drc);
        }

        private void accordionControlElement83_Click(object sender, EventArgs e)
        {
            carf = new CarFee();
            carf.Show();
            carf.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(carf);
        }

        /*********************************************************************************************************/
    }
}
