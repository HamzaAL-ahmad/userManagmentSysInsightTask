using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserInfo
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Skills { get; set; }
        public string ID_User { get; set; }
        public int ID_City { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public City ?City { get; set; }
    }

}
