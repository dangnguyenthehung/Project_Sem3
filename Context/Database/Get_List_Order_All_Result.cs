//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Context.Database
{
    using System;
    
    public partial class Get_List_Order_All_Result
    {
        public int IdOrder { get; set; }
        public Nullable<int> IdCustomer { get; set; }
        public Nullable<int> IdEmployee_Verify { get; set; }
        public Nullable<int> NumberOfTable { get; set; }
        public Nullable<int> NumberOfCustomer { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public Nullable<int> OrderStatus { get; set; }
        public Nullable<int> IdBranch { get; set; }
        public Nullable<System.DateTime> BeginTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> Deposit { get; set; }
    }
}
