using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 货主定价主表
    /// </summary>
    public class ShipperPrice
    {
        /// <summary>
        /// 定价单号
        /// </summary>
        public virtual string price_ID { get; set; }
        /// <summary>
        /// 总金额
        /// </summary>
        public virtual decimal total_money { get; set; }
        /// <summary>
        /// 登记人员
        /// </summary>
        public virtual string enter_staff { get; set; }
        /// <summary>
        /// 登记时间
        /// </summary>
        public virtual DateTime enter_time { get; set; }
        /// <summary>
        /// 修改人员
        /// </summary>
        public virtual string change_staff { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime change_time { get; set; }
        public virtual IList<ShipperPrice_Detail> ShipperPrice_Details { get; set; }
    }
}
