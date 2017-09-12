using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.权限
{
    /// <summary>
    /// 用户组
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public virtual int ID {get;set;}

        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string name { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public virtual string password { get; set; }

        /// <summary>
        /// 多对多 角色ID
        /// </summary>
        public virtual IList<domain.权限.Role> Role { get; set; }
    }
}
