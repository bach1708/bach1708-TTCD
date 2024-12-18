﻿using System;
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
    public class BookingsController : Controller
    {
        private Entities db = new Entities();

        // GET: Bookings
        public async Task<ActionResult> Index()
        {
            var bookings = db.Bookings.Include(b => b.User).Include(b => b.Showtime);
            return View(await bookings.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = await db.Bookings.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.ma_nguoi_dung = new SelectList(db.Users, "ma_nguoi_dung", "ho_ten");
            ViewBag.ma_suat_chieu = new SelectList(db.Showtimes, "ma_suat_chieu", "phong_chieu");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ma_dat_ve,ma_nguoi_dung,ma_suat_chieu,ghe_ngoi,tong_tien,trang_thai,ngay_dat")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ma_nguoi_dung = new SelectList(db.Users, "ma_nguoi_dung", "ho_ten", booking.ma_nguoi_dung);
            ViewBag.ma_suat_chieu = new SelectList(db.Showtimes, "ma_suat_chieu", "phong_chieu", booking.ma_suat_chieu);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = await db.Bookings.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.ma_nguoi_dung = new SelectList(db.Users, "ma_nguoi_dung", "ho_ten", booking.ma_nguoi_dung);
            ViewBag.ma_suat_chieu = new SelectList(db.Showtimes, "ma_suat_chieu", "phong_chieu", booking.ma_suat_chieu);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ma_dat_ve,ma_nguoi_dung,ma_suat_chieu,ghe_ngoi,tong_tien,trang_thai,ngay_dat")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ma_nguoi_dung = new SelectList(db.Users, "ma_nguoi_dung", "ho_ten", booking.ma_nguoi_dung);
            ViewBag.ma_suat_chieu = new SelectList(db.Showtimes, "ma_suat_chieu", "phong_chieu", booking.ma_suat_chieu);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = await db.Bookings.FindAsync(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Booking booking = await db.Bookings.FindAsync(id);
            db.Bookings.Remove(booking);
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
