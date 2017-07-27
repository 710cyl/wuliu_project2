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
   public class ILotteryMain : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public ILotteryMain()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<LottreyMain>(LottreyMain entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<LottreyMain>(LottreyMain entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<LottreyMain>(LottreyMain entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<LottreyMain>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.LottreyMain>(id);
            }
        }

        public object Load<LottreyMain>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.LottreyMain>(id);
            }
        }
    }
}
