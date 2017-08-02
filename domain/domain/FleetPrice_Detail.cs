using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 司机定价明细表
    /// </summary>
    public class FleetPrice_Detail
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public virtual string order_ID { get; set; }
        /// <summary>
        /// 货主
        /// </summary>
        public virtual string owner { get; set; }
        /// <summary>
        /// 卷号
        /// </summary>
        public virtual string reel_number { get; set; }
        /// <summary>
        /// 品种
        /// </summary>
        public virtual string variety { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        public virtual string texture { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public virtual string standard { get; set; }
        /// <summary>
        /// 件数
        /// </summary>
        public virtual int number { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public virtual decimal quantity { get; set; }
        /// <summary>
        /// 车队运价
        /// </summary>
        public virtual decimal car_fare { get; set; }
        /// <summary>
        /// 车队运费
        /// </summary>
        public virtual decimal car_fee { get; set; }
        /// <summary>
        /// 运输单标识
        /// </summary>
        public virtual string transport_identifying { get; set; }
        /// <summary>
        /// 业务部门
        /// </summary>
        public virtual string operating_department { get; set; }
        /// <summary>
        /// 业务员
        /// </summary>
        public virtual string salesman { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string note { get; set; }
        /// <summary>
        /// 运输单号
        /// </summary>
        public virtual string transport_ID { get; set; }
    }
}
