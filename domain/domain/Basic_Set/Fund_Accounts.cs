using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 资金账号
    /// </summary>
  public  class Fund_Accounts
    {
        /// <summary>
        /// 编号
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 账户性质
        /// </summary>
        public virtual string account_property { get; set; }

        /// <summary>
        /// 账户名称
        /// </summary>
        public virtual string account_name { get; set; }

        /// <summary>
        /// 开户行
        /// </summary>
        public virtual string bank_deposit { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public virtual int account_number { get; set; }

        /// <summary>
        /// 期初余额
        /// </summary>
        public virtual decimal initial_balance { get; set; }

        /// <summary>
        /// 收款总额
        /// </summary>
        public virtual decimal collection_sum { get; set; }

        /// <summary>
        /// 付款总额
        /// </summary>
        public virtual decimal payment_sum { get; set; }

        /// <summary>
        /// 现余额
        /// </summary>
        public virtual decimal remaining_sum { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public virtual string statement { get; set; }
    }
}
