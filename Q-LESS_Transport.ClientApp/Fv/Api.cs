using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.ClientApp.Fv
{
    public class Api
    {
        // API - {Controller}{Action}{Id}
        // Cards
        public static readonly string CARDS_GET_LIST = "cards/getList";
        public static readonly string CARDS_GET_LIST_BY_ID = "cards/getListById/";
        public static readonly string CARDS_GET_BY_ID = "cards/getById/";
        public static readonly string CARDS_SAVE = "cards/save";

        // Transaction
        public static readonly string TRANSACTION_SAVE = "transactions/save";

        // CardTypeDetails
        public static readonly string CARD_TYPE_DETAILS_GET_LIST = "cardTypeDetails/getList";

        // API - Method Type
        // GET
        public static readonly string METHOD_GET = "GET";
        // POST
        public static readonly string METHOD_POST = "POST";
        // PUT
        public static readonly string METHOD_PUT = "PUT";
        // DELETE
        public static readonly string METHOD_DELETE = "DELETE";

    }
}
