using System;
//using System.Collections.Generic;
using Iesi.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NUnit.Framework;


namespace Basic_SetTest
{
    [TestFixture]
    public class NHibernateInit
    {
        [Test]
        public void InitTest()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory()) { }
        }
    }
}
