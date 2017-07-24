using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{/// <summary>
/// 仓库货位
/// </summary>
   public class Warehouse_Space
    {
        /// <summary>
        /// 编号ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public virtual string storage { get; set; }

        /// <summary>
        /// 垛位号
        /// </summary>
        public virtual string crib_number { get; set; }
        
        /// <summary>
        /// 说明
        /// </summary>
        public virtual string statement { get; set; }
    }
}
