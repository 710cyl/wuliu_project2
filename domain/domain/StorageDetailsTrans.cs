using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 移库单——明细表
    /// </summary>
    public class StorageDetailsTrans
    {
        /// <summary>
        /// 入库单识别码
        /// </summary>
        public virtual string StorageCode { set; get; }

        /// <summary>
        /// 订单号
        /// </summary>
        public virtual string OrderNumber { set; get; }

        /// <summary>
        /// 项目号
        /// </summary>
        public virtual string ItemNumber { set; get; }

        /// <summary>
        /// 卷号
        /// </summary>
        public virtual string ReelNumber { set; get; }

        /// <summary>
        /// 品种
        /// </summary>
        public virtual string Variety { set; get; }

        /// <summary>
        /// 材质
        /// </summary>
        public virtual string Material { set; get; }

        /// <summary>
        /// 规格
        /// </summary>
        public virtual string Specification { set; get; }

        /// <summary>
        /// 库存件数
        /// </summary>
        public virtual int InventoryNumber { set; get; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public virtual decimal StockQuantity { set; get; }

        /// <summary>
        /// 原垛位号
        /// </summary>
        public virtual string CribNumberOri { set; get; }

        /// <summary>
        /// 新垛位号
        /// </summary>
        public virtual string CribNumberNew { set; get; }
        /// <summary>
        /// 移库件数
        /// </summary>
        public virtual int InventoryNumberTrans { set; get; }

        /// <summary>
        /// 移库数量
        /// </summary>
        public virtual decimal StockQuantityTrans { set; get; }

        /// <summary>
        /// 移库识别码
        /// </summary>
        public virtual string transStorageCode { set; get; }

        /// <summary>
        /// 票数
        /// </summary>
        public virtual int Poll { set; get; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public virtual DateTime StorageTime { set; get; }

        /// <summary>
        /// 出厂日期
        /// </summary>
        public virtual DateTime ProductionDate { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string statement { set; get; }

        /// <summary>
        /// 移库单号
        /// </summary>
        public virtual string StorageNumber { set; get; }
    }
}
