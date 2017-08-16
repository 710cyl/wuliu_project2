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
    public class IShipperPrice : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public IShipperPrice()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<ShipperPrice>(ShipperPrice entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<ShipperPrice>(ShipperPrice entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<ShipperPrice>(ShipperPrice entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<ShipperPrice>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.ShipperPrice>(id);
            }
        }

        public object Load<ShipperPrice>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.ShipperPrice>(id);
            }
        }
    }
}
