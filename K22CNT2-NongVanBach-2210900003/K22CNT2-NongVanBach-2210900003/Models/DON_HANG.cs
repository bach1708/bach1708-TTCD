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
    
    public partial class DON_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DON_HANG()
        {
            this.CT_DON_HANG = new HashSet<CT_DON_HANG>();
        }
    
        public int ID { get; set; }
        public string MaDH { get; set; }
        public Nullable<int> MaKH { get; set; }
        public string Ten_Nguoi_Nhan { get; set; }
        public string Dia_Chi_Nhan { get; set; }
        public string Dien_Thoai_Nhan { get; set; }
        public Nullable<System.DateTime> Ngay_dat { get; set; }
        public decimal Tong_tien { get; set; }
        public Nullable<byte> Trang_thai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_DON_HANG> CT_DON_HANG { get; set; }
        public virtual KHACH_HANG KHACH_HANG { get; set; }
    }
}
