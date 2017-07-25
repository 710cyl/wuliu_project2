using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 移库单——主表
    /// </summary>
    public class StorageFormMainTrans
    {
        /// <summary>
        /// 仓库名称
        /// </summary>
        public virtual string StorageName { set; get; }

        /// <summary>
        /// 移库单号
        /// </summary>
        public virtual string StorageNumber { set; get; }

        /// <summary>
        /// 移库方式
        /// </summary>
        public virtual string StorageWay { set; get; }

        /// <summary>
        /// 移出客户
        /// </summary>
        public virtual string RemoveCustomer { set; get; }

        /// <summary>
        /// 移入客户
        /// </summary>
        public virtual string InCustomer { set; get; }

        /// <summary>
        /// 记账日期
        /// </summary>
        public virtual DateTime AccountDate { set; get; }

        /// <summary>
        /// 录入员
        /// </summary>
        public virtual string KeyBoarder { set; get; }

        /// <summary>
        /// 录入时间
        /// </summary>
        public virtual DateTime KeyTime { set; get; }

        /// <summary>
        /// 修改人
        /// </summary>
        public virtual string Modifier { set; get; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime ModifyTime { set; get; }

        /// <summary>
        /// 库管
        /// </summary>
        public virtual string StorageKeeper { set; get; }

        /// <summary>
        /// 吊车工
        /// </summary>
        public virtual string Craneman { set; get; }

        /// <summary>
        /// 装卸工
        /// </summary>
        public virtual string Loader { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Statement { set; get; }

        /// <summary>
        /// 移库总量
        /// </summary>
        public virtual decimal TotalStorage { set; get; }

        /// <summary>
        /// 仓储费单位
        /// </summary>
        public virtual string StoragePriceUnit { set; get; }

        /// <summary>
        /// 移库单价
        /// </summary>
        public virtual decimal StoragePriceSingle { set; get; }

        /// <summary>
        /// 移库金额
        /// </summary>
        public virtual decimal StoragePrice { set; get; }

        /// <summary>
        /// 移库费单位
        /// </summary>
        public virtual string StorageUnitPrice { set; get; }

        /// <summary>
        /// 装卸工1
        /// </summary>
        public virtual string Loader_1 { set; get; }

        public virtual IList<StorageDetailsTrans> StorageDetailsTrans { set; get; }
    }
}
