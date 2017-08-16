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
       public  class IGoDownEntry : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public IGoDownEntry()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<StorageFormMain>(StorageFormMain entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<StorageFormMain>(StorageFormMain entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete<StorageFormMain>(StorageFormMain entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<StorageFormMain>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.StorageFormMain>(id);
            }
        }

        public object Load<StorageFormMain>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.StorageFormMain>(id);
            }
        }
    }
}
