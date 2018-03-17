using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProRecruit;
using Microsoft.AspNet.Identity;

namespace ProRecruit.Controllers
{
    public class OrganizationsController : Controller
    {
        private ProRecruit_FinalEntities db = new ProRecruit_FinalEntities();

        // GET: Organizations
        public ActionResult Index()
        {
            var organizations = db.Organizations.Include(o => o.AspNetUser);
            return View(organizations.ToList());
        }

        public ActionResult Dashboard()
        {
            var organization = db.Organizations.Find(User.Identity.GetUserId());
            return View(organization);
        }

        // GET: Organizations/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // GET: Organizations/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Organizations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Organization organization)
        {
            AspNetUser user = db.AspNetUsers.Find(User.Identity.GetUserId());
            var aspuser = db.AspNetUsers.Find(User.Identity.GetUserId());

            if (ModelState.IsValid)
            {
                aspuser.Type = "Organization";
                db.Entry(aspuser).State = EntityState.Modified;
                organization.Email = user.Email;
                organization.UserId = User.Identity.GetUserId();
                db.Organizations.Add(organization);
                db.SaveChanges();
                return RedirectToAction("Dashboard");
            }

            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", organization.UserId);
            return View(organization);
        }

        // GET: Organizations/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", organization.UserId);
            return View(organization);
        }

        // POST: Organizations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Name,Industry,ContactPerson,Phonenumber,Fax,NoOfEmployee,OperatingSince,StockSymbol,CompanyLogo,PostedJobs,Email")] Organization organization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", organization.UserId);
            return View(organization);
        }

        // GET: Organizations/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organization organization = db.Organizations.Find(id);
            if (organization == null)
            {
                return HttpNotFound();
            }
            return View(organization);
        }

        // POST: Organizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Organization organization = db.Organizations.Find(id);
            db.Organizations.Remove(organization);
            db.SaveChanges();
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
