using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int ID_Country { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
