using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;
namespace domain
{
    /// <summary>
    /// 入库单_明细
    /// </summary>
   public class StorageDetails
    {
        /// <summary>
        /// 入库单识别码
        /// </summary>
        public virtual string StorageCode { set; get; }

        /// <summary>
        /// 仓库名称
        /// </summary>
        public virtual string StorageName { set; get; }

        /// <summary>
        /// 出厂日期
        /// </summary>
        public virtual DateTime ProductionDate { set; get; }

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
        /// 件数
        /// </summary>
        public virtual int PackagesNumber { set; get; }

        /// <summary>
        /// 数量
        /// </summary>
        public virtual decimal Numbers { set; get; }

        /// <summary>
        /// 垛位号
        /// </summary>
        public virtual string CribNumber { set; get; }


        /// <summary>
        /// 入库方式
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
        public virtual string Drive { set; get; }

        /// <summary>
        /// 装货城市
        /// </summary>
        public virtual string LoadingCity { set; get; }

        /// <summary>
        /// 装货地点
        /// </summary>
        public virtual string LoadingSpot { set; get; }

        /// <summary>
        /// 装货区域
        /// </summary>
        public virtual string LoadingArea { set; get; }

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
        /// 入库时间
        /// </summary>
        public virtual DateTime StorageTime { set; get; }

        /// <summary>
        /// 入库单号
        /// </summary>
        public virtual string StorageNumber { set; get; }

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
        /// 其他人
        /// </summary>
        public virtual string Others { set; get; }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Statement { set; get; }

        /// <summary>
        /// 库存件数
        /// </summary>
        public virtual int InventoryNumber { set; get; }

        /// <summary>
        /// 库存数量
        /// </summary>
        public virtual decimal StockQuantity { set; get; }

        /// <summary>
        /// 票数
        /// </summary>
        public virtual int Poll { set; get; }

        /// <summary>
        /// 车队标识
        /// </summary>
        public virtual string TeamLog { set; get; }

        /// <summary>
        /// 项目号
        /// </summary>
        public virtual string ItemNumber { set; get; }

        /// <summary>
        /// 可派件数
        /// </summary>
        public virtual int SendNumber { set; get; }

        /// <summary>
        /// 可派数量
        /// </summary>
        public virtual decimal SendQuantity { set; get; }

       // public virtual StorageFormMain StorageFormMain { set; get; }
    }
}
