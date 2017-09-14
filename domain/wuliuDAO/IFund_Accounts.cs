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
    public class IFund_Accounts : InterfaceDAO
    {
        private ISessionFactory sessionFactory;

        public IFund_Accounts()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<Fund_Accounts>(Fund_Accounts entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<Fund_Accounts>(Fund_Accounts entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<Fund_Accounts>(Fund_Accounts entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<Fund_Accounts>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<Fund_Accounts>(id);
            }
        }

        public object Load<Fund_Accounts>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<Fund_Accounts>(id);
            }
        }

        void BatchSave(List<Fund_Accounts> record)
        {

        }
    }
}
