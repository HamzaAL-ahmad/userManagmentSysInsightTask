using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.dto
{
    public class UserInfoDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Skills { get; set; }
        public int ID_City { get; set; }
    }
}
