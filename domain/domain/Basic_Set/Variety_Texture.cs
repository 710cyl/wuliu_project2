using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{/// <summary>
/// 品种材质
/// </summary>
     public class Variety_Texture
    {
        /// <summary>
        /// 编号
        /// </summary>
        public virtual Guid ID { get; set; }
        /// <summary>
        /// 品种
        /// </summary>
        public virtual string variety { get; set; }
        /// <summary>
        /// 材质
        /// </summary>
        public virtual string texture { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public virtual string statement { get; set; }
    }
}
