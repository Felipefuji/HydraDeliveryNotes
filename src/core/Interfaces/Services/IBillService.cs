using core.DTO.Bill;
using core.DTO.Helpers;
using core.Helpers;

namespace core.Interfaces.Services
{
    public interface IBillService
    {
        #region Actions
        /// <summary>
        /// Get Bill by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DtoBill> GetBillById(int id);

        /// <summary>
        /// Get All Bill 
        /// </summary>
        /// <returns></returns>
        Task<PagedList<DtoBill>> GetAllBills(DtoFilterPagedList pagedListParams);

        /// <summary>
        /// Create Bill
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        Task<int?> CreateBill(DtoBillCreate data);

        /// <summary>
        /// Update Bill
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        Task<int?> UpdateBill(DtoBillUpdate data);

        /// <summary>
        /// Remove Bill by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task RemoveBill(int id);
    }
}