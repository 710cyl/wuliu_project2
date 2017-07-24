using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{/// <summary>
/// 外部车队
/// </summary>
  public  class External_Vehicle
    {
        /// <summary>
        /// 编号
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 车队
        /// </summary>
        public virtual string motorcade { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        public virtual string car_number { get; set; }

        /// <summary>
        /// 司机
        /// </summary>
        public virtual string car_driver { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public virtual string statement { get; set; }
    }
}
