using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain;

namespace wuliuDAO
{
    public interface IOutbound_CarDAO
    {
        object Save(Outbound_Car entity);

        void Update(Outbound_Car entity);

        
        void Delete<Outbound_Car>(Outbound_Car entity);

        Outbound_Car Get(object store_code);

        Outbound_Car Load(object store_code);

         IList<Outbound_Car> LoadALL();

        void BatchSave(List<Outbound_Car> record);
    
    }
}
