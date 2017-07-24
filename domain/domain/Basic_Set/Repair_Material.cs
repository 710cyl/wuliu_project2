using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{/// <summary>
/// 维修物料
/// </summary>
  public  class Repair_Material
    {
        /// <summary>
        /// 编号
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 速查码
        /// </summary>
        public virtual string quick_code { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public virtual string category { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string name { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public virtual string units { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string remarks { get; set; }
    }
}
