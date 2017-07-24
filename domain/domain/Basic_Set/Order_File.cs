using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 订单档案
    /// </summary>
  public  class Order_File
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public virtual int ID { get; set; }

        /// <summary>
        /// 货主
        /// </summary>
        public virtual string shipper { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string remarks { get; set; }

    }
}
