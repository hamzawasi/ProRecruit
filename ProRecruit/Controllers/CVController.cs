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
    public class CVController : Controller
    {
        private ProRecruit_FinalEntities db = new ProRecruit_FinalEntities();

        // GET: CV
        public ActionResult Index()
        {
            var cvs = db.Candidates.Include(c => c.CandidateCertifications).Include(c => c.CandidateExperiences).Include(c => c.CandidateJobs).Include(c => c.CandidateLanguages).Include(c => c.CandidateProjects).Include(c => c.CandidateQualifications).Include(c => c.CandidateSkills).ToList();
            return View(cvs);
        }

        // GET: CV/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Candidate candidate = db.Candidates.Find(id);
        //    if (candidate == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(candidate);
        //}

        public ActionResult DetailsById(string id)
        {
            var cv = db.Candidates.Include(c => c.CandidateQualifications).Include(c => c.CandidateLanguages).Include(c => c.CandidateProjects).Include(c => c.CandidateSkills).Include(c => c.CandidateJobs).Include(c => c.CandidateCertifications).Include(c => c.CandidateExperiences).SingleOrDefault(c => c.UserId == id);

            if (cv == null)
            {
                return HttpNotFound();
            }

            return View(cv);
        }

        [Authorize]
        public ActionResult AddCandidateQualifications()
        {
            ViewBag.QualificationId = new SelectList(db.Qualifications, "Id", "QualificationName");
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult GetTypesByQualification(string id)
        {
            int _id = Convert.ToInt32(id);
            List<SelectListItem> types = new List<SelectListItem>();
            var fetchTypes = db.QualificationTypes.Where(ft => ft.TypeOf == _id).ToList();
            for (int i = 0; i < fetchTypes.Count; i++)
            {
                types.Add(new SelectListItem
                {
                    Value = fetchTypes[i].Id.ToString(),
                    Text = fetchTypes[i].TypeName
                });
            }
            return Json(types);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddCandidateQualifications(CandidateQualification cq)
        {
            ViewBag.QualificationId = new SelectList(db.Qualifications, "Id", "QualificationName", cq.DegreeLevel);

            string id = User.Identity.GetUserId();
            cq.UserId = id;
            if (ModelState.IsValid)
            {
                try
                {
                    if (cq.Id > 0)
                    {
                        db.Entry(cq).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        db.CandidateQualifications.Add(cq);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            return View(cq);
        }


        [Authorize]
        public ActionResult QualificationMulitpleView()
        {
            string id = User.Identity.GetUserId();
            var model = (from r in db.CandidateQualifications
                         where r.UserId.Equals(id)
                         select r).ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult AddCandidateSkills()
        {
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "SkillName");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddCandidateSkills(CandidateSkill cs)
        {
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "SkillName", cs.SkillId);
            
            string id = User.Identity.GetUserId();
            cs.UserId = id;

            if (ModelState.IsValid)
            {
                if (cs.Id > 0)
                {
                    db.Entry(cs).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.CandidateSkills.Add(cs);
                    db.SaveChanges();
                }
            }
            return View(cs);
        }

        [Authorize]
        public ActionResult SkillMulitpleView()
        {
            string id = User.Identity.GetUserId();
            var SkillsAdded = (from r in db.CandidateSkills
                               where r.UserId.Equals(id)
                               select r).ToList();
            return View(SkillsAdded);
        }

        [Authorize]
        public ActionResult AddCandidateCertifications()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddCandidateCertifications(CandidateCertification cc)
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", cc.UserId);
            string id = User.Identity.GetUserId();
            cc.UserId = id;
            if (ModelState.IsValid)
            {
                if (cc.Id > 0)
                {
                    db.Entry(cc).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.CandidateCertifications.Add(cc);
                    db.SaveChanges();
                }
            }
            return View(cc);
        }

        public ActionResult CertificationsMultipleView()
        {
            string id = User.Identity.GetUserId();
            var certificationsAdded = (from r in db.CandidateCertifications
                                       where r.UserId.Equals(id)
                                       select r);
            return View(certificationsAdded);
        }

        [Authorize]
        public ActionResult AddCandidateExperience()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddCandidateExperience(CandidateExperience ce)
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", ce.UserId);
            string id = User.Identity.GetUserId();
            ce.UserId = id;

            if (ModelState.IsValid)
            {
                if (ce.Id > 0)
                {
                    db.Entry(ce).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.CandidateExperiences.Add(ce);
                    db.SaveChanges();
                }
            }
            return View(ce);
        }

        [Authorize]
        public ActionResult ExperienceMultipleView()
        {
            string id = User.Identity.GetUserId();
            var experienceAdded = (from r in db.CandidateExperiences
                                   where r.UserId.Equals(id)
                                   select r);
            return View(experienceAdded);
        }

        [Authorize]
        public ActionResult AddCandidateLanguage()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddCandidateLanguage(CandidateLanguage cl)
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            string id = User.Identity.GetUserId();
            cl.UserId = id;

            if (cl.Id > 0)
            {
                db.Entry(cl).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.CandidateLanguages.Add(cl);
                db.SaveChanges();
            }
            return View(cl);
        }

        public ActionResult LanguageMultipleView()
        {
            string id = User.Identity.GetUserId();
            var LanguagesAdded = (from r in db.CandidateLanguages
                                  where r.UserId.Equals(id)
                                  select r);
            return View(LanguagesAdded);
        }

        [Authorize]
        public ActionResult AddCandidateProject()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddCandidateProject(CandidateProject cp)
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            string id = User.Identity.GetUserId();
            cp.UserId = id;

            if (cp.Id > 0)
            {
                db.Entry(cp).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.CandidateProjects.Add(cp);
                db.SaveChanges();
            }
            return View(cp);
        }

        public ActionResult ProjectsMultipleView()
        {
            string id = User.Identity.GetUserId();
            var LanguagesAdded = (from r in db.CandidateProjects
                                  where r.UserId.Equals(id)
                                  select r);
            return View(LanguagesAdded);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        #region boilerplate
        //// GET: CV/Create
        //public ActionResult Create()
        //{
        //    ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
        //    return View();
        //}

        //// POST: CV/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "FirstName,LastName,Email,DateOfBirth,Gender,MaritalStatus,Nationality,City,CNIC,CurrentAddress,Contact,Experience,Qualification,Industry,FunctionalArea,CurrentSalary,ExpectedSalary,CarreerLevel,UserId")] Candidate candidate)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Candidates.Add(candidate);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", candidate.UserId);
        //    return View(candidate);
        //}

        //// GET: CV/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Candidate candidate = db.Candidates.Find(id);
        //    if (candidate == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", candidate.UserId);
        //    return View(candidate);
        //}

        //// POST: CV/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "FirstName,LastName,Email,DateOfBirth,Gender,MaritalStatus,Nationality,City,CNIC,CurrentAddress,Contact,Experience,Qualification,Industry,FunctionalArea,CurrentSalary,ExpectedSalary,CarreerLevel,UserId")] Candidate candidate)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(candidate).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", candidate.UserId);
        //    return View(candidate);
        //}

        //// GET: CV/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Candidate candidate = db.Candidates.Find(id);
        //    if (candidate == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(candidate);
        //}

        //// POST: CV/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Candidate candidate = db.Candidates.Find(id);
        //    db.Candidates.Remove(candidate);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        #endregion
    }
}
