using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using domain;
namespace wuliuDAO
{
    public interface IInternal_VehicleDAO
    {
        object Save(Internal_Vehicle entity);

        void Update(Internal_Vehicle entity);

        void Delete(Internal_Vehicle entity);

        Internal_Vehicle Get(object id);

        Internal_Vehicle Load(object id);

        IList<Internal_Vehicle> LoadALL();
    }
}
