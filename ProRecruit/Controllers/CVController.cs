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
            //var cvs = db.Candidates.Include(c => c.CandidateCertifications).Include(c => c.CandidateExperiences).Include(c => c.CandidateJobs).Include(c => c.CandidateLanguages).Include(c => c.CandidateProjects).Include(c => c.CandidateQualifications).Include(c => c.CandidateSkills).ToList();
            var cvs = db.Candidates.Include(c => c.CandidateExperiences).Include(c => c.CandidateJobs).Include(c => c.CandidateLanguages).Include(c => c.CandidateProjects).Include(c => c.CandidateQualifications).Include(c => c.CandidateSkills).ToList();
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
            //var cv = db.Candidates.Include(c => c.CandidateQualifications).Include(c => c.CandidateLanguages).Include(c => c.CandidateProjects).Include(c => c.CandidateSkills).Include(c => c.CandidateJobs).Include(c => c.CandidateCertifications).Include(c => c.CandidateExperiences).SingleOrDefault(c => c.UserId == id);
            var cv = db.Candidates.Include(c => c.CandidateQualifications).Include(c => c.CandidateLanguages).Include(c => c.CandidateProjects).Include(c => c.CandidateSkills).Include(c => c.CandidateJobs).Include(c => c.CandidateExperiences).SingleOrDefault(c => c.UserId == id);

            if (cv == null)
            {
                return HttpNotFound();
            }

            return View(cv);
        }

        [Authorize]
        public ActionResult AddCandidateQualifications()
        {
            ViewBag.DegreeLevelId = new SelectList(db.Qualifications, "Id", "QualificationName");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddCandidateQualifications(CandidateQualification cq)
        {
            ViewBag.DegreeLevelId = new SelectList(db.Qualifications, "Id", "QualificationName", cq.DegreeLevel);

            string id = User.Identity.GetUserId();
            cq.UserId = id;
            //DateTime? dateCompleted = DateTime.Parse(cq.DateCompleted.Value.Year.ToString());
            //cq.DateCompleted = dateCompleted;
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

        [HttpPost]
        public JsonResult GetTypesByQualification(string id)
        {
            int _id = Convert.ToInt32(id);
            List<SelectListItem> types = new List<SelectListItem>();
            //types.Add(new SelectListItem { Text = "Select One", Value = "" });
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
        public JsonResult ReturnValuesOfGPA4()
        {
            List<SelectListItem> values = new List<SelectListItem>();
            #region interestingApproach
            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 9; j++)
            //    {
            //        values.Add(new SelectListItem
            //        {
            //            Value = j.ToString(),
            //            Text = j.ToString()
            //        });
            //    }
            //}
            #endregion
            values.Add(new SelectListItem { Value = "1.0", Text = "1.0" });
            values.Add(new SelectListItem { Value = "1.1", Text = "1.1" });
            values.Add(new SelectListItem { Value = "1.2", Text = "1.2" });
            values.Add(new SelectListItem { Value = "1.3", Text = "1.3" });
            values.Add(new SelectListItem { Value = "1.4", Text = "1.4" });
            values.Add(new SelectListItem { Value = "1.5", Text = "1.5" });
            values.Add(new SelectListItem { Value = "1.6", Text = "1.6" });
            values.Add(new SelectListItem { Value = "1.7", Text = "1.7" });
            values.Add(new SelectListItem { Value = "1.8", Text = "1.8" });
            values.Add(new SelectListItem { Value = "1.9", Text = "1.9" });
            values.Add(new SelectListItem { Value = "2.0", Text = "2.0" });
            values.Add(new SelectListItem { Value = "2.1", Text = "2.1" });
            values.Add(new SelectListItem { Value = "2.2", Text = "2.2" });
            values.Add(new SelectListItem { Value = "2.3", Text = "2.3" });
            values.Add(new SelectListItem { Value = "2.4", Text = "2.4" });
            values.Add(new SelectListItem { Value = "2.5", Text = "2.5" });
            values.Add(new SelectListItem { Value = "2.6", Text = "2.6" });
            values.Add(new SelectListItem { Value = "2.7", Text = "2.7" });
            values.Add(new SelectListItem { Value = "2.8", Text = "2.8" });
            values.Add(new SelectListItem { Value = "2.9", Text = "2.9" });
            values.Add(new SelectListItem { Value = "3.0", Text = "3.0" });
            values.Add(new SelectListItem { Value = "3.1", Text = "3.1" });
            values.Add(new SelectListItem { Value = "3.2", Text = "3.2" });
            values.Add(new SelectListItem { Value = "3.3", Text = "3.3" });
            values.Add(new SelectListItem { Value = "3.4", Text = "3.4" });
            values.Add(new SelectListItem { Value = "3.5", Text = "3.5" });
            values.Add(new SelectListItem { Value = "3.6", Text = "3.6" });
            values.Add(new SelectListItem { Value = "3.7", Text = "3.7" });
            values.Add(new SelectListItem { Value = "3.8", Text = "3.8" });
            values.Add(new SelectListItem { Value = "3.9", Text = "3.9" });
            values.Add(new SelectListItem { Value = "4.0", Text = "4.0" });
            return Json(values);
        }

        [HttpPost]
        public JsonResult ReturnValuesOfGPA5()
        {
            List<SelectListItem> values = new List<SelectListItem>();
            values.Add(new SelectListItem { Value = "1.0", Text = "1.0" });
            values.Add(new SelectListItem { Value = "1.1", Text = "1.1" });
            values.Add(new SelectListItem { Value = "1.2", Text = "1.2" });
            values.Add(new SelectListItem { Value = "1.3", Text = "1.3" });
            values.Add(new SelectListItem { Value = "1.4", Text = "1.4" });
            values.Add(new SelectListItem { Value = "1.5", Text = "1.5" });
            values.Add(new SelectListItem { Value = "1.6", Text = "1.6" });
            values.Add(new SelectListItem { Value = "1.7", Text = "1.7" });
            values.Add(new SelectListItem { Value = "1.8", Text = "1.8" });
            values.Add(new SelectListItem { Value = "1.9", Text = "1.9" });
            values.Add(new SelectListItem { Value = "2.0", Text = "2.0" });
            values.Add(new SelectListItem { Value = "2.1", Text = "2.1" });
            values.Add(new SelectListItem { Value = "2.2", Text = "2.2" });
            values.Add(new SelectListItem { Value = "2.3", Text = "2.3" });
            values.Add(new SelectListItem { Value = "2.4", Text = "2.4" });
            values.Add(new SelectListItem { Value = "2.5", Text = "2.5" });
            values.Add(new SelectListItem { Value = "2.6", Text = "2.6" });
            values.Add(new SelectListItem { Value = "2.7", Text = "2.7" });
            values.Add(new SelectListItem { Value = "2.8", Text = "2.8" });
            values.Add(new SelectListItem { Value = "2.9", Text = "2.9" });
            values.Add(new SelectListItem { Value = "3.0", Text = "3.0" });
            values.Add(new SelectListItem { Value = "3.1", Text = "3.1" });
            values.Add(new SelectListItem { Value = "3.2", Text = "3.2" });
            values.Add(new SelectListItem { Value = "3.3", Text = "3.3" });
            values.Add(new SelectListItem { Value = "3.4", Text = "3.4" });
            values.Add(new SelectListItem { Value = "3.5", Text = "3.5" });
            values.Add(new SelectListItem { Value = "3.6", Text = "3.6" });
            values.Add(new SelectListItem { Value = "3.7", Text = "3.7" });
            values.Add(new SelectListItem { Value = "3.8", Text = "3.8" });
            values.Add(new SelectListItem { Value = "3.9", Text = "3.9" });
            values.Add(new SelectListItem { Value = "4.0", Text = "4.0" });
            values.Add(new SelectListItem { Value = "4.1", Text = "4.1" });
            values.Add(new SelectListItem { Value = "4.2", Text = "4.2" });
            values.Add(new SelectListItem { Value = "4.3", Text = "4.3" });
            values.Add(new SelectListItem { Value = "4.4", Text = "4.4" });
            values.Add(new SelectListItem { Value = "4.5", Text = "4.5" });
            values.Add(new SelectListItem { Value = "4.6", Text = "4.6" });
            values.Add(new SelectListItem { Value = "4.7", Text = "4.7" });
            values.Add(new SelectListItem { Value = "4.8", Text = "4.8" });
            values.Add(new SelectListItem { Value = "4.9", Text = "4.9" });
            values.Add(new SelectListItem { Value = "5.0", Text = "5.0" });
            return Json(values);
        }

        [HttpPost]
        public JsonResult RetrunValuesOfPercentage()
        {
            List<SelectListItem> values = new List<SelectListItem>();
            for (int i = 40; i < 101; i++)
            {
                values.Add(new SelectListItem {
                    Value = i.ToString(),
                    Text = i.ToString()
                });
            }
            return Json(values);
        }

        [Authorize]
        public ActionResult AddCandidateSkills()
        {
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "SkillName");
            ViewBag.SkillExperienceId = new SelectList(db.SkillExperiences, "Id", "Experience");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddCandidateSkills(CandidateSkill cs)
        {
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "SkillName", cs.SkillId);
            ViewBag.SkillExperienceId = new SelectList(db.SkillExperiences, "Id", "Experience", cs.Experience);

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
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                       .Where(y => y.Count > 0)
                       .ToList();
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

        //[Authorize]
        //public ActionResult AddCandidateCertifications()
        //{
        //    ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
        //    return View();
        //}

        //[HttpPost]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddCandidateCertifications(CandidateCertification cc)
        //{
        //    ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", cc.UserId);
        //    string id = User.Identity.GetUserId();
        //    cc.UserId = id;
        //    if (ModelState.IsValid)
        //    {
        //        if (cc.Id > 0)
        //        {
        //            db.Entry(cc).State = EntityState.Modified;
        //            db.SaveChanges();
        //        }
        //        else
        //        {
        //            db.CandidateCertifications.Add(cc);
        //            db.SaveChanges();
        //        }
        //    }
        //    return View(cc);
        //}

        //public ActionResult CertificationsMultipleView()
        //{
        //    string id = User.Identity.GetUserId();
        //    var certificationsAdded = (from r in db.CandidateCertifications
        //                               where r.UserId.Equals(id)
        //                               select r);
        //    return View(certificationsAdded);
        //}

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
