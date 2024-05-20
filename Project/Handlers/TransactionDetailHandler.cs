using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handlers
{
    public class TransactionDetailHandler
    {
        TransactionDetailRepository transactiondetailRepo = new TransactionDetailRepository();
        public int GetLastTHID()
        {
            return transactiondetailRepo.GetLastTHID();
        }

        public void InsertTransactionDetail(int lastid, int albumId, int qty)
        {
            transactiondetailRepo.InsertTransactionDetail(lastid, albumId, qty);
        }


        public List<TransactionDetail> GetTransactionDetail(int trId)
        {
            return transactiondetailRepo.GetTDByTransaction(trId);
        }
    }
}