using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 出车报销表
    /// </summary>
    public class Car_Reimbursement
    {
        /// <summary>
        /// 报销单号
        /// </summary>
        public virtual string reimbursement_id { get; set; }

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
        /// 登记人员
        /// </summary>
        public virtual string regist_man { get; set; }

        /// <summary>
        /// 付款人员
        /// </summary>
        public virtual string pay_man { get; set; }

        /// <summary>
        /// 录入时间
        /// </summary>
        public virtual DateTime input_time { get; set; }

        /// <summary>
        /// 付款时间
        /// </summary>
        public virtual DateTime pay_time { get; set; }

        /// <summary>
        /// 报销金额
        /// </summary>
        public virtual decimal reimbursement_money { get; set; }

        /// <summary>
        /// 是否付款
        /// </summary>
        public virtual string is_payment { get; set; }

        /// <summary>
        /// 付款账户编号
        /// </summary>
        public virtual string pay_account_id { get; set; }

        /// <summary>
        /// 付款账户
        /// </summary>
        public virtual string pay_account { get; set; }

        /// <summary>
        /// 报销内容
        /// </summary>
        public virtual string reimbursement_content { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string remark { get; set; }

    }
}
