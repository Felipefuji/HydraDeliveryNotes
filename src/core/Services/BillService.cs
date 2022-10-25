using AutoMapper;
using AutoMapper.QueryableExtensions;
using core.DTO.Bill;
using core.DTO.Helpers;
using core.Helpers;
using core.Interfaces.Services;
using data.Data.APIContext.Context;
using data.Data.APIContext.Models;
using data.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace core.Services
{
    public class BillService : IBillService
    {
        #region Constructor

        private readonly APIContext _context;
        private readonly IMapper _mapper;
        private readonly IBillRepository _billRepository;

        public BillService(APIContext context, IMapper mapper, IBillRepository billRepository)
        {
            _context = context;
            _mapper = mapper;
            _billRepository = billRepository;
        }
        #endregion
        #region Actions
        /// <summary>
        /// Get Bill by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DtoBill> GetBillById(int id)
        {
            DtoBill bill = await _billRepository.GetBill().AsNoTracking().Where(c => c.Id == id).ProjectTo<DtoBill>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
            return bill;
        }

        /// <summary>
        /// Get All Bill 
        /// </summary>
        /// <returns></returns>
        public async Task<PagedList<DtoBill>> GetAllBills(DtoFilterPagedList pagedListParams)
        {
            //Servicio con paginacion en servidor

            PagedList<DtoBill> listResult = null;

            var query = _billRepository.GetBill().AsNoTracking().IgnoreQueryFilters().ProjectTo<DtoBill>(_mapper.ConfigurationProvider);

            if (pagedListParams.Active)
            {
                listResult = await PagedList<DtoBill>.ToPagedListAsync(query, pagedListParams.PageNumber, pagedListParams.PageSize);
                return listResult;
            }

            listResult = await PagedList<DtoBill>.ToOnlyListAsync(query);

            return listResult;
        }


        /// <summary>
        /// Create Bill
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public async Task<int?> CreateBill(DtoBillCreate data)
        {
            int? result = null;

            Bill entity = _mapper.Map<Bill>(data);
            _billRepository.AddBill(entity);
            await _context.SaveChangesAsync();

            result = entity.Id;


            return result;
        }

        /// <summary>
        /// Update Bill
        /// </summary>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public async Task<int?> UpdateBill(DtoBillUpdate data)
        {
            int? result = null;


            var lastEntity = await _billRepository.GetBill().IgnoreQueryFilters().Where(c => c.Id == data.Id).FirstOrDefaultAsync();

            if (lastEntity != null)
            {
                Bill entity = _mapper.Map(data, lastEntity);
                _billRepository.UpdateBill(entity);
                await _context.SaveChangesAsync();

                result = entity.Id;
            }

            return result;
        }

        /// <summary>
        /// Remove Bill by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveBill(int id)
        {
            var entity = await _billRepository.GetBill().IgnoreQueryFilters().Where(c => c.Id == id).FirstOrDefaultAsync();

            if (entity != null)
            {
                _billRepository.DeleteBill(entity);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
        #region Private Method

        #endregion
    }

}