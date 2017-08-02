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
    public class Car_ReimbursementDAO : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public Car_ReimbursementDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<Car_Reimbursement>(Car_Reimbursement entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<Car_Reimbursement>(Car_Reimbursement entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete<Car_Reimbursement>(Car_Reimbursement entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<Car_Reimbursement>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.Car_Reimbursement>(id);
            }
        }

        public object Load<Car_Reimbursement>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.Car_Reimbursement>(id);
            }
        }
    }
}
