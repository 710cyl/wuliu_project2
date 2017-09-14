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
    public class ITransportationsDAO : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public ITransportationsDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }
        public object Save<Transportations>(Transportations entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<Transportations>(Transportations entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete<Transportations>(Transportations entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<Transportations>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.Transportations>(id);
            }
        }

        public object Load<Transportations>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.Transportations>(id);
            }
        }
    }
}
