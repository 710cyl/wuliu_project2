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
    public class IDecorateDAO : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public IDecorateDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }
        public object Save<Decorate>(Decorate entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<Decorate>(Decorate entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete<Decorate>(Decorate entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<Decorate>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.Decorate>(id);
            }
        }

        public object Load<Decorate>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.Decorate>(id);
            }
        }
    }
}
