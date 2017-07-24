using System;
using System.Collections.Generic;
//using Iesi.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;
namespace domain
{
/// <summary>
///入库单主表 
/// </summary>
  public  class StorageFormMain
    {
        /// <summary>
        /// 入库单号
        /// </summary>
        public virtual string StorageNumber{ set; get; }
        
        /// <summary>
        /// 仓库
        /// </summary>
        public virtual string Storage { set; get; }

        /// <summary>
        /// 入库时间
        /// </summary>
        public virtual DateTime StorageTime { set; get; }

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
        public virtual string Driver { set; get; }

        /// <summary>
        /// 入库总量
        /// </summary>
        public virtual decimal TotalStorage { set; get; }

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
        /// 发卸点
        /// </summary>
        public virtual string UnLoadingSpot { set; get; }

        /// <summary>
        /// 发卸城市
        /// </summary>
        public virtual string UnLoadingCity { set; get; }

        /// <summary>
        /// 发卸区域
        /// </summary>
        public virtual string UnLoadingArea { set; get; }

        /// <summary>
        /// 一对多，一个主表可以对应多
        /// </summary>
        public virtual IList<StorageDetails> StorageDetails { set; get; }

    }
}
