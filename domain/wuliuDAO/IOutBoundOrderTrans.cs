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
    /// 移库单 主表接口
    /// </summary>
    public class IOutBoundOrderTrans : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public IOutBoundOrderTrans()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<StorageFormMainTrans>(StorageFormMainTrans entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<StorageFormMainTrans>(StorageFormMainTrans entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<StorageFormMainTrans>(StorageFormMainTrans entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<StorageFormMainTrans>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.StorageFormMainTrans>(id);
            }
        }

        public object Load<StorageFormMainTrans>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.StorageFormMainTrans>(id);
            }
        }
    }
}
