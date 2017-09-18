using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain;

namespace wuliuDAO
{
    public interface IOutbound_Car_DetailDAO
    {
        object Save(Outbound_Car_Detail entity);

        void Update(Outbound_Car_Detail entity);

        void Delete(Outbound_Car_Detail entity);

        Outbound_Car_Detail Get(object sendcar_num);

        Outbound_Car_Detail Load(object sendcar_num);

         IList<Outbound_Car_Detail> LoadALL();

        void BatchSave(List<Outbound_Car_Detail> record);
    
    }
}
