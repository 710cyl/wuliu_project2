using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain;

namespace wuliuDAO
{
    public interface InterfaceDAO
    {
        object Save<T>(T entity);

        void Update<T>(T entity);

        void Delete<T>(T entity);

        object Get<T>(object id);

        object Load<T>(object id);

        //IList<T> LoadALL<T>();

        //void BatchSave(List<Basic_Set> record);
    
    }
}
