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
   public class ServerStorageDetails : WebSocketBehavior
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
                    IList<StorageDetails> storageway = session.QueryOver<StorageDetails>().List<StorageDetails>().Where(c =>c.StorageName ==e.Data).ToList();
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
