//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MajourApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Majour
    {
        public int MajourID { get; set; }
        public string MajourName { get; set; }
        public string img { get; set; }
        public Nullable<int> FacultieID { get; set; }
    
        public virtual Faculty Faculty { get; set; }
    }
}