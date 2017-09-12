using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using domain;
using Newtonsoft.Json;

namespace wuliuDAO
{
    public class IWarehouse_Space :InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public IWarehouse_Space()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<Warehouse_Space>(Warehouse_Space entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<Warehouse_Space>(Warehouse_Space entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete<Warehouse_Space>(Warehouse_Space entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<Warehouse_Space>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.Warehouse_Space>(id);
            }
        }

        public object Load<Warehouse_Space>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.Warehouse_Space>(id);
            }
        }
    }
}
