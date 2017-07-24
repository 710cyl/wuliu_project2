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
    
    public class Basic_SetDAO : IBasic_SetDAO
    {
        private ISessionFactory sessionFactory;

        public Basic_SetDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save(domain.Basic_Set entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return id;
            }
        }

        public void Update(domain.Basic_Set entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Update(entity);
                session.Flush();
            }
        }

        public void Delete(domain.Basic_Set entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public domain.Basic_Set Get(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.Basic_Set>(id);
            }
                
        }
        public domain.Basic_Set Load(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.Basic_Set>(id);
            }
        }


        public IList<Basic_Set> LoadALL()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Query<domain.Basic_Set>().ToList();
            }
        }

        public void BatchSave(List<Basic_Set> records)
        {

            using (ISession session = sessionFactory.OpenSession())
            {
                using (ITransaction tran = session.BeginTransaction())
                {
                    try
                    {
                        session.SetBatchSize(50);
                        foreach (var obj in records)
                        {
                            //Basic_Set item = (Basic_Set)obj;
                            Basic_Set item = (Basic_Set)obj;
                            session.SaveOrUpdate(item);
                           session.Flush();
                        }
                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                    }
                }
            }
        }
    }
}
