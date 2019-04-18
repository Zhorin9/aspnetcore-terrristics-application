using AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Interfaces
{
    public interface ITerraristicWindowRepository
    {
        /// <summary>
        /// Return window with included items for specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TerraristicWindow> GetByIdWithItemsAsync(int id);
    }
}
