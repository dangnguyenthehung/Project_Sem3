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
    using System.Collections.Generic;
    
    public partial class Order_Table
    {
        public int Id_Order_Table { get; set; }
        public Nullable<int> IdOrder { get; set; }
        public Nullable<int> IdTable { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string Description { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual RestaurantTable RestaurantTable { get; set; }
    }
}
