using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{/// <summary>
 /// 车队付款明细表
 /// </summary>
    public class FleetPayment_Detail
    {
        /// <summary>
        /// 定价单号
        /// </summary>
        public virtual string price_ID { get; set; }
        /// <summary>
        /// 运输方式
        /// </summary>
        public virtual string transport_way { get; set; }
        /// <summary>
        /// 出发地点
        /// </summary>
        public virtual string depart_point { get; set; }
        /// <summary>
        /// 装货地点
        /// </summary>
        public virtual string ship_point { get; set; }
        /// <summary>
        /// 卸货地点
        /// </summary>
        public virtual string unload_point { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public virtual DateTime depart_date { get; set; }
        /// <summary>
        /// 返回日期
        /// </summary>
        public virtual DateTime back_date { get; set; }
        /// <summary>
        /// 运量
        /// </summary>
        public virtual decimal traffic { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public virtual decimal unit_price { get; set; }
        /// <summary>
        /// 运费
        /// </summary>
        public virtual decimal freight { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string note { get; set; }
        /// <summary>
        /// 运输单号
        /// </summary>
        public virtual string transport_ID { get; set; }
        /// <summary>
        /// 清单号
        /// </summary>
        public virtual string list_ID { get; set; }
    }
}
