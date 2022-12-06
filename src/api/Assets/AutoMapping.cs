using AutoMapper;
using core.DTO.Bill;
using data.Data.APIContext.Models;

namespace api.Assets
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region Bill
            CreateMap<Bill, DtoBill>();
            CreateMap<DtoBillCreate, Bill>()
                .ForMember(des => des.Id, opt => opt.Ignore());
            CreateMap<DtoBillUpdate, Bill>();
            #endregion
        }
    }
}
