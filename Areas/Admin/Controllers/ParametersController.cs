﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using ClothesShop.Models;
using ClothesShop.Models.Common;
using ClothesShop.Models.EF;
using PagedList;


namespace ClothesShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ParametersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Parameters
        public ActionResult Index(string Searchtext, int? page, int? size )
        {
            
            IEnumerable<Parameter> items = db.Parameters.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(Searchtext))
            {
                items = items.Where(x => x.Name.IndexOf(Searchtext, StringComparison.OrdinalIgnoreCase) >= 0);
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            var pageSize = size.HasValue ? Convert.ToInt32(size) : 5;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.pageSize = pageSize;
            ViewBag.page = page;
            return View(items);
            
        }
        // GET: Admin/Parameters/Create
        public ActionResult Create()
        {
            Parameter p = new Parameter();
            return View(p);
        }


        // GET: Admin/Parameters/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                TempData["message"] = new XMessage("danger", "Mẫu tin không tồn tại");
                return RedirectToAction("Index");
            }
            Parameter parameter = db.Parameters.Find(id);
            if (parameter == null)
            {
                TempData["message"] = new XMessage("danger", "Mẫu tin không tồn tại");
                return RedirectToAction("Index");
            }
            return View(parameter);
        }



        // POST: Admin/Parameters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Value")] Parameter parameter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parameter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parameter);
        }

        [HttpPost]
        public ActionResult IsApply(string id)
        {
            var item = db.Parameters.Find(id);
            if (item != null)
            {
                item.Apply = !item.Apply;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isAcive = item.Apply });
            }
            return Json(new { success = false });
        }
    }
}
