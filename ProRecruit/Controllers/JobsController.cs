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
    public class JobsController : Controller
    {
        private ProRecruit_FinalEntities db = new ProRecruit_FinalEntities();

        // GET: Jobs
        public ActionResult Index()
        {
            var jobs = db.Jobs.Include(j => j.Organization);
            return View(jobs.ToList());
        }

        public ActionResult ViewJobsPosted()
        {
            string userid = User.Identity.GetUserId();
            var jobsPosted = (from jp in db.Jobs
                                   where jp.UserId.Equals(userid)
                                   select jp);
            return View(jobsPosted);
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
                values.Add(new SelectListItem
                {
                    Value = i.ToString(),
                    Text = i.ToString()
                });
            }
            return Json(values);
        }

        [Authorize]
        public ActionResult AddJobQualifications(int? id)
        {
            ViewBag.JobId = id.ToString();
            ViewBag.QualificationId = new SelectList(db.Qualifications, "Id", "QualificationName");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddJobQualifications(JobQualification jq)
        {
            string viewBagJobId = Request["JobId"].ToString();
            //ViewBag.Trigger = Request.Form["JobId"];
            ViewBag.QualificationId = new SelectList(db.Qualifications, "Id", "QualificationName", jq.DegreeLevel);
            
            if (ModelState.IsValid)
            {
                try
                {
                    jq.JobId = Convert.ToInt32(viewBagJobId);
                    if (jq.Id > 0)
                    {
                        db.Entry(jq).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        db.JobQualifications.Add(jq);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            return View(jq);
        }

        [Authorize]
        public ActionResult QualificationMulitpleView(int id)
        {
            var jobQualifications = from jobQualification in db.JobQualifications
                                    join qualification in db.Qualifications
                                    on jobQualification.DegreeLevel equals qualification.Id
                                    where jobQualification.JobId.Equals(id)
                                    select jobQualification;
            return View(jobQualifications.ToList());
        }

        [Authorize]
        public ActionResult AddJobSkills(int? id)
        {
            ViewBag.JobId = id.ToString();
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "SkillName");
            ViewBag.SkillExperienceId = new SelectList(db.SkillExperiences, "Id", "Experience");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult AddJobSkills(JobSkill js)
        {
            string viewBagJobId = Request["JobId"].ToString();
            //ViewBag.Trigger = Request.Form["JobId"];
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "SkillName", js.SkillId);
            ViewBag.SkillExperienceId = new SelectList(db.SkillExperiences, "Id", "Experience", js.Experience);

            if (ModelState.IsValid)
            {
                try
                {
                    js.JobId = Convert.ToInt32(viewBagJobId);
                    if (js.Id > 0)
                    {
                        db.Entry(js).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        db.JobSkills.Add(js);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            return View(js);
        }

        [Authorize]
        public ActionResult ViewSavedJobs()
        {
            string id = User.Identity.GetUserId();
            var savedJobs = db.CandidateSavedJobs.Where(sj => sj.CandidateId == id).ToList();
            return View(savedJobs);
        }

        //public ActionResult SaveCandidateJob(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Job job = db.Jobs.Find(id);
        //    if (job == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(job);
        //}

        //[HttpPost]
        [Authorize]
        public ActionResult SaveCandidateJob(int jobId)
        {
            string userid = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                try
                {
                    CandidateSavedJob csj = new CandidateSavedJob();
                    csj.CandidateId = userid;
                    csj.JobId = jobId;
                    if (csj.Id > 0)
                    {
                        db.Entry(csj).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        db.CandidateSavedJobs.Add(csj);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }

            return RedirectToAction("ViewSavedJobs", "Jobs");
        }

        [Authorize]
        public ActionResult SkillMulitpleView(int id)
        {
            var skills = from skill in db.JobSkills
                         where skill.JobId.Equals(id)
                         select skill;
            return View(skills.ToList());
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Where(j => j.Id == id).SingleOrDefault();
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.Organizations, "UserId", "Name");
            //ViewBag.Id = new SelectList(db.JobQualifications, "Id", "DegreeLevel");
            ViewBag.FunctionalArea = new SelectList(db.FunctionalAreas, "Id", "Name");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(Job job)
        {
            string userid = User.Identity.GetUserId();
            job.UserId = userid;

            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Dashboard", "Organizations");
            }

            ViewBag.FunctionalArea = new SelectList(db.FunctionalAreas, "Id", "Name");
            //ViewBag.UserId = new SelectList(db.Organizations, "UserId", "Name", job.UserId);
            //ViewBag.Id = new SelectList(db.JobQualifications, "Id", "DegreeLevel", job.Id);
            return View(job);
        }

        [Authorize]
        public ActionResult ViewCandidatesApplied(string jobId)
        {
            //string userid = User.Identity.GetUserId();
            int id = Convert.ToInt32(jobId);
            var candidatesApplied = from candidateJob in db.CandidateJobs
                                    join job in db.Jobs
                                    on candidateJob.JobId equals job.Id
                                    where job.Id == id
                                    select candidateJob;
            return View(candidatesApplied);
        }

        [Authorize]
        public ActionResult ViewJobsAppliedFor()
        {
            string userid = User.Identity.GetUserId();
            var candidateJobsApplied = db.CandidateJobs.Where(c => c.UserId == userid).ToList();
            return View(candidateJobsApplied);
        }

        public ActionResult ViewAllJobs()
        {
            var jobs = db.Jobs.ToList();
            return View(jobs);
        }


        public ActionResult ApplyForJob(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ApplyForJob(Job job)
        {
            if (ModelState.IsValid)
            {
                CandidateJob candidateJob = new CandidateJob();
                candidateJob.DateApplied = DateTime.UtcNow;
                candidateJob.JobId = job.Id;
                candidateJob.UserId = User.Identity.GetUserId();
                db.CandidateJobs.Add(candidateJob);
                db.SaveChanges();
                return RedirectToAction("Dashboard", "Candidates");
            }
            return View(job);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Organizations, "UserId", "Name", job.UserId);
            ViewBag.Id = new SelectList(db.JobQualifications, "Id", "DegreeLevel", job.Id);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Organizations, "UserId", "Name", job.UserId);
            ViewBag.Id = new SelectList(db.JobQualifications, "Id", "DegreeLevel", job.Id);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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
