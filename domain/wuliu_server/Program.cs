using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocketSharp;
using WebSocketSharp.Server;
using NHibernate;
using domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using wuliuDAO;
using System.Data;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;

namespace wuliu_server
{
    class Program
    {
        static void Main(string[] args)
        {
            var wssv = new WebSocketServer("ws://localhost:9000");
            wssv.AddWebSocketService<GetField>("/GetField");
            wssv.AddWebSocketService<ShowData>("/ShowData");
            wssv.AddWebSocketService<DeleteData>("/DeleteData");
            wssv.AddWebSocketService<BatchSave>("/BatchSave");
            wssv.AddWebSocketService<SaveData>("/SaveData");
            wssv.AddWebSocketService<GetCount>("/GetCount");
            wssv.AddWebSocketService<NowPage>("/NowPage");
            wssv.AddWebSocketService<UpdateData>("/UpdateData");
            wssv.AddWebSocketService<FindDetails>("/FindDetails");
            wssv.AddWebSocketService<DeleteMain>("/DeleteMain");
            wssv.AddWebSocketService<MutiSave>("/MutiSave");
            wssv.AddWebSocketService<MainSave>("/MainSave");

            wssv.AddWebSocketService<DetailsChange>("/DetailsChange");
            wssv.AddWebSocketService<MainChange>("/MainChange");

            wssv.AddWebSocketService<GetClassName>("/GetClassName/Main"); //获得主表表明
            wssv.AddWebSocketService<GetClassName>("/GetClassName/Detail");//获得明细表表明

            wssv.AddWebSocketService<ShowDataLike>("/ShowDataLike");
            wssv.AddWebSocketService<GetValLike>("/GetValLike");

            wssv.AddWebSocketService<Combobox_StorageWay>("/Combobox/Combobox_StorageWay");
            wssv.AddWebSocketService<Combobox_StorageName>("/Combobox/Combobox_StorageName");
            wssv.AddWebSocketService<Combobox_Loader>("/Combobox/Combobox_Loader");
            wssv.AddWebSocketService<Combobox_keeper>("/Combobox/Combobox_keeper");
            wssv.AddWebSocketService<Combobox_Crane>("/Combobox/Combobox_Crane");
            wssv.AddWebSocketService<Combobox_CraneNumber>("/Combobox/Combobox_CraneNumber");
            wssv.AddWebSocketService<Combobox_Texture>("/Combobox/Combobox_Texture");
            wssv.AddWebSocketService<Combobox_Variety>("/Combobox/Combobox_Variety");

            wssv.AddWebSocketService<Combobox_refundMode>("/Combobox/Combobox_refundMode");
            wssv.AddWebSocketService<Combobox_oilVariety>("/Combobox/Combobox_oilVariety");

            wssv.AddWebSocketService<Combobox_Transportation>("/Combobox/Combobox_Transportation");
            wssv.AddWebSocketService<Combobox_AddRole>("/Combobox/Combobox_AddRole");

            wssv.AddWebSocketService<ServerStorageDetails>("/ServerStorageDetails");
            wssv.AddWebSocketService<ServerOuBounceCarDetails>("/ServerOuBounceCarDetails");

            wssv.AddWebSocketService<server_Login>("/server_Login");
            wssv.AddWebSocketService<server_adduser>("/server_adduser");
            wssv.AddWebSocketService<server_addrole>("/server_addrole");
            wssv.AddWebSocketService<server_userrole>("/server_userrole");

            wssv.AddWebSocketService<server_deleteUser>("/server_deleteUser");
            wssv.AddWebSocketService<server_deleteRole>("/server_deleteRole");
            wssv.Start();
            Console.ReadKey();
            wssv.Stop();


        }
    }


    public class GetClassName : WebSocketBehavior //获取对象类名
    {
        public static string classname;
        protected override void OnMessage(MessageEventArgs e)
        {
            try
            {
                classname = e.Data;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class MainChange : WebSocketBehavior  //修改主表服务器
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            try
            {
                GetClass(GetClassName.classname, e.Data);
            }
            catch (Exception ex)
            {
                Send(ex.Message);
            }
        }

        private void GetClass(string name, string data)
        {
            if (name == "StorageFormMain")
            {
                StorageFormMain sfm = JsonConvert.DeserializeObject<StorageFormMain>(data);
                IGoDownEntry gde = new IGoDownEntry();
                gde.Update(sfm);
            }

            else if (name == "Outbound_Car")
            {
                Outbound_Car sfm = JsonConvert.DeserializeObject<Outbound_Car>(data);
                Outbound_CarDAO gde = new Outbound_CarDAO();
                gde.Update(sfm);
                Console.WriteLine("出库派车主表修改成功！");
            }

            else if (name == "StorageFormMainOut")
            {
                StorageFormMainOut sfm = JsonConvert.DeserializeObject<StorageFormMainOut>(data);
                IOutBoundOrder gde = new IOutBoundOrder();
                gde.Update(sfm);
            }

            else if (name == "StorageFormMainTrans")
            {
                StorageFormMainTrans sfm = JsonConvert.DeserializeObject<StorageFormMainTrans>(data);
                IOutBoundOrderTrans gde = new IOutBoundOrderTrans();
                gde.Update(sfm);
            }
            else if (name == "TransportationRegister")
            {
                TransportationRegister tr = JsonConvert.DeserializeObject<TransportationRegister>(data);
                ITransportationRegister itr = new ITransportationRegister();
                itr.Update(tr);
            }
            else if (name == "FleetPrice")
            {
                FleetPrice tr = JsonConvert.DeserializeObject<FleetPrice>(data);
                IFleetPrice itr = new IFleetPrice();
                itr.Update(tr);
            }
            else if (name == "FleetPayment")
            {
                FleetPayment tr = JsonConvert.DeserializeObject<FleetPayment>(data);
                IFleetPayment itr = new IFleetPayment();
                itr.Update(tr);
            }
            else if (name == "ShipperPrice")
            {
                ShipperPrice tr = JsonConvert.DeserializeObject<ShipperPrice>(data);
                IShipperPrice itr = new IShipperPrice();
                itr.Update(tr);
            }
            else if (name == "TransportationClearing_Main")
            {
                TransportationClearing_Main tr = JsonConvert.DeserializeObject<TransportationClearing_Main>(data);
                TransportationClearing_MainDAO itr = new TransportationClearing_MainDAO();
                itr.Update(tr);
            }
            else if (name == "OilGasRegister_Main")
            {
                OilGasRegister_Main tr = JsonConvert.DeserializeObject<OilGasRegister_Main>(data);
                OilGasRegister_MainDAO itr = new OilGasRegister_MainDAO();
                itr.Update(tr);
            }

        }
    }

    public class DetailsChange : WebSocketBehavior //修改明细服务器
    {
        protected override void OnMessage(MessageEventArgs e)
        {

            try
            {
                GetClass(GetClassName.classname, e.Data);
            }
            catch (Exception ex)
            {
                Send(ex.Message);
                // tran.Rollback();
            }
        }

        private void GetClass(string name, string data)

