//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace vize.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kayit
    {
        public string kayitId { get; set; }
        public string kayitKategoriId { get; set; }
        public string kayitilanId { get; set; }
    
        public virtual ilan ilan { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}
