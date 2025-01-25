using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.dto;
using Model;

namespace Services
{
    public interface IUserService
    {

        Task<bool> AddUserAsync(UserInfoDto user, string password);
        Task<string> LoginAsync(string login, string password);
        Task<List<UserInfo>> GetAllUsersAsync();
    }
}
