using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProRecruit.Models;
using Microsoft.AspNet.Identity;

namespace ProRecruit.Controllers
{
	public class CandidatesController : Controller
	{
		private ProRecruit_FinalEntities db = new ProRecruit_FinalEntities();

		// GET: Candidates
		public ActionResult Index()
		{
			var candidates = db.Candidates.Include(c => c.AspNetUser);
			return View(candidates.ToList());
		}
		[Authorize]
		public ActionResult Dashboard()
		{
			var candidate = db.Candidates.Find(User.Identity.GetUserId());
			return View(candidate);
		}

		public ActionResult Summary(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Candidate candidate = db.Candidates.Find(id);
			if (candidate == null)
			{
				return HttpNotFound();
			}
			return View(candidate);
		}

  //      [Authorize]
		//public ActionResult Summary()
		//{
		//	var candidate = db.Candidates.Find(User.Identity.GetUserId());
		//	return View(candidate);
		//}

		[HttpPost]
		[Authorize]
		[ValidateAntiForgeryToken]
		public ActionResult Summary(Candidate candidate)
		{
			if (ModelState.IsValid)
			{
				db.Entry(candidate).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Dashboard");
			}
			return View(candidate);
		}

		// GET: Candidates/Details/5
		public ActionResult Details(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Candidate candidate = db.Candidates.Where(c => c.UserId == id).FirstOrDefault();
			if (candidate == null)
			{
				return HttpNotFound();
			}
			return View(candidate);
		}

		// GET: Candidates/Create
		public ActionResult Create()
		{
			//ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
			return View();
		}

		// POST: Candidates/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Candidate candidate)
		{
			AspNetUser user = db.AspNetUsers.Find(User.Identity.GetUserId());
			//var aspuser = db.AspNetUsers.Find(User.Identity.GetUserId());

			if (ModelState.IsValid)
			{
				user.Type = "Candidate";
				db.Entry(user).State = EntityState.Modified;
				candidate.Email = user.Email;
				candidate.UserId = User.Identity.GetUserId();
				db.Candidates.Add(candidate);
				db.SaveChanges();
				return RedirectToAction("Dashboard");
			}

			//ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", candidate.UserId);
			return View(candidate);
		}

		// GET: Candidates/Edit/5
		public ActionResult Edit(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Candidate candidate = db.Candidates.Find(id);
			if (candidate == null)
			{
				return HttpNotFound();
			}
			ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", candidate.UserId);
			return View(candidate);
		}

		// POST: Candidates/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "FirstName,LastName,Email,DateOfBirth,Gender,MaritalStatus,Nationality,City,CNIC,CurrentAddress,Contact,Experience,Qualification,Industry,FunctionalArea,CurrentSalary,ExpectedSalary,CarreerLevel,UserId")] Candidate candidate)
		{
			if (ModelState.IsValid)
			{
				db.Entry(candidate).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", candidate.UserId);
			return View(candidate);
		}

		// GET: Candidates/Delete/5
		public ActionResult Delete(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Candidate candidate = db.Candidates.Find(id);
			if (candidate == null)
			{
				return HttpNotFound();
			}
			return View(candidate);
		}

		// POST: Candidates/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(string id)
		{
			Candidate candidate = db.Candidates.Find(id);
			db.Candidates.Remove(candidate);
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
