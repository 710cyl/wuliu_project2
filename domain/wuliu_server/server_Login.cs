using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocketSharp;
using WebSocketSharp.Server;
using NHibernate;
using domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using wuliuDAO;
using System.Data;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;

namespace wuliu_server
{
    /// <summary>
    /// 登录服务器
    /// </summary>
    public class server_Login :WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory())
            {
                ISession session = null;
                try
                {
                    session = sessionFactory.OpenSession();
                    IList<domain.权限.User> storageway = session.QueryOver<domain.权限.User>().Where(c => c.name == e.Data).List();
                    string storage_mode = JsonConvert.SerializeObject(storageway, Formatting.None, new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });

                    Send(storage_mode);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

    /// <summary>
    /// 添加用户
    /// </summary>
    public class server_adduser :WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            domain.权限.User users = new domain.权限.User();
            IUserDAO userDAO = new IUserDAO();
            users = JsonConvert.DeserializeObject<domain.权限.User>(e.Data);

            userDAO.Save(users);
        }
    }

    public class server_addrole : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            domain.权限.Role roles = new domain.权限.Role();
            IRoleDAO roleDAO = new IRoleDAO();
            roles = JsonConvert.DeserializeObject<domain.权限.Role>(e.Data);

            roleDAO.Save(roles);
        }
    }

    public class server_userrole : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure("Config/hibernate.cfg.xml");
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory())
            {
                ISession session = null;
                try
                {
                    session = sessionFactory.OpenSession();
                    IList<domain.权限.Role> storage = session.QueryOver<domain.权限.Role>().Where(o=>o.rolename == e.Data).List<domain.权限.Role>();
                    string storages = JsonConvert.SerializeObject(storage);

                    Send(storages);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
    /// <summary>
    /// 删除用户
    /// </summary>
    public class server_deleteUser : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            domain.权限.User user = new domain.权限.User();
            IUserDAO userDAO = new IUserDAO();
            var users = userDAO.Get<domain.权限.User>(Convert.ToInt32(e.Data));
            userDAO.Delete(users);
        }
    }
    /// <summary>
    /// 删除角色
    /// </summary>
    public class server_deleteRole : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            domain.权限.Role user = new domain.权限.Role();
            IRoleDAO userDAO = new IRoleDAO();
            var users = userDAO.Get<domain.权限.Role>(Convert.ToInt32(e.Data));
            userDAO.Delete(users);
        }
    }
}
