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
    public class ITransportationRegister_Detail : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public ITransportationRegister_Detail()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<TransportationRegister_Detail>(TransportationRegister_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<TransportationRegister_Detail>(TransportationRegister_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<TransportationRegister_Detail>(TransportationRegister_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<TransportationRegister_Detail>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.TransportationRegister_Detail>(id);
            }
        }

        public object Load<TransportationRegister_Detail>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.TransportationRegister_Detail>(id);
            }
        }
    }
}
