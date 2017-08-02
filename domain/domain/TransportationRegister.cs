using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 运输登记主表
    /// </summary>
    public class TransportationRegister
    {
        /// <summary>
        /// 运输单号
        /// </summary>
        public virtual string transport_ID { get; set; }
        /// <summary>
        /// 记账日期
        /// </summary>
        public virtual DateTime tally_date { get; set; }
        /// <summary>
        /// 运输方式
        /// </summary>
        public virtual string transport_way { get; set; }
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
        /// 运输总量
        /// </summary>
        public virtual decimal transport_gross { get; set; }
        /// <summary>
        /// 货主运费
        /// </summary>
        public virtual decimal owner_freight { get; set; }
        /// <summary>
        /// 车队运费
        /// </summary>
        public virtual decimal  car_fee { get; set; }
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
        /// 出发城市
        /// </summary>
        public virtual string depart_city { get; set; }
        /// <summary>
        /// 装货城市
        /// </summary>
        public virtual string ship_city { get; set; }
        /// <summary>
        /// 卸货城市
        /// </summary>
        public virtual string unload_city { get; set; }
        /// <summary>
        /// 出发区域
        /// </summary>
        public virtual string depart_area { get; set; }
        /// <summary>
        /// 装货区域
        /// </summary>
        public virtual string ship_area { get; set; }
        /// <summary>
        /// 卸货区域
        /// </summary>
        public virtual string unload_area { get; set; }
        /// <summary>
        /// 自动生成
        /// </summary>
        public virtual string autogeneration { get; set; }
        /// <summary>
        /// 录入人员
        /// </summary>
        public virtual string enter_staff { get; set; }
        /// <summary>
        /// 录入时间
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
        /// <summary>
        /// 说明
        /// </summary>
        public virtual string statement { get; set; }
        public virtual IList<TransportationRegister_Detail> TransportationRegister_Details { get; set; }
    }
}
