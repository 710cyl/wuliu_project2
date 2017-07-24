using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using domain;
namespace wuliuDAO
{
    class Internal_VehicleDAO :IInternal_VehicleDAO
    {
        private ISessionFactory sessionFactory;

        public Internal_VehicleDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save(Internal_Vehicle entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

       public void Update(Internal_Vehicle entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete(Internal_Vehicle entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public domain.Internal_Vehicle Get(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<Internal_Vehicle>(id);
            }

        }
        public domain.Internal_Vehicle Load(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.Internal_Vehicle>(id);
            }
        }


        public IList<Internal_Vehicle> LoadALL()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Query<Internal_Vehicle>().ToList();
            }
        }
    }
}
