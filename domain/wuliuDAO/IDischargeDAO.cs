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
    public class IDischargeDAO : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public IDischargeDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<Discharge>(Discharge entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<Discharge>(Discharge entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete<Discharge>(Discharge entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<Discharge>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.Discharge>(id);
            }
        }

        public object Load<Discharge>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.Discharge>(id);
            }
        }
    }
}
