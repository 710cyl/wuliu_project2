using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{/// <summary>
/// 打包摇号
/// </summary>
   public class YaohaoPac
    {

        /// <summary>
        /// 打包单号
        /// </summary>
        public virtual string package_num { get; set; }

        /// <summary>
        /// 摇号状态
        /// </summary>
        public virtual string lottery_state { get; set; }

        /// <summary>
        /// 派车单数量
        /// </summary>
        public virtual string ordernum_num { get; set; }
        /// <summary>
        /// 发货总量
        /// </summary>
        public virtual decimal quantity_all { get; set; }
       
        /// <summary>
        /// 打包人
        /// </summary>
        public virtual string pac_staff { get; set; }
       
        /// <summary>
        /// 打包日期
        /// </summary>
        public virtual DateTime pac_time { get; set; }

        public virtual IList<Outbound_Car> Outbound_Car { get; set; }

    }
}
