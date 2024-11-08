using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using K22CNT2_NongVanBach_2210900003.Models;

namespace K22CNT2_NongVanBach_2210900003.Controllers
{
    public class ShowtimesController : Controller
    {
        private Entities db = new Entities();

        // GET: Showtimes
        public async Task<ActionResult> Index()
        {
            var showtimes = db.Showtimes.Include(s => s.Cinema).Include(s => s.Movy);
            return View(await showtimes.ToListAsync());
        }

        // GET: Showtimes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showtime showtime = await db.Showtimes.FindAsync(id);
            if (showtime == null)
            {
                return HttpNotFound();
            }
            return View(showtime);
        }

        // GET: Showtimes/Create
        public ActionResult Create()
        {
            ViewBag.ma_rap = new SelectList(db.Cinemas, "ma_rap", "ten_rap");
            ViewBag.ma_phim = new SelectList(db.Movies, "ma_phim", "ten_phim");
            return View();
        }

        // POST: Showtimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ma_suat_chieu,ma_phim,ma_rap,ngay_chieu,gio_chieu,phong_chieu")] Showtime showtime)
        {
            if (ModelState.IsValid)
            {
                db.Showtimes.Add(showtime);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ma_rap = new SelectList(db.Cinemas, "ma_rap", "ten_rap", showtime.ma_rap);
            ViewBag.ma_phim = new SelectList(db.Movies, "ma_phim", "ten_phim", showtime.ma_phim);
            return View(showtime);
        }

        // GET: Showtimes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showtime showtime = await db.Showtimes.FindAsync(id);
            if (showtime == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_rap = new SelectList(db.Cinemas, "ma_rap", "ten_rap", showtime.ma_rap);
            ViewBag.ma_phim = new SelectList(db.Movies, "ma_phim", "ten_phim", showtime.ma_phim);
            return View(showtime);
        }

        // POST: Showtimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ma_suat_chieu,ma_phim,ma_rap,ngay_chieu,gio_chieu,phong_chieu")] Showtime showtime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(showtime).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ma_rap = new SelectList(db.Cinemas, "ma_rap", "ten_rap", showtime.ma_rap);
            ViewBag.ma_phim = new SelectList(db.Movies, "ma_phim", "ten_phim", showtime.ma_phim);
            return View(showtime);
        }

        // GET: Showtimes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Showtime showtime = await db.Showtimes.FindAsync(id);
            if (showtime == null)
            {
                return HttpNotFound();
            }
            return View(showtime);
        }

        // POST: Showtimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Showtime showtime = await db.Showtimes.FindAsync(id);
            db.Showtimes.Remove(showtime);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
