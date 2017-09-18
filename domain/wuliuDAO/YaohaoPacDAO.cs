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
    
    public class YaohaoPacDAO : IYaohaoPacDAO
    {
        private ISessionFactory sessionFactory;

        public YaohaoPacDAO()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            sessionFactory = cfg.BuildSessionFactory();
        }

        public object Save(domain.YaohaoPac entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                var package_num = session.Save(entity);
                session.Flush();
                return package_num;
            }
        }

        public void Update(domain.YaohaoPac entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.SaveOrUpdate(entity);
                session.Flush();
              
            }
        }

        
        public void Delete<YaohaoPac>(YaohaoPac entity)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        public object Get<YaohaoPac>(object id)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.YaohaoPac>(id);
            }
        }
        public domain.YaohaoPac Get(object order_num)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Get<domain.YaohaoPac>(order_num);
            }
                
        }
        public domain.YaohaoPac Load(object order_num)
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Load<domain.YaohaoPac>(order_num);
            }
        }


        public IList<YaohaoPac> LoadALL()
        {
            using (ISession session = sessionFactory.OpenSession())
            {
                return session.Query<domain.YaohaoPac>().ToList();
            }
        }

        public void BatchSave(List<YaohaoPac> records)
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
                            YaohaoPac item = (YaohaoPac)obj;
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
