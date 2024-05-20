using Project.Factories;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Repositories
{
    public class TransactionDetailRepository
    {
        DatabaseEntities db = DatabaseSingleton.GetInstance();
        public void InsertTransactionDetail(int TransactionID, int MakeupID, int Quantity)
        {
            TransactionDetail transactiondetail = TransactionDetailFactory.Create(TransactionID, MakeupID, Quantity);
            db.TransactionDetails.Add(transactiondetail);
            db.SaveChanges();
        }
        public List<TransactionDetail> GetTransactionDetails()
        {
            return db.TransactionDetails.ToList();
        }
        public List<TransactionDetail> GetTDByTransaction(int id)
        {
            return (from transaction in db.TransactionDetails where transaction.TransactionID == id select transaction).ToList();
        }
        public List<TransactionDetail> GetTDByMakeup(int id)
        {
            return (from transaction in db.TransactionDetails where transaction.MakeupID == id select transaction).ToList();
        }
        public void RemoveTransactionDetailByID(int id)
        {
            TransactionDetail transactiondetail = db.TransactionDetails.Find(id);
            db.TransactionDetails.Add(transactiondetail);
            db.SaveChanges();
        }
        public void UpdateTransactionDetailByID(int id, int MakeupID, int Quantity)
        {
            TransactionDetail updatetd = db.TransactionDetails.Find(id);
            updatetd.MakeupID = MakeupID;
            updatetd.Quantity = Quantity;
            db.SaveChanges();
        }
        public TransactionDetail GetTransactionDetailByID(int id)
        {
            return (from x in db.TransactionDetails
                    where x.TransactionID.Equals(id)
                    select x).FirstOrDefault();
        }
        public int GetLastTHID()
        {
            var latestTransaction = (from transaction in db.TransactionHeaders
                                     orderby transaction.TransactionID descending
                                     select transaction).FirstOrDefault();

            return latestTransaction.TransactionID;
        }
    }
}