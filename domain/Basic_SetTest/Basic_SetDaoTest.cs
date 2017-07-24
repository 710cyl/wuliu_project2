using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using wuliuDAO;
namespace Basic_SetTest
{

    [TestFixture]
    class Basic_SetDaoTest
    {
        private IBasic_SetDAO basicsetDao;


        [SetUp]
        public void Init()
        {
            basicsetDao = new Basic_SetDAO();
        }

        [Test]
        public void SaveTest()
        {
            var basic = new domain.Basic_Set
            {
              //  ID = Guid.NewGuid()
        };
            var obj = this.basicsetDao.Save(basic);

            Assert.NotNull(obj);
        }

        [Test]
        public void UpdateTest()
        {
            var basic = this.basicsetDao.LoadALL().FirstOrDefault();
            Assert.NotNull(basic);

            basic.storage = "32123";

            Assert.AreEqual("32123", basic.storage);
        }

    }


}
