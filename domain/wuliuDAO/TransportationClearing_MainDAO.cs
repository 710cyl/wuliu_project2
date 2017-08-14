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
    public class TransportationClearing_MainDAO : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public TransportationClearing_MainDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<TransportationClearing_Main>(TransportationClearing_Main entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<TransportationClearing_Main>(TransportationClearing_Main entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<TransportationClearing_Main>(TransportationClearing_Main entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<TransportationClearing_Main>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.TransportationClearing_Main>(id);
            }
        }

        public object Load<TransportationClearing_Main>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.TransportationClearing_Main>(id);
            }
        }
    }
}
