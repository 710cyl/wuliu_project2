using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace domain
{
    /// <summary>
    /// 出库单明细
    /// </summary>
    public class StorageDetailsOut
    {
        /// <summary>
        /// 入库性质
        /// </summary>
        public virtual string StorageProperty { set; get; }

        /// <summary>
        /// 入库时间
        /// </summary>
        public virtual DateTime StorageTime { set; get; }

        /// <summary>
        /// 订单号
        /// </summary>
        public virtual string OrderNumber { set; get; }

        /// <summary>
        /// 货主
        /// </summary>
        public virtual string CargoOwner { set; get; }


        /// <summary>
        /// 卸货点
        /// </summary>
        public virtual string UnLoadingSpot { set; get; }

        /// <summary>
        /// 卸货城市
        /// </summary>
        public virtual string UnLoadingCity { set; get; }

        /// <summary>
        /// 卸货区域
        /// </summary>
        public virtual string UnLoadingArea { set; get; }

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
        /// 实发件数
        /// </summary>
        public virtual int PackagesNumber { set; get; }

        /// <summary>
        /// 实发数量
        /// </summary>
        public virtual decimal Numbers { set; get; }

        /// <summary>
        /// 入库单识别码
        /// </summary>
        public virtual string StorageCode { set; get; }

        /// <summary>
        /// 出库单识别码——主键
        /// </summary>
        public virtual string outStorageCode { set; get; }

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

        ///// <summary>
        ///// 入库单号
        ///// </summary>
        //public virtual string StorageNumber { set; get; }

            /// <summary>
            /// 发货员
            /// </summary>
        public virtual string shipper { set; get; }

        /// <summary>
        /// 发货时间
        /// </summary>
        public virtual DateTime shipperTime { set; get; }

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
        /// 装卸工1
        /// </summary>
        public virtual string Loader_1 { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Statement { set; get; }


        /// <summary>
        /// 实际卸货点
        /// </summary>
        public virtual string UnLoadingSpotACT { set; get; }

        /// <summary>
        /// 实际卸货城市
        /// </summary>
        public virtual string UnLoadingCityACT { set; get; }

        /// <summary>
        /// 实际卸货区域
        /// </summary>
        public virtual string UnLoadingAreaACT { set; get; }

        /// <summary>
        /// 发装城市
        /// </summary>
        public virtual string LoadingCity { set; get; }

        /// <summary>
        /// 发装区域
        /// </summary>
        public virtual string LoadingArea { set; get; }

        /// <summary>
        /// 发装点
        /// </summary>
        public virtual string LoadingSpot { set; get; }

        /// <summary>
        /// 车队标识
        /// </summary>
        public virtual string TeamLog { set; get; }

        /// <summary>
        /// 出库时间
        /// </summary>
        public virtual DateTime outStorageTime { set; get; }

        /// <summary>
        /// 出库单号
        /// </summary>
        public virtual string outStorageNumber { set; get; }
        /// <summary>
        /// 垛位号
        /// </summary>
        public virtual string CribNumber { set; get; }

        /// <summary>
        /// 修改人
        /// </summary>
        public virtual string Modifier { set; get; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime ModifyTime { set; get; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public virtual string StorageName { set; get; }

        /// <summary>
        /// 项目号
        /// </summary>
        public virtual string ItemNumber { set; get; }

        /// <summary>
        /// 仓费单价
        /// </summary>
        public virtual decimal StoragePriceSingle { set; get; }

        /// <summary>
        /// 仓储费
        /// </summary>
        public virtual decimal StoragePrice { set; get; }


        /// <summary>
        /// 付费单位
        /// </summary>
        public virtual string PayUnits { set; get; }

        /// <summary>
        /// 基础存储期
        /// </summary>
        public virtual int BasicStoragePeriod { set; get; }

        /// <summary>
        /// 实际存储期
        /// </summary>
        public virtual int BasicStoragePeriodACT { set; get; }

        /// <summary>
        /// 超期
        /// </summary>
        public virtual int ChaoQi { set; get; }


        /// <summary>
        /// 基本仓储单价
        /// </summary>
        public virtual decimal BasicStoragePriceSingle { set; get; }

        /// <summary>
        /// 超期单价
        /// </summary>
        public virtual decimal ChaoQiPriceSingle { set; get; }
    }
}
