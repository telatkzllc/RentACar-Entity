//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity_Framework_2.ders
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public int customerNo { get; set; }
        public string customerNameSurname { get; set; }
        public string customerPhone { get; set; }
        public Nullable<int> customerAge { get; set; }
        public Nullable<decimal> customerBalance { get; set; }
        public Nullable<decimal> customerDeposit { get; set; }
        public Nullable<int> employeeNo { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
