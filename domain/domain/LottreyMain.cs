using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{/// <summary>
/// 摇号——主表
/// </summary>
    public class LottreyMain
    {
        /// <summary>
        /// 摇号单号
        /// </summary>
        public virtual string LotteryNumber { set; get; }
        /// <summary>
        /// 车队
        /// </summary>
        public virtual string StorageFleet { set; get; }

        /// <summary>
        /// 车号
        /// </summary>
        public virtual string CarNumber { set; get; }

        /// <summary>
        /// 司机
        /// </summary>
        public virtual string Driver { set; get; }

        /// <summary>
        /// 中奖单号
        /// </summary>
        public virtual string WinNumber { set; get; }

        /// <summary>
        /// 中奖数量
        /// </summary>
        public virtual decimal WinQuantity { set; get; }

        /// <summary>
        /// 数据
        /// </summary>
        public virtual string data { set; get; }

        /// <summary>
        /// 时间
        /// </summary>
        public virtual DateTime time { set; get; }

        /// <summary>
        /// 一对多关系
        /// </summary>
        public virtual IList<LotteryDetails> LotteryDetails { set; get; }
    }
}
