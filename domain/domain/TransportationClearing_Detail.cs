using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 运输结算明细表
    /// </summary>
    public class TransportationClearing_Detail
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public virtual string order_id { get; set; }

        /// <summary>
        /// 装货地点
        /// </summary>
        public virtual string loading_place { get; set; }

        /// <summary>
        /// 卸货地点
        /// </summary>
        public virtual string landing_place { get; set; }

        /// <summary>
        /// 出发日期
        /// </summary>
        public virtual DateTime depart_date { get; set; }

        /// <summary>
        /// 返回日期
        /// </summary>
        public virtual DateTime return_date { get; set; }

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
        public virtual decimal standard { get; set; }

        /// <summary>
        /// 件数
        /// </summary>
        public virtual int unit_number { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public virtual decimal amount { get; set; }

        /// <summary>
        /// 运价
        /// </summary>
        public virtual decimal freight_rates { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public virtual decimal money { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string remark { get; set; }

        /// <summary>
        /// 运输单标识
        /// </summary>
        public virtual string transportation_logo { get; set; }

        /// <summary>
        /// 货主
        /// </summary>
        public virtual string shipper { get; set; }

        /// <summary>
        /// 结算单号  外键
        /// </summary>
        public virtual string clearing_id { get; set; }

    }
}
