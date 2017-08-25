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

/// <summary>
/// 控件combobox 的相关服务器
/// </summary>
namespace wuliu_server
{
    public class server_combobox
    {
    }

    /// <summary>
    /// 基础——入库方式
    /// </summary>
    public class Combobox_StorageWay : WebSocketBehavior
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
                    IList<string> storageway = session.QueryOver<Basic_Set>().List<Basic_Set>().Select(c => c.storage_Mode).Distinct().ToList<string>();
                    string storage_mode = JsonConvert.SerializeObject(storageway);

                    Send(storage_mode);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

    /// <summary>
    /// 基础——仓库名称
    /// </summary>
    public class Combobox_StorageName : WebSocketBehavior
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
                    IList<string> storage = session.QueryOver<Basic_Set>().List<Basic_Set>().Select(c => c.storage).Distinct().ToList<string>();
                    string storages = JsonConvert.SerializeObject(storage);

                    Send(storages);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }


    /// <summary>
    /// 仓库档案——仓库人员——装卸工
    /// </summary>
    public class Combobox_Loader : WebSocketBehavior
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
                    IList<string> storage = session.QueryOver<Warehouse_Staff>().List<Warehouse_Staff>().Select(c => c.loader).Distinct().ToList<string>();
                    string storages = JsonConvert.SerializeObject(storage);

                    Send(storages);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

    /// <summary>
    /// 仓库档案——仓库人员——库管
    /// </summary>
    public class Combobox_keeper :WebSocketBehavior
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
                    IList<string> storage = session.QueryOver<Warehouse_Staff>().List<Warehouse_Staff>().Select(c => c.inventory_keeper).Distinct().ToList<string>();
                    string storages = JsonConvert.SerializeObject(storage);

                    Send(storages);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

    /// <summary>
    /// 仓库档案——仓库人员——吊车
    /// </summary>
    public class Combobox_Crane :WebSocketBehavior
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
                    IList<string> storage = session.QueryOver<Warehouse_Staff>().List<Warehouse_Staff>().Select(c => c.crane).Distinct().ToList<string>();
                    string storages = JsonConvert.SerializeObject(storage);

                    Send(storages);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

    /// <summary>
    /// 垛位号
    /// </summary>
    public class Combobox_CraneNumber : WebSocketBehavior
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
                    IList<string> storage = session.QueryOver<Warehouse_Space>().List<Warehouse_Space>().Select(c => c.crib_number).Distinct().ToList<string>();
                    string storages = JsonConvert.SerializeObject(storage);

                    Send(storages);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }


    /// <summary>
    /// 品种
    /// </summary>
    public class Combobox_Variety : WebSocketBehavior
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
                    IList<string> storage = session.QueryOver<Variety_Texture>().List<Variety_Texture>().Select(c => c.variety).Distinct().ToList<string>();
                    string storages = JsonConvert.SerializeObject(storage);

                    Send(storages);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

    /// <summary>
    /// 材质
    /// </summary>
    public class Combobox_Texture : WebSocketBehavior
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
                    IList<string> storage = session.QueryOver<Variety_Texture>().List<Variety_Texture>().Select(c => c.texture).Distinct().ToList<string>();
                    string storages = JsonConvert.SerializeObject(storage);

                    Send(storages);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }


    /// <summary>
    /// 基础——报销类型（报销内容）
    /// </summary>
    public class Combobox_refundMode : WebSocketBehavior
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
                    IList<string> rm_IList = session.QueryOver<Basic_Set>().List<Basic_Set>().Select(c => c.refund_Mode).Distinct().ToList<string>();
                    string refund_Mode_string = JsonConvert.SerializeObject(rm_IList);
                    Send(refund_Mode_string);
                }
                catch (Exception)
                {
                    throw;
                }        
            }
        }

    }
    /// <summary>
    /// 运输方式
    /// </summary>
    public class Combobox_Transportation : WebSocketBehavior
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
                    IList<string> storage = session.QueryOver<Basic_Set>().List<Basic_Set>().Select(c => c.transportation_Mode).Distinct().ToList<string>();
                    string storages = JsonConvert.SerializeObject(storage);
                    Send(storages);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

    /// <summary>
    /// 基础——油气类型（油气种类）
    /// </summary>
    public class Combobox_oilVariety : WebSocketBehavior
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
                    IList<string> rm_IList = session.QueryOver<Basic_Set>().List<Basic_Set>().Select(c => c.oil_Varirety).Distinct().ToList<string>();
                    string refund_Mode_string = JsonConvert.SerializeObject(rm_IList);

                    Send(refund_Mode_string);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
