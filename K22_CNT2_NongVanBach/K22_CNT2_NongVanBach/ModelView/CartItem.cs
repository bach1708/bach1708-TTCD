using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K22_CNT2_NongVanBach.ModelView
{

    public class CartItem
        { 
            public int Id { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }

            public int Qty { get; set; }
            public float Price { get; set; }
            public int Total { get; set; }
        }
   }
