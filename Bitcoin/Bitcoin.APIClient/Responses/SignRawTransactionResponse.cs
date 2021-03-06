﻿// Copyright (c) 2014 George Kimionis
// Distributed under the GPLv3 software license, see the accompanying file LICENSE or http://opensource.org/licenses/GPL-3.0

using System;

namespace Bitcoin.APIClient.Responses
{
    public class SignRawTransactionResponse
    {
        public String Hex { get; set; }
        public Boolean Complete { get; set; }
    }
}