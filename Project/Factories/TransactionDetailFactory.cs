using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Models;
namespace Project.Factories
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail Create(int TransactionID, int MakeupID, int Quantity)
        {
            TransactionDetail td = new TransactionDetail();
            td.TransactionID = TransactionID;
            td.MakeupID = MakeupID;
            td.Quantity = Quantity;
            return td;
        }
    }
}