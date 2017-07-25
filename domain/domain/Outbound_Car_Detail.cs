using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{/// <summary>
/// 出库派车明细
/// </summary>
   public class Outbound_Car_Detail
    {
        public static bool isExist;

        /// <summary>
        /// 入库标识码
        /// </summary>
        public virtual string store_code { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public virtual string order_num { get; set; }

        /// <summary>
        /// 入库性质
        /// </summary>
        public virtual string store_kind { get; set; }
        /// <summary>
        /// 入库日期
        /// </summary>
        public virtual DateTime store_date { get; set; }

       
        /// <summary>
        /// 项目号
        /// </summary>
        public virtual decimal pro_num { get; set; }
        /// <summary>
        /// 卷号
        /// </summary>
        public virtual string roll_num { get; set; }
        /// <summary>
        /// 品种
        /// </summary>
        public virtual string kind { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        public virtual string textures { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public virtual string norms { get; set; }

        /// <summary>
        /// 可派件数
        /// </summary>
        public virtual int piece { get; set; }
        /// <summary>
        /// 可派数量
        /// </summary>
        public virtual string out_num { get; set; }
        /// <summary>
        /// 拟发件数
        /// </summary>
        public virtual int retail_piece { get; set; }
        /// <summary>
        /// 拟发数量
        /// </summary>
        public virtual string retail_num { get; set; }
        /// <summary>
        /// 派车时间
        /// </summary>
        public virtual DateTime sendcar_time { get; set; }
        
        /// <summary>
        /// 订单卸城
        /// </summary>
        public virtual string order_city { get; set; }
        /// <summary>
        /// 订单卸区
        /// </summary>
        public virtual string order_area { get; set; }
        /// <summary> 
        /// 订单卸点
        /// </summary>
        public virtual string order_point { get; set; }

        /// <summary>
        /// 垛位号
        /// </summary>
        public virtual string crib_num { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public virtual string remark { get; set; }

       // public virtual Outbound_Car Outbound_Car { get; set; }

    }
}
