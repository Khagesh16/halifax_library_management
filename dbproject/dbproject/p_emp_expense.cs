//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dbproject
{
    using System;
    using System.Collections.Generic;
    
    public partial class p_emp_expense
    {
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> hours { get; set; }
        public string sin { get; set; }
        public Nullable<float> salary { get; set; }
        public int C_id { get; set; }
    
        public virtual p_employee p_employee { get; set; }
    }
}
