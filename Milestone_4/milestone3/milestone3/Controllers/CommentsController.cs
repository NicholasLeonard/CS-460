using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using milestone3.Models;
using System.Diagnostics;

namespace milestone3.Controllers
{
    public class CommentsController : Controller
    {
        private ToasterItContext db = new ToasterItContext();

        // GET: Comments with ID
        public ActionResult Index(int id)
        {
            // Get the title of the page of the comments we are looking at
            var title = db.Topics.Where(x => x.TopicId == id).SingleOrDefault()?.Title;
            ViewBag.Title = title;
            // Store the id for the page
            ViewBag.Topic = id;
            // Return only comments from current post (this will have to be fixed if we add navigation to just comments
            return View(db.Comments.Where(i => i.TopicId.Value == id).ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            //For use of return button in details page
            ViewBag.Topic = comment.TopicId;
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        // Make sure to pass in topicid or this baby will break the site now
        public ActionResult Create(int? topicid)
        {
            ViewBag.Topic = topicid;
            Comment comment = new Comment
            {
                TopicId = topicid
            };
            return View(comment);
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentId,Content,Ranking,TopicId")] Comment comment)
        {
            //Viewbag is a blessing, we can return with it
            ViewBag.Topic = comment.TopicId;

            if (ModelState.IsValid)
            {
                comment.Timestamp = DateTime.Now;
                // User defaultly upvotes their own post
                comment.Ranking = 1;
                db.Comments.Add(comment);
                db.SaveChanges();
                //Make sure we are redirected to comments with appropriate id
                return RedirectToAction("Index", new { id = ViewBag.Topic });
            }

            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentId,Content,Ranking,Timestamp,TopicId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
