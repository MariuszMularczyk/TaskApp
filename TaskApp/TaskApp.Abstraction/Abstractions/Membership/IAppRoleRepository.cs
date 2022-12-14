using XMLApp.Domain;
using XMLApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLApp.Data
{
    public interface IAppRoleRepository : IRepository<AppRole>
    {
        object GetRolesToList();
        List<SelectModelBinder<int>> GetRolesToSelect();
    }
}
