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
    public class IExternalFleetDAO : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public IExternalFleetDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<External_Vehicle>(External_Vehicle entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<External_Vehicle>(External_Vehicle entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete<External_Vehicle>(External_Vehicle entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<External_Vehicle>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.External_Vehicle>(id);
            }
        }

        public object Load<External_Vehicle>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.External_Vehicle>(id);
            }
        }

    }
}
