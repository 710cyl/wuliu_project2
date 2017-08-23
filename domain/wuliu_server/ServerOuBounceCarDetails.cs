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
    public class ServerOuBounceCarDetails :WebSocketBehavior
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
                    IList<Outbound_Car_Detail> storageway = session.QueryOver<Outbound_Car_Detail>().List<Outbound_Car_Detail>().Where(c => c.order_num == e.Data).ToList();
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
}
