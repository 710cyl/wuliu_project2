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
    /// 出库单主表接口
    /// </summary>
    public class IOutBoundOrder : InterfaceDAO
    {
        private ISessionFactory sessionFactory;

        public IOutBoundOrder()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<StorageFormMainOut>(StorageFormMainOut entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<StorageFormMainOut>(StorageFormMainOut entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<StorageFormMainOut>(StorageFormMainOut entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<StorageFormMainOut>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.StorageFormMainOut>(id);
            }
        }

        public object Load<StorageFormMainOut>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.StorageFormMainOut>(id);
            }
        }
    }
}
