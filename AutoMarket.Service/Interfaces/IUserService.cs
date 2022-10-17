using AutoMarket.Domain.Entity;
using AutoMarket.Domain.ViewModels.User;
using AutoMarket.Domain.Response;

namespace AutoMarket.Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<User>> Create(UserViewModel model);

        BaseResponse<Dictionary<int, string>> GetRoles();

        Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();

        Task<IBaseResponse<bool>> DeleteUser(long id);
    }
}
