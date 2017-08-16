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
    public class IFleetPrice_Detail : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public IFleetPrice_Detail()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<FleetPrice_Detail>(FleetPrice_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<FleetPrice_Detail>(FleetPrice_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<FleetPrice_Detail>(FleetPrice_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<FleetPrice_Detail>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.FleetPrice_Detail>(id);
            }
        }

        public object Load<FleetPrice_Detail>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.FleetPrice_Detail>(id);
            }
        }
    }
}
