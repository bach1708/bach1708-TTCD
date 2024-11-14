using K22_CNT2_NongVanBach.Models;
using System.Linq;
using System.Web.Mvc;

namespace K22_CNT2_NongVanBach.Areas.AdminNVB.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            if (Session["IsAdmin"] == null || !(bool)Session["IsAdmin"])
            {
                return RedirectToAction("Login", "Admin", new { area = "AdminNVB" });
            }

            return View();
        }
        private Project2Entities db = new Project2Entities();

        // GET: AdminNVB/Admin/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: AdminNVB/Admin/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string taiKhoan, string matKhau)
        {
            var admin = db.QuanTris.SingleOrDefault(q => q.Tai_khoan == taiKhoan && q.Mat_khau == matKhau);

            if (admin != null && admin.Trang_Thai == 1)
            {
                Session["Tai_khoan"] = admin.Tai_khoan;
                Session["AdminName"] = admin.Tai_khoan;
                Session["IsAdmin"] = true; // Đánh dấu người dùng là admin
                return RedirectToAction("Index", "Admin", new { area = "AdminNVB" });
            }

            ViewBag.Error = "Thông tin đăng nhập không hợp lệ hoặc tài khoản chưa kích hoạt.";
            return View();
        }

        // GET: AdminNVB/Admin/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: AdminNVB/Admin/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(string taiKhoan, string matKhau)
        {
            if (db.QuanTris.Any(q => q.Tai_khoan == taiKhoan))
            {
                ViewBag.Error = "Tài khoản đã tồn tại.";
                return View();
            }

            var admin = new QuanTri
            {
                Tai_khoan = taiKhoan,
                Mat_khau = matKhau,
                Trang_Thai = 1  // Cấp quyền hoạt động cho tài khoản
            };

            db.QuanTris.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            Session["Tai_khoan"] = null;
            Session["IsAdmin"] = null; // Xóa quyền admin
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}