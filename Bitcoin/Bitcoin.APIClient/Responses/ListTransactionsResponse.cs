// Copyright (c) 2014 George Kimionis
// Distributed under the GPLv3 software license, see the accompanying file LICENSE or http://opensource.org/licenses/GPL-3.0

using System;

namespace Bitcoin.APIClient.Responses
{

    public class ListTransactionsResponse
    {
        public Decimal Fee { get; set; }
        public Decimal Amount { get; set; }
        public Double BlockIndex { get; set; }
        public long Time { get; set; }
        public String Category { get; set; }
        public Decimal Confirmations { get; set; }
        public String Address { get; set; }
        //public Double TimeReceived { get; set; }
        //public Double BlockTime { get; set; }
        public String TxId { get; set; }
        //public Double Block { get; set; }
        public String BlockHash { get; set; }
        public String Account { get; set; }
        public String Label { get; set; }
    }

    public class JsonResponseResult
    {
        public String LastBlock { get; set; }
        public String Transactions { get; set; }
    }
}

    //public class ListTransactionsResponse
    //{
    //    public String Account { get; set; }
    //    public String Address { get; set; }
    //    public String Category { get; set; }
    //    public Decimal Amount { get; set; }
    //    public UInt32 Confirmations { get; set; }
    //    public String BlockHash { get; set; }
    //    public Double BlockIndex { get; set; }
    //    public Double BlockTime { get; set; }
    //    public String TxId { get; set; }
    //    public Double Time { get; set; }
    //    public Double TimeReceived { get; set; }
    //}
