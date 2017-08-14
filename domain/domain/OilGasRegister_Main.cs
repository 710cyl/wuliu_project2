using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 油气登记主表
    /// </summary>
    public class OilGasRegister_Main
    {
        /// <summary>
        /// 登记单号
        /// </summary>
        public virtual string register_id { get; set; }

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
        public virtual Decimal oilgas_unitprice { get; set; }

        /// <summary>
        /// 登记人
        /// </summary>
        public virtual string register_man { get; set; }

        /// <summary>
        /// 登记时间
        /// </summary>
        public virtual DateTime register_time { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public virtual string modifier { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime modify_time { get; set; }

        //一对多(需要隐藏)
        public virtual IList<OilGasRegister_Detail> ogrd { get; set; }
    }
}
