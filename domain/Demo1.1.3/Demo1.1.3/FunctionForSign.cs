using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.ByteCode.Castle;
using domain;
using WebSocketSharp;
using Basic_SetTest;
using System.Threading;
using Newtonsoft.Json;
using System.Reflection;
using System.Data.OleDb;
using Newtonsoft.Json.Converters;
using Demo1._1._3.MyWorkBench_SkipForm;
using System.IO;
using DevExpress.XtraEditors;
using System.Drawing.Printing;

namespace Demo1._1._3
{
    /// <summary>
    /// 权限登录的功能代码
    /// </summary>
     public class FunctionForSign
    {
        private string IP = "localhost";
        private string Host = "9000";
        /// <summary>
        /// 获取用户信息用于校验密码等信息
        /// </summary>
        /// <returns>user类信息</returns>
        public domain.权限.User getPassword(string username)
        {
            string info = null;
            domain.权限.User user = new domain.权限.User();
            List<domain.权限.User> uselist = new List<domain.权限.User>();
            using (var ws = new WebSocket("ws://" + IP + ":" + Host + "/server_Login")) //////dwdwdw
            {
                ws.Connect();
                ws.Send(username);

                while (info == null)
                {
                    ws.OnMessage += (sender, e) =>
                    info = e.Data;
                    Thread.Sleep(500);
                }
                ws.Close();
                uselist = JsonConvert.DeserializeObject<List<domain.权限.User>>(info);
                user = uselist[0];
            }

            return user;
        }

        /// <summary>
        /// 回去权限
        /// </summary>
        /// <returns></returns>
        public IList<domain.权限.Role> getAuthority(string ID)
        {
            string info = null;
            //domain.权限.Role Auth = new domain.权限.Role();
            List<domain.权限.Role> uselist = new List<domain.权限.Role>();
            using (var ws = new WebSocket("ws://" + IP + ":" + Host + "/server_userrole")) 
            {
                ws.Connect();
                ws.Send(ID);

                while (info == null)
                {
                    ws.OnMessage += (sender, e) =>
                    info = e.Data;
                }
                ws.Close();
                uselist = JsonConvert.DeserializeObject<List<domain.权限.Role>>(info);
               // Auth = uselist[0];
            }
            return uselist;
        }

        public void saveUser(domain.权限.User user)
        {
            string json = JsonConvert.SerializeObject(user);
            using (var ws = new WebSocket("ws://" + IP + ":" + Host + "/server_adduser"))
            {
                ws.Connect();
                ws.Send(json);
                ws.Close();
            }
        }

        public void saveRole(domain.权限.Role role)
        {
            string json = JsonConvert.SerializeObject(role);
            using (var ws = new WebSocket("ws://" + IP + ":" + Host + "/server_addrole"))
            {
                ws.Connect();
                ws.Send(json);
                ws.Close();
            }
        }

       public void DeleteUser(string ID)
        {
            using (var ws = new WebSocket("ws://" + IP + ":" + Host + "/server_deleteUser"))
            {
                ws.Connect();
                ws.Send(ID);
                ws.Close();
            }
        }

        public void DeleteRole(string ID)
        {
            using (var ws = new WebSocket("ws://" + IP + ":" + Host + "/server_deleteRole"))
            {
                ws.Connect();
                ws.Send(ID);
                ws.Close();
            }
        }
    }
}
