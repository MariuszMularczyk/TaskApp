using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Dictionaries;

namespace TaskApp.Domain
{
    public class AppSetting : Entity
    {
        public string Value { get; set; }
        public AppSettingEnum Type { get; set; }
    }
}
