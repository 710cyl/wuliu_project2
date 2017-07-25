using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{/// <summary>
 /// 摇号——明细
 /// </summary>
    public class LotteryDetails
    {
        /// <summary>
        /// 打包单号
        /// </summary>
        public virtual string PackgingNumber { set; get; }

        /// <summary>
        /// 派车单数量
        /// </summary>
        public virtual int SendCarNumber { set; get; }

        /// <summary>
        /// 发货总量
        /// </summary>
        public virtual decimal storageToltal { set; get; }  
        
        /// <summary>
        /// 打包日期
        /// </summary>
        public virtual DateTime PackagingNumber { set; get; }

        /// <summary>
        /// 摇号单号
        /// </summary>
        public virtual decimal LotteryNumber { set; get; }
    }
}
