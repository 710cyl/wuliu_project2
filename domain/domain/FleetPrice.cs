using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 司机定价主表
    /// </summary>
    public class FleetPrice
    {
        /// <summary>
        /// 定价单号
        /// </summary>
        public virtual string price_ID { get; set; }
        /// <summary>
        /// 运输单号
        /// </summary>
        public virtual string transport_ID { get; set; }
        /// <summary>
        /// 总运量
        /// </summary>
        public virtual decimal transport_gross { get; set; }
        /// <summary>
        ///总运费
        /// </summary>
        public virtual decimal car_fee { get; set; }
        /// <summary>
        /// 是否付款
        /// </summary>
        public virtual string payment { get; set; }
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
        /// 登记人员
        /// </summary>
        public virtual string enter_staff { get; set; }
        /// <summary>
        /// 修改人员
        /// </summary>
        public virtual string change_staff { get; set; }
        /// <summary>
        /// 登记时间
        /// </summary>
        public virtual DateTime enter_time { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime change_time { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public virtual string statement { get; set; }
        public virtual IList<FleetPrice_Detail> FleetPrice_Details { get; set; }
    }
}
