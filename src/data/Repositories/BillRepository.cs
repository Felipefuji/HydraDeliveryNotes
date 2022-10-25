using data.Data.APIContext.Context;
using data.Data.APIContext.Models;
using data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Repositories
{
    public class BillRepository : IBillRepository
    {
        #region Constructor
        private readonly APIContext _context;
        public BillRepository(APIContext context)
        {
            _context = context;
        }
        #endregion

        /// <summary>
        /// Get Entities from Bill
        /// </summary>
        /// <returns></returns>
        public IQueryable<Bill> GetBill()
        {
            return _context.Bills;
        }

        /// <summary>
        /// Add new Entity Bill
        /// </summary>
        /// <param name="entity"></param>
        public void AddBill(Bill entity)
        {
            _context.Bills.Add(entity);
        }

        /// <summary>
        /// Update Entity Bill
        /// </summary>
        /// <param name="entity"></param>
        public void UpdateBill(Bill entity)
        {
            _context.Bills.Update(entity);
        }

        /// <summary>
        /// Delete Entity Bill
        /// </summary>
        /// <param name="entity"></param>
        public void DeleteBill(Bill entity)
        {
            _context.Bills.Remove(entity);
        }
    }
}
