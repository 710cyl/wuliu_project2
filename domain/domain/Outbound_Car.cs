using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{/// <summary>
/// 出库派车
/// </summary>
   public class Outbound_Car
    {

        /// <summary>
        /// 订单号
        /// </summary>
        public virtual string order_num { get; set; }

        /// <summary>
        /// 派车单号
        /// </summary>
        public virtual string sendcar_num { get; set; }
        /// <summary>
        /// 货主单位
        /// </summary>
        public virtual string owner_unit { get; set; }

        /// <summary>
        /// 发货仓库
        /// </summary>
        public virtual string warehouse_send { get; set; }
        /// <summary>
        /// 发货量
        /// </summary>
        public virtual decimal deliver_quantity { get; set; }
        /// <summary>
        /// 出货方式
        /// </summary>
        public virtual string out_way { get; set; }
        /// <summary>
        /// 业务部门
        /// </summary>
        public virtual string oper_apart { get; set; }
        /// <summary>
        /// 业务人员
        /// </summary>
        public virtual string oper_staff { get; set; }
        /// <summary>
        /// 付费单位
        /// </summary>
        public virtual string pay_unit { get; set; }

        /// <summary>
        /// 车队
        /// </summary>
        public virtual string cars { get; set; }
        /// <summary>
        /// 车号
        /// </summary>
        public virtual string carnum { get; set; }

        /// <summary>
        /// 司机
        /// </summary>
        public virtual string driver { get; set; }
        /// <summary>
        /// 派车人
        /// </summary>
        public virtual string sendcar_staff { get; set; }
        /// <summary>
        /// 派车时间
        /// </summary>
        public virtual DateTime sendcar_time { get; set; }
        /// <summary>
        /// 卸货城市
        /// </summary>
        public virtual string unload_city { get; set; }
        /// <summary>
        /// 卸货区域
        /// </summary>
        public virtual string unload_area { get; set; }
        /// <summary>
        /// 实际卸点
        /// </summary>
        public virtual string unload_point { get; set; }
        /// <summary>
        /// 打包
        /// </summary>
       public virtual string packge { get; set; }
        /// <summary>
        /// 关闭
        /// </summary>
       public virtual string is_close { get; set; }
        /// <summary>
        /// 关闭人
        /// </summary>
        public virtual string close_staff { get; set; }
        /// <summary>
        /// 关闭时间
        /// </summary>
        public virtual DateTime close_time { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public virtual string explain { get; set; }


        public virtual IList<Outbound_Car_Detail> Outbound_Car_Detail { get; set; }

    }
}
