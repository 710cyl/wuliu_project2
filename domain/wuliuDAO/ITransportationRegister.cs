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
    public class ITransportationRegister : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public ITransportationRegister()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<TransportationRegister>(TransportationRegister entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<TransportationRegister>(TransportationRegister entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<TransportationRegister>(TransportationRegister entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<TransportationRegister>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.TransportationRegister>(id);
            }
        }

        public object Load<TransportationRegister>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.TransportationRegister>(id);
            }
        }
    }
}
