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
    
    public class Outbound_CarDAO : IOutbound_CarDAO
    {
        private ISessionFactory sessionFactory;

        public Outbound_CarDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save(domain.Outbound_Car entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var order_num = session.Save(entity);
                session.Flush();
                return order_num;
            }
        }

        public void Update(domain.Outbound_Car entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
              
            }
        }

        
        public void Delete<Outbound_Car>(Outbound_Car entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<Outbound_Car>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.Outbound_Car>(id);
            }
        }
        public domain.Outbound_Car Get(object order_num)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.Outbound_Car>(order_num);
            }
                
        }
        public domain.Outbound_Car Load(object order_num)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.Outbound_Car>(order_num);
            }
        }


        public IList<Outbound_Car> LoadALL()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Query<domain.Outbound_Car>().ToList();
            }
        }

        public void BatchSave(List<Outbound_Car> records)
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
                            Outbound_Car item = (Outbound_Car)obj;
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
