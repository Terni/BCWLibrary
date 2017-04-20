using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitcoin.APIv2Client.Models
{
    public class OutRow
    {
        public bool Spent { get; set; }
        public long TxIndex { get; set; }
        public int Type { get; set; }
        public string Address { get; set; }
        public long Value { get; set; }
        public int Number { get; set; } //n
        public string Script { get; set; }
    }

    public class InputRow
    {
        public long Sequence { get; set; }
        public OutRow PrevOut { get; set; }
        public string Script { get; set; }
    }

    public class Transaction
    {
        public int Ver { get; set; }
        public List<InputRow> ListInputs { get; set; }
        public long BlockHeight { get; set; }
        public string RelayedBy { get; set; }
        public Tuple<OutRow, OutRow> TupleOuts { get; set; }
        public string LockTime { get; set; }
        public double Result { get; set; }
        public long Size { get; set; }
        public string Time { get; set; }
        public long TxIndex { get; set; }
        public int VinSz { get; set; }
        public string Hash { get; set; }
        public int VoutSz { get; set; }
    }

    /// <summary>
    /// Main Data Transaction
    /// </summary>
    public class DataTransaction
    {
        public string Hash160 { get; set; }
        public string Address { get; set; }
        public int NumberTransaction { get; set; } //n_tx
        public long TotalRecived { get; set; }
        public long TotalSent { get; set; }
        public long TotalBalance { get; set; }
        public List<Transaction> ListTransactions { get; set; }
    }
}
