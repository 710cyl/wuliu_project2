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
    /// <summary>
    /// 出库单明细接口
    /// </summary>
    public class IOutBoundOrderDetails : InterfaceDAO
    {
        private ISessionFactory sessionFactory;

        public IOutBoundOrderDetails()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<StorageDetailsOut>(StorageDetailsOut entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<StorageDetailsOut>(StorageDetailsOut entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<StorageDetailsOut>(StorageDetailsOut entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<StorageDetailsOut>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.StorageDetailsOut>(id);
            }
        }

        public object Load<StorageDetailsOut>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.StorageDetailsOut>(id);
            }
        }
    }
}
