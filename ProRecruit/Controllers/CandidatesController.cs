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
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using CrystalDecisions.Shared;

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

		public ActionResult ExportCVToPDF()
		{
			ReportDocument rd = new ReportDocument();
			ConnectionInfo crconnectioninfo = new ConnectionInfo();
			TableLogOnInfos crtablelogoninfos = new TableLogOnInfos();
			TableLogOnInfo crtablelogoninfo = new TableLogOnInfo();

            Tables CrTables;

            crconnectioninfo.ServerName = "DESKTOP-CQSA7LV";
			crconnectioninfo.DatabaseName = "ProRecruit_Final";
			crconnectioninfo.UserID = "sa";
			crconnectioninfo.Password = "hamza1996";
			
			rd.Load(Path.Combine(Server.MapPath("~/Reports"), "CV.rpt"));
			rd.SetParameterValue("userid", User.Identity.GetUserId().ToString());

            CrTables = rd.Database.Tables;

            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtablelogoninfo = CrTable.LogOnInfo;
                crtablelogoninfo.ConnectionInfo = crconnectioninfo;
                CrTable.ApplyLogOnInfo(crtablelogoninfo);
            }

            //rd.Refresh();

            Response.Buffer = false;
			Response.ClearContent();
			Response.ClearHeaders();
			Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
			stream.Seek(0, SeekOrigin.Begin);
            rd.Refresh();
            return File(stream, "application/pdf", "CV.pdf");
		}

		//[Authorize]
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
			Candidate candidate = db.Candidates.Include(c => c.CareerLevel1).Include(c => c.FunctionalArea1).Include(c => c.Industry1).Where(c => c.UserId == id).FirstOrDefault();
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
			ViewBag.Industry = new SelectList(db.Industries, "Id", "Name");
			ViewBag.CareerLevel = new SelectList(db.CareerLevels, "Id", "Name");
			ViewBag.FunctionalArea = new SelectList(db.FunctionalAreas, "Id", "Name");
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
			ViewBag.Industry = new SelectList(db.Industries, "Id", "Name", candidate.Industry);
			ViewBag.CareerLevel = new SelectList(db.CareerLevels, "Id", "Name", candidate.CareerLevel);
			ViewBag.FunctionalArea = new SelectList(db.FunctionalAreas, "Id", "Name", candidate.FunctionalArea);
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
