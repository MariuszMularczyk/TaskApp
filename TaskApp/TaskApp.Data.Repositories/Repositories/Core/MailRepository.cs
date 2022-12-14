using TaskApp.Domain;
using TaskApp.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Dictionaries;

namespace TaskApp.Data
{
    public class MailRepository : Repository<Mail, MainDatabaseContext>, IMailRepository
    {
        public MailRepository(MainDatabaseContext context) : base(context)
        { }

        

    }
}
