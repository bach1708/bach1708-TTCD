using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace K22_CNT2_NongVanBach.ModelView
{
    public class DH_ChiTiet
    { 
            public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public Nullable<int> Qty { get; set; }
        public double? Price { get; set; }
        public double? Total { get; set; }
    }
}
