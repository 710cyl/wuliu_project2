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
    public class OilGasRegister_MainDAO : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public OilGasRegister_MainDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save<OilGasRegister_Main>(OilGasRegister_Main entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<OilGasRegister_Main>(OilGasRegister_Main entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        public void Delete<OilGasRegister_Main>(OilGasRegister_Main entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<OilGasRegister_Main>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.OilGasRegister_Main>(id);
            }
        }

        public object Load<OilGasRegister_Main>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.OilGasRegister_Main>(id);
            }
        }
    }
}
