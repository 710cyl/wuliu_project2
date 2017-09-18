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
    class ServerShipperPrice : WebSocketBehavior
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
                    String sql = "select a.* from T_ShipperPrice b,T_TransportationRegister_Detail a where a.transport_identifying =b.transport_identifying and a.transport_identifying = ?  ";
                    ISQLQuery query = session.CreateSQLQuery(sql);
                    query.SetString(0, e.Data);
                    IList<TransportationRegister_Detail> TransportationRegister = query.List<TransportationRegister_Detail>();
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
