using XMLApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLApp.Data
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        object GetUsersLookup();
        object GetUsersToList();
        string GetActiveUserIdByEmail(string email);
        int GetUnknownUserId();
    }
}
