using XMLApp.Dictionaries;
using XMLApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLApp.Data
{
    public interface IAppUserRoleRepository : IRepository<AppUserRole>
    {
        List<FunctionalityType> GetUserFunctionalities(int userId);
        bool CheckIfIsAdmin(int userId);
        object GetUserRoles(int userId);
        object GetRoleUsers(int roleId);
    }
}
