using AutoMarket.Domain.ViewModels.Profile;
using AutoMarket.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMarket.Domain.Entity;

namespace AutoMarket.Service.Interfaces
{
    public interface IProfileService
    {
        Task<BaseResponse<ProfileViewModel>> GetProfile(string userName);

        Task<BaseResponse<Profile>> Save(ProfileViewModel model);
    }
}
