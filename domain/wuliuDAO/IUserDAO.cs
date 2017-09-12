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
    /// 用户DAO层
    /// </summary>
    public class IUserDAO : InterfaceDAO
    {
        private ISessionFactory sessionFactory;

        public IUserDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<User>(User entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<User>(User entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<User>(User entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<User>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<User>(id);
            }
        }

        public object Load<User>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<User>(id);
            }
        }

        void BatchSave(List<Basic_Set> record)
        {

        }
    }
}
