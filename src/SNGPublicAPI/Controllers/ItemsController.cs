using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleInjector;
using SNGPublicAPI.Models.StoredProcs;
using OWSShared.Interfaces;
using OWSPublicAPI.Requests.Items;
using SNGPublicAPI.Repositories.Interfaces;




namespace OWSPublicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _itemsRepository;
        private readonly IHeaderCustomerGUID _customerGuid;

        /// <summary>
        /// Constructor for Item related API calls.
        /// </summary>
        /// <remarks>
        /// All dependencies are injected.
        /// </remarks>
        public ItemsController(IItemsRepository itemsRepository, IHeaderCustomerGUID customerGuid)
        {
            _itemsRepository = itemsRepository;
            _customerGuid = customerGuid;
        }

        /// <summary>
        /// Get All Items
        /// </summary>
        /// <remarks>
        /// Gets a list of all items from the database
        /// </remarks>
        [HttpGet]
        [Route("GetAllItems")]
        [Produces(typeof(GetAllItems))]
        public async Task<IActionResult> GetAllItems()
        {
            GetAllItemsRequest request = new GetAllItemsRequest();
            request.SetData(_itemsRepository, _customerGuid);
            return await request.Handle();
        }
    }
}
