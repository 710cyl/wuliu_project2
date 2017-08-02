using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 运输结算主表
    /// </summary>
    public class TransportationClearing_Main
    {
        /// <summary>
        /// 结算单号
        /// </summary>
        public virtual string clearing_id { get; set; }

        /// <summary>
        /// 登记人员
        /// </summary>
        public virtual string register_man { get; set; }

        /// <summary>
        /// 登记时间
        /// </summary>
        public virtual DateTime register_time { get; set; }

        /// <summary>
        /// 修改人员
        /// </summary>
        public virtual string modifier { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime modify_time { get; set; }

        /// <summary>
        /// 货主
        /// </summary>
        public virtual string shipper { get; set; }

        /// <summary>
        /// 货主全称
        /// </summary>
        public virtual string shipper_fullname { get; set; }

        /// <summary>
        /// 货主税号
        /// </summary>
        public virtual string shipper_TFN { get; set; }

        /// <summary>
        /// 付款单位
        /// </summary>
        public virtual string paycompany { get; set; }

        /// <summary>
        /// 付款单位全称
        /// </summary>
        public virtual string paycompany_fullname { get; set; }

        /// <summary>
        /// 付款单位税号
        /// </summary>
        public virtual string paycompany_TFN { get; set; }

        /// <summary>
        /// 开票单位
        /// </summary>
        public virtual string billcompany { get; set; }

        /// <summary>
        /// 开票单位全称
        /// </summary>
        public virtual string billcompany_fullname { get; set; }

        /// <summary>
        /// 开票单位税号
        /// </summary>
        public virtual string billcompany_TFN { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public virtual decimal total_money { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public virtual string explain { get; set; }

        /// <summary>
        /// 总运量
        /// </summary>
        public virtual decimal total_volume { get; set; }

        /// <summary>
        /// 运输结算详细表   列表
        /// </summary>
        public virtual IList<TransportationClearing_Detail> tcd { get; set; }
    }
}
