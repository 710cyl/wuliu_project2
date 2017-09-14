using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 货主定价明细表
    /// </summary>
    public class ShipperPrice_Detail
    {
        /// <summary>
        /// 货主
        /// </summary>
        public virtual string owner { get; set; }
        /// <summary>
        /// 运输单标识
        /// </summary>
        public virtual string transport_identifying { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public virtual string order_nubmer { get; set; }
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
        /// 货主运价
        /// </summary>
        public virtual decimal owner_fare { get; set; }
        /// <summary>
        /// 货主金额
        /// </summary>
        public virtual decimal owner_amount { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string note { get; set; }
        /// <summary>
        /// 车队
        /// </summary>
        public virtual string fleet { get; set; }
        /// <summary>
        /// 车号
        /// </summary>
        public virtual string car_number { get; set; }
        /// <summary>
        /// 司机
        /// </summary>
        public virtual string driver { get; set; }
        /// <summary>
        /// 出发城市
        /// </summary>
        public virtual string depart_city { get; set; }
        /// <summary>
        /// 出发区域
        /// </summary>
        public virtual string depart_area { get; set; }
        /// <summary>
        /// 装货城市
        /// </summary>
        public virtual string ship_city { get; set; }
        /// <summary>
        /// 装货区域
        /// </summary>
        public virtual string ship_area { get; set; }
        /// <summary>
        /// 卸货城市
        /// </summary>
        public virtual string unload_city { get; set; }
        /// <summary>
        /// 卸货区域
        /// </summary>
        public virtual string unload_area { get; set; }
        /// <summary>
        /// 定价单号
        /// </summary>
        public virtual string price_ID { get; set; }

    }
}
