using TaskApp.Dictionaries;
using TaskApp.Resources.Shared;
using TaskApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Application
{
    public class MailVM
    {
        public int Id { get; set; }
        public string eMail { get; set; }

    }
}
