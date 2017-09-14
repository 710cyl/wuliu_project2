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
     public class ICustomerFile : InterfaceDAO
    {
        private ISessionFactory sessionFactory;

        public ICustomerFile()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<Customer_File>(Customer_File entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<Customer_File>(Customer_File entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<Customer_File>(Customer_File entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<Customer_File>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<Customer_File>(id);
            }
        }

        public object Load<Customer_File>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<Customer_File>(id);
            }
        }

        void BatchSave(List<Customer_File> record)
        {

        }
    }
}
