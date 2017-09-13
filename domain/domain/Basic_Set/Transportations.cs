﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{/// <summary>
/// 集运卸点
/// </summary>
   public class Transportations
    {
        /// <summary>
        /// 编号
        /// </summary>
        public virtual int ID { get; set; }
        /// <summary>
        /// 集运卸点
        /// </summary>
        public virtual string transportation_place { get; set; }

        /// <summary>
        /// 所在城市
        /// </summary>
        public virtual string city { get; set; }
        /// <summary>
        /// 所在区域
        /// </summary>
        public virtual string region { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public virtual string statement { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public virtual string linkman { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public virtual string phone_number { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public virtual string adress { get; set; }
    }
}
