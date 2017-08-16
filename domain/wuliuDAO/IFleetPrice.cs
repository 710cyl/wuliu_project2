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
    public class IFleetPrice : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public IFleetPrice()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<FleetPrice>(FleetPrice entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<FleetPrice>(FleetPrice entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<FleetPrice>(FleetPrice entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<FleetPrice>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.FleetPrice>(id);
            }
        }

        public object Load<FleetPrice>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.FleetPrice>(id);
            }
        }
    }
}
