using System;

namespace Model.Models
{
    public class Orders
    {
        public int IdOrder { get; set; }
        public int IdCustomer { get; set; }
        public int IdEmployee_Verify { get; set; }
        public int NumberOfTable { get; set; }
        public int NumberOfCustomer { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public int OrderStatus { get; set; }
        public int IdBranch { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string VerifyBy { get; set; }

        public string CustomerName { get; set; }

        public decimal Deposit { get; set; }

    }
}
