// Copyright (c) 2014 Bc.Tomas Prokop
// Distributed under the GPLv3 software license.

using System;
using System.IO;

namespace Bitcoin.APIClient
{
    interface IWEBClient
    {

        /// <summary> GetBalance
        /// If [account] is not specified, returns the server's total available balance.
        /// If [account] is specified, returns the balance in the account.
        /// </summary>
        void GetBalance();

        /// <summary> GetAddressBalance
        /// </summary>
        void GetAddressBalance();

        /// <summary> GetAddressList
        /// </summary>
        void GetAddressList();

        /// <summary> SetPayment
        /// </summary>
        void SetPayment();

        /// <summary> SetNewAddress
        /// </summary>
        void SetNewAddress(String getNewLabel);

        /// <summary> SetArchiveAddress
        /// </summary>
        void SetArchiveAddress(String getAddress);

        /// <summary> SetUnarchiveAddress
        /// </summary>
        void SetUnarchiveAddress(String getAddress);

        /// <summary> GetStats
        /// </summary>
        void GetStats();
    }
}
