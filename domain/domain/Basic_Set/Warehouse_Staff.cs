using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{/// <summary>
/// 仓库人员
/// </summary>
  public  class Warehouse_Staff
    {
        /// <summary>
        /// 编号ID
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// 库管
        /// </summary>
        public virtual string inventory_keeper { get; set; }
        /// <summary>
        /// 吊车
        /// </summary>
        public virtual string crane { get; set; }
        /// <summary>
        /// 装卸工
        /// </summary>
        public virtual string loader { get; set; }
        /// <summary>
        /// 其他
        /// </summary>
        public virtual string other { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public virtual string statement { get; set; }
    }
}
