using System;
using System.Collections.Generic;
using System.Text;

namespace SNGPublicAPI.SQL
{
    public static class GenericQueries
    {
        #region System Queries

        public static readonly string GetAllItems = @"SELECT I.*, IT.ItemTypeDesc
				FROM Items I
				INNER JOIN ItemTypes IT ON IT.ItemTypeID = I.ItemTypeID
				WHERE I.CustomerGUID = @CustomerGUID
				ORDER BY I.ItemID";

        #endregion
    }
}
