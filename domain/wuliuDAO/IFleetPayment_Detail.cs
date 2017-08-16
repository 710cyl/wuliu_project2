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
    public class IFleetPayment_Detail : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public IFleetPayment_Detail()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<FleetPayment_Detail>(FleetPayment_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<FleetPayment_Detail>(FleetPayment_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<FleetPayment_Detail>(FleetPayment_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<FleetPayment_Detail>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.FleetPayment_Detail>(id);
            }
        }

        public object Load<FleetPayment_Detail>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.FleetPayment_Detail>(id);
            }
        }
    }
}
