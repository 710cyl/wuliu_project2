using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 运输登记明细
    /// </summary>
    public class TransportationRegister_Detail
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
        /// 订单号
        /// </summary>
        public virtual string order_number { get; set; }
        /// <summary>
        /// 运输单标识
        /// </summary>
        public virtual string transport_identifying { get; set; }
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
        /// 毛重
        /// </summary>
        public virtual decimal rough_weight { get; set; }
        /// <summary>
        /// 车队运价
        /// </summary>
        public virtual decimal car_fare { get; set; }
        /// <summary>
        /// 车队运费
        /// </summary>
        public virtual decimal car_fee { get; set; }
        /// <summary>
        /// 货主运价
        /// </summary>
        public virtual decimal owner_fare { get; set; }
        /// <summary>
        /// 货主金额
        /// </summary>
        public virtual decimal owner_amount { get; set; }
        /// <summary>
        /// 已结算金额
        /// </summary>
        public virtual decimal settlement_amount { get; set; }
        /// <summary>
        /// 未结算金额
        /// </summary>
        public virtual decimal outstanding_amount { get; set; }
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
        /// 业务部门
        /// </summary>
        public virtual string operating_department { get; set; }
        /// <summary>
        /// 业务员
        /// </summary>
        public virtual string salesman { get; set; }
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
        /// 出发日期
        /// </summary>
        public virtual DateTime depart_date { get; set; }
        /// <summary>
        /// 返回日期
        /// </summary>
        public virtual DateTime back_date { get; set; }
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
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string note { get; set; }
    }
}
