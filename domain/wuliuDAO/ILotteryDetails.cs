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
    public class ILotteryDetails : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public ILotteryDetails()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<LotteryDetails>(LotteryDetails entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<LotteryDetails>(LotteryDetails entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete<LotteryDetails>(LotteryDetails entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<LotteryDetails>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.LotteryDetails>(id);
            }
        }

        public object Load<LotteryDetails>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.LotteryDetails>(id);
            }
        }
    }
}
