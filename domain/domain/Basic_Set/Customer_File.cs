using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 客户档案
    /// </summary>
   public class Customer_File
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 客户简称
        /// </summary>
        public virtual string customer_name { get; set; }

        /// <summary>
        /// 客户全称
        /// </summary>
        public virtual string customer_fullname { get; set; }

        /// <summary>
        /// 速查码
        /// </summary>
        public virtual string quick_code { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public virtual string address { get; set; }

        /// <summary>
        /// 开户行
        /// </summary>
        public virtual string bank_deposit { get; set; }

        /// <summary>
        /// 税号
        /// </summary>
        public virtual string duty_number { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public virtual string linkman { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public virtual int phone_number { get; set; }

        /// <summary>
        /// 客户类型1——5
        /// </summary>
        public virtual string customer_type1 { get; set; }
        public virtual string customer_type2 { get; set; }
        public virtual string customer_type3 { get; set; }
        public virtual string customer_type4 { get; set; }
        public virtual string customer_type5 { get; set; }

    }
}
