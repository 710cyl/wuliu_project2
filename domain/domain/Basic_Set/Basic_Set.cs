using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 基本系统
    /// </summary>
    public class Basic_Set
    {
        ///<summary>
        ///编号
        ///</summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 岗位性质
        /// </summary>
        public virtual string position_Set { get; set; }

        /// <summary>
        /// 应收账款
        /// </summary>
        public virtual decimal account_Receive { get; set; }

        /// <summary>
        /// 应付账款
        /// </summary>
        public virtual decimal account_Pay { get; set; }

        /// <summary>
        /// 入库方式
        /// </summary>
        public virtual string storage_Mode { get; set; }

        /// <summary>
        /// 出库方式
        /// </summary>
        public virtual string outStorage_Mode { get; set; }

        /// <summary>
        /// 运输方式
        /// </summary>
        public virtual string transportation_Mode { get; set; }

        /// <summary>
        /// 岗位性质
        /// </summary>
        public virtual string post_Property { get; set; }

        /// <summary>
        /// 借款性质
        /// </summary>
        public virtual string borrow_Property { get; set; }

        /// <summary>
        /// 客户类型
        /// </summary>
        public virtual string customer_Type { get; set; }

        /// <summary>
        /// 费用类型
        /// </summary>
        public virtual string expense_Category { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public virtual string nationality { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public virtual string storage { get; set; }

        /// <summary>
        /// 报销类型
        /// </summary>
        public virtual string refund_Mode { get; set; }

        /// <summary>
        /// 油气类型
        /// </summary>
        public virtual string oil_Varirety { get; set; }
    }
}
