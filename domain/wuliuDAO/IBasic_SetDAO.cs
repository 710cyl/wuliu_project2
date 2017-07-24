using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain;

namespace wuliuDAO
{
    public interface IBasic_SetDAO
    {
        object Save(Basic_Set entity);

        void Update(Basic_Set entity);

        void Delete(Basic_Set entity);

        Basic_Set Get(object id);

          Basic_Set Load(object id);

         IList<Basic_Set> LoadALL();

        void BatchSave(List<Basic_Set> record);
    
    }
}