        {

            string json = null;
            if (name == "StorageDetails")
            {
                List<domain.StorageDetails> sd = null;
                json = null;
                IStorageDetail isd = new IStorageDetail();
                json = data;
                sd = JsonConvert.DeserializeObject<List<domain.StorageDetails>>(json);
                foreach (StorageDetails item in sd)
                {
                    isd.Update(item);
                    Console.WriteLine("1111111111111111111");
                }
            }
            else if (name == "Outbound_Car_Detail")
            {
                List<domain.Outbound_Car_Detail> sd = null;
                Outbound_Car_DetailDAO isd = new Outbound_Car_DetailDAO();
                json = data;
                sd = JsonConvert.DeserializeObject<List<domain.Outbound_Car_Detail>>(json);
                foreach (Outbound_Car_Detail item in sd)
                {
                    isd.Update(item);
                    Console.WriteLine("出库派车明细表修改成功！");
                }
            }
            else if (name == "StorageDetailsOut")
            {
                List<domain.StorageDetailsOut> sd = null;

                IOutBoundOrderDetails isd = new IOutBoundOrderDetails();
                json = data;
                sd = JsonConvert.DeserializeObject<List<domain.StorageDetailsOut>>(json);
                foreach (StorageDetailsOut item in sd)
                {
                    isd.Update(item);
                    Console.WriteLine("1111111111111111111");
                }
            }

            else if (name == "StorageDetailsTrans")
            {
                List<domain.StorageDetailsTrans> sd = null;

                IOutBoundOrderTransDetails isd = new IOutBoundOrderTransDetails();
                json = data;
                sd = JsonConvert.DeserializeObject<List<domain.StorageDetailsTrans>>(json);
                foreach (StorageDetailsTrans item in sd)
                {
                    isd.Update(item);
                    Console.WriteLine("1111111111111111111");
                }
            }
            else if (name == "TransportationRegister_Detail")
            {
                List<domain.TransportationRegister_Detail> trd = null;
                ITransportationRegister_Detail isd = new ITransportationRegister_Detail();
                json = data;
                trd = JsonConvert.DeserializeObject<List<domain.TransportationRegister_Detail>>(json);
                foreach (TransportationRegister_Detail item in trd)
                {
                    isd.Update(item);
                    Console.WriteLine("1111111111111111111");
                }
            }
            else if (name == "FleetPrice_Detail")
            {
                List<domain.FleetPrice_Detail> trd = null;
                IFleetPrice_Detail isd = new IFleetPrice_Detail();
                json = data;
                trd = JsonConvert.DeserializeObject<List<domain.FleetPrice_Detail>>(json);
                foreach (FleetPrice_Detail item in trd)
                {
                    isd.Update(item);
                    Console.WriteLine("1111111111111111111");
                }
            }
            else if (name == "FleetPayment_Detail")
            {
                List<domain.FleetPayment_Detail> trd = null;
                IFleetPayment_Detail isd = new IFleetPayment_Detail();
                json = data;
                trd = JsonConvert.DeserializeObject<List<domain.FleetPayment_Detail>>(json);
                foreach (FleetPayment_Detail item in trd)
                {
                    isd.Update(item);
                    Console.WriteLine("1111111111111111111");
                }
            }
            else if (name == "ShipperPrice_Detail")
            {
                List<domain.ShipperPrice_Detail> trd = null;
                IShipperPrice_Detail isd = new IShipperPrice_Detail();
                json = data;
                trd = JsonConvert.DeserializeObject<List<domain.ShipperPrice_Detail>>(json);
                foreach (ShipperPrice_Detail item in trd)
                {
                    isd.Update(item);
                    Console.WriteLine("1111111111111111111");
                }
            }
            else if (name == "OilGasRegister_Detail")
            {
                List<domain.OilGasRegister_Detail> trd = null;
                OilGasRegister_DetailDAO isd = new OilGasRegister_DetailDAO();
                json = data;
                trd = JsonConvert.DeserializeObject<List<domain.OilGasRegister_Detail>>(json);
                foreach (OilGasRegister_Detail item in trd)
                {
                    isd.Update(item);
                    Console.WriteLine("1111111111111111111");
                }
            }
            else if (name == "TransportationClearing_Detail")
            {
                List<domain.TransportationClearing_Detail> trd = null;
                TransportationClearing_DetailDAO isd = new TransportationClearing_DetailDAO();
                json = data;
                trd = JsonConvert.DeserializeObject<List<domain.TransportationClearing_Detail>>(json);
                foreach (TransportationClearing_Detail item in trd)
                {
                    isd.Update(item);
                    Console.WriteLine("1111111111111111111");
                }
            }
        }
    }

