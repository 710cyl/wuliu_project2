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
    public class IVariety_TextureDAO : InterfaceDAO
    {
        private ISessionFactory sessionFactory;
        public IVariety_TextureDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }
        public object Save<Variety_Texture>(Variety_Texture entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update<Variety_Texture>(Variety_Texture entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Clear();
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete<Variety_Texture>(Variety_Texture entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<Variety_Texture>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.Variety_Texture>(id);
            }
        }

        public object Load<Variety_Texture>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.Variety_Texture>(id);
            }
        }
    }
}
