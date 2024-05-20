using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;

namespace Project.Factories
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader Create(int TransactionID, int UserID, DateTime Transactiondate, String Status)
        {
            TransactionHeader th = new TransactionHeader();
            th.TransactionID = TransactionID;
            th.UserID = UserID;
            th.TransactionDate = Transactiondate;
            th.Status = Status;
            return th;
        }
    }
}