using AutoMapper;
using core.DTO.Bill;
using core.DTO.User;
using data.Data.APIContext.Models;

namespace api.Assets
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region Users
            CreateMap<User, DtoUser>()
                .ForMember(u => u.Email, opt => opt.MapFrom(ur => ur.UserName));
            CreateMap<DtoUser, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
            #endregion
            #region Bill
            CreateMap<Bill, DtoBill>();
            CreateMap<DtoBillCreate, Bill>()
                .ForMember(des => des.Id, opt => opt.Ignore());
            CreateMap<DtoBillUpdate, Bill>();
            #endregion
        }
    }
}