    public class MainSave : WebSocketBehavior  //主表保存
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            try
            {
                GetClass(GetClassName.classname, e.Data);
            }
            catch (Exception ex)
            {
                Send(ex.Message);

            }
        }
        private void GetClass(string name, string data)
        {
            if (name == "StorageFormMain")
            {
                StorageFormMain sfm = JsonConvert.DeserializeObject<StorageFormMain>(data);
                IGoDownEntry gde = new IGoDownEntry();
                gde.Save(sfm);
                Console.WriteLine("主表保存成功！");
            }
            else if (name == "Outbound_Car")
            {
                Outbound_Car sfm = JsonConvert.DeserializeObject<Outbound_Car>(data);
                Outbound_CarDAO gde = new Outbound_CarDAO();
                gde.Save(sfm);
                Console.WriteLine("出库派车主表保存成功！");
            }

            else if (name == "StorageFormMainOut")
            {
                StorageFormMainOut sfm = JsonConvert.DeserializeObject<StorageFormMainOut>(data);
                IOutBoundOrder gde = new IOutBoundOrder();
                gde.Save(sfm);
                Console.WriteLine("主表保存成功！");
            }
            else if (name == "StorageFormMainTrans")
            {
                StorageFormMainTrans sfm = JsonConvert.DeserializeObject<StorageFormMainTrans>(data);
                IOutBoundOrderTrans gde = new IOutBoundOrderTrans();
                gde.Save(sfm);
            }
            else if (name == "TransportationRegister")
            {
                TransportationRegister sfm = JsonConvert.DeserializeObject<TransportationRegister>(data);
                ITransportationRegister gde = new ITransportationRegister();
                gde.Save(sfm);
            }
            else if (name == "FleetPrice")
            {
                FleetPrice sfm = JsonConvert.DeserializeObject<FleetPrice>(data);
                IFleetPrice gde = new IFleetPrice();
                gde.Save(sfm);
            }
            else if (name == "FleetPayment")
            {
                FleetPayment sfm = JsonConvert.DeserializeObject<FleetPayment>(data);
                IFleetPayment gde = new IFleetPayment();
                gde.Save(sfm);
            }
            else if (name == "ShipperPrice")
            {
                ShipperPrice sfm = JsonConvert.DeserializeObject<ShipperPrice>(data);
                IShipperPrice gde = new IShipperPrice();
                gde.Save(sfm);
            }
            else if (name == "OilGasRegister_Main")
            {
                OilGasRegister_Main sfm = JsonConvert.DeserializeObject<OilGasRegister_Main>(data);
                OilGasRegister_MainDAO gde = new OilGasRegister_MainDAO();
                gde.Save(sfm);
            }
            else if (name == "TransportationClearing_Main")
            {
                TransportationClearing_Main sfm = JsonConvert.DeserializeObject<TransportationClearing_Main>(data);
                TransportationClearing_MainDAO gde = new TransportationClearing_MainDAO();
                gde.Save(sfm);
            }
        }
    }
    public class MutiSave : WebSocketBehavior  //明细表保存
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            try
            {
                GetClass(GetClassName.classname, e.Data);
            }
            catch (Exception ex)
            {
                Send(ex.Message);
                // tran.Rollback();
            }
        }
        private void GetClass(string name, string data)
        {
            string json = null;
            if (name == "StorageDetails")
            {
                List<domain.StorageDetails> sd = null;
                IStorageDetail isd = new IStorageDetail();
                json = data;
                sd = JsonConvert.DeserializeObject<List<domain.StorageDetails>>(json);
                foreach (StorageDetails item in sd)
                {
                    isd.Save(item);
                    Console.WriteLine("1111111111111111111");
                }
            }
            else if (name == "Outbound_Car_Detail")
            {
                List<domain.Outbound_Car_Detail> sd = null;
                Outbound_Car_DetailDAO isd = new Outbound_Car_DetailDAO();
                json = data;
                sd = JsonConvert.DeserializeObject<List<domain.Outbound_Car_Detail>>(json);
                foreach (Outbound_Car_Detail item in sd)
                {
                    isd.Save(item);
                    Console.WriteLine("出库派车明细表保存成功！");
                }
            }

            else if (name == "StorageDetailsOut")
            {
                List<domain.StorageDetailsOut> sd = null;

                IOutBoundOrderDetails isd = new IOutBoundOrderDetails();
                json = data;
                sd = JsonConvert.DeserializeObject<List<domain.StorageDetailsOut>>(json);
                foreach (StorageDetailsOut item in sd)
                {
                    isd.Save(item);
                    Console.WriteLine("1111111111111111111");
                }
            }

            else if (name == "StorageDetailsTrans")
            {
                List<domain.StorageDetailsTrans> sd = null;

                IOutBoundOrderTransDetails isd = new IOutBoundOrderTransDetails();
                json = data;
                sd = JsonConvert.DeserializeObject<List<domain.StorageDetailsTrans>>(json);
                foreach (StorageDetailsTrans item in sd)
                {
                    isd.Save(item);
                    Console.WriteLine("1111111111111111111");
                }
            }
            else if (name == "TransportationRegister_Detail")
            {
                List<domain.TransportationRegister_Detail> sd = null;
                ITransportationRegister_Detail isd = new ITransportationRegister_Detail();
                json = data;
                sd = JsonConvert.DeserializeObject<List<domain.TransportationRegister_Detail>>(json);
                foreach (TransportationRegister_Detail item in sd)
                {
                    isd.Save(item);
                    Console.WriteLine("1111111111111111111");
                }
            }
            else if (name == "FleetPrice_Detail")
            {
                List<domain.FleetPrice_Detail> sd = null;
                IFleetPrice_Detail isd = new IFleetPrice_Detail();
                json = data;
                sd = JsonConvert.DeserializeObject<List<domain.FleetPrice_Detail>>(json);
                foreach (FleetPrice_Detail item in sd)
                {
                    isd.Save(item);
                    Console.WriteLine("1111111111111111111");
                }
            }
            else if (name == "FleetPayment_Detail")
            {
                List<domain.FleetPayment_Detail> sd = null;
                IFleetPayment_Detail isd = new IFleetPayment_Detail();
                json = data;
                sd = JsonConvert.DeserializeObject<List<domain.FleetPayment_Detail>>(json);
                foreach (FleetPayment_Detail item in sd)
                {
                    isd.Save(item);
                    Console.WriteLine("1111111111111111111");
                }
            }
            else if (name == "ShipperPrice_Detail")
            {
                List<domain.ShipperPrice_Detail> sd = null;
                IShipperPrice_Detail isd = new IShipperPrice_Detail();
                json = data;
                sd = JsonConvert.DeserializeObject<List<domain.ShipperPrice_Detail>>(json);
                foreach (ShipperPrice_Detail item in sd)
                {
                    isd.Save(item);
                    Console.WriteLine("1111111111111111111");
                }
            }
            else if (name == "TransportationClearing_Detail")
            {
                List<domain.TransportationClearing_Detail> sd = null;
                TransportationClearing_DetailDAO isd = new TransportationClearing_DetailDAO();
                json = data;
                sd = JsonConvert.DeserializeObject<List<domain.TransportationClearing_Detail>>(json);
                foreach (TransportationClearing_Detail item in sd)
                {
                    isd.Save(item);
                    Console.WriteLine("1111111111111111111");
                }
            }
            else if (name == "OilGasRegister_Detail")
            {
                List<domain.OilGasRegister_Detail> sd = null;
                OilGasRegister_DetailDAO isd = new OilGasRegister_DetailDAO();
                json = data;
                sd = JsonConvert.DeserializeObject<List<domain.OilGasRegister_Detail>>(json);
                foreach (OilGasRegister_Detail item in sd)
                {
                    isd.Save(item);
                    Console.WriteLine("1111111111111111111");
                }
            }
        }
    }


    public class GetField : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            string json = null;
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory())
            {
                ISession session = null;
                try
                {
                    session = sessionFactory.OpenSession();
                    json = GetClass(GetClassName.classname, session);
                    Console.WriteLine(e.Data);
                    Console.WriteLine(json);
                    Send(json);

                }
                catch (Exception ex)
                {
                    Send(ex.Message);
                }
                session.Close();
            }
        }

        private string GetClass(string name, ISession session)
        {
            string json = null;
            if (name == "StorageDetails")
            {
                List<domain.StorageDetails> sd = null;
                IStorageDetail isd = new IStorageDetail();
                IList<domain.StorageDetails> basic_set = session.QueryOver<domain.StorageDetails>().Skip(0).Take(0).List();
                json = JsonConvert.SerializeObject(basic_set);
            }

            if (name == "Outbound_Car_Detail")
            {
                IList<domain.Outbound_Car_Detail> basic_set = session.QueryOver<domain.Outbound_Car_Detail>().Skip(0).Take(0).List();
                json = JsonConvert.SerializeObject(basic_set);
            }

            else if (name == "StorageDetailsOut")
            {
                IOutBoundOrderDetails isd = new IOutBoundOrderDetails();
                IList<domain.StorageDetailsOut> basic_set = session.QueryOver<domain.StorageDetailsOut>().Skip(0).Take(0).List();
                json = JsonConvert.SerializeObject(basic_set);
            }

            else if (name == "StorageDetailsTrans")
            {
                IOutBoundOrderTransDetails isd = new IOutBoundOrderTransDetails();
                IList<domain.StorageDetailsTrans> basic_set = session.QueryOver<domain.StorageDetailsTrans>().Skip(0).Take(0).List();
                json = JsonConvert.SerializeObject(basic_set);
            }
            else if (name == "TransportationRegister_Detail")
            {
                IList<domain.TransportationRegister_Detail> basic_set = session.QueryOver<domain.TransportationRegister_Detail>().Skip(0).Take(0).List();
                json = JsonConvert.SerializeObject(basic_set);
            }
            else if (name == "FleetPrice_Detail")
            {
                IList<domain.FleetPrice_Detail> basic_set = session.QueryOver<domain.FleetPrice_Detail>().Skip(0).Take(0).List();
                json = JsonConvert.SerializeObject(basic_set);
            }
            else if (name == "FleetPayment_Detail")
            {
                IList<domain.FleetPayment_Detail> basic_set = session.QueryOver<domain.FleetPayment_Detail>().Skip(0).Take(0).List();
                json = JsonConvert.SerializeObject(basic_set);
            }
            else if (name == "ShipperPrice_Detail")
            {
                IList<domain.ShipperPrice_Detail> basic_set = session.QueryOver<domain.ShipperPrice_Detail>().Skip(0).Take(0).List();
                json = JsonConvert.SerializeObject(basic_set);
            }
            else if (name == "OilGasRegister_Detail")
            {
                IList<domain.OilGasRegister_Detail> basic_set = session.QueryOver<domain.OilGasRegister_Detail>().Skip(0).Take(0).List();
                json = JsonConvert.SerializeObject(basic_set);
            }
            else if (name == "TransportationClearing_Detail")
            {
                IList<domain.TransportationClearing_Detail> basic_set = session.QueryOver<domain.TransportationClearing_Detail>().Skip(0).Take(0).List();
                json = JsonConvert.SerializeObject(basic_set);
            }
            return json;
        }

    }



    public class NowPage : WebSocketBehavior //获取页码
    {
        public static string nowpage;
        protected override void OnMessage(MessageEventArgs e)
        {
            nowpage = e.Data;
        }
    }
    public class ShowData : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory())
            {
                ISession session = null;
                try
                {
                    session = sessionFactory.OpenSession();
                    string json = SwitchData(session, e.Data);

                    Console.WriteLine(e.Data);
                    Console.WriteLine(json);
                    Send(json);

                }
                catch (Exception ex)
                {

                    Send(ex.Message);
                }
                session.Close();
            }
        }


        public string SwitchData(ISession session, string s)
        {
            if (s == "Basic_Set")
            {
                // NowPage np = new NowPage();
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<Basic_Set> basic_set = session.QueryOver<Basic_Set>().Skip((page - 1) * 50).Take(50).List();
                string json = JsonConvert.SerializeObject(basic_set);
                return json;
            }

            else if (s == "Fund_Accounts")
            {
                IList<Fund_Accounts> fund_account = session.QueryOver<Fund_Accounts>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Internal_Vehicle")
            {
                IList<Internal_Vehicle> fund_account = session.QueryOver<Internal_Vehicle>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "External_Vehicle")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<External_Vehicle> basic_set = session.QueryOver<External_Vehicle>().Skip((page - 1) * 50).Take(50).List();
                string json = JsonConvert.SerializeObject(basic_set);
                return json;
            }
               
            else if (s == "Customer_File")
            {
                IList<Customer_File> fund_account = session.QueryOver<Customer_File>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }


            else if (s == "Office_Supply")
            {
                IList<Office_Supply> fund_account = session.QueryOver<Office_Supply>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Order_File")
            {
                IList<Order_File> fund_account = session.QueryOver<Order_File>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Repair_Material")
            {
                IList<Repair_Material> fund_account = session.QueryOver<Repair_Material>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Transportations")
            {
                IList<Transportations> fund_account = session.QueryOver<Transportations>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Variety_Texture")
            {
                IList<Variety_Texture> fund_account = session.QueryOver<Variety_Texture>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Warehouse_Space")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<Warehouse_Space> fund_account = session.QueryOver<Warehouse_Space>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Decorate")
            {
                IList<Decorate> fund_account = session.QueryOver<Decorate>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Discharge")
            {
                IList<Discharge> fund_account = session.QueryOver<Discharge>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Transportations")
            {
                IList<Transportations> fund_account = session.QueryOver<Transportations>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Warehouse_Staff")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<Warehouse_Staff> fund_account = session.QueryOver<Warehouse_Staff>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "StorageFormMain")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<StorageFormMain> fund_account = session.QueryOver<StorageFormMain>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(fund_account, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }

            else if (s == "Outbound_Car")
            {

                int page = Convert.ToInt32(NowPage.nowpage);
                IList<Outbound_Car> Outbound_Car = session.QueryOver<Outbound_Car>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(Outbound_Car, Formatting.None, new JsonSerializerSettings());
                return json;
            }
            else if (s == "StorageFormMainOut")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<StorageFormMainOut> fund_account = session.QueryOver<StorageFormMainOut>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(fund_account, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }

            else if (s == "StorageFormMainTrans")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<StorageFormMainTrans> fund_account = session.QueryOver<StorageFormMainTrans>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(fund_account, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }

            else if (s == "TransportationRegister")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<TransportationRegister> fund_account = session.QueryOver<TransportationRegister>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(fund_account, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }

            else if (s == "TransportationRegister_Detail")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<TransportationRegister_Detail> fund_account = session.QueryOver<TransportationRegister_Detail>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(fund_account, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }

            else if (s == "FleetPrice")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<FleetPrice> fund_account = session.QueryOver<FleetPrice>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(fund_account, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
            else if (s == "FleetPrice_Detail")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<FleetPrice_Detail> fund_account = session.QueryOver<FleetPrice_Detail>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(fund_account, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
            else if (s == "FleetPayment")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<FleetPayment> fund_account = session.QueryOver<FleetPayment>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(fund_account, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
            else if (s == "FleetPayment_Detail")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<FleetPayment_Detail> fund_account = session.QueryOver<FleetPayment_Detail>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(fund_account, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
            else if (s == "ShipperPrice")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<ShipperPrice> fund_account = session.QueryOver<ShipperPrice>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(fund_account, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
            else if (s == "ShipperPrice_Detail")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<ShipperPrice_Detail> fund_account = session.QueryOver<ShipperPrice_Detail>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(fund_account, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
            else if (s == "TransportationClearing_Main")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<TransportationClearing_Main> fund_account = session.QueryOver<TransportationClearing_Main>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(fund_account, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
            else if (s == "OilGasRegister_Main")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<OilGasRegister_Main> fund_account = session.QueryOver<OilGasRegister_Main>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(fund_account, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
            else if (s == "Car_Reimbursement")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<Car_Reimbursement> cr = session.QueryOver<Car_Reimbursement>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(cr);
                return json;
            }
            else if (s == "Driver_Check")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<Driver_Check> cr = session.QueryOver<Driver_Check>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(cr);
                return json;
            }


            else if (s == "User")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<domain.权限.User> cr = session.QueryOver<domain.权限.User>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(cr, Formatting.None, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }


            else if (s == "Role")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<domain.权限.Role> cr = session.QueryOver<domain.权限.Role>().Skip((page - 1) * 5).Take(5).List();
                string json = JsonConvert.SerializeObject(cr, Formatting.None, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }

            else
                return null;
        }
    }


    public class GetCount : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory())
            {
                try
                {
                    ISession session = sessionFactory.OpenSession();
                    long total = CountSwitch(e.Data, session);
                    Send(total.ToString());
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public long CountSwitch(string className, ISession session)
        {
            long total = 0;
            if (className == "Basic_Set")
            {
                total = session.QueryOver<Basic_Set>().RowCountInt64();
                return total;
            }
            else if (className == "Fund_Accounts")
            {
                total = session.QueryOver<Fund_Accounts>().RowCountInt64();
                return total;
            }
            else if (className == "Internal_Vehicle")
            {
                total = session.QueryOver<Internal_Vehicle>().RowCountInt64();
                return total;
            }
            else if (className == "Office_Supply")
            {
                total = session.QueryOver<Office_Supply>().RowCountInt64();
                return total;
            }
            else if (className == "Order_File")
            {
                total = session.QueryOver<Order_File>().RowCountInt64();
                return total;
            }
            else if (className == "Repair_Material")
            {
                total = session.QueryOver<Repair_Material>().RowCountInt64();
                return total;
            }
            else if (className == "Transportations")
            {
                total = session.QueryOver<Transportations>().RowCountInt64();
                return total;
            }
            else if (className == "Variety_Texture")
            {
                total = session.QueryOver<Variety_Texture>().RowCountInt64();
                return total;
            }
            else if (className == "Warehouse_Space")
            {
                total = session.QueryOver<Warehouse_Space>().RowCountInt64();
                return total;
            }
            else if (className == "Warehouse_Staff")
            {
                total = session.QueryOver<Warehouse_Staff>().RowCountInt64();
                return total;
            }
            else if (className == "Decorate")
            {
                total = session.QueryOver<Decorate>().RowCountInt64();
                return total;
            }
            else if (className == "Discharge")
            {
                total = session.QueryOver<Discharge>().RowCountInt64();
                return total;
            }
            else if (className == "Transportations")
            {
                total = session.QueryOver<Transportations>().RowCountInt64();
                return total;
            }
            else if (className == "StorageFormMain")
            {
                total = session.QueryOver<StorageFormMain>().RowCountInt64();
                return total;
            }

            else if (className == "StorageFormMainOut")
            {
                total = session.QueryOver<StorageFormMainOut>().RowCountInt64();
                return total;
            }
            else if (className == "StorageFormMainTrans")
            {
                total = session.QueryOver<StorageFormMainTrans>().RowCountInt64();
                return total;
            }
            else if (className == "TransportationRegister")
            {
                total = session.QueryOver<TransportationRegister>().RowCountInt64();
                return total;
            }
            else if (className == "TransportationRegister_Detail")
            {
                total = session.QueryOver<TransportationRegister_Detail>().RowCountInt64();
                return total;
            }
            else if (className == "FleetPrice")
            {
                total = session.QueryOver<FleetPrice>().RowCountInt64();
                return total;
            }
            else if (className == "FleetPrice_Detail")
            {
                total = session.QueryOver<FleetPrice_Detail>().RowCountInt64();
                return total;
            }
            else if (className == "FleetPayment")
            {
                total = session.QueryOver<FleetPayment>().RowCountInt64();
                return total;
            }
            else if (className == "FleetPayment_Detail")
            {
                total = session.QueryOver<FleetPayment_Detail>().RowCountInt64();
                return total;
            }
            else if (className == "ShipperPrice")
            {
                total = session.QueryOver<ShipperPrice>().RowCountInt64();
                return total;
            }
            else if (className == "ShipperPrice_Detail")
            {
                total = session.QueryOver<ShipperPrice_Detail>().RowCountInt64();
                return total;
            }
            else if (className == "TransportationClearing_Main")
            {
                total = session.QueryOver<TransportationClearing_Main>().RowCountInt64();
                return total;
            }
            else if (className == "TransportationClearing_Detail")
            {
                total = session.QueryOver<TransportationClearing_Detail>().RowCountInt64();
                return total;
            }
            else if (className == "OilGasRegister_Main")
            {
                total = session.QueryOver<OilGasRegister_Main>().RowCountInt64();
                return total;
            }
            else if (className == "OilGasRegister_Detail")
            {
                total = session.QueryOver<OilGasRegister_Detail>().RowCountInt64();
                return total;
            }
            else if (className == "Car_Reimbursement")
            {
                total = session.QueryOver<Car_Reimbursement>().RowCountInt64();
                return total;
            }
            else if (className == "Driver_Check")
            {
                total = session.QueryOver<Driver_Check>().RowCountInt64();
                return total;
            }

            else if (className == "User")
            {
                total = session.QueryOver<domain.权限.User>().RowCountInt64();
                return total;
            }

            else if (className == "Role")
            {
                total = session.QueryOver<domain.权限.Role>().RowCountInt64();
                return total;
            }
            return total;
        }
    }
    //*****************
    //服务器保存数据
    //*****************
    public class SaveData : WebSocketBehavior
    {

        protected override void OnMessage(MessageEventArgs e)
        {
            if (GetClassName.classname == "Basic_Set")
            {
                Basic_SetDAO bsd = new Basic_SetDAO();
                Basic_Set bs = new Basic_Set();
                bs = null;
                string tmp = null;
                tmp = e.Data;
                bs = JsonConvert.DeserializeObject<Basic_Set>(tmp);
                bsd.Save(bs);
            }
            else if (GetClassName.classname == "Car_Reimbursement")
            {
                try
                {
                    Car_ReimbursementDAO crd = new Car_ReimbursementDAO();
                    Car_Reimbursement cr = new Car_Reimbursement();
                    cr = null;
                    string tmp = null;
                    tmp = e.Data;
                    cr = JsonConvert.DeserializeObject<Car_Reimbursement>(tmp, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    crd.Save(cr);
                }
                catch (Exception)
                {
                    //  Console.WriteLine(w.Message);
                    throw;
                }

            }
            else if (GetClassName.classname == "Driver_Check")
            {
                try
                {
                    Driver_CheckDAO crd = new Driver_CheckDAO();
                    Driver_Check cr = new Driver_Check();
                    cr = null;
                    string tmp = null;
                    tmp = e.Data;
                    cr = JsonConvert.DeserializeObject<Driver_Check>(tmp, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    crd.Save(cr);
                }
                catch (Exception)
                {
                    //  Console.WriteLine(w.Message);
                    throw;
                }
            }

            else if (GetClassName.classname == "Warehouse_Staff")
            {
                try
                {
                    IWarehouse_Staff crd = new IWarehouse_Staff();
                    Warehouse_Staff cr = new Warehouse_Staff();
                    cr = null;
                    string tmp = null;
                    tmp = e.Data;
                    cr = JsonConvert.DeserializeObject<Warehouse_Staff>(tmp, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    crd.Save(cr);
                }
                catch (Exception)
                {
                    //  Console.WriteLine(w.Message);
                    throw;
                }
            }

            else if (GetClassName.classname == "Warehouse_Space")
            {
                try
                {
                    IWarehouse_Space crd = new IWarehouse_Space();
                    Warehouse_Space cr = new Warehouse_Space();
                    cr = null;
                    string tmp = null;
                    tmp = e.Data;
                    cr = JsonConvert.DeserializeObject<Warehouse_Space>(tmp, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    crd.Save(cr);
                }
                catch (Exception)
                {
                    //  Console.WriteLine(w.Message);
                    throw;
                }
            }

            else if (GetClassName.classname == "External_Vehicle")
            {
                try
                {
                    IExternalFleetDAO crd = new IExternalFleetDAO();
                    External_Vehicle cr = new External_Vehicle();
                    cr = null;
                    string tmp = null;
                    tmp = e.Data;
                    cr = JsonConvert.DeserializeObject<External_Vehicle>(tmp, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    crd.Save(cr);
                }
                catch (Exception)
                {
                    //  Console.WriteLine(w.Message);
                    throw;
                }
            }
        }


    }


    public class UpdateData : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            if (GetClassName.classname == "Basic_Set")
            {
                Basic_SetDAO bsd = new Basic_SetDAO();
                Basic_Set bs = new Basic_Set();
                bs = null;
                string tmp = null;
                tmp = e.Data;
                bs = JsonConvert.DeserializeObject<Basic_Set>(tmp);
                bsd.Update(bs);
            }
            else if (GetClassName.classname == "Car_Reimbursement")
            {
                Car_ReimbursementDAO bsd = new Car_ReimbursementDAO();
                Car_Reimbursement bs = new Car_Reimbursement();
                bs = null;
                string tmp = null;
                tmp = e.Data;
                bs = JsonConvert.DeserializeObject<Car_Reimbursement>(tmp);
                bsd.Update(bs);
            }
            else if (GetClassName.classname == "Driver_Check")
            {
                Driver_CheckDAO bsd = new Driver_CheckDAO();
                Driver_Check bs = new Driver_Check();
                bs = null;
                string tmp = null;
                tmp = e.Data;
                bs = JsonConvert.DeserializeObject<Driver_Check>(tmp);
                bsd.Update(bs);
            }

            else if (GetClassName.classname == "Warehouse_Space")
            {
                IWarehouse_Space bsd = new IWarehouse_Space();
                Warehouse_Space bs = new Warehouse_Space();
                bs = null;
                string tmp = null;
                tmp = e.Data;
                bs = JsonConvert.DeserializeObject<Warehouse_Space>(tmp);
                bsd.Update(bs);
            }

            else if (GetClassName.classname == "Warehouse_Staff")
            {
                IWarehouse_Staff bsd = new IWarehouse_Staff();
                Warehouse_Staff bs = new Warehouse_Staff();
                bs = null;
                string tmp = null;
                tmp = e.Data;
                bs = JsonConvert.DeserializeObject<Warehouse_Staff>(tmp);
                bsd.Update(bs);
            }

            else if (GetClassName.classname == "External_Vehicle")
            {
                IExternalFleetDAO bsd = new IExternalFleetDAO();
                External_Vehicle bs = new External_Vehicle();
                bs = null;
                string tmp = null;
                tmp = e.Data;
                bs = JsonConvert.DeserializeObject<External_Vehicle>(tmp);
                bsd.Update(bs);
            }
        }
    }

    public class DeleteData : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            if (GetClassName.classname == "Basic_Set")
            {
                Basic_SetDAO bs = new Basic_SetDAO();
                Guid ID = new Guid(e.Data);
                var basicset = bs.Get(ID);
                bs.Delete(basicset);
            }
            else if (GetClassName.classname == "Car_Reimbursement")
            {
                Car_ReimbursementDAO bs = new Car_ReimbursementDAO();
                string str = e.Data;
                var basicset = bs.Get<Car_Reimbursement>(str);
                bs.Delete(basicset);
            }
            else if (GetClassName.classname == "Driver_Check")
            {
                Driver_CheckDAO bs = new Driver_CheckDAO();
                string str = e.Data;
                var basicset = bs.Get<Driver_Check>(str);
                bs.Delete(basicset);
            }

            else if (GetClassName.classname == "Warehouse_Space")
            {
                IWarehouse_Space bs = new IWarehouse_Space();
                int str =Convert.ToInt32(e.Data);
                var basicset = bs.Get<Warehouse_Space>(str);
                bs.Delete(basicset);
            }

            else if (GetClassName.classname == "Warehouse_Staff")
            {
                IWarehouse_Staff bs = new IWarehouse_Staff();
                int str = Convert.ToInt32(e.Data);
                var basicset = bs.Get<Warehouse_Staff>(str);
                bs.Delete(basicset);
            }

            else if (GetClassName.classname == "External_Vehicle")
            {
                IExternalFleetDAO bs = new IExternalFleetDAO();
                int str = Convert.ToInt32(e.Data);
                var basicset = bs.Get<External_Vehicle>(str);
                bs.Delete(basicset);
            }
        }
    }

    public class DeleteMain : WebSocketBehavior //删除主表信息
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            string id = e.Data;
            switchDelete(GetClassName.classname, id);
        }

        public void switchDelete<T>(string classname, T id)
        {
            try
            {
                if (classname == "StorageFormMain")
                {
                    IGoDownEntry gde = new IGoDownEntry();
                    var godownentry = gde.Get<StorageFormMain>(id);
                    gde.Delete<StorageFormMain>((StorageFormMain)godownentry);
                }
                else if (classname == "OutBound_Car")
                {
                    Outbound_CarDAO gde = new Outbound_CarDAO();
                    var Outbound_Car = gde.Get<Outbound_Car>(id);
                    gde.Delete<Outbound_Car>((Outbound_Car)Outbound_Car);
                }
                else if (classname == "StorageFormMainOut")
                {
                    IOutBoundOrder gde = new IOutBoundOrder();
                    var godownentry = gde.Get<StorageFormMainOut>(id);
                    gde.Delete<StorageFormMainOut>((StorageFormMainOut)godownentry);
                }
                else if (classname == "StorageFormMainTrans")
                {
                    IOutBoundOrderTrans gde = new IOutBoundOrderTrans();
                    var godownentry = gde.Get<StorageFormMainTrans>(id);
                    gde.Delete<StorageFormMainTrans>((StorageFormMainTrans)godownentry);
                }
                else if (classname == "TransportaitonRegister")
                {
                    ITransportationRegister tr = new ITransportationRegister();
                    var godownentry = tr.Get<TransportationRegister>(id);
                    tr.Delete<TransportationRegister>((TransportationRegister)godownentry);
                }
                else if (classname == "FleetPrice")
                {
                    IFleetPrice tr = new IFleetPrice();
                    var godownentry = tr.Get<FleetPrice>(id);
                    tr.Delete<FleetPrice>((FleetPrice)godownentry);
                }
                else if (classname == "FleetPayment")
                {
                    IFleetPayment tr = new IFleetPayment();
                    var godownentry = tr.Get<FleetPayment>(id);
                    tr.Delete<FleetPayment>((FleetPayment)godownentry);
                }
                else if (classname == "ShipperPrice")
                {
                    IShipperPrice tr = new IShipperPrice();
                    var godownentry = tr.Get<ShipperPrice>(id);
                    tr.Delete<ShipperPrice>((ShipperPrice)godownentry);
                }
                else if (classname == "TransportationClearing_Main")
                {
                    TransportationClearing_MainDAO tcmd = new TransportationClearing_MainDAO();
                    var tcm = tcmd.Get<domain.TransportationClearing_Main>(id);
                    tcmd.Delete<domain.TransportationClearing_Main>((TransportationClearing_Main)tcm);
                }
                else if (classname == "OilGasRegister_Main")
                {
                    OilGasRegister_MainDAO tcmd = new OilGasRegister_MainDAO();
                    var tcm = tcmd.Get<domain.OilGasRegister_Main>(id);
                    tcmd.Delete<domain.OilGasRegister_Main>((OilGasRegister_Main)tcm);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }

    public class BatchSave : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            string dataString = e.Data;
            DataTable dt = null;
            dt = JsonConvert.DeserializeObject<DataTable>(dataString);
            if (GetClassName.classname == "TransportationRegister")
            {
                AddDataTableToDB(dt, "dbo.T_transportationRegister");
            }

            else if (GetClassName.classname == "StorageFormMain")
            {
                AddDataTableToDB(dt, "dbo.T_StorageFormMain");
            }

            else if (GetClassName.classname == "StorageFormMainOut")
            {
                AddDataTableToDB(dt, "dbo.T_StorageFormMainOut");
            }
            else if (GetClassName.classname == "StorageFormMainTrans")
            {
                AddDataTableToDB(dt, "dbo.T_StorageFormMainTrans");
            }
            else if (GetClassName.classname == "FleetPrice")
            {
                AddDataTableToDB(dt, "dbo.T_FleetPrice");
            }
            else if (GetClassName.classname == "FleetPayment")
            {
                AddDataTableToDB(dt, "dbo.T_FleetPayment");
            }
            else if (GetClassName.classname == "ShipperPrice")
            {
                AddDataTableToDB(dt, "dbo.T_ShipperPrice");
            }
            else if (GetClassName.classname == "TransportationClearing_Main")
            {
                AddDataTableToDB(dt, "dbo.T_TransportationClearing_Main");
            }
            else if (GetClassName.classname == "OilGasRegister_Main")
            {
                AddDataTableToDB(dt, "dbo.T_OilGasRegister_Main");
            }
            else if (GetClassName.classname == "Car_Reimbursement")
            {
                AddDataTableToDB(dt, "dbo.T_Car_Reimbursement");
            }
            else if (GetClassName.classname == "Driver_Check")
            {
                AddDataTableToDB(dt, "dbo.T_Driver_Check");
            }
        }

        public void AddDataTableToDB(DataTable dt, string dbName) //批量导入excel
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=sa123456;database=test;"))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        using (SqlBulkCopy copy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran))
                        {
                            copy.DestinationTableName = dbName;
                            copy.WriteToServer(dt);
                            tran.Commit();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
    }

    public class FindDetails : WebSocketBehavior //根据主表传明细
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory())
            {

                ISession session;
                string json = null;
                try
                {
                    session = sessionFactory.OpenSession();
                    json = SwitchDetail(session, GetClassName.classname, e.Data);//判断是那个明细表
                    Send(json);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public string SwitchDetail(ISession session, string classname, string primarykey)
        {

            string json = null;
            if (classname == "StorageDetails")
            {
                IList<domain.StorageDetails> sd = null;
                string sql = "select a.* from T_StorageFormMain b,T_StorageDetails a where a.StorageNumber =b.StorageNumber and a.StorageNumber= ? ";
                ISQLQuery query = session.CreateSQLQuery(sql)
                .AddEntity("StorageDetails", typeof(domain.StorageDetails));
                query.SetString(0, primarykey);
                sd = query.List<StorageDetails>();

                json = JsonConvert.SerializeObject(sd, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            else if (classname == "Outbound_Car_Detail")
            {

                int page = Convert.ToInt32(NowPage.nowpage);
                String sql = "select a.* from WL_sendcar b,WL_sendcar_detail a where a.order_num =b.order_num and a.order_num= ? ";
                ISQLQuery query = session.CreateSQLQuery(sql)
                .AddEntity("Outbound_Car_Detail", typeof(Outbound_Car_Detail));
                query.SetString(0, primarykey);
                IList<Outbound_Car_Detail> Outbound_Car_detail = query.List<Outbound_Car_Detail>();
                json = JsonConvert.SerializeObject(Outbound_Car_detail, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            else if (classname == "StorageDetailsOut")
            {
                IList<domain.StorageDetailsOut> sd = null;
                string sql = "select a.* from T_StorageFormMainOut b,T_StorageDetailsOut a where a.出库单号 =b.出库单号 and a.出库单号= ? ";
                ISQLQuery query = session.CreateSQLQuery(sql)
                .AddEntity("StorageDetailsOut", typeof(domain.StorageDetailsOut));
                query.SetString(0, primarykey);
                sd = query.List<StorageDetailsOut>();

                json = JsonConvert.SerializeObject(sd, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }

            else if (classname == "StorageDetailsTrans")
            {
                IList<domain.StorageDetailsTrans> sd = null;
                string sql = "select a.* from T_StorageFormMainTrans b,T_StorageDetailsTrans a where a.移库单号 =b.移库单号 and a.移库单号= ? ";
                ISQLQuery query = session.CreateSQLQuery(sql)
                .AddEntity("StorageDetailsTrans", typeof(domain.StorageDetailsTrans));
                query.SetString(0, primarykey);
                sd = query.List<StorageDetailsTrans>();

                json = JsonConvert.SerializeObject(sd, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }

            else if (classname == "TransportationRegister_Detail")
            {
                IList<domain.TransportationRegister_Detail> trd = null;
                string sql = "select a.* from T_TransportationRegister b,T_TransportationRegister_Detail a where a.transport_ID =b.transport_ID and a.transport_ID= ? ";
                ISQLQuery query = session.CreateSQLQuery(sql)
                .AddEntity("TransportationRegister_Detail", typeof(domain.TransportationRegister_Detail));
                query.SetString(0, primarykey);
                trd = query.List<TransportationRegister_Detail>();

                json = JsonConvert.SerializeObject(trd, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            else if (classname == "FleetPrice_Detail")
            {
                IList<domain.FleetPrice_Detail> trd = null;
                string sql = "select a.* from T_FleetPrice b,T_FleetPrice_Detail a where a.transport_ID =b.transport_ID and a.transport_ID= ? ";
                ISQLQuery query = session.CreateSQLQuery(sql)
                .AddEntity("FleetPrice_Detail", typeof(domain.FleetPrice_Detail));
                query.SetString(0, primarykey);
                trd = query.List<FleetPrice_Detail>();

                json = JsonConvert.SerializeObject(trd, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            else if (classname == "FleetPayment_Detail")
            {
                IList<domain.FleetPayment_Detail> trd = null;
                string sql = "select a.* from T_FleetPayment b,T_FleetPayment_Detail a where a.list_ID =b.list_ID and a.list_ID= ? ";
                ISQLQuery query = session.CreateSQLQuery(sql)
                .AddEntity("FleetPayment_Detail", typeof(domain.FleetPayment_Detail));
                query.SetString(0, primarykey);
                trd = query.List<FleetPayment_Detail>();

                json = JsonConvert.SerializeObject(trd, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            else if (classname == "ShipperPrice_Detail")
            {
                IList<domain.ShipperPrice_Detail> trd = null;
                string sql = "select a.* from T_ShipperPrice b,T_ShipperPrice_Detail a where a.price_ID =b.price_ID and a.price_ID= ? ";
                ISQLQuery query = session.CreateSQLQuery(sql)
                .AddEntity("ShipperPrice_Detail", typeof(domain.ShipperPrice_Detail));
                query.SetString(0, primarykey);
                trd = query.List<ShipperPrice_Detail>();

                json = JsonConvert.SerializeObject(trd, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            else if (classname == "TransportationClearing_Detail")
            {
                IList<domain.TransportationClearing_Detail> tcd = null;
                string sql = "select a.* from T_TransportationClearing_Main b,T_TransportationClearing_Detail a where a.结算单号 =b.结算单号 and a.结算单号= ? ";
                ISQLQuery query = session.CreateSQLQuery(sql)
                .AddEntity("TransportationClearing_Detail", typeof(domain.TransportationClearing_Detail));
                query.SetString(0, primarykey);
                tcd = query.List<TransportationClearing_Detail>();

                json = JsonConvert.SerializeObject(tcd, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            else if (classname == "OilGasRegister_Detail")
            {
                IList<domain.OilGasRegister_Detail> ogrd = null;
                string sql = "select a.* from T_OilGasRegister_Main b,T_OilGasRegister_Detail a where a.登记单号 =b.登记单号 and a.登记单号= ? ";
                ISQLQuery query = session.CreateSQLQuery(sql)
                .AddEntity("OilGasRegister_Detail", typeof(domain.OilGasRegister_Detail));
                query.SetString(0, primarykey);
                ogrd = query.List<OilGasRegister_Detail>();

                json = JsonConvert.SerializeObject(ogrd, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            return json;
        }
    }

    #region
    /// <summary>
    /// 查询值
    /// </summary>
    public class GetValLike : WebSocketBehavior
    {
        public static string input_val;
        protected override void OnMessage(MessageEventArgs e)
        {
            input_val = e.Data;
        }
    }


    /// <summary>
    /// 模糊查询服务器
    /// </summary>
    public class ShowDataLike : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory())
            {
                ISession session = null;
                try
                {
                    session = sessionFactory.OpenSession();
                    string json = SwitchDataLike(session, e.Data);
                    Console.WriteLine(e.Data);
                    Console.WriteLine(json);
                    Send(json);

                }
                catch (Exception ex)
                {

                    Send(ex.Message);
                }

                session.Close();
            }
        }

        public string SwitchDataLike(ISession session, string s)
        {
            if (s == "Basic_Set")
            {
                // NowPage np = new NowPage();
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<Basic_Set> basic_set = session.QueryOver<Basic_Set>().Skip((page - 1) * 50).Take(50).List();
                string json = JsonConvert.SerializeObject(basic_set);
                return json;
            }
            else if (s == "StorageFormMain")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                string input_val = GetValLike.input_val;
                String sql = "select c.* from T_StorageFormMain c where c.StorageNumber  like '%" + input_val + "%' or c.Storage  like '%" + input_val + "%'" +
                      "or c.StorageTime  like '%" + input_val + "%'or c.StorageWay  like '%" + input_val + "%' or c.StorageFleet  like '%" + input_val + "%' or c.CarNumber  like '%" + input_val + "%' " +
                      "or c.Driver  like '%" + input_val + "%'" +
                       "or c.TotalStorage  like '%" + input_val + "%'" +
                       "or c.LoadingCity  like '%" + input_val + "%'" +
                       "or c.LoadingSpot  like '%" + input_val + "%'" +
                       "or c.LoadingArea  like '%" + input_val + "%'" +
                       "or c.KeyBoarder  like '%" + input_val + "%'" +
                       "or c.KeyTime  like '%" + input_val + "%'" +
                       "or c.Modifier like '%" + input_val + "%'" +
                       "or c.ModifyTime  like '%" + input_val + "%'" +
                       "or c.StorageKeeper  like '%" + input_val + "%'" +
                       "or c.Craneman  like '%" + input_val + "%'" +
                       "or c.Loader  like '%" + input_val + "%'" +
                       "or c.Others  like '%" + input_val + "%'" +
                       "or c.UnLoadingSpot  like '%" + input_val + "%'" +
                       "or c.UnLoadingCity  like '%" + input_val + "%'" +
                       "or c.UnLoadingArea  like '%" + input_val + "%'" +
                       "or c.Statement  like '%" + input_val + "%'";
                ISQLQuery query = session.CreateSQLQuery(sql)
               .AddEntity("StorageFormMain", typeof(domain.StorageFormMain));
                IList<StorageFormMain> StorageFormMain = query.List<StorageFormMain>();
                string json = JsonConvert.SerializeObject(StorageFormMain, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
            // 出库派车 主表模糊查询 strat 2017-07-27 fairy
            else if (s == "Outbound_Car")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                string input_val = GetValLike.input_val;
                String sql = "select c.* from WL_sendcar c where c.order_num  like '%" + input_val + "%' or c.sendcar_num  like '%" + input_val + "%'" +
                      "or c.owner_unit  like '%" + input_val + "%'or c.warehouse_send  like '%" + input_val + "%' or c.deliver_quantity  like '%" + input_val + "%' or c.out_way  like '%" + input_val + "%' " +
                      "or c.oper_apart  like '%" + input_val + "%'" +
                       "or c.pay_unit  like '%" + input_val + "%'" +
                       "or c.cars  like '%" + input_val + "%'" +
                       "or c.carnum  like '%" + input_val + "%'" +
                       "or c.driver  like '%" + input_val + "%'" +
                       "or c.sendcar_staff  like '%" + input_val + "%'" +
                       "or c.sendcar_time  like '%" + input_val + "%'" +
                       "or c.unload_city  like '%" + input_val + "%'" +
                       "or c.unload_area  like '%" + input_val + "%'" +
                       "or c.unload_point  like '%" + input_val + "%'" +
                       "or c.packge  like '%" + input_val + "%'" +
                       "or c.is_close  like '%" + input_val + "%'" +
                       "or c.close_staff  like '%" + input_val + "%'" +
                       "or c.close_time  like '%" + input_val + "%'";
                ISQLQuery query = session.CreateSQLQuery(sql)
               .AddEntity("Outbound_Car", typeof(Outbound_Car));
                IList<Outbound_Car> Outbound_Car = query.List<Outbound_Car>();
                string json = JsonConvert.SerializeObject(Outbound_Car, Formatting.None, new JsonSerializerSettings());
                return json;
            }
            else if (s == "StorageFormMainOut")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                string input_val = GetValLike.input_val;
                String sql = "select c.* from T_StorageFormMainOut c where c.出库单号  like '%" + input_val + "%' or c.发货仓库  like '%" + input_val + "%'" +
                      "or c.出库日期  like '%" + input_val + "%'or c.货主  like '%" + input_val + "%' or c.付费单位  like '%" + input_val + "%' or c.出库总量  like '%" + input_val + "%' " +
                      "or c.仓储费  like '%" + input_val + "%'" +
                       "or c.实收金额  like '%" + input_val + "%'" +
                       "or c.未收仓储费  like '%" + input_val + "%'" +
                       "or c.收款完成  like '%" + input_val + "%'" +
                       "or c.出库方式  like '%" + input_val + "%'" +
                       "or c.车队  like '%" + input_val + "%'" +
                       "or c.车号  like '%" + input_val + "%'" +
                       "or c.司机 like '%" + input_val + "%'" +
                       "or c.库管  like '%" + input_val + "%'" +
                       "or c.吊车  like '%" + input_val + "%'" +
                       "or c.装卸工  like '%" + input_val + "%'" +
                       "or c.装卸工1  like '%" + input_val + "%'" +
                       "or c.发货人员  like '%" + input_val + "%'" +
                       "or c.登记时间  like '%" + input_val + "%'" +
                       "or c.修改人  like '%" + input_val + "%'" +
                       "or c.修改时间  like '%" + input_val + "%'" +
                       "or c.备注  like '%" + input_val + "%'" +
                       "or c.发装城市  like '%" + input_val + "%'" +
                       "or c.发装地点  like '%" + input_val + "%'" +
                       "or c.发装区域  like '%" + input_val + "%'" +
                       "or c.实际卸点  like '%" + input_val + "%'" +
                       "or c.卸货城市  like '%" + input_val + "%'" +
                       "or c.卸货区域  like '%" + input_val + "%'" +
                       "or c.收款人  like '%" + input_val + "%'" +
                       "or c.收款时间  like '%" + input_val + "%'";
                ISQLQuery query = session.CreateSQLQuery(sql)
               .AddEntity("StorageFormMainOut", typeof(domain.StorageFormMainOut));
                IList<StorageFormMainOut> StorageFormMain = query.List<StorageFormMainOut>();
                string json = JsonConvert.SerializeObject(StorageFormMain, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }

            else if (s == "StorageFormMainTrans")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                string input_val = GetValLike.input_val;
                String sql = "select c.* from T_StorageFormMainTrans c where c.移库单号  like '%" + input_val + "%' or c.仓库名称  like '%" + input_val + "%'" +
                      "or c.移库方式  like '%" + input_val + "%'or c.移出客户  like '%" + input_val + "%' or c.移入客户  like '%" + input_val + "%' or c.仓储费单位  like '%" + input_val + "%' " +
                      "or c.移库费单位  like '%" + input_val + "%'" +
                       "or c.记账日期  like '%" + input_val + "%'" +
                       "or c.移库总量  like '%" + input_val + "%'" +
                       "or c.移库单价  like '%" + input_val + "%'" +
                       "or c.移库金额  like '%" + input_val + "%'" +
                       "or c.录入员  like '%" + input_val + "%'" +
                       "or c.录入时间  like '%" + input_val + "%'" +
                       "or c.修改人 like '%" + input_val + "%'" +
                       "or c.修改时间  like '%" + input_val + "%'" +
                       "or c.库管  like '%" + input_val + "%'" +
                       "or c.吊车工  like '%" + input_val + "%'" +
                       "or c.装卸工1  like '%" + input_val + "%'" +
                       "or c.装卸工  like '%" + input_val + "%'" +
                       "or c.备注  like '%" + input_val + "%'";

                ISQLQuery query = session.CreateSQLQuery(sql)
               .AddEntity("StorageFormMainOut", typeof(domain.StorageFormMainTrans));
                IList<StorageFormMainTrans> StorageFormMain = query.List<StorageFormMainTrans>();
                string json = JsonConvert.SerializeObject(StorageFormMain, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
            else if (s == "Fund_Accounts")
            {
                IList<Fund_Accounts> fund_account = session.QueryOver<Fund_Accounts>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Internal_Vehicle")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                string input_val = GetValLike.input_val;
                String sql = "select c.* from T_Internal_Vehicle c where c.车队  like '%" + input_val + "%' or c.车号  like '%" + input_val + "%'" +
                      "or c.司机  like '%" + input_val + "%'";

                ISQLQuery query = session.CreateSQLQuery(sql)
               .AddEntity("Internal_Vehicle", typeof(domain.Internal_Vehicle));
                IList<Internal_Vehicle> fund_account = query.List<Internal_Vehicle>();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }

            else if (s == "External_Vehicle")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                string input_val = GetValLike.input_val;
                String sql = "select c.* from T_External_Vehicle c where c.车队  like '%" + input_val + "%' or c.车号  like '%" + input_val + "%'" +
                      "or c.司机  like '%" + input_val + "%'";

                ISQLQuery query = session.CreateSQLQuery(sql)
               .AddEntity("External_Exhicle", typeof(domain.External_Vehicle));
                IList<External_Vehicle> fund_account = query.List<External_Vehicle>();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }

            else if (s == "Customer_File")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                string input_val = GetValLike.input_val;
                String sql = "select c.* from T_Customer_File c where c.编号  like '%" + input_val + "%' or c.客户编号  like '%" + input_val + "%'" +
                      "or c.客户全程  like '%" + input_val + "%'" +
                      "or c.速查码  like '%" + input_val + "%'" +
                      "or c.地址  like '%" + input_val + "%'" +
                      "or c.开户行  like '%" + input_val + "%'" +
                      "or c.税号  like '%" + input_val + "%'" +
                      "or c.联系人  like '%" + input_val + "%'" +
                      "or c.电话  like '%" + input_val + "%'" +
                      "or c.客户类型1  like '%" + input_val + "%'";

                ISQLQuery query = session.CreateSQLQuery(sql)
               .AddEntity("Customer_File", typeof(domain.Customer_File));
                IList<Customer_File> fund_account = query.List<Customer_File>();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }

            else if (s == "Office_Supply")
            {
                IList<Office_Supply> fund_account = session.QueryOver<Office_Supply>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Order_File")
            {
                IList<Order_File> fund_account = session.QueryOver<Order_File>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Repair_Material")
            {
                IList<Repair_Material> fund_account = session.QueryOver<Repair_Material>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == " ")
            {
                IList<Transportations> fund_account = session.QueryOver<Transportations>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Variety_Texture")
            {
                IList<Variety_Texture> fund_account = session.QueryOver<Variety_Texture>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Warehouse_Space")
            {
                IList<Warehouse_Space> fund_account = session.QueryOver<Warehouse_Space>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Decorate")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                string input_val = GetValLike.input_val;
                String sql = "select c.* from T_Decorate c where c.编号  like '%" + input_val + "%' or c.装点  like '%" + input_val + "%'" +
                      "or c.所在城市  like '%" + input_val + "%'" +
                       "or c.所在区域  like '%" + input_val + "%'" +
                       "or c.说明  like '%" + input_val + "%'" +
                       "or c.联系人  like '%" + input_val + "%'" +
                       "or c.电话  like '%" + input_val + "%'" +
                       "or c.地址  like '%" + input_val + "%'";

                ISQLQuery query = session.CreateSQLQuery(sql)
               .AddEntity("Decorate", typeof(domain.Decorate));
                IList<Decorate> fund_account = query.List<Decorate>();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Discharge")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                string input_val = GetValLike.input_val;
                String sql = "select c.* from T_Discharge c where c.编号  like '%" + input_val + "%' or c.卸点  like '%" + input_val + "%'" +
                      "or c.所在城市  like '%" + input_val + "%'" +
                       "or c.所在区域  like '%" + input_val + "%'" +
                       "or c.说明  like '%" + input_val + "%'" +
                       "or c.联系人  like '%" + input_val + "%'" +
                       "or c.电话  like '%" + input_val + "%'" +
                       "or c.地址  like '%" + input_val + "%'";

                ISQLQuery query = session.CreateSQLQuery(sql)
               .AddEntity("Discharge", typeof(domain.Discharge));
                IList<Discharge> fund_account = query.List<Discharge>();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Transportations")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                string input_val = GetValLike.input_val;
                String sql = "select c.* from T_Transportations c where c.ID  like '%" + input_val + "%' or c.transportation_place  like '%" + input_val + "%'" +
                      "or c.city  like '%" + input_val + "%'" +
                       "or c.region  like '%" + input_val + "%'" +
                       "or c.statement  like '%" + input_val + "%'" +
                       "or c.linkman  like '%" + input_val + "%'" +
                       "or c.phone_number  like '%" + input_val + "%'" +
                       "or c.adress  like '%" + input_val + "%'";

                ISQLQuery query = session.CreateSQLQuery(sql)
               .AddEntity("Transportations", typeof(domain.Transportations));
                IList<Transportations> fund_account = query.List<Transportations>();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "Warehouse_Staff")
            {
                IList<Warehouse_Staff> fund_account = session.QueryOver<Warehouse_Staff>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }

            else if (s == "TransportationRegister")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                string input_val = GetValLike.input_val;
                String sql = "select c.* from T_TransportationRegister c where c.transport_ID  like '%" + input_val + "%' or c.tally_date  like '%" + input_val + "%'" +
                      "or c.transport_way  like '%" + input_val + "%'or c.fleet  like '%" + input_val + "%' or c.car_number  like '%" + input_val + "%' or c.driver  like '%" + input_val + "%' " +
                      "or c.transport_gross  like '%" + input_val + "%'" +
                       "or c.owner_freight  like '%" + input_val + "%'" +
                       "or c.car_fee  like '%" + input_val + "%'" +
                       "or c.depart_point  like '%" + input_val + "%'" +
                       "or c.ship_point  like '%" + input_val + "%'" +
                       "or c.unload_point  like '%" + input_val + "%'" +
                       "or c.depart_date  like '%" + input_val + "%'" +
                       "or c.back_date like '%" + input_val + "%'" +
                       "or c.depart_city  like '%" + input_val + "%'" +
                       "or c.ship_city  like '%" + input_val + "%'" +
                       "or c.unload_city  like '%" + input_val + "%'" +
                       "or c.depart_area  like '%" + input_val + "%'" +
                       "or c.ship_area  like '%" + input_val + "%'" +
                       "or c.unload_area  like '%" + input_val + "%'" +
                       "or c.autogeneration  like '%" + input_val + "%'" +
                       "or c.enter_staff  like '%" + input_val + "%'" +
                       "or c.enter_time  like '%" + input_val + "%'" +
                       "or c.change_staff  like '%" + input_val + "%'" +
                       "or c.change_time  like '%" + input_val + "%'" +
                       "or c.statement  like '%" + input_val + "%'";
                ISQLQuery query = session.CreateSQLQuery(sql)
               .AddEntity("TransportationRegister", typeof(domain.TransportationRegister));
                IList<TransportationRegister> TransportationRegister = query.List<TransportationRegister>();
                string json = JsonConvert.SerializeObject(TransportationRegister, Formatting.None, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
            else if (s == "FleetPrice")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                string input_val = GetValLike.input_val;
                String sql = "select c.* from T_FleetPrice c where c.transport_ID  like '%" + input_val + "%' or c.price_ID  like '%" + input_val + "%'" +
                      "or c.transport_gross  like '%" + input_val + "%'or c.car_fee  like '%" + input_val + "%' or c.payment  like '%" + input_val + "%' or c.fleet like '%" + input_val + "%' " +
                      "or c.car_number  like '%" + input_val + "%'" +
                       "or c.driver  like '%" + input_val + "%'" +
                       "or c.transport_way  like '%" + input_val + "%'" +
                       "or c.depart_point  like '%" + input_val + "%'" +
                       "or c.ship_point  like '%" + input_val + "%'" +
                       "or c.unload_point  like '%" + input_val + "%'" +
                       "or c.depart_date  like '%" + input_val + "%'" +
                       "or c.back_date like '%" + input_val + "%'" +
                       "or c.enter_staff  like '%" + input_val + "%'" +
                       "or c.enter_time  like '%" + input_val + "%'" +
                       "or c.change_staff  like '%" + input_val + "%'" +
                       "or c.change_time  like '%" + input_val + "%'" +
                       "or c.statement  like '%" + input_val + "%'";
                ISQLQuery query = session.CreateSQLQuery(sql)
               .AddEntity("FleetPrice", typeof(domain.FleetPrice));
                IList<FleetPrice> fund_account = query.List<FleetPrice>();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "FleetPayment")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                string input_val = GetValLike.input_val;
                String sql = "select c.* from T_FleetPayment c where c.list_ID  like '%" + input_val + "%' or c.fleet  like '%" + input_val + "%'" +
                      "or c.car_number  like '%" + input_val + "%'or c.transport_gross  like '%" + input_val + "%' or c.car_fee  like '%" + input_val + "%' or c.make_staff like '%" + input_val + "%' " +
                      "or c.make_time  like '%" + input_val + "%'" +
                       "or c.statement  like '%" + input_val + "%'";
                ISQLQuery query = session.CreateSQLQuery(sql)
               .AddEntity("FleetPayment", typeof(domain.FleetPayment));
                IList<FleetPayment> fund_account = query.List<FleetPayment>();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "ShipperPrice")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                string input_val = GetValLike.input_val;
                String sql = "select c.* from T_ShipperPrice c where c.owner  like '%" + input_val + "%' or c.order_number  like '%" + input_val + "%'" +
                      "or c.transport_way  like '%" + input_val + "%'or c.depart_point  like '%" + input_val + "%' or ship_point  like '%" + input_val + "%' or c.unload_pont like '%" + input_val + "%' " +
                      "or c.depart_date  like '%" + input_val + "%'" +
                       "or c.back_date  like '%" + input_val + "%'" +
                       "or c.reel_number  like '%" + input_val + "%'" +
                       "or c.variety  like '%" + input_val + "%'" +
                       "or c.texture  like '%" + input_val + "%'" +
                       "or c.standard  like '%" + input_val + "%'" +
                       "or c.number  like '%" + input_val + "%'" +
                       "or c.quantity like '%" + input_val + "%'" +
                       "or c.owner_fare  like '%" + input_val + "%'" +
                       "or c.owner_amount  like '%" + input_val + "%'" +
                       "or c.note  like '%" + input_val + "%'" +
                       "or c.fleet  like '%" + input_val + "%'" +
                       "or c.driver  like '%" + input_val + "%'" +
                       "or c.depart_city  like '%" + input_val + "%'" +
                       "or c.depart_area  like '%" + input_val + "%'" +
                       "or c.ship_city  like '%" + input_val + "%'" +
                       "or c.ship_area  like '%" + input_val + "%'" +
                       "or c.unload_city  like '%" + input_val + "%'" +
                       "or c.unload_area  like '%" + input_val + "%'" +
                       "or c.car_number  like '%" + input_val + "%'";
                ISQLQuery query = session.CreateSQLQuery(sql)
               .AddEntity("ShipperPrice", typeof(domain.ShipperPrice));
                IList<ShipperPrice> fund_account = query.List<ShipperPrice>();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            return null;
        }
    }
    #endregion

    
}