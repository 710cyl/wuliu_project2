using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain.权限
{
    /// <summary>
    /// 角色组
    /// </summary>
    public class Role
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        public virtual int ID { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public virtual string rolename { get; set; }

        /// <summary>
        /// 派车模块
        /// </summary>
        public virtual string sendcar { get; set; }

        /// <summary>
        /// 仓库模块
        /// </summary>
        public virtual string storage { get; set; }

        /// <summary>
        /// 运输模块
        /// </summary>
        public virtual string transpotation { get; set; }

        /// <summary>
        /// 基础模块
        /// </summary>
        public virtual string basic { get; set; }

        /// <summary>
        /// 多对多 用户ID
        /// </summary>
        public virtual IList<domain.权限.User> User { get; set; }

    }
}
