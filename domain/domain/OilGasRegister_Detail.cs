using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 油气登记明细表
    /// </summary>
    public class OilGasRegister_Detail
    {
        /// <summary>
        ///  油气登记详细单号
        /// </summary>
        public virtual string OilGasRegister_Detail_Id { get; set; }

        /// <summary>
        /// 车队
        /// </summary>
        public virtual string motorcade { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public virtual string car_id { get; set; }

        /// <summary>
        /// 司机
        /// </summary>
        public virtual string driver { get; set; }

        /// <summary>
        /// 油气量
        /// </summary>
        public virtual Decimal oilgas_amount { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public virtual Decimal money { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string remark { get; set; }

        /// <summary>
        /// 加注日期
        /// </summary>
        public virtual DateTime fueling_date { get; set; }

        /// <summary>
        /// 油气种类
        /// </summary>
        public virtual string oilgas_type { get; set; }

        /// <summary>
        /// 油气单价
        /// </summary>
        public virtual string oilgas_unitprice { get; set; }

        /// <summary>
        /// 登记单号、、、、、、、、、、、、、
        /// </summary> 
        public virtual string register_id { get; set; }


    }
}
