using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain;

namespace wuliuDAO
{
    public interface IYaohaoPacDAO
    {
        object Save(YaohaoPac entity);

        void Update(YaohaoPac entity);

        
        void Delete<YaohaoPac>(YaohaoPac entity);

        YaohaoPac Get(object package_num);

        YaohaoPac Load(object package_num);

         IList<YaohaoPac> LoadALL();

        void BatchSave(List<YaohaoPac> record);
    
    }
}
