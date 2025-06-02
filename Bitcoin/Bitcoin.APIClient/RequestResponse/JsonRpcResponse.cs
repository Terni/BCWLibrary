// Copyright (c) 2014 George Kimionis
// Distributed under the GPLv3 software license, see the accompanying file LICENSE or http://opensource.org/licenses/GPL-3.0

// Changes 2014.5 Bc.Tomas Prokop
// Distributed under the GPLv3 software license.

using System;
using Newtonsoft.Json;

namespace Bitcoin.APIClient.RequestResponse
{
    public class JsonRpcResponse<T>
    {

        #region Constructor
        public JsonRpcResponse(Int32 id, String error, T result)
        {
            Id = id;
            Error = error;
            Result = result;
        }
        #endregion

        #region Public Methods Setting for Response
        [JsonProperty(PropertyName = "result", Order = 0)]
        public T Result { get; set; }

        [JsonProperty(PropertyName = "id", Order = 1)]
        public Int32 Id { get; set; }

        [JsonProperty(PropertyName = "error", Order = 2)]
        public String Error { get; set; }
        #endregion
    }

    public class JsonResponse
    {
        public Int32 Id { get; set; }
        public String Result { get; set; }
        public String Error { get; set; }
        public float JsonRpc { get; set; }
    }


}