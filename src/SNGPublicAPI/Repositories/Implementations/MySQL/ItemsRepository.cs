using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OWSData.Models;
using SNGPublicAPI.Models.StoredProcs;
using SNGPublicAPI.Repositories.Interfaces;
using SNGPublicAPI.SQL;

namespace SNGPublicAPI.Repositories.Implementations.MySQL
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly IOptions<StorageOptions> _storageOptions;

        public ItemsRepository(IOptions<StorageOptions> storageOptions)
        {
            _storageOptions = storageOptions;
        }

        private IDbConnection Connection => new MySqlConnection(_storageOptions.Value.OWSDBConnectionString);

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
