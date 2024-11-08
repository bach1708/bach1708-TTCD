using K22_CNT2_NongVanBach.Bussiness;
using K22_CNT2_NongVanBach.Models;
using K22_CNT2_NongVanBach.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K22_CNT2_NongVanBach.Controllers
{
    public class CartController : Controller
    {
        private const string CartSessionKey = "CartSession";

        Project2Entities db = new Project2Entities();
        // Lấy giỏ hàng từ Session hoặc tạo mới nếu chưa có
        private ShoppingCart GetCart()
        {
            var cart = Session[CartSessionKey] as ShoppingCart;
            if (cart == null)
            {
                cart = new ShoppingCart();
                Session[CartSessionKey] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart (int Id, string name,string image, float price, int qty = 1  ) { 
            var cart = GetCart();
            var item = new CartItem
            {
                Id = Id,
                Name = name,
                Image = image,
                Price = price,
                Qty = qty,
            };
            cart.AddToCart( item );
            return RedirectToAction( "Index" );
                }
        public ActionResult UpdateToCart(int Id, int qty = 1)
        {
            var cart = GetCart();
            
            cart.UpdateToCart(Id,qty);
            return RedirectToAction("Index");
        }
        // GET: NVBCart
        public ActionResult Index()
        {
            var cart = GetCart();
            return View( cart );
        }
        //Thông tin thanh toán
        public ActionResult ThongTinThanhToan() 
        {
            var cart = GetCart();
            return View(cart);
        }
        public ActionResult ThanhToan(FormCollection form)
        {
            //lấy thông tin khách hàng
            var ten_nguoi_nhan = form["Ten_Nguoi_Nhan"];
            var dia_chi_nguoi_nhan = form["Dia_Chi_Nhan"];
            var dien_thoai_nguoi_nhan = form["Dien_Thoai_Nhan"];
            
            //Tạo đơn hàng (thêm mới một đơn hàng vào bảng DON_HANG
            DON_HANG don_Hang = new DON_HANG();
            DateTime dt = DateTime.Now;
            don_Hang.MaDH = "DH-" + dt.ToString("yyyyMMdd-HHmmss");
            don_Hang.Ten_Nguoi_Nhan = ten_nguoi_nhan;
            don_Hang.Dia_Chi_Nhan = dia_chi_nguoi_nhan;
            don_Hang.Dien_Thoai_Nhan = dien_thoai_nguoi_nhan;
            don_Hang.Ngay_dat = dt;
            don_Hang.Trang_thai = 0;
            db.DON_HANG.Add( don_Hang );
            db.SaveChanges();

            //Lấy mã đơn hàng mới nhất -> Thêm vào chi tiết đơn hàng

            int maxID_DH = db.DON_HANG.Max(x=>x.ID);
            var cart = GetCart();
            foreach (CartItem item in cart.Items)
            {
                CT_DON_HANG ct = new CT_DON_HANG();
                ct.ID_DH = maxID_DH;
                ct.ID_SP = item.Id;
                ct.So_Luong = item.Qty;
                ct.Don_gia = item.Price;
                ct.Thanh_tien = item.Qty*item.Price;
                db.CT_DON_HANG.Add(ct);
                db.SaveChanges();
            }    
            return Redirect("/");
        }
    }
}