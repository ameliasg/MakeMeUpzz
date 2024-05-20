using Project.Models;
using Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Handlers
{
    public class TransactionHeaderHandler
    {
        TransactionHeaderRepository transactionHeaderRepo = new TransactionHeaderRepository();

        public void InsertTransactionHeader(int id, int UserID, DateTime date, String status)
        {
            transactionHeaderRepo.InsertTransactionHeader(id, UserID, date, status);
        }

        public List<TransactionHeader> GetTransactionHeaderByUser(int customerId)
        {
            return transactionHeaderRepo.GetTHByUser(customerId);
        }
        public String GetTransactionStatusByID(int id)
        {
            return transactionHeaderRepo.GetTransactionHeaderStatus(id);
        }
    }
}