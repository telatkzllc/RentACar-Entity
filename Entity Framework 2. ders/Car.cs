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
    
    public partial class Car
    {
        public int carNo { get; set; }
        public Nullable<decimal> carPrice { get; set; }
        public string carPlate { get; set; }
        public string carBrand { get; set; }
        public string carModel { get; set; }
        public Nullable<System.DateTime> carYear { get; set; }
        public Nullable<int> carEngine { get; set; }
        public string carPac { get; set; }
        public string carColor { get; set; }
        public string carTransmission { get; set; }
        public Nullable<int> branchNo { get; set; }
    
        public virtual Branch Branch { get; set; }
    }
}
