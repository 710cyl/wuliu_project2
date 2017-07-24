using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace wuliuDAO
{
  public  class IStorageDetail : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public IStorageDetail()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<StorageDetails>(StorageDetails entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<StorageDetails>(StorageDetails entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<StorageDetails>(StorageDetails entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<StorageDetails>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.StorageDetails>(id);
            }
        }

        public object Load<StorageDetail>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.StorageDetails>(id);
            }
        }
    }
}
