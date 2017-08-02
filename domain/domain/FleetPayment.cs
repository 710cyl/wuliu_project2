using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 车队付款主表
    /// </summary>
    public class FleetPayment
    {
        /// <summary>
        /// 清单号
        /// </summary>
        public virtual string list_ID { get; set; }
        /// <summary>
        /// 车队
        /// </summary>
        public virtual string fleet { get; set; }
        /// <summary>
        /// 车号
        /// </summary>
        public virtual string car_number { get; set; }
        /// <summary>
        /// 总运量
        /// </summary>
        public virtual decimal transport_gross { get; set; }
        /// <summary>
        ///总运费
        /// </summary>
        public virtual decimal car_fee { get; set; }
        /// <summary>
        /// 制单人员
        /// </summary>
        public virtual string make_staff { get; set; }
        /// <summary>
        /// 制单时间
        /// </summary>
        public virtual DateTime make_time { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public virtual string statement { get; set; }
        public virtual IList<FleetPayment_Detail> FleetPayment_Details { get; set; }
    }
}
