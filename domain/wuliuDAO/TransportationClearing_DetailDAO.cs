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
    public class TransportationClearing_DetailDAO : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public TransportationClearing_DetailDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<TransportationClearing_Detail>(TransportationClearing_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<TransportationClearing_Detail>(TransportationClearing_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<TransportationClearing_Detail>(TransportationClearing_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<TransportationClearing_Detail>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.TransportationClearing_Detail>(id);
            }
        }

        public object Load<TransportationClearing_Detail>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.TransportationClearing_Detail>(id);
            }
        }
    }
}
