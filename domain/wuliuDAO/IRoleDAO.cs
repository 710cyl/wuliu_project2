﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using domain;
using Newtonsoft.Json;

namespace wuliuDAO
{
   public class IRoleDAO :InterfaceDAO
    {
        private ISessionFactory sessionFactory;

        public IRoleDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<Role>(Role entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<Role>(Role entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<Role>(Role entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<Role>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<Role>(id);
            }
        }

        public object Load<Role>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<Role>(id);
            }
        }

        void BatchSave(List<Basic_Set> record)
        {

        }
    }
}
