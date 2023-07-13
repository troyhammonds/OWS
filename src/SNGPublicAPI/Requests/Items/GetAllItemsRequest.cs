using Microsoft.AspNetCore.Mvc;
using SNGPublicAPI.Models.StoredProcs;
using SNGPublicAPI.Repositories.Interfaces;
using OWSShared.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace OWSPublicAPI.Requests.Items
{
    /// <summary>
    /// GetAllItemsRequest
    /// </summary>
    /// <remarks>
    /// This request object handles requests for api/Items/GetAllItemsRequest
    /// </remarks>
    public class GetAllItemsRequest
    {

        private IEnumerable<GetAllItems> output;
        private Guid customerGUID;
        private IItemsRepository itemsRepository;

        /// <summary>
        /// SetData
        /// </summary>
        /// <remarks>
        /// Used to pass dependencies to the Request object (for performance reasons).
        /// </remarks>
        public void SetData(IItemsRepository itemsRepository, IHeaderCustomerGUID customerGuid)
        {
            this.itemsRepository = itemsRepository;
            customerGUID = customerGuid.CustomerGUID;
        }

        /// <summary>
        /// Handle
        /// </summary>
        /// <remarks>
        /// This handles the Request.
        /// </remarks>
        public async Task<IActionResult> Handle()
        {

            if (customerGUID == Guid.Empty)
            {
                return new NotFoundObjectResult("customerGUID not found");
            }

            output = await itemsRepository.GetAllItems(customerGUID);

            return new OkObjectResult(output);
        }
    }
}
