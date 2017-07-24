using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{/// <summary>
/// 办公用品
/// </summary>
  public  class Office_Supply
    {
        /// <summary>
        /// 编号ID
        /// </summary>
        public virtual Guid ID { get; set; }

        /// <summary>
        /// 速查码
        /// </summary>
        public virtual string quick_code{ get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        public virtual string categort { get; set; }

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
        public virtual string remark { get; set; }
    }
}
