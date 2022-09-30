using AutoMarket.Domain.Response;
using AutoMarket.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMarket.Service.Interfaces
{
    public interface IUserService
    {
        Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();

        Task<IBaseResponse<bool>> DeleteUser(long id);
    }
}
