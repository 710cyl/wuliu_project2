using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 出库单主表
    /// </summary>
    public class StorageFormMainOut
    {
        /// <summary>
        /// 出库单号
        /// </summary>
        public virtual string outStorageNumber { set; get; }

        /// <summary>
        /// 登记时间
        /// </summary>
        public virtual DateTime LogTime { set; get; }

        /// <summary>
        /// 出库方式
        /// </summary>
        public virtual string StorageWay { set; get; }

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
        /// 出库总量
        /// </summary>
        public virtual decimal TotalStorage { set; get; }

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
        /// 发货人员
        /// </summary>
        public virtual string Shipper { set; get; }

        /// <summary>
        /// 修改人
        /// </summary>
        public virtual string Modifier { set; get; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime ModifyTime { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Statement { set; get; }

        /// <summary>
        /// 发装点
        /// </summary>
        public virtual string LoadingSpot { set; get; }

        /// <summary>
        /// 发装城市
        /// </summary>
        public virtual string LoadingCity { set; get; }

        /// <summary>
        /// 发装区域
        /// </summary>
        public virtual string LoadingArea { set; get; }

        /// <summary>
        /// 实际卸点
        /// </summary>
        public virtual string UnLoadingSpotActual { set; get; }

        /// <summary>
        /// 卸货城市
        /// </summary>
        public virtual string UnLoadingCity { set; get; }

        /// <summary>
        /// 卸货区域
        /// </summary>
        public virtual string UnLoadingArea { set; get; }

        ///// <summary>
        ///// 车队标识
        ///// </summary>
        //public virtual string TeamLog { set; get; }


        /// <summary>
        /// 出库时间
        /// </summary>
        public virtual DateTime StorageTime { set; get; }

        /// <summary>
        /// 发货仓库
        /// </summary>
        public virtual string Storage { set; get; }

        /// <summary>
        /// 货主
        /// </summary>
        public virtual string CargoOwner { set; get; }

        /// <summary>
        /// 付费单位
        /// </summary>
        public virtual string PayUnits { set; get; }

        /// <summary>
        /// 收款人
        /// </summary>
        public virtual string Payee { set; get; }

        /// <summary>
        /// 资金账户
        /// </summary>
        public virtual string Accountants { set; get; }

        /// <summary>
        /// 账户名称
        /// </summary>
        public virtual string AccountName { set; get; }

        /// <summary>
        /// 仓储费
        /// </summary>
        public virtual decimal StorageFee { set; get; }

        /// <summary>
        /// 收款时间
        /// </summary>
        public virtual DateTime CollectionTime { set; get; }


        /// <summary>
        /// 实收金额
        /// </summary>
        public virtual decimal FeeReceive { set; get; }


        /// <summary>
        /// 收款完成
        /// </summary>
        public virtual string ReceiveComplete { set; get; }

        /// <summary>
        /// 未收仓储费
        /// </summary>
        public virtual decimal unStorageFee { set; get; }

        /// <summary>
        /// 装卸工1
        /// </summary>
        public virtual string Loader_1 { set; get; }

        ///// <summary>
        ///// 单位全称
        ///// </summary>
        //public virtual string UnitName { set; get; }
        /// <summary>
        /// 一对多，一个主表可以对应多
        /// </summary>
        public virtual IList<StorageDetailsOut> StorageDetailsOut { set; get; }
    }
}
