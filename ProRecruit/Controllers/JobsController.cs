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
            var qualifications = from qualification in db.JobQualifications
                                 where qualification.JobId.Equals(id)
                                 select qualification;
            return View(qualifications.ToList());
        }

        [Authorize]
        public ActionResult AddJobSkills(int? id)
        {
            ViewBag.JobId = id.ToString();
            ViewBag.SkillId = new SelectList(db.Skills, "Id", "SkillName");
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
            //AspNetUser user = db.AspNetUsers.Find(User.Identity.GetUserId());
            string userid = User.Identity.GetUserId();
            job.UserId = userid;

            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Dashboard", "Organizations");
            }

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
