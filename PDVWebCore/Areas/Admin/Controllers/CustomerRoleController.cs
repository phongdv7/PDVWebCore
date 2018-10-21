using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PDVWebCore.Areas.Admin.Models.Customers;
using PDVWebCore.DAL;

namespace PDVWebCore.Areas.Admin.Controllers
{
    public class CustomerRoleController : Controller
    {
        private PDVWebCoreContext db = new PDVWebCoreContext();

        // GET: Admin/CustomerRoles
        public ActionResult Index(int? page)
        {
            List<CustomerRole> lstCustomerRoles = new List<CustomerRole>();
            int pageno = 0;
            pageno = page == null ? 1 : int.Parse(page.ToString());

            int pageSize = 2;
            int totalCount = 0;

            int limitEnd = pageno * pageSize;
            int limitStart = limitEnd - pageSize;

            var query = from s in db.CustomerRoles
                        orderby s.RoleCode
                        select new
                        {
                            CustomerRoleID = s.CustomerRoleID,
                            RoleCode = s.RoleCode,
                            Name = s.Name,
                            Active = s.Active
                        };

            totalCount = query.Count();

            lstCustomerRoles = query.AsEnumerable()
                                    .Where((role, index) => index >= limitStart && index < limitEnd)
                                    .Select(r => new CustomerRole()
                                    {
                                        CustomerRoleID = r.CustomerRoleID,
                                        RoleCode = r.RoleCode,
                                        Name = r.Name,
                                        Active = r.Active
                                    }).ToList();

            //Pager<CustomerRole> pager = new Pager<CustomerRole>(lstCustomerRoles.AsQueryable(),
            //                           pageno, pageSize, totalCount);
            ViewBag.TotalCount = totalCount;
            ViewBag.CurrentPage = pageno;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            return View(lstCustomerRoles);
        }

        //// GET: Admin/CustomerRoles/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CustomerRole customerRole = db.CustomerRoles.Find(id);
        //    if (customerRole == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customerRole);
        //}

        // GET: Admin/CustomerRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CustomerRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerRoleID,RoleCode,Name,Active")] CustomerRole customerRole)
        {
            if (ModelState.IsValid)
            {
                db.CustomerRoles.Add(customerRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerRole);
        }

        // GET: Admin/CustomerRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerRole customerRole = db.CustomerRoles.Find(id);
            if (customerRole == null)
            {
                return HttpNotFound();
            }
            return View(customerRole);
        }

        // POST: Admin/CustomerRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerRoleID,RoleCode,Name,Active")] CustomerRole customerRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerRole);
        }

        // GET: Admin/CustomerRoles/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CustomerRole customerRole = db.CustomerRoles.Find(id);
        //    if (customerRole == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customerRole);
        //}

        //// POST: Admin/CustomerRoles/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CustomerRole customerRole = db.CustomerRoles.Find(id);
        //    db.CustomerRoles.Remove(customerRole);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
