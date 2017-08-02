using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 司机考核
    /// </summary>
    public class Driver_Check
    {
        /// <summary>
        /// 考核单号
        /// </summary>
        public virtual string check_id { get; set; }

        /// <summary>
        /// 考核类别
        /// </summary>
        public virtual string check_type { get; set; }

        /// <summary>
        /// 考核月份
        /// </summary>
        public virtual string check_month { get; set; }

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
        /// 考核金额
        /// </summary>
        public virtual decimal check_money { get; set; }

        /// <summary>
        /// 工资金额
        /// </summary>
        public virtual decimal salary_money { get; set; }

        /// <summary>
        /// 考核下达人
        /// </summary>
        public virtual string check_herald { get; set; }

        /// <summary>
        /// 录入人员
        /// </summary>
        public virtual string input_man { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        public virtual DateTime input_time { get; set; }

        /// <summary>
        /// 考核事由
        /// </summary>
        public virtual string check_reason { get; set; }

        /// <summary>
        /// 记账日期
        /// </summary>
        public virtual DateTime bookkeeping_time { get; set; }

    }
}
