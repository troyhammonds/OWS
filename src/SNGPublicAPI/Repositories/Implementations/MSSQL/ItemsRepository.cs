using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper.Transaction;
using Microsoft.Extensions.Options;
using OWSData.Models;
using SNGPublicAPI.SQL;
using SNGPublicAPI.Models.StoredProcs;
using SNGPublicAPI.Repositories.Interfaces;

namespace SNGPublicAPI.Repositories.Implementations.MSSQL
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly IOptions<StorageOptions> _storageOptions;

        public ItemsRepository(IOptions<StorageOptions> storageOptions)
        {
            _storageOptions = storageOptions;
        }

        private IDbConnection Connection => new SqlConnection(_storageOptions.Value.OWSDBConnectionString);

        public async Task<IEnumerable<GetAllItems>> GetAllItems(Guid customerGUID)
        {
            IEnumerable<GetAllItems> outputGetItems;

            using (Connection)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerGUID", customerGUID);

                outputGetItems = await Connection.QueryAsync<GetAllItems>(GenericQueries.GetAllItems,
                    parameters,
                    commandType: CommandType.Text);
            }

            return outputGetItems;
        }
    }
}
