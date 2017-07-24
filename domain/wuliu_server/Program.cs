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
                GetClass(GetClassName.classname,e.Data);
            }
            catch (Exception ex)
            {
                Send(ex.Message);
            }
        }

        private void GetClass(string name,string data)
        {
            if (name == "StorageFormMain")
            {
                StorageFormMain sfm = JsonConvert.DeserializeObject<StorageFormMain>(data);
                IGoDownEntry gde = new IGoDownEntry();
                gde.Update(sfm);
            }
        }
    }


    public class DetailsChange : WebSocketBehavior //修改明细服务器
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            
            try
            {
                GetClass(GetClassName.classname,e.Data);
            }
            catch (Exception ex)
            {
                Send(ex.Message);
                // tran.Rollback();
            }
        }

        private void GetClass(string name, string data)
        {
            List<domain.StorageDetails> sd = null;
            string json = null;
            IStorageDetail isd = new IStorageDetail();
            if (name == "StorageDetails")
            {
                json = data;
                sd = JsonConvert.DeserializeObject<List<domain.StorageDetails>>(json);
                foreach (StorageDetails item in sd)
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
                GetClass(GetClassName.classname,e.Data);
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
            }
        }
    }
    public class MutiSave : WebSocketBehavior  //明细表保存
    {
        protected override void OnMessage(MessageEventArgs e)
        {
                try
                {
                    GetClass(GetClassName.classname,e.Data);
                }
                catch (Exception ex)
                {
                    Send(ex.Message);
                // tran.Rollback();
            }
         }
        private void GetClass(string name, string data)
        {
            List<domain.StorageDetails> sd = null;
            string json = null;
            IStorageDetail isd = new IStorageDetail();
            if (name == "StorageDetails")
            {
                json = data;
                sd = JsonConvert.DeserializeObject<List<domain.StorageDetails>>(json);
                foreach (StorageDetails item in sd)
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
                    session.Close();
                    Send(ex.Message);
                }
            }
        }

        private string GetClass(string name, ISession session)
        {
            List<domain.StorageDetails> sd = null;
            string json = null;
            IStorageDetail isd = new IStorageDetail();
            if (name == "StorageDetails")
            {
                IList<domain.StorageDetails> basic_set = session.QueryOver<domain.StorageDetails>().Skip(0).Take(0).List();
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
    public class ShowData :WebSocketBehavior
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
                    string json = SwitchData(session,e.Data);

                    Console.WriteLine(e.Data);
                    Console.WriteLine(json);
                    Send(json);

                }
                catch (Exception ex)
                {
                    session.Close();
                    Send(ex.Message);
                }
            }
        }

 
       public string SwitchData(ISession session,string s)
        {
            if (s == "Basic_Set")
            {
               // NowPage np = new NowPage();
                int page = Convert.ToInt32(NowPage.nowpage);
               IList<Basic_Set> basic_set = session.QueryOver<Basic_Set>().Skip((page-1)*50).Take(50).List();
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
                IList<Warehouse_Space> fund_account = session.QueryOver<Warehouse_Space>().List();
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
                IList<Warehouse_Staff> fund_account = session.QueryOver<Warehouse_Staff>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }
            else if (s == "StorageFormMain")
            {
                int page = Convert.ToInt32(NowPage.nowpage);
                IList<StorageFormMain> fund_account = session.QueryOver<StorageFormMain>().Skip((page-1)*5).Take(5).List();
                string json = JsonConvert.SerializeObject(fund_account,Formatting.None,new JsonSerializerSettings()
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
                    long total = CountSwitch(e.Data,session);
                    Send(total.ToString());
                }
                catch (Exception)
                {
                    throw;
                }              
            }
        }

        public long CountSwitch(string className,ISession session)
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
            Basic_SetDAO bsd = new Basic_SetDAO();
            Basic_Set bs = new Basic_Set();
            bs = null;
            string tmp = null;
            tmp = e.Data;
            bs = JsonConvert.DeserializeObject<Basic_Set>(tmp);
            bsd.Save(bs);
        }
    }


    public class UpdateData : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Basic_SetDAO bsd = new Basic_SetDAO();
            Basic_Set bs = new Basic_Set();
            bs = null;
            string tmp = null;
            tmp = e.Data;
            bs = JsonConvert.DeserializeObject<Basic_Set>(tmp);
            bsd.Update(bs);
        }
    }

    public class DeleteData :WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Basic_SetDAO bs = new Basic_SetDAO();
            Guid ID = new Guid(e.Data);
            var basicset = bs.Get(ID);
            bs.Delete(basicset);
        }
    }

    public class DeleteMain : WebSocketBehavior //删除主表信息
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            string id = e.Data.ToString();
            switchDelete(GetClassName.classname,id);
        }

        public void switchDelete(string classname,string id )
        {
            try
            {
                if (classname == "StorageFormMain")
                {
                    IGoDownEntry gde = new IGoDownEntry();
                    var godownentry = gde.Get<StorageFormMain>(id);
                    gde.Delete<StorageFormMain>((StorageFormMain)godownentry);
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

        }

        public void AddDataTableToDB(DataTable dt,string dbName) //批量导入excel
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("server=localhost;uid=sa;pwd=sa123456;database=test;"))
                {
                    conn.Open();
                    using (SqlTransaction tran = conn.BeginTransaction())
                    {
                        using (SqlBulkCopy copy = new SqlBulkCopy(conn,SqlBulkCopyOptions.Default,tran))
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
                IList<domain.StorageDetails> sd = null;
                ISession session ;
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

        public string SwitchDetail(ISession session,string classname,string primarykey)
        {
            IList<domain.StorageDetails> sd = null;
            string json = null; 
            if (classname == "StorageDetails")
            {

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
            else if (true)
            {

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
                    session.Close();
                    Send(ex.Message);
                }
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
                IList<Warehouse_Space> fund_account = session.QueryOver<Warehouse_Space>().List();
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
                IList<Warehouse_Staff> fund_account = session.QueryOver<Warehouse_Staff>().List();
                string json = JsonConvert.SerializeObject(fund_account);
                return json;
            }

            else
                return null;
        }
    }
    #endregion
}
