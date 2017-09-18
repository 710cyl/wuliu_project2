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
    class ServerFleetPrice : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory())
            {
                ISession session = null;
                try
                {
                    string json = null;
                    session = sessionFactory.OpenSession();
                    String sql = "select a.* from T_FleetPayment b,T_FleetPrice a where a.price_ID =b.price_ID and a.price_ID = ?  ";
                    ISQLQuery query = session.CreateSQLQuery(sql);
                    query.SetString(0, e.Data);
                    IList<FleetPrice> TransportationRegister = query.List<FleetPrice>();
                    json = JsonConvert.SerializeObject(TransportationRegister, Formatting.None, new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                    Send(json);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
