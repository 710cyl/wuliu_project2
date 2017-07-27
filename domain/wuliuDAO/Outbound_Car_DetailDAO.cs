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
    
    public class Outbound_Car_DetailDAO : IOutbound_Car_DetailDAO
    {
        private ISessionFactory sessionFactory;

        public Outbound_Car_DetailDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save(domain.Outbound_Car_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var store_code = session.Save(entity);
                session.Flush();
                return store_code;
            }
        }

        public void Update(domain.Outbound_Car_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }
       

        public void Delete(domain.Outbound_Car_Detail entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public domain.Outbound_Car_Detail Get(object store_code)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.Outbound_Car_Detail>(store_code);
            }
                
        }
        public domain.Outbound_Car_Detail Load(object store_code)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.Outbound_Car_Detail>(store_code);
            }
        }


        public IList<Outbound_Car_Detail> LoadALL()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Query<domain.Outbound_Car_Detail>().ToList();
            }
        }

        public void BatchSave(List<Outbound_Car_Detail> records)
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
                            Outbound_Car_Detail item = (Outbound_Car_Detail)obj;
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
