using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SNGPublicAPI.Models.StoredProcs;

namespace SNGPublicAPI.Repositories.Interfaces
{
    public interface IItemsRepository
    {
        Task<IEnumerable<GetAllItems>> GetAllItems(Guid customerGUID);
    }
}
