//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace K22CNT2_NongVanBach_2210900003.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payment
    {
        public int ma_giao_dich { get; set; }
        public Nullable<int> ma_dat_ve { get; set; }
        public string phuong_thuc_thanh_toan { get; set; }
        public Nullable<decimal> so_tien { get; set; }
        public string trang_thai_thanh_toan { get; set; }
        public Nullable<System.DateTime> ngay_thanh_toan { get; set; }
    
        public virtual Booking Booking { get; set; }
    }
}
