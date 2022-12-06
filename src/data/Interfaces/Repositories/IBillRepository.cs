using data.Data.APIContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Interfaces.Repositories
{
    public interface IBillRepository
    {
        /// <summary>
        /// Get Entities from Bill
        /// </summary>
        /// <returns></returns>
        IQueryable<Bill> GetBill();

        /// <summary>
        /// Add new Entity Bill
        /// </summary>
        /// <param name="entity"></param>
        void AddBill(Bill entity);

        /// <summary>
        /// Update Entity Bill
        /// </summary>
        /// <param name="entity"></param>
        void UpdateBill(Bill entity);

        /// <summary>
        /// Delete Entity Bill
        /// </summary>
        /// <param name="entity"></param>
        void DeleteBill(Bill entity);
    }
}
